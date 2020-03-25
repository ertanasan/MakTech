// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ShipmentSchedule } from '@warehouse/model/shipment-schedule.model';
import { ShipmentScheduleService } from '@warehouse/service/shipment-schedule.service';
import { ShipmentScheduleEditComponent } from '@warehouse/screen/shipment-schedule/shipment-schedule-edit/shipment-schedule-edit.component';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-shipment-schedule-list',
    templateUrl: './shipment-schedule-list.component.html',
    styleUrls: ['./shipment-schedule-list.component.css', ]
})
export class ShipmentScheduleListComponent extends ListScreenBase<ShipmentSchedule> implements AfterViewInit, OnInit {
    @ViewChild(ShipmentScheduleEditComponent, {static: true}) editScreen: ShipmentScheduleEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ShipmentScheduleService,
        public storeService: StoreService,
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
                    this.dataService.convertScheduleTxtToBooleanDays(this.dataList[0].ScheduleDetail);
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                },
                () => this.dataLoading = false
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Shipment Schedule', RouterLink: '/warehouse/shipment-schedule'}];
    }

    createEmptyModel(): ShipmentSchedule {
        return new ShipmentSchedule();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
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
