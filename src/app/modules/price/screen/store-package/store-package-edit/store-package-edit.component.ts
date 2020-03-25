// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StorePackage } from '@price/model/store-package.model';
import { StorePackageService } from '@price/service/store-package.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { PricePackage } from '@price/model/price-package.model';
import { PricePackageService } from '@price/service/price-package.service';
import { PackageVersion } from '@price/model/package-version.model';
import { PackageVersionService } from '@price/service/package-version.service';
import { EditDialogScreenBase } from '@otscreen-base/edit-dialog-screen-base';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { UserService } from '@frame/security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-package-edit',
    templateUrl: './store-package-edit.component.html',
    styleUrls: ['./store-package-edit.component.css', ]
})
export class StorePackageEditComponent extends CRUDDialogScreenBase<StorePackage> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StorePackage>;

    @Input() storeId = -1;

    currentItem: StorePackage;
    showAllStores: Boolean = true;
    hasAutomaticIdentity = true;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StorePackageService,
        public userService: UserService,
        public storeService: StoreService,
        public pricePackageService: PricePackageService,
        public packageVersionService: PackageVersionService,
    ) {
        super(messageService, translateService, dataService, 'StorePackage');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StorePackageId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Store: new FormControl(),
            Package: new FormControl(),
            PriorityNumber: new FormControl(),
            IsCurrentFlag: new FormControl(),
            CurrentVersion: new FormControl(),
            StartTime: new FormControl(),
            EndTime: new FormControl(),
            StoreList: new FormControl(),
            AllStores: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();

        if (!this.pricePackageService.completeList) {
            this.pricePackageService.listAll();
        }

        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.userService.completeList) {
            this.userService.listAll();
        }
        this.actions.push(
            {
                name: 'Create',
                isAcceptable: true,
                title: `New ${ this.modelName }`,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: !this.hasAutomaticIdentity,
            },
            {
                name: 'Read',
                isAcceptable: false,
                title: `${ this.modelName } Details`,
                controlsDisabled: true,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: false,
            },
            {
                name: 'Update',
                isAcceptable: true,
                title: `Update ${ this.modelName }`,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: false,
            },
            {
                name: 'Delete',
                isAcceptable: true,
                title: `Delete ${ this.modelName }`,
                controlsDisabled: true,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: false,
            },
            {
                name: 'Review',
                isAcceptable: false,
                title: `Review ${ this.modelName }`,
                controlsDisabled: false,
                hasChildren: true,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: false,
            }
        );
    }

    onSubmit() {
        this.currentItem = this.container.currentItem;

        if (this.container.useExternalLogic) {
            this.container.onDialogAction.next(this.currentItem);
        } else {
            this.container.showProgress();
            switch (this.container.actionName) {
                case 'Create':
                    this.create();
                    break;
                case 'Update':
                    this.update();
                    break;
                case 'Delete':
                    this.delete();
                    break;
                case 'Review':
                    this.review();
                    break;
                default:
                    this.messageService.error( `Unrecognized dialog action ${this.container.actionName}`);
            }
        }
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    create() {
        // Determine crate REST controller action name
        let restAction = 'Create';
        if (this.container.leftRelationId > 0) {
            restAction = 'AddLeft';
        } else if (this.container.rightRelationId > 0) {
            restAction = 'AddRight';
        }

        this.currentItem.StartTime = this.addHours(this.currentItem.StartTime, 3);
        this.currentItem.EndTime = this.addHours(this.currentItem.EndTime, 3);
        this.dataService.create(this.currentItem, 'CreateStorePackage').subscribe(
            model => {
                // const returnedItem = Object.assign(this.currentItem, model);
                this.messageService.success(`Package assigned to stores.`);
                this.mainScreen.refreshData();
                this.container.hide();
                this.container.hideProgress();
            },
            error => {
                this.messageService.error(`${ this.modelName } create failed. Error: ${error}.`);
                this.container.hideProgress();
            }
        );
    }

    update() {
        this.currentItem.StartTime = this.addHours(this.currentItem.StartTime, 3);
        this.currentItem.EndTime = this.addHours(this.currentItem.EndTime, 3);
        this.dataService.update(this.currentItem).subscribe(
            model => {
                this.messageService.success(`Updated ${ this.modelName } with id ${this.currentItem.getId()}.`);
                this.mainScreen.refreshData(this.currentItem.getId());
                this.container.hide();
                this.container.hideProgress();
            },
            error => {
                this.messageService.error(`${ this.modelName } update failed. Error: ${error}.`);
                this.container.hideProgress();
            }
        );
    }

    delete() {
        this.dataService.delete(this.currentItem.getId()).subscribe(
          model => {
            this.messageService.success(`Deleted ${ this.modelName }.`);
            this.mainScreen.refreshData();
            this.container.hide();
            this.container.hideProgress();
        },
          error => {
            this.messageService.error( `${ this.modelName } delete failed. Error: ${error}.`);
            this.container.hideProgress();
        }
        );
    }

    review() {
        this.currentItem.action = this.modeContext.actionId;
        this.dataService.takeAction(this.currentItem).subscribe(
            model => {
                this.messageService.success( `Updated ${ this.modelName } with id ${this.currentItem.getId()}.`);
                this.mainScreen.refreshData(this.currentItem.getId());
                this.mainScreen.modeEvent.emit();
                this.container.hide();
                this.container.hideProgress();
            },
            error => {
                this.messageService.error( `${ this.modelName } update failed. Error: ${error}.`);
                this.container.hideProgress();
            }
        );
    }
}
