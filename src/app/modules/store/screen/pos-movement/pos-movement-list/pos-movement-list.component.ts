// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { PosMovement } from '@store/model/pos-movement.model';
import { PosMovementService } from '@store/service/pos-movement.service';
import { PosMovementEditComponent } from '@store/screen/pos-movement/pos-movement-edit/pos-movement-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { PosService } from '@store/service/pos.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-pos-movement-list',
    templateUrl: './pos-movement-list.component.html',
    styleUrls: ['./pos-movement-list.component.css', ]
})
export class PosMovementListComponent extends ListScreenBase<PosMovement> implements AfterViewInit, OnInit {
    @ViewChild(PosMovementEditComponent, { static: true }) editScreen: PosMovementEditComponent;

    posList: any;
    storeList: Store[];
    authorization: string;
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: PosMovementService,
        public storeService: StoreService,
        public posService: PosService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Pos Movement', RouterLink: '/store/pos-movement'}];
    }

    createEmptyModel(): PosMovement {
        return new PosMovement();
    }

    ngOnInit() {
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        
        this.storeService.listUserStores().subscribe(list => {
            this.storeList = list;
            this.editScreen.storeList = this.storeList;

            if (list[0].UserBranchType === 'Central Office') {
              this.editScreen.authorization = 'HQ';
              this.authorization = 'HQ';
            } else if (list[0].UserBranchType === 'Region') {
                this.editScreen.authorization = 'RG';
                this.authorization = 'RG';
            } else {
              this.editScreen.authorization = 'ST';
              this.authorization = 'ST';
            }
          }, error => {
            this.messageService.error(error);
        });

        this.posService.listAllAsync().subscribe(posResult => {
            this.posList = posResult.filter(row => row.MobilFlag);
            this.editScreen.posList = this.posList;
        });

        this.dataService.PosMoveInitial().subscribe(result => {
            this.dataService.listAsync(this.listParams).subscribe(result => {
                this.dataService.activeList.data = result.Data;
                this.dataService.activeList.total = result.Total;
                this.dataService.activeListChanged.next(this.dataService.activeList);
            });
        });


        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.movetime = new Date();
        super.showDialog(target, actionName, dataItem);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
