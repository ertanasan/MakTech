// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { FixtureModel } from '@product/model/fixture-model.model';
import { FixtureModelService } from '@product/service/fixture-model.service';
import { FixtureModelEditComponent } from '@product/screen/fixture-model/fixture-model-edit/fixture-model-edit.component';
import { finalize } from 'rxjs/operators';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-fixture-model-list',
    templateUrl: './fixture-model-list.component.html',
    styleUrls: ['./fixture-model-list.component.css', ]
})
export class FixtureModelListComponent extends ListScreenBase<FixtureModel> implements AfterViewInit {
    @ViewChild(FixtureModelEditComponent, { static: true }) editScreen: FixtureModelEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: FixtureModelService,
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
        return [{Caption: 'Product' }, {Caption: 'Fixture Model', RouterLink: '/product/fixture-model'}];
    }

    createEmptyModel(): FixtureModel {
        return new FixtureModel();
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
