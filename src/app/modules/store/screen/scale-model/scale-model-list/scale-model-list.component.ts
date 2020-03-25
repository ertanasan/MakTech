// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ScaleModel } from '@store/model/scale-model.model';
import { ScaleModelService } from '@store/service/scale-model.service';
import { ScaleModelEditComponent } from '@store/screen/scale-model/scale-model-edit/scale-model-edit.component';
import { ScaleBrand } from '@store/model/scale-brand.model';
import { ScaleBrandService } from '@store/service/scale-brand.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-scale-model-list',
    templateUrl: './scale-model-list.component.html',
    styleUrls: ['./scale-model-list.component.css', ]
})
export class ScaleModelListComponent extends ListScreenBase<ScaleModel> implements AfterViewInit, OnInit {
    @ViewChild(ScaleModelEditComponent, {static: true}) editScreen: ScaleModelEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: ScaleModelService,
        public scaleBrandService: ScaleBrandService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.subscribe(
                list => {
                    this.dataList = list;
                    this.dataLoading = false;
                },
                error => {
                    this.dataLoading = false;
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Scale Model', RouterLink: '/store/scale-model'}];
    }

    createEmptyModel(): ScaleModel {
        return new ScaleModel();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.scaleBrandService.completeList) {
            this.scaleBrandService.listAll();
        }
        super.ngOnInit();
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
