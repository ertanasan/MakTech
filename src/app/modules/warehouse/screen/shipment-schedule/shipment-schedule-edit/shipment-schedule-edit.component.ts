// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ShipmentSchedule } from '@warehouse/model/shipment-schedule.model';
import { ShipmentScheduleService } from '@warehouse/service/shipment-schedule.service';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-shipment-schedule-edit',
    templateUrl: './shipment-schedule-edit.component.html',
    styleUrls: ['./shipment-schedule-edit.component.css', ]
})
export class ShipmentScheduleEditComponent extends CRUDDialogScreenBase<ShipmentSchedule> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ShipmentSchedule>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ShipmentScheduleService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Shipment Schedule');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ShipmentScheduleId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            ShipmentScheduleName: new FormControl(),
            Store: new FormControl(),
            ScheduleDetail: new FormControl(),
            Comment: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    update() {
        this.currentItem.ScheduleDetail = this.dataService.revertToScheduleTxt();
        super.update();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
