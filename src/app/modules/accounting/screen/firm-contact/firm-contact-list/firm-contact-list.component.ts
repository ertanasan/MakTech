// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { FirmContact } from '@accounting/model/firm-contact.model';
import { FirmContactService } from '@accounting/service/firm-contact.service';
import { FirmContactEditComponent } from '@accounting/screen/firm-contact/firm-contact-edit/firm-contact-edit.component';
import { Firm } from '@accounting/model/firm.model';
import { FirmService } from '@accounting/service/firm.service';
import { Contact } from '@contact/model/contact.model';
import {finalize} from 'rxjs/operators';
import {DialogScreenBase} from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-firm-contact-list',
    templateUrl: './firm-contact-list.component.html',
    styleUrls: ['./firm-contact-list.component.css', ]
})
export class FirmContactListComponent extends ListScreenBase<FirmContact> implements AfterViewInit, OnInit {
    @ViewChild(FirmContactEditComponent, { static: true }) editScreen: FirmContactEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: FirmContactService,
        public firmService: FirmService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.listAllContactByFirmId(this.leftRelationId);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Firm Contact', RouterLink: '/accounting/firm-contact'}];
    }

    createEmptyModel(): FirmContact {
        const firmContact = new FirmContact();
        if (this.leftRelationId > 0) {
            firmContact.Firm = this.leftRelationId;
        }
        if (this.rightRelationId > 0) {
            firmContact.Contact = this.rightRelationId;
        }
        return firmContact;
    }

    ngOnInit() {
        // Fill reference lists
        // if (!this.leftRelationId && !this.firmService.completeList) {
        //     this.firmService.listAll();
        // }
        // if (!this.rightRelationId && !this.contactService.completeList) {
        //     this.contactService.listAll();
        // }
        if (!this.dataService.mainTypeCompleteList) {
            this.dataService.listAllMainType();
        }
        if (!this.dataService.subContactTypeCompleteList) {
            this.dataService.listAllSubContactType();
        }
        if (!this.dataService.countryCompleteList) {
            this.dataService.listAllCountry();
        }
        if (!this.dataService.cityCompleteList) {
            this.dataService.listAllCity();
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
    showDialogByType(mainContactType: number, target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.activeContactType = mainContactType;
        this.showDialog(target, actionName, dataItem);
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
