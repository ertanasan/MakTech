// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { IntakeStatus } from '@warehouse/model/intake-status.model';
import { IntakeStatusService } from '@warehouse/service/intake-status.service';
import { IntakeStatusEditComponent } from '@warehouse/screen/intake-status/intake-status-edit/intake-status-edit.component';
import { IntakeStatusTypeService } from '@warehouse/service/intake-status-type.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-intake-status-list',
    templateUrl: './intake-status-list.component.html',
    styleUrls: ['./intake-status-list.component.css', ]
})
export class IntakeStatusListComponent extends ListScreenBase<IntakeStatus> implements OnInit, AfterViewInit {
    @ViewChild(IntakeStatusEditComponent, {static: true}) editScreen: IntakeStatusEditComponent;
    includeTransferredFlag = false;
    intakesToTransfer =  [];
    hasEditPrivilege = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: IntakeStatusService,
        public intakeStatusTypeService: IntakeStatusTypeService,
        public privilegeCacheService: PrivilegeCacheService
    ) {
        super(messageService, translateService);
    }

    onIncludeChecked() {
        this.includeTransferredFlag = !this.includeTransferredFlag;
        this.refreshList();
    }

    refreshList() {
        if (!this.includeTransferredFlag) {
            this.listParams.filter.filters.push({ field: 'IsTransferred', operator: 'eq', value: false });
            this.dataService.list(this.listParams);
            this.listParams.filter.filters.pop();
        } else {
            this.dataService.list(this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Intake Status', RouterLink: '/warehouse/intake-status'}];
    }

    createEmptyModel(): IntakeStatus {
        return new IntakeStatus();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    ngOnInit() {
        if (!this.intakeStatusTypeService.completeList) {
            this.intakeStatusTypeService.listAll();
        }
        this.privilegeCacheService.checkPrivilege('WHS-Update IntakeStatus').subscribe( result => {
            this.hasEditPrivilege = result;
        });

        super.ngOnInit();
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['MikroShipmentDate', 'IntakeDate'];
        super.handleDataStateChange(state);
    }

    onTransferButtonClicked() {
        if (this.intakesToTransfer.length) {
            let transferrableIntakes = [];
            const statusTypesToBeTransfered = [1, 4];  // 1:'Mağaza Haklı' , 4:'Sevkiyatta Karışıklık'
            transferrableIntakes = this.intakesToTransfer.filter( sodId => this.dataService.activeList.data.filter( a => statusTypesToBeTransfered.includes(a.IntakeStatusType)).map( b => b.StoreOrderDetail).includes(sodId));
            if (transferrableIntakes.length) {
                this.dataService.transferToMikro(transferrableIntakes).subscribe(
                    result => {
                        this.intakesToTransfer = [];
                        this.refreshList();
                        this.messageService.success(this.translateService.instant('Items successfully transferred to Mikro DB'));
                    }, error => this.messageService.error(this.translateService.instant('Transfer process failed'))
                );
            } else {
                this.messageService.warning(this.translateService.instant('There is not any transferrable store order'));
            }
        } else {
            this.messageService.warning(this.translateService.instant('At least one item must be selected'));
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
