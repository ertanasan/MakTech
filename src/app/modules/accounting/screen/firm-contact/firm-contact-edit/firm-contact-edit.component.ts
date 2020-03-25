// Created by OverGenerator
/*Section="Imports"*/
import {Component, Input, OnInit, ViewChild} from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { FirmContact } from '@accounting/model/firm-contact.model';
import { FirmContactService } from '@accounting/service/firm-contact.service';
import { Firm } from '@accounting/model/firm.model';
import { FirmService } from '@accounting/service/firm.service';
import { Contact } from '@contact/model/contact.model';
import {MainContactType} from '@contact/model/main-contact-type.model';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-firm-contact-edit',
    templateUrl: './firm-contact-edit.component.html',
    styleUrls: ['./firm-contact-edit.component.css', ]
})
export class FirmContactEditComponent extends CRUDDialogScreenBase<FirmContact> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<FirmContact>;
    @Input() activeContactType;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: FirmContactService,
        public firmService: FirmService,
        public firmContactService: FirmContactService,
    ) {
        super(messageService, translateService, dataService, 'Firm Contact');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            Firm: new FormControl(),
            Contact: new FormControl(),
            CreateDate: new FormControl(),
            CreateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            IsDefault: new FormControl(),
            IsActive: new FormControl(),
            IsPreferred: new FormControl(),
            ContactObject: this.container.formBuilder.group({
                ContactId: new FormControl(),
                Deleted: new FormControl(false),
                CreateDate: new FormControl(),
                UpdateDate: new FormControl(),
                CreateUser: new FormControl(),
                UpdateUser: new FormControl(),
                Organization: new FormControl(),
                MainContactType: new FormControl(),
                SubContactTypeName: new FormControl(),
                Description: new FormControl(),
                AddressContact: this.container.formBuilder.group({
                    AddressId: new FormControl(),
                    Deleted: new FormControl(false),
                    CreateDate: new FormControl(),
                    UpdateDate: new FormControl(),
                    CreateUser: new FormControl(),
                    UpdateUser: new FormControl(),
                    Organization: new FormControl(),
                    Contact: new FormControl(),
                    SubContactType: new FormControl(),
                    IsLocal: new FormControl(),
                    Country: new FormControl(),
                    LocalCity: new FormControl(),
                    GlobalCityName: new FormControl(),
                    CitySubDivision: new FormControl(),
                    Street: new FormControl(this.translateService.instant('Street')),
                    BuildingName: new FormControl(),
                    BuildingNo: new FormControl(),
                    RoomNo: new FormControl(),
                    ZipCode: new FormControl(),
                    Region: new FormControl(),
                }),
                PhoneContact: this.container.formBuilder.group({
                    PhoneId: new FormControl(),
                    Deleted: new FormControl(false),
                    CreateDate: new FormControl(),
                    UpdateDate: new FormControl(),
                    CreateUser: new FormControl(),
                    UpdateUser: new FormControl(),
                    Organization: new FormControl(),
                    Contact: new FormControl(),
                    SubContactType: new FormControl(),
                    PhoneNo: new FormControl('0'),
                }),
                WebContact: this.container.formBuilder.group({
                    WebId: new FormControl(),
                    Deleted: new FormControl(false),
                    CreateDate: new FormControl(),
                    UpdateDate: new FormControl(),
                    CreateUser: new FormControl(),
                    UpdateUser: new FormControl(),
                    Organization: new FormControl(),
                    Contact: new FormControl(),
                    SubContactType: new FormControl(),
                    Address: new FormControl(),
                    Description: new FormControl(),
                }),
            }),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        if (this.container.actionName === 'Create') {
            this.container.currentItem.ContactObject.MainContactType = this.activeContactType;
        }
        super.onSubmit();
    }

    activeContactChanged(selectedContactType) {
        this.activeContactType = selectedContactType;
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
