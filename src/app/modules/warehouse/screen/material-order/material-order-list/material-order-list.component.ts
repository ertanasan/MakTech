// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { MaterialOrder } from '@warehouse/model/material-order.model';
import { MaterialOrderService } from '@warehouse/service/material-order.service';
import { MaterialOrderEditComponent } from '@warehouse/screen/material-order/material-order-edit/material-order-edit.component';
import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import { StoreService } from '@store/service/store.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { MaterialService } from '@warehouse/service/material.service';
import { MaterialInfoService } from '@warehouse/service/material-info.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import * as _ from 'lodash';
import { select } from '@ngrx/store';
import { SelectEndEvent } from '@progress/kendo-angular-charts';
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { GridComponent, GridDataResult } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';
import { first } from 'rxjs/operators';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-material-order-list',
    templateUrl: './material-order-list.component.html',
    styleUrls: ['./material-order-list.component.css', ]
})
export class MaterialOrderListComponent extends ListScreenBase<MaterialOrder> implements AfterViewInit, OnInit {
    @ViewChild(MaterialOrderEditComponent, { static: true }) editScreen: MaterialOrderEditComponent;
    @ViewChild(GridComponent, {static: true}) grid: GridComponent;

    StatusCodeList = [
    {value: 1, text: 'Giriş', responsible: 'Şube'}, 
    {value: 2, text: 'Talep Gönderildi', responsible: 'İdari İşler'}, 
    {value: 3, text: 'Sevk Emri Verildi', responsible: 'Depo'},
    {value: 4, text: 'Sevk Edildi', responsible: 'Şube'},
    {value: 5, text: 'Kabul Edildi', responsible: ''},
    {value: 6, text: 'Mal Kabul Edilmedi', responsible: 'Şube'},
    {value: 7, text: '', responsible: ''},
    {value: 8, text: 'Depoda Yok', responsible: 'Depo'},
    {value: 9, text: 'Reddedildi', responsible: 'İdari İşler'},
    ];
    selectedDay: Date = new Date(Date.now());
    allFlag = false;
    orderActionName: string;
    showAction = false;
    showActionSplit = false;
    showActionReject = false;
    showActionNone = false;
    showActionRefuse = false;

    checkedList =  [];
    contextState$: Observable<OTContext>;

    OrderActionNameList : string[] = ['Talebi Gönder', 'Sevk Emri', 'Sevk Et', 'Kabul']
    branchType: string;
    isHeadQuarter: boolean;
    departmentName: string;
    isDepot: boolean;
    isStore: boolean;
    orderList: MaterialOrder[];
    orderActiveList: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: MaterialOrderService,
        public storeService: StoreService,
        public userService: UserService,
        private store: Store<fromApp.AppState>,
        public materialService: MaterialService,
        public materialInfoService: MaterialInfoService,
        public formBuilder: FormBuilder,
        public datePipe: DatePipe,


    ) {
        super(messageService, translateService);
        this.contextState$ = this.store.select('context');
        this.allData = this.allData.bind(this);

    }

    public allData(): any {
        let newList = JSON.parse(JSON.stringify(this.orderList));
        newList.forEach(row => {
            row.StoreName = this.storeService.completeList.filter(r => r.StoreId === row.Store)[0].Name;
            row.OrderStatusName = this.StatusCodeList.filter(r => r.value === row.OrderStatusCode)[0].text;
            row.MaterialName = this.materialService.completeList.filter(r => r.MaterialId === row.Material)[0].MaterialName;
            if (row.MaterialInfo) {
                row.MaterialInfoName = this.materialInfoService.completeList.filter(r => r.MaterialInfoId === row.MaterialInfo)[0].ShortName;
            }
        })
        return <GridDataResult> {
            data: process(newList, { sort: [{ field: 'OrderDate', dir: 'asc' }] }).data,
            total: newList.length
        };
    }
    
    public getxlsFileName(): string {
        const todayString = this.datePipe.transform(new Date(), 'yyyyMMdd');
        return `${'MalzemeSiparişListesi'}_${todayString}.xlsx`;
    }

    public exportToExcel(grid: GridComponent): void {
        grid.saveAsExcel();
    }

    refreshList() {
        this.orderActiveList = process(this.orderList, this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Material Order', RouterLink: '/warehouse/material-order'}];
    }

    createEmptyModel(): MaterialOrder {
        return new MaterialOrder();
    }

    ngOnInit() {

        if (!this.storeService.completeList) this.storeService.listAll();
        // Fill reference lists
        this.storeService.listUserStores().subscribe(storeList => {
            this.storeService.userStores = storeList;
            this.branchType = storeList[0].UserBranchType;
            this.departmentName = storeList[0].UserDepartment;
            this.isHeadQuarter = (this.branchType === 'Central Office');
            this.isDepot = (this.departmentName === 'Merkez Depo');
            this.isStore = (this.branchType === 'Branch');
        });

        if (!this.userService.completeList) {
            this.userService.listAll();
        }
        if (!this.materialService.completeList) { this.materialService.listAll();}
        if (!this.materialInfoService.completeList) { this.materialInfoService.listAll();}

        this.selectedDay.setDate(this.selectedDay.getDate() - 30);
        this.onOrderFilter();

        // super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.editScreen.callee = <MaterialOrderListComponent>this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        // console.log(this.editScreen.callee);
        if (dataItem) {
            this.editScreen.statusCode = dataItem.OrderStatusCode;
        } else {
            this.editScreen.statusCode = 1;
        }
        super.showDialog(target, actionName, dataItem);
    }

    onOrderAction() {
        const newStatusCode = this.OrderActionNameList.findIndex(row => row === this.orderActionName) + 2;

        this.dataService.UpdateStatus(newStatusCode, this.checkedList).subscribe(result => {
            this.messageService.success('İşlem tamamlandı.');
            this.onOrderFilter();
        }, (error: HttpErrorResponse) => {
            console.log(error);
            this.messageService.error(this.translateService.instant(`An error occured while transferring-${error.error.text}`));
        });
    }

    refreshData() {
        this.onOrderFilter();
    }
    
    onOrderFilter() {
        this.dataService.ListOrders(this.datePipe.transform(new Date(this.selectedDay), 'yyyy-MM-dd'), this.allFlag).subscribe (result => {
            this.orderList = result;
            this.refreshList();
            this.showAction = false;
            this.showActionNone = false;
            this.showActionRefuse = false;
            this.showActionReject = false;
            this.showActionSplit = false;
            this.checkedList = [];
        })
    }

    onSelectedKeysChange(event) {
        this.orderActionName = "";
        this.showAction = false;
        this.showActionSplit = false;
        this.showActionReject = false;
        this.showActionRefuse = false;
        this.showActionNone = false;
        let actionCount = 0;
        event.forEach(rowno => {
            const selectedRow = _.filter(this.orderList, ['MaterialOrderId', rowno])[0];
            if (selectedRow && this.orderActionName !== this.OrderActionNameList[selectedRow.OrderStatusCode-1]) {
                actionCount++;
                if ((this.isStore && (selectedRow.OrderStatusCode === 1 || selectedRow.OrderStatusCode === 4))
                    ||
                    (this.isDepot && (selectedRow.OrderStatusCode === 3))
                    ||
                    (this.isHeadQuarter && (selectedRow.OrderStatusCode === 2))) {
                    this.orderActionName = this.OrderActionNameList[selectedRow.OrderStatusCode-1];
                    this.showAction = true;
                }
            } 
        });
        if (actionCount > 1) this.showAction = false;
        if (this.showAction) {
            switch (this.orderActionName) {
                case 'Sevk Emri' : this.showActionSplit = true; this.showActionReject = true; break;
                case 'Sevk Et' : this.showActionNone = true; break;
                case 'Kabul' : this.showActionRefuse = true; break;
            }
        }
    }

    createFormGroup(dataItem: any): FormGroup {

        let fg: FormGroup = null;
        switch (dataItem.OrderStatusCode) {
            case 1: if (this.isStore || this.isHeadQuarter) {
                        fg = this.formBuilder.group({
                            OrderQuantity: new FormControl(dataItem.OrderQuantity),
                        }); 
                    } break;
            case 2: if (this.isHeadQuarter) {
                        fg = this.formBuilder.group({
                            RevisedQuantity: new FormControl(dataItem.RevisedQuantity),
                        }); 
                    } break; 
            case 3: if (this.isDepot || this.isHeadQuarter) {
                        fg = this.formBuilder.group({
                            ShippedQuantity: new FormControl(dataItem.ShippedQuantity),
                        }); 
                    } break;
            case 4: if (this.isStore || this.isHeadQuarter) {
                        fg = this.formBuilder.group({
                            IntakeQuantity: new FormControl(dataItem.IntakeQuantity),
                        });
                    }  break;
        }
        return fg;
    }

    cellClickHandler({ sender, rowIndex, columnIndex, dataItem, isEdited }) {

        if (!isEdited && ((this.isStore && (dataItem.OrderStatusCode === 4 || dataItem.OrderStatusCode === 1)) || 
            (this.isDepot && dataItem.OrderStatusCode === 3) || this.isHeadQuarter)) {
            sender.editCell(rowIndex, columnIndex, this.createFormGroup(dataItem));
        }
    }

    onEnterClicked(e) {
        if (this.grid.activeCell) {
            if (this.grid.isEditing) {
                this.grid.focusCell(this.grid.activeCell.rowIndex, this.grid.activeCell.colIndex);
            } else {
                this.grid.editCell(this.grid.activeCell.rowIndex, this.grid.activeCell.colIndex);
            }
        } else {
            e.preventDefault();
        }
    }

    public cellCloseHandler(args: any) {

        let changed = false;
        const { formGroup, dataItem } = args;

        if (!formGroup.valid) {
            args.preventDefault();
        } else if (formGroup.dirty) {
            if (args.column.field === 'OrderQuantity' && formGroup.value.OrderQuantity) {

                if (formGroup.value.OrderQuantity > 0) {
                    dataItem.OrderQuantity = formGroup.value.OrderQuantity;
                    changed = true;
                } else {
                    dataItem.OrderQuantity = 0;
                }
                dataItem.RevisedQuantity = dataItem.OrderQuantity;
                dataItem.ShippedQuantity = dataItem.OrderQuantity;
                dataItem.IntakeQuantity = dataItem.OrderQuantity;

            } else if (args.column.field === 'RevisedQuantity' && formGroup.value.RevisedQuantity) {
                if (formGroup.value.RevisedQuantity > 0) {
                    dataItem.RevisedQuantity = formGroup.value.RevisedQuantity;
                    changed = true;
                } else {
                    dataItem.RevisedQuantity = 0;
                }
                dataItem.ShippedQuantity = dataItem.RevisedQuantity;
                dataItem.IntakeQuantity = dataItem.RevisedQuantity;
            } else if (args.column.field === 'ShippedQuantity' && formGroup.value.ShippedQuantity) {
                if (formGroup.value.ShippedQuantity > 0) {
                    dataItem.ShippedQuantity = formGroup.value.ShippedQuantity;
                    changed = true;
                } else {
                    dataItem.ShippedQuantity = 0;
                }
                dataItem.IntakeQuantity = dataItem.ShippedQuantity;
            } else if (args.column.field === 'IntakeQuantity' && formGroup.value.IntakeQuantity) {
                if (formGroup.value.IntakeQuantity > 0) {
                    dataItem.IntakeQuantity = formGroup.value.IntakeQuantity;
                    changed = true;
                } else {
                    dataItem.IntakeQuantity = 0;
                }
            } 
            if (changed) {
                this.dataService.update(dataItem).subscribe(()=>{});
            }
        }

    }

    public onAction(actionCode) {
        this.dataService.TakeOrderAction(actionCode, this.checkedList).subscribe(result => {
            this.messageService.success('İşlem tamamlandı.');
            this.onOrderFilter();
        }, (error: HttpErrorResponse) => {
            console.log(error);
            this.messageService.error(this.translateService.instant(`An error occured while transferring-${error.error.text}`));
        });        
    }

    updateControl(dataItem) {
        if ((this.isStore && (dataItem.OrderStatusCode === 1 || dataItem.OrderStatusCode === 4))
            ||
            (this.isHeadQuarter)
            ||
            (this.isDepot && (dataItem.OrderStatusCode === 3)) ){
                return true;
        } else {
            return false;
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
