// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Adjustment } from '@reconciliation/model/adjustment.model';
import { AdjustmentService } from '@reconciliation/service/adjustment.service';
import { AdjustmentEditComponent } from '@reconciliation/screen/adjustment/adjustment-edit/adjustment-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-adjustment-list',
    templateUrl: './adjustment-list.component.html',
    styleUrls: ['./adjustment-list.component.css', ]
})
export class AdjustmentListComponent extends ListScreenBase<Adjustment> implements AfterViewInit, OnInit {
    @ViewChild(AdjustmentEditComponent, {static: true}) editScreen: AdjustmentEditComponent;

    storeList: Store[];
    today: Date;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: AdjustmentService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Adjustment', RouterLink: '/reconciliation/adjustment'}];
    }

    createEmptyModel(): Adjustment {
        let model = new Adjustment();
        model.Date = this.today;
        return model;
    }

    ngOnInit() {
        this.today = new Date();
        this.today = this.dataService.addHours(this.today, 3);

        this.storeService.listUserStores().subscribe(result => {

            this.storeList = result;
            this.editScreen.storeList = this.storeList;

        }, error => {
            this.messageService.error(error);
        });

        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['Date'];
        super.handleDataStateChange(state);
    }

}
