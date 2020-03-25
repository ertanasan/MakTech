// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { MaterialInfo } from '@warehouse/model/material-info.model';
import { MaterialInfoService } from '@warehouse/service/material-info.service';
import { MaterialInfoEditComponent } from '@warehouse/screen/material-info/material-info-edit/material-info-edit.component';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-material-info-list',
    templateUrl: './material-info-list.component.html',
    styleUrls: ['./material-info-list.component.css', ]
})
export class MaterialInfoListComponent extends ListScreenBase<MaterialInfo> implements AfterViewInit {
    @ViewChild(MaterialInfoEditComponent, { static: true }) editScreen: MaterialInfoEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: MaterialInfoService,
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
                    this.dataService.activeList.data = list.Data;
                    this.dataService.activeList.total = list.Total;
                    // this.dataList = list;
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Material Info', RouterLink: '/warehouse/material-info'}];
    }

    createEmptyModel(): MaterialInfo {
        const model = new MaterialInfo();
        model.Material = this.masterId;
        return model;
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
