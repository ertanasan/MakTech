// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { UsersStores } from '@store/model/users-stores.model';
import { UsersStoresService } from '@store/service/users-stores.service';
import { UsersStoresEditComponent } from '@store/screen/users-stores/users-stores-edit/users-stores-edit.component';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { finalize } from 'rxjs/operators';
import { process } from '@progress/kendo-data-query';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-users-stores-list',
    templateUrl: './users-stores-list.component.html',
    styleUrls: ['./users-stores-list.component.css', ]
})
export class UsersStoresListComponent extends ListScreenBase<UsersStores> implements AfterViewInit, OnInit {
    @ViewChild(UsersStoresEditComponent, {static: true}) editScreen: UsersStoresEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: UsersStoresService,
        public userService: UserService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService);
        this.updateEnabled = false;
    }

    refreshList() {
        this.listParams.queryParams.clear();
        this.listParams.queryParams.set('leftId', this.leftRelationId);
        this.listParams.queryParams.set('rightId', this.rightRelationId);
        this.dataLoading = true;
        this.dataService.listAsync(this.listParams).pipe(
            finalize(() => this.dataLoading = false)
        ).subscribe(
            listResult => {
                this.dataService.activeList.data = listResult.Data;
                this.dataService.activeList.total = listResult.Total;
            },
            error => {
                this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
            }
        );
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Users Stores', RouterLink: '/store/users-stores'}];
    }

    createEmptyModel(): UsersStores {
        const usersStores = new UsersStores();
        if (this.leftRelationId > 0) {
            usersStores.User = this.leftRelationId;
        }
        if (this.rightRelationId > 0) {
            usersStores.Store = this.rightRelationId;
        }
        return usersStores;
    }

    ngOnInit() {
        // Fill reference lists
        this.userService.listAll();
        this.storeService.listAll();
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
