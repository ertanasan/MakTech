
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { HelpdeskRequest, HeldeskRequestInfo } from '@helpdesk/model/helpdesk-request.model';
import { HelpdeskRequestService } from '@helpdesk/service/helpdesk-request.service';
import { RequestDefinition } from '@helpdesk/model/request-definition.model';
import { RequestDefinitionService } from '@helpdesk/service/request-definition.service';
import { RequestGroupService } from '@helpdesk/service/request-group.service';
import { StoreScalesService } from '@store/service/store-scales.service';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { StoreFixtureService } from '@store/service/store-fixture.service';
import { RequestAttributeService } from '@helpdesk/service/request-attribute.service';
import { AttributeChoiceService } from '@helpdesk/service/attribute-choice.service';
import { RequestDetail } from '@helpdesk/model/request-detail.model';
import { ProcessDefinitionService } from '@helpdesk/service/process-definition.service';
import { StoreService } from '@store/service/store.service';
import * as _ from 'lodash';
import { DatePipe } from '@angular/common';
import { RequestGroup } from '@helpdesk/model/request-group.model';
import { HelpdeskRequestListComponent } from '../helpdesk-request-list/helpdesk-request-list.component';
import { finalize } from 'rxjs/operators';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-helpdesk-request-edit',
    templateUrl: './helpdesk-request-edit.component.html',
    styleUrls: ['./helpdesk-request-edit.component.css', ]
})
export class HelpdeskRequestEditComponent extends CRUDDialogScreenBase<HelpdeskRequest> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<HelpdeskRequest>;

    public reqDefList: RequestDefinition[] = [];
    public typeList = [{value: 1, text: 'Metin'}, {value: 2, text: 'Sayı'}, {value: 3, text: 'Çoklu seçenek'},
    {value: 4, text: 'Tarih'}, {value: 5, text: 'Terazi'}, {value: 6, text: 'Yazar Kasa'}, {value: 7, text: 'Demirbaş'}];
    // public InfoList = [{type: 1, text: 'başlık1', control: 'Info1'}, {type: 2, text: 'başlık2', control: 'Info2'}, {type: 3, text: 'başlık3', control: 'Info3'}];
    public InfoList: HeldeskRequestInfo[];
    selectedRequestGroup: number;
    mask = "(999) 000-00-00";
    reqGroupList: RequestGroup[] = [];
    
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: HelpdeskRequestService,
        public requestGroupService: RequestGroupService,
        public requestDefinitionService: RequestDefinitionService,
        public requestAttributeService: RequestAttributeService,
        public attributeChoiceService: AttributeChoiceService,
        public scaleService: StoreScalesService,
        public cashregisterService: StoreCashRegisterService,
        public fixtureService: StoreFixtureService,
        public processDefinitionService: ProcessDefinitionService,
        public datePipe: DatePipe,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Helpdesk Request');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            HelpdeskRequestId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            RequestGroup: new FormControl(),
            RequestDefinition: new FormControl(),
            RequestDescription: new FormControl(),
            StatusCode: new FormControl(),
            ProcessInstance: new FormControl(),
            Info1: new FormControl(),
            Info2: new FormControl(),
            Info3: new FormControl(),
            Info4: new FormControl(),
            Info5: new FormControl(),
            Info6: new FormControl(),
            Info7: new FormControl(),
            Info8: new FormControl(),
            Info9: new FormControl(),
            Store: new FormControl(),
            actionComment: new FormControl(),
            ContactPhoneNumber: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    public onReqGroupChange(event) {
        this.selectedRequestGroup = event;
        // console.log('onReqGroupChange : ', this.currentAction);
        this.reqDefList = this.requestDefinitionService.completeList.filter(row => (row.RequestGroup === event && row.ActiveFlag));
        this.InfoList = [];
        const gl = this.requestAttributeService.completeList.filter(row => row.RequestGroup === event);
        gl.forEach (row => {
            const m = new HeldeskRequestInfo();
            m.attributeId = row.RequestAttributeId;
            m.type = row.AttributeType;
            m.text = row.AttributeName;
            m.control = `Info${this.InfoList.length + 1}`;
            m.displayorder = row.DisplayOrder;
            m.required = row.RequiredFlag;
            if (m.type === 3) { // drop down
                m.dropdownlist = this.attributeChoiceService.completeList.filter(row2 => row2.Attribute === row.RequestAttributeId);
            }
            this.InfoList.push(m);
        });
    }

    public onReqDefChange(event) {
        this.onReqGroupChange(this.selectedRequestGroup);
        // console.log('onReqDefChange : ', this.currentAction);
        const dl = this.requestAttributeService.completeList.filter(row => row.RequestDefinition === event);
        dl.forEach (row => {
            const m = new HeldeskRequestInfo();
            m.attributeId = row.RequestAttributeId;
            m.type = row.AttributeType;
            m.text = row.AttributeName;
            m.control = `Info${this.InfoList.length + 1}`;
            m.displayorder = row.DisplayOrder;
            m.required = row.RequiredFlag;
            if (m.type === 3) { // drop down
                m.dropdownlist = this.attributeChoiceService.completeList.filter(row2 => row2.Attribute === row.RequestAttributeId);
            }
            this.InfoList.push(m);
        });
        this.InfoList = _.sortBy(this.InfoList, 'displayorder');
    }

    public requiredControl(): boolean {
        if (!this.container.currentItem.Store) { this.messageService.warning(`Mağaza seçiniz.`); return false; }
        if (!this.container.currentItem.RequestGroup) { this.messageService.warning(`Talep Grubu seçiniz.`); return false; }
        if (!this.container.currentItem.RequestDefinition) { this.messageService.warning(`Talep seçiniz.`); return false; }
        if (!this.container.currentItem.RequestDescription) { this.messageService.warning(`Talep açıklaması giriniz.`); return false; }
        if (!this.container.currentItem.ContactPhoneNumber) { this.messageService.warning(`Telefon numarası giriniz.`); return false; }
        return true;
    }
    public create() {
        if (!this.requiredControl()) { this.container.hideProgress(); return; }
        const request: HelpdeskRequest = this.container.currentItem;
        const process = this.reqDefList.filter(row => row.RequestDefinitionId === request.RequestDefinition)[0];
        const processdef = this.processDefinitionService.completeList.filter(row => row.ProcessDefinitionId === process.Process)[0];
        request.ProcessName = processdef.ProcessDefinitionName;
        request.Process = processdef.ProcessNo;
        request.RequestDetailList = [];
        request.RequestDetailList = [];
        let reqControl = true;
        this.InfoList.forEach(row => {
            if (row.required && !this.currentItem[row.control]) {
                this.messageService.warning(`${row.text} alanını boş geçemezsiniz.`);
                reqControl = false;
            } else if (this.currentItem[row.control]) {
                const newRow: RequestDetail = new RequestDetail();
                newRow.Organization = 1;
                newRow.Event = 1;
                newRow.Attribute = row.attributeId;
                if (row.type === 4) { // tarih
                    newRow.AttributeValue = this.datePipe.transform(new Date(this.currentItem[row.control]), 'yyyy-MM-dd');
                } else {
                    newRow.AttributeValue = this.currentItem[row.control];
                }
                request.RequestDetailList.push(newRow);
            }
        });
        this.container.currentItem = request;
        if (reqControl) {
            this.dataService.create(this.currentItem, 'Create').pipe(
                finalize(() => this.container.hideProgress())
            ).subscribe(
                model => {
                    this.messageService.success(this.translateService.instant(this.createSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                    (<HelpdeskRequestListComponent> this.mainScreen).filterList();
                    this.mainScreen.refreshData(this.currentItem.getId());
                    this.container.hide();
                },
                error => {
                        this.handleHttpError(error, this.createFailMessage, this.modelName);
                }
            );
            
        } else {
            this.container.hideProgress();
        }
    }

    public onSubmit() {
        super.onSubmit();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
