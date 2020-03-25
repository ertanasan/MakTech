// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit, ViewContainerRef, Injector } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { HelpdeskRequest, HeldeskRequestInfo } from '@helpdesk/model/helpdesk-request.model';
import { HelpdeskRequestService } from '@helpdesk/service/helpdesk-request.service';
import { HelpdeskRequestEditComponent } from '@helpdesk/screen/helpdesk-request/helpdesk-request-edit/helpdesk-request-edit.component';
import { RequestGroupService } from '@helpdesk/service/request-group.service';
import { RequestDefinitionService } from '@helpdesk/service/request-definition.service';
import { RequestAttributeService } from '@helpdesk/service/request-attribute.service';
import { AttributeChoiceService } from '@helpdesk/service/attribute-choice.service';
import { StoreScalesService } from '@store/service/store-scales.service';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { StoreFixtureService } from '@store/service/store-fixture.service';
import { ProcessDefinitionService } from '@helpdesk/service/process-definition.service';
import { StoreService } from '@store/service/store.service';
import { RequestStatusService } from '@helpdesk/service/request-status.service';
import { ProcessHistoryComponent } from '@app-main/screen/process-history/process-history.component';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { RequestDetail } from '@helpdesk/model/request-detail.model';
import { AttributeTypeService } from '@helpdesk/service/attribute-type.service';
import * as _ from 'lodash';
import { parseNumber } from '@telerik/kendo-intl';
import { process } from '@progress/kendo-data-query';
import { DatePipe } from '@angular/common';
import { AssignUserService } from '@helpdesk/service/assign-user.service';
import { Observable, Subscription } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';
import { Store as Store2} from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import { first, find } from 'rxjs/operators';
import { OTScreenBase } from '@otscreen-base/ot-screen-base';
import { DynamicComponentLoader } from '@otui/dynamic-component-loader/dynamic-component-loader.service';
import { InboxService } from '@frame/bpm-core/service/inbox.service';
import { GridDataResult, GridComponent } from '@progress/kendo-angular-grid';
import { AssignUser } from '@helpdesk/model/assign-user.model';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-helpdesk-request-list',
    templateUrl: './helpdesk-request-list.component.html',
    styleUrls: ['./helpdesk-request-list.component.css', ]
})
export class HelpdeskRequestListComponent extends ListScreenBase<HelpdeskRequest> implements AfterViewInit, OnInit {
    @ViewChild(HelpdeskRequestEditComponent, {static: true}) editScreen: HelpdeskRequestEditComponent;
    @ViewChild(ProcessHistoryComponent, {static: true}) historyScreen: ProcessHistoryComponent;
    @ViewChild('reviewComponent', { static: true, read: ViewContainerRef }) reviewComponent;

    componentRef: any;
    componentSubscription: Subscription;
    actionSubscription: Subscription;
    screenModeSubscription: Subscription;
    
    branchType: string;
    isHeadQuarter: boolean;
    openFlag = true;
    startDate: Date;
    endDate: Date;
    filteredList: HelpdeskRequest[];
    filteredActiveList: any;

    contextState$: Observable<OTContext>;
    contextInfo;

    todayString: string;
    userList: AssignUser[];
    
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: HelpdeskRequestService,
        public requestGroupService: RequestGroupService,
        public requestDefinitionService: RequestDefinitionService,
        public requestAttributeService: RequestAttributeService,
        public attributeChoiceService: AttributeChoiceService,
        public scaleService: StoreScalesService,
        public cashregisterService: StoreCashRegisterService,
        public fixtureService: StoreFixtureService,
        public processDefinitionService: ProcessDefinitionService,
        public storeService: StoreService,
        public attributeTypeService: AttributeTypeService,
        public requestStatusService: RequestStatusService,
        public assignUserService: AssignUserService,
        private store: Store2<fromApp.AppState>,
        public datePipe: DatePipe,
        public dynamicComponentLoader: DynamicComponentLoader,
        public inboxService: InboxService,
        private injector: Injector,

    ) {
        super(messageService, translateService);

        this.contextState$ = this.store.select('context');
        this.allData = this.allData.bind(this);
    }

    public allData(): any {
        let newList = JSON.parse(JSON.stringify(this.filteredList));
        newList.forEach(row => {
            row.RequestGroupName = this.requestGroupService.completeList.filter(r => r.RequestGroupId === row.RequestGroup)[0].RequestGroupName;
            const findUser = this.userList.filter(r => r.ResponsibleUser === row.ResponsibleUser);
            if (findUser.length > 0) row.ResponsibleUserName = findUser[0].UserFullName;
            row.RequestDefinitionName = this.requestDefinitionService.completeList.filter(r => r.RequestDefinitionId === row.RequestDefinition)[0].RequestDefinitionName;
            row.StatusCodeName = this.requestStatusService.completeList.filter(r => r.RequestStatusId === row.StatusCode)[0].StatusName;
        })
        return <GridDataResult> {
            data: process(newList, { sort: [{ field: 'CreateDate', dir: 'desc' }] }).data,
            total: newList.length
        };
    }

    refreshList() {
        if (this.filteredList) {
            this.filteredActiveList = process(this.filteredList, this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Helpdesk Request', RouterLink: '/helpdesk/helpdesk-request'}];
    }

    createEmptyModel(): HelpdeskRequest {
        const model = new HelpdeskRequest();
        model.RequestDetailList = [];
        if (this.storeService.userStores && this.storeService.userStores.length === 1) {
            model.Store = this.storeService.userStores[0].StoreId;
        }
        return model;
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);

        if (this.modeReview && !this.isEmbedded) {
            const requestId = this.modeContext.id;
            this.dataService.read(requestId).subscribe(helpdeskRequest => {
                this.editScreen.modeContext = this.modeContext;
                this.editScreen.modeReview = true;
                const dataItem = Object.assign(this.createEmptyItem(), helpdeskRequest);
                // console.log('ngAfterViewInit : ', dataItem);
                this.showDialog(this.editScreen, 'Review', dataItem );
            });
        }
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    ngOnInit() {
        
        const d: Date = new Date();
        this.todayString = this.datePipe.transform(d, 'yyyyMMdd');

        this.contextState$.pipe(first()).subscribe(context => {
            this.contextInfo = context;
            this.endDate = new Date();
            this.startDate = new Date();
            this.startDate.setDate(this.startDate.getDate() - 7);
            this.assignUserService.listAllAsync().subscribe( result => {
                this.userList = result;
                this.assignUserService.completeList = result;
                this.filterList();
            });
        });
        
        this.requestGroupService.listAllAsync().subscribe(list => {
            this.requestGroupService.completeList = list;
            this.editScreen.reqGroupList = list.filter(row => row.ActiveFlag);
        });

        this.requestDefinitionService.listAll();
        this.requestAttributeService.listAll();
        this.attributeChoiceService.listAll();
        this.processDefinitionService.listAll();
        this.scaleService.getUserScale();
        this.cashregisterService.getUserCashRegister();
        this.fixtureService.getUserFixture();
        this.storeService.listUserStores().subscribe(storeList => {
            this.branchType = storeList[0].UserBranchType;
            this.isHeadQuarter = (this.branchType === 'Central Office');
        });
        this.attributeTypeService.listAll();
        this.requestStatusService.listAll();
        
        super.ngOnInit();
    }

    fillInfoModel(rd: RequestDetail[]): HeldeskRequestInfo[] {
        const model: HeldeskRequestInfo[] = [];
        rd.forEach(row => {
            const infoRow = new HeldeskRequestInfo();
            infoRow.attributeId = row.Attribute;
            const attr = this.requestAttributeService.completeList.filter(r => r.RequestAttributeId === infoRow.attributeId)[0];
            infoRow.type = attr.AttributeType;
            infoRow.text = attr.AttributeName;
            infoRow.required = attr.RequiredFlag;
            if (model) {
                infoRow.control = `Info${model.length + 1}`;
            }
            infoRow.displayorder = attr.DisplayOrder;
            if (infoRow.type === 3) { // drop down
                infoRow.dropdownlist = this.attributeChoiceService.completeList.filter(r => r.Attribute === infoRow.attributeId);
            }
            // const attrType = _.filter(this.attributeTypeService.completeList, ['AttributeTypeId', attr.AttributeType])[0];
            // switch (attrType.AttributeTypeName) {
            //     case 'Metin' : infoRow.value = row.AttributeValue.toString(); break;
            //     case 'Sayı'  : infoRow.value = parseFloat(row.AttributeValue); break;
            //     case 'Tarih' : infoRow.value = new Date(row.AttributeValue); break;
            //     default      : infoRow.value = parseInt(row.AttributeValue, 10); break;
            // }

            model.push(infoRow);
        });
        return model;
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {

        if (actionName === 'ShowHistory') {
            this.historyScreen.ProcessInstanceId = dataItem.ProcessInstance;
            this.historyScreen.dialog.show();
        } else if (actionName === 'Read' || actionName === 'Review') {
            this.dataService.read(dataItem.HelpdeskRequestId).subscribe(helpdeskRequest => {
                this.editScreen.reqDefList = this.requestDefinitionService.completeList.filter(row => row.RequestGroup === dataItem.RequestGroup);
                this.editScreen.InfoList = this.fillInfoModel(helpdeskRequest.RequestDetailList);
                helpdeskRequest.RequestDetailList.forEach ((row, index) => {
                    switch (row.AttributeTypeName) {
                        case 'Metin' : dataItem[`Info${index + 1}`] = row.AttributeValue.toString(); break;
                        case 'Sayı'  : dataItem[`Info${index + 1}`] = parseFloat(row.AttributeValue); break;
                        case 'Tarih' : dataItem[`Info${index + 1}`] = new Date(row.AttributeValue); break;
                        default      : dataItem[`Info${index + 1}`] = parseInt(row.AttributeValue, 10); break;
                    }
                });
                super.showDialog(target, actionName, dataItem);
            });
        } else if (actionName === 'Create') {
            this.editScreen.InfoList = [];
            super.showDialog(target, actionName, dataItem);
        } else {
            super.showDialog(target, actionName, dataItem);
        }
    }

    onAllFlag() {
        this.openFlag = !this.openFlag;
        this.filterList();
    }

    filterList() {
        this.dataService.listFiltered(this.openFlag, 
            this.datePipe.transform(new Date(this.startDate), 'yyyy-MM-dd'),
            this.datePipe.transform(new Date(this.endDate), 'yyyy-MM-dd')).subscribe(list => {
            
            const userList = this.assignUserService.completeList;
            const user = userList.filter(r => r.ResponsibleUser === this.contextInfo.User.Id);
            const itUserList = userList.filter(r => r.GroupName === 'BilgiIslem');
            const momendeUserList = userList.filter(r => r.GroupName === 'Momende');
            list.forEach(row => {
                row.AdminFlag = false;
                switch (row.ActivityName) {
                    case 'BilgiIslem' : 
                        row.UserList = itUserList; 
                        if (user.length > 0 && user[0].GroupName === 'BilgiIslem') row.AdminFlag = user[0].AdminFlag;
                        break;
                    case 'Momende' : 
                        row.UserList = momendeUserList; 
                        if (user.length > 0 && user[0].GroupName === 'Momende') row.AdminFlag = user[0].AdminFlag;
                        break;
                }
                if (row.ResponsibleUser && row.ResponsibleUser > 0 && row.UserList) {
                    const findUser = row.UserList.find(r => r.ResponsibleUser === row.ResponsibleUser);
                    if (!findUser) row.ResponsibleUser = undefined;
                } else {
                    row.ResponsibleUser = undefined;
                }
            });           
            this.filteredList = list;
            this.refreshList();
        });
    }

    onResponsibleUserChanged(event, dataItem) {
        if (event) {
            dataItem.ResponsibleUser = event;
        } else {
            dataItem.ResponsibleUser = null;
        }
        this.dataService.update(dataItem, 'Update').subscribe(result => {
        });
    }

    openTask(instanceId) {
        this.dataService.UserTask(instanceId).subscribe(dataItem => {
            const screenParts = dataItem.ScreenReference.split('#');
            if (screenParts.length === 3) {
                this.createReviewComponent(dataItem.ActionId, screenParts[0], screenParts[1], screenParts[2]);
            } else {
                this.messageService.warning('Screen Reference is not well-formatted. Screen Reference is:' + dataItem.ScreenReference );
            }
        });
    }

    clearComponent() {
        this.reviewComponent.clear();
        if (this.componentRef) { this.componentRef.destroy(); }
        if (this.componentSubscription) {
            this.componentSubscription.unsubscribe();
        }
        if (this.actionSubscription) {
            this.actionSubscription.unsubscribe();
        }
        if (this.screenModeSubscription) {
            this.screenModeSubscription.unsubscribe();
        }
    }

    createReviewComponent(actionId: number, moduleName: string, componentName: string, context: string): any {
        this.clearComponent();
        const componentMap = {
            'HelpdeskRequestListComponent': HelpdeskRequestListComponent,
          };
        this.actionSubscription = this.inboxService.readActionInfo(actionId).subscribe(actionInfo => {
            this.componentSubscription = this.dynamicComponentLoader
                .getComponentFactory(moduleName, componentMap['HelpdeskRequestListComponent'], this.injector)
                .subscribe(componentFactory => {
                    const childActions = actionInfo['Choices'].join(';');
                    this.componentRef = this.reviewComponent.createComponent(componentFactory);
                    const screenRef = <OTScreenBase>this.componentRef._component;
                    screenRef.modeDefault = false;
                    screenRef.modeReview = true;
                    screenRef.modeContext = { childActions: childActions, id: context, actionId: actionId };
                    this.screenModeSubscription = screenRef.modeEvent.subscribe((data: any) => {
                        this.refreshList();
                    });
                    this.componentRef.changeDetectorRef.detectChanges();
                }, error => {
                    console.warn(error);
                });
        });
    }

    public getxlsFileName(): string {

        return `${'KolayliklarMasasi'}_${this.todayString}.xlsx`;
    }

    public exportToExcel(grid: GridComponent): void {
        grid.saveAsExcel();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
