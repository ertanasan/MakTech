// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Pos } from '@store/model/pos.model';
import { PosService } from '@store/service/pos.service';
import { PosEditComponent } from '@store/screen/pos/pos-edit/pos-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Bank } from '@store/model/bank.model';
import { BankService } from '@store/service/bank.service';
import { GridComponent, GridDataResult } from '@progress/kendo-angular-grid';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-pos-list',
    templateUrl: './pos-list.component.html',
    styleUrls: ['./pos-list.component.css']
})
export class PosListComponent extends ListScreenBase<Pos> implements AfterViewInit, OnInit {
    @ViewChild(PosEditComponent, {static: true}) editScreen: PosEditComponent;
    posList: any[];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: PosService,
        public storeService: StoreService,
        public bankService: BankService,
    ) {
        super(messageService, translateService);
        this.allData = this.allData.bind(this);
    }

    public allData(): any {
        
            this.posList.forEach(row => {
                const s: Store[] = this.storeService.completeList.filter(f => f.StoreId === row.Store);
                if (s.length > 0) row.StoreName = s[0].Name;

                const b: Bank[] = this.bankService.completeList.filter(f => f.BankId === row.Bank);
                if (b.length > 0) row.BankName = b[0].BankName;
            });
            return <GridDataResult> {
                data: this.posList,
                total: this.posList.length
            };
        
        
    }

    refreshList() {
        if (!this.isEmbedded) {
            this.dataService.list(this.listParams);
        } else {
            const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
            if (result) {
                this.dataLoading = true;
                result.subscribe(
                    list => {
                        this.dataList = list;
                    },
                    error => {
                        this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                    },
                    () => this.dataLoading = false
                );
            }
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Store' }, { Caption: 'Pos', RouterLink: '/store/pos' }];
    }

    createEmptyModel(): Pos {
        const model = new Pos();
        if (this.isEmbedded) {
            model.Store = this.masterId;
            this.editScreen.storeVisible = false;
        } else {
            this.editScreen.storeVisible = true;
        }
        return model;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.bankService.completeList) {
            this.bankService.listAll();
        }
        this.dataService.listAllAsync().subscribe(list => {
            this.posList = list;
        });

        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    public exportToExcel(grid: GridComponent): void {
        grid.saveAsExcel();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
