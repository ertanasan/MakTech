// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormControl, FormControlName } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { PricePackage } from '@price/model/price-package.model';
import { PricePackageService } from '@price/service/price-package.service';
import { PackageType } from '@price/model/package-type.model';
import { PackageTypeService } from '@price/service/package-type.service';
import { StorePackage } from '@price/model/store-package.model';
import { StorePackageService } from '@price/service/store-package.service';
import { NumericEntryComponent } from '@otuidataentry/numeric-entry/numeric-entry.component';
import { DateEntryComponent } from '@otuidataentry/date-entry/date-entry.component';
import { finalize } from 'rxjs/operators';
import { DocumentHandle } from '@otmodel/document-handle.model';
import { environment } from '../../../../../../environments/environment';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-price-package-edit',
    templateUrl: './price-package-edit.component.html',
    styleUrls: ['./price-package-edit.component.css', ]
})
export class PricePackageEditComponent extends CRUDDialogScreenBase<PricePackage> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<PricePackage>;
    @ViewChild('startTime', {static: true}) storePackagesStartTime: DateEntryComponent;
    @ViewChild('endTime', {static: true}) storePackagesEndTime: DateEntryComponent;
    @ViewChild('priorityNumber', {static: true}) storePackagesPriority: NumericEntryComponent;
    isCampaignGeneral = false;
    deleteUrl = '';
    downloadUrl = '';

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: PricePackageService,
        public packageTypeService: PackageTypeService,
        public storePackageService: StorePackageService
    ) {
        super(messageService, translateService, dataService, 'Price Package');
        this.deleteUrl = environment.baseRoute + '/Price/PricePackage/DeleteDocument';
        this.downloadUrl = environment.baseRoute + '/Price/PricePackage/DownloadDocument';
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            PackageId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            PackageName: new FormControl(),
            PackageType: new FormControl(),
            Comment: new FormControl(),
            Image: new FormControl(),
            ImageDocument: new FormControl(new DocumentHandle())
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    onSubmit() {
        if (this.container.actionName === 'Create' && this.container.currentItem.PackageType === 3) {
            // OVERRIDDEN Create method of CRUD-DIALOG-SCREEN-BASE
            const restAction = 'Create';
            this.dataService.create(this.currentItem, restAction).pipe(
                finalize(() => this.container.hideProgress())
            ).subscribe(
                model => {
                    this.messageService.success(this.translateService.instant(this.createSuccessMessage, {0: this.translateService.instant(this.modelName)}));

                    // ASSIGNING PACKAGE STORES
                    const storePackage = new StorePackage();
                    storePackage.Package = model.PackageId;
                    storePackage.PriorityNumber = this.storePackagesPriority.value;
                    storePackage.StartTime = this.addHours(this.storePackagesStartTime.value, 3);
                    storePackage.EndTime = this.addHours(this.storePackagesStartTime.value, 3);
                    storePackage.AllStores = true;
                    this.storePackageService.create(storePackage, 'CreateStorePackage').subscribe(
                        model_2 => {
                            // this.messageService.success(`Package assigned to stores.`);
                            this.mainScreen.refreshData();
                            this.container.hide();
                        },
                        error => {
                            this.messageService.error(`Package could not assingned to stores.. Error: ${error}.`);
                        }
                    );
                },
                error => {
                    this.messageService.error(this.translateService.instant(this.createFailMessage, {0: this.translateService.instant(this.modelName), 1: error}));
                }
            );
        }
        super.onSubmit();
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    typeChanged(event: any) {
        this.isCampaignGeneral = event === 3;
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
