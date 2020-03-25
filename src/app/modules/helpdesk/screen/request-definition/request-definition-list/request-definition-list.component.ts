// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { RequestDefinition } from '@helpdesk/model/request-definition.model';
import { RequestDefinitionService } from '@helpdesk/service/request-definition.service';
import { RequestDefinitionEditComponent } from '@helpdesk/screen/request-definition/request-definition-edit/request-definition-edit.component';
import { finalize } from 'rxjs/operators';
import { ProcessDefinitionService } from '@helpdesk/service/process-definition.service';
import { process } from '@progress/kendo-data-query';
import {RequestGroupService} from '@helpdesk/service/request-group.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-definition-list',
    templateUrl: './request-definition-list.component.html',
    styleUrls: ['./request-definition-list.component.css', ]
})
export class RequestDefinitionListComponent extends ListScreenBase<RequestDefinition> implements AfterViewInit, OnInit {
    @ViewChild(RequestDefinitionEditComponent, {static: true}) editScreen: RequestDefinitionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: RequestDefinitionService,
        public processDefinitionService: ProcessDefinitionService,
        public requestGroupService: RequestGroupService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.pipe(
                finalize(() => this.dataLoading = false)
            ).subscribe(
                list => {
                    if (this.masterId && this.masterId > 0) {
                        this.dataList = list.Data; // process(list.Data, this.listParams);
                    } else {
                        this.dataService.activeList.data = list;
                        this.dataService.activeList.total = list.length;
                        this.dataService.activeListChanged.next(this.dataService.activeList);
                    }
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Request Definition', RouterLink: '/helpdesk/request-definition'}];
    }

    createEmptyModel(): RequestDefinition {
        const model = new RequestDefinition();
        model.RequestGroup = this.masterId;
        return model;
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    ngOnInit() {
        if (!this.processDefinitionService.completeList) {
            this.processDefinitionService.listAll();
        }
        if (!this.masterId && !this.requestGroupService.completeList) {
            this.requestGroupService.listAll();
        }
        super.ngOnInit();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
