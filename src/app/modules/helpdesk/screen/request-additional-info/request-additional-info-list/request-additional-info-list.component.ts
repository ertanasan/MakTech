// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { RequestAdditionalInfo } from '@helpdesk/model/request-additional-info.model';
import { RequestAdditionalInfoService } from '@helpdesk/service/request-additional-info.service';
import { RequestAdditionalInfoEditComponent } from '@helpdesk/screen/request-additional-info/request-additional-info-edit/request-additional-info-edit.component';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-additional-info-list',
    templateUrl: './request-additional-info-list.component.html',
    styleUrls: ['./request-additional-info-list.component.css', ]
})
export class RequestAdditionalInfoListComponent extends ListScreenBase<RequestAdditionalInfo> implements AfterViewInit {
    @ViewChild(RequestAdditionalInfoEditComponent, { static: true }) editScreen: RequestAdditionalInfoEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: RequestAdditionalInfoService,
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
                    this.dataList = list;
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Request Additional Info', RouterLink: '/helpdesk/request-additional-info'}];
    }

    createEmptyModel(): RequestAdditionalInfo {
        return new RequestAdditionalInfo();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
