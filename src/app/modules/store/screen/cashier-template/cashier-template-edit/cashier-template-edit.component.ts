// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { CashierTemplate } from '@store/model/cashier-template.model';
import { CashierTemplateService } from '@store/service/cashier-template.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cashier-template-edit',
    templateUrl: './cashier-template-edit.component.html',
    styleUrls: ['./cashier-template-edit.component.css', ]
})
export class CashierTemplateEditComponent extends CRUDDialogScreenBase<CashierTemplate> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<CashierTemplate>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: CashierTemplateService,
    ) {
        super(messageService, translateService, dataService, 'Cashier Template');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CashierTemplateId: new FormControl(),
            CashierTemplateName: new FormControl(),
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
