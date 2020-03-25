// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { PosMovement } from '@store/model/pos-movement.model';
import { PosMovementService } from '@store/service/pos-movement.service';
import { Pos } from '@store/model/pos.model';
import { PosService } from '@store/service/pos.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-pos-movement-edit',
    templateUrl: './pos-movement-edit.component.html',
    styleUrls: ['./pos-movement-edit.component.css', ]
})
export class PosMovementEditComponent extends CRUDDialogScreenBase<PosMovement> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<PosMovement>;

    posList: any;
    movetime: Date;
    storeList: Store[];
    authorization: string;
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: PosMovementService,
        public posService: PosService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Pos Movement');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            PosMovementId: new FormControl(),
            PosId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            MoveTime: new FormControl(),
            Store: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
