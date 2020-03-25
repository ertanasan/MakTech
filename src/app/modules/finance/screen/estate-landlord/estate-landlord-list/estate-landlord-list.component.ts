// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { EstateLandlord } from '@finance/model/estate-landlord.model';
import { EstateLandlordService } from '@finance/service/estate-landlord.service';
import { EstateLandlordEditComponent } from '@finance/screen/estate-landlord/estate-landlord-edit/estate-landlord-edit.component';
import { Landlord } from '@finance/model/landlord.model';
import { LandlordService } from '@finance/service/landlord.service';
import { EstateRent } from '@finance/model/estate-rent.model';
import { EstateRentService } from '@finance/service/estate-rent.service';
import {finalize} from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-estate-landlord-list',
    templateUrl: './estate-landlord-list.component.html',
    styleUrls: ['./estate-landlord-list.component.css', ]
})
export class EstateLandlordListComponent extends ListScreenBase<EstateLandlord> implements AfterViewInit, OnInit {
    @ViewChild(EstateLandlordEditComponent, { static: true }) editScreen: EstateLandlordEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: EstateLandlordService,
        public landlordService: LandlordService,
        public estateRentService: EstateRentService,
    ) {
        super(messageService, translateService);
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
                this.dataList = <EstateLandlord[]>listResult.Data;
            },
            error => {
                this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
            }
        );
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Finance' }, {Caption: 'Estate Landlord', RouterLink: '/finance/estate-landlord'}];
    }

    createEmptyModel(): EstateLandlord {
        const estateLandlord = new EstateLandlord();
        if (this.leftRelationId > 0) {
            estateLandlord.EstateRent = this.leftRelationId;
        }
        if (this.rightRelationId > 0) {
            estateLandlord.Landlord = this.rightRelationId;
        }
        return estateLandlord;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.leftRelationId) {
            this.estateRentService.listAll();
        }
        if (!this.rightRelationId) {
            this.landlordService.listAll();
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
    //#endregion Customized

    /*Section="ClassFooter"*/
}
