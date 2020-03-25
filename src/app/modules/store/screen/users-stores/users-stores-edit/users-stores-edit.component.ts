// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { UsersStores } from '@store/model/users-stores.model';
import { UsersStoresService } from '@store/service/users-stores.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Subscription } from 'rxjs';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-users-stores-edit',
    templateUrl: './users-stores-edit.component.html',
    styleUrls: ['./users-stores-edit.component.css', ]
})
export class UsersStoresEditComponent extends CRUDDialogScreenBase<UsersStores> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<UsersStores>;
    showSubscription: Subscription;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: UsersStoresService,
        public userService: UserService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Users Stores');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            User: new FormControl(),
            Store: new FormControl(),
            CreateDate: new FormControl(),
            CreateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
        this.showSubscription = this.container.onShow.subscribe(item => {
            if (this.container.actionName === 'Create') {
                // this.container.mainForm.reset();
                this.container.mainForm.get('User').reset();
                this.container.mainForm.get('Store').reset();
            }
        });
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        if (!this.mainScreen.isEmbedded) {
            this.container.leftRelationId = this.container.currentItem.User;
        }
        super.onSubmit();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
