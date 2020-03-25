// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Supplier } from '@warehouse/model/supplier.model';
import { SupplierService } from '@warehouse/service/supplier.service';
import { SupplierEditComponent } from '@warehouse/screen/supplier/supplier-edit/supplier-edit.component';
import { SupplierType } from '@warehouse/model/supplier-type.model';
import { SupplierTypeService } from '@warehouse/service/supplier-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-supplier-list',
    templateUrl: './supplier-list.component.html',
    styleUrls: ['./supplier-list.component.css', ]
})
export class SupplierListComponent extends ListScreenBase<Supplier> implements AfterViewInit, OnInit {
    @ViewChild(SupplierEditComponent, {static: true}) editScreen: SupplierEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: SupplierService,
        public supplierTypeService: SupplierTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Supplier', RouterLink: '/warehouse/supplier'}];
    }

    createEmptyModel(): Supplier {
        return new Supplier();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.supplierTypeService.completeList) {
            this.supplierTypeService.listAll();
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
