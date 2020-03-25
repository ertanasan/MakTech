// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StockTakingSchedule } from '@warehouse/model/stock-taking-schedule.model';
import { StockTakingScheduleService } from '@warehouse/service/stock-taking-schedule.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { CountingType } from '@warehouse/model/counting-type.model';
import { CountingTypeService } from '@warehouse/service/counting-type.service';
import { CountingStatus } from '@warehouse/model/counting-status.model';
import { CountingStatusService } from '@warehouse/service/counting-status.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-stock-taking-schedule-edit',
    templateUrl: './stock-taking-schedule-edit.component.html',
    styleUrls: ['./stock-taking-schedule-edit.component.css', ]
})
export class StockTakingScheduleEditComponent extends CRUDDialogScreenBase<StockTakingSchedule> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StockTakingSchedule>;

    public countingStatusReadOnly = true;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StockTakingScheduleService,
        public storeService: StoreService,
        public countingTypeService: CountingTypeService,
        public countingStatusService: CountingStatusService,
    ) {
        super(messageService, translateService, dataService, 'StockTaking Schedule');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StockTakingScheduleId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            ScheduleName: new FormControl(),
            Store: new FormControl(),
            CountingType: new FormControl(),
            PlannedDate: new FormControl(),
            ActualDate: new FormControl(),
            CountingStatus: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    onSubmit() {
        this.container.currentItem.PlannedDate = this.addHours(this.container.currentItem.PlannedDate, 3);
        if (this.container.currentItem.ActualDate) {
             this.container.currentItem.ActualDate = this.addHours(this.container.currentItem.ActualDate, 3);
        }
        super.onSubmit();
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
