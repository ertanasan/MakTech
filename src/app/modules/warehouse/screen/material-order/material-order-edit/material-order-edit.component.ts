// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { MaterialOrder } from '@warehouse/model/material-order.model';
import { MaterialOrderService } from '@warehouse/service/material-order.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { Material } from '@warehouse/model/material.model';
import { MaterialService } from '@warehouse/service/material.service';
import { MaterialInfo } from '@warehouse/model/material-info.model';
import { MaterialInfoService } from '@warehouse/service/material-info.service';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { MaterialOrderListComponent } from '../material-order-list/material-order-list.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-material-order-edit',
    templateUrl: './material-order-edit.component.html',
    styleUrls: ['./material-order-edit.component.css', ]
})
export class MaterialOrderEditComponent extends CRUDDialogScreenBase<MaterialOrder> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<MaterialOrder>;
    materialInfoList: MaterialInfo[];
    statusCode: number;
    callee: MaterialOrderListComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: MaterialOrderService,
        public storeService: StoreService,
        public userService: UserService,
        public materialService: MaterialService,
        public materialInfoService: MaterialInfoService,
        public commonMethods: OverstoreCommonMethods,
    ) {
        super(messageService, translateService, dataService, 'Material Order');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            MaterialOrderId: new FormControl(),
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
            OrderName: new FormControl(),
            OrderDate: new FormControl(),
            OrderStatusCode: new FormControl(),
            Store: new FormControl(),
            ProcessInstanceNumber: new FormControl(),
            MikroStatusCode: new FormControl(),
            MikroReference: new FormControl(),
            MikroTime: new FormControl(),
            MikroUser: new FormControl(),
            Material: new FormControl(),
            MaterialInfo: new FormControl(),
            OrderQuantity: new FormControl(),
            RevisedQuantity: new FormControl(),
            ShippedQuantity: new FormControl(),
            IntakeQuantity: new FormControl(),
            Note: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    materialChange(materialId) {
        this.materialInfoList = this.materialInfoService.completeList.filter(row => row.Material === materialId);
    }

    create() {
        const d: Date = new Date();
        this.currentItem.OrderDate = this.commonMethods.addHours(d, 3);
        this.currentItem.Organization = 1;
        this.currentItem.Event = 1;
        this.currentItem.OrderName = 'will be updated in DB-Insert Proc';
        this.currentItem.OrderStatusCode = 2;
        this.currentItem.RevisedQuantity = this.currentItem.OrderQuantity;
        this.currentItem.ShippedQuantity = this.currentItem.OrderQuantity;
        this.currentItem.IntakeQuantity = this.currentItem.OrderQuantity;
        super.create();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
