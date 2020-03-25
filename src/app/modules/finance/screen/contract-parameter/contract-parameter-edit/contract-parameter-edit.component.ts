// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ContractParameter } from '@finance/model/contract-parameter.model';
import { ContractParameterService } from '@finance/service/contract-parameter.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-contract-parameter-edit',
    templateUrl: './contract-parameter-edit.component.html',
    styleUrls: ['./contract-parameter-edit.component.css', ]
})
export class ContractParameterEditComponent extends CRUDDialogScreenBase<ContractParameter> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<ContractParameter>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ContractParameterService,
    ) {
        super(messageService, translateService, dataService, 'Contract Parameter');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ContractParameterId: new FormControl(),
            ParameterName: new FormControl(),
            Value: new FormControl(),
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
