// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { FixtureBrand } from '@product/model/fixture-brand.model';
import { FixtureBrandService } from '@product/service/fixture-brand.service';
import { FixtureBrandEditComponent } from '@product/screen/fixture-brand/fixture-brand-edit/fixture-brand-edit.component';
import { finalize } from 'rxjs/operators';
import { act } from '@ngrx/effects';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { ThemeService } from '@progress/kendo-angular-gauges';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-fixture-brand-list',
    templateUrl: './fixture-brand-list.component.html',
    styleUrls: ['./fixture-brand-list.component.css', ]
})
export class FixtureBrandListComponent extends ListScreenBase<FixtureBrand> implements AfterViewInit {
    @ViewChild(FixtureBrandEditComponent, { static: true }) editScreen: FixtureBrandEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: FixtureBrandService,
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
                    this.dataList = list.Data;
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Fixture Brand', RouterLink: '/product/fixture-brand'}];
    }

    createEmptyModel(): FixtureBrand {
        return new FixtureBrand();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        if (this.masterId) {
            this.editScreen.masterId = this.masterId;
            this.editScreen.masterObject = this.masterObject;
        } else {
            this.editScreen.masterId = undefined;
        }
        super.showDialog(target, actionName, dataItem);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
