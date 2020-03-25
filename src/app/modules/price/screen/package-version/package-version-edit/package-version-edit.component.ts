// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { PackageVersion } from '@price/model/package-version.model';
import { PackageVersionService } from '@price/service/package-version.service';
import { PricePackage } from '@price/model/price-package.model';
import { PricePackageService } from '@price/service/price-package.service';
import { IntlModule } from '@progress/kendo-angular-intl';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { EditDialogScreenBase } from '@otscreen-base/edit-dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-package-version-edit',
    templateUrl: './package-version-edit.component.html',
    styleUrls: ['./package-version-edit.component.css', ]
})
export class PackageVersionEditComponent extends EditDialogScreenBase implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<PackageVersion>;

    // public activationTime: Date = new Date();
    currentItem: PackageVersion;
    hasAutomaticIdentity = true;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: PackageVersionService,
        public pricePackageService: PricePackageService,
    ) {
        super(messageService, translateService, 'PackageVersion');
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

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            PackageVersionId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Package: new FormControl(),
            VersionDate: new FormControl(),
            ActiveFlag: new FormControl(),
            Comment: new FormControl(),
            ActivationTime: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    onSubmit() {
        if (this.container.mainForm.controls.ActiveFlag.value) {
            // this.container.mainForm.controls.ActivationTime.setValue(null);
            this.container.currentItem.ActivationTime = new Date();
        }
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

    create() {
        // Determine crate REST controller action name
        let restAction = 'Create';
        if (this.container.leftRelationId > 0) {
            restAction = 'AddLeft';
        } else if (this.container.rightRelationId > 0) {
            restAction = 'AddRight';
        }

        // Make the REST call
        this.dataService.create(this.currentItem, restAction).subscribe(
            model => {
                const returnedItem = Object.assign(this.currentItem, model);
                this.messageService.success(`Created a new ${ this.modelName } with id ${returnedItem.getId()}.`);
                this.mainScreen.refreshData(this.currentItem.getId());
                this.container.hide();
                this.container.hideProgress();
            },
            error => {
                this.messageService.error(`${ this.modelName } create failed. Error: ${error}.`);
                this.container.hideProgress();
            }
        );
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    update() {
        // const d = new Date(this.currentItem.ActivationTime);
        // d.setHours(this.activationTime.getHours(), this.activationTime.getMinutes());
        // d = kendo.timezone.apply(kendo.parseDate(d), "Etc/UTC");
        // this.currentItem.ActivationTime = d;
        this.currentItem.ActivationTime = this.addHours(this.currentItem.ActivationTime, 3);
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
