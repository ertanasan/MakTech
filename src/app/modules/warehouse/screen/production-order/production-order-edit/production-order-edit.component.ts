// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductionOrder } from '@warehouse/model/production-order.model';
import { ProductionOrderService } from '@warehouse/service/production-order.service';
import { Production } from '@warehouse/model/production.model';
import { ProductionService } from '@warehouse/service/production.service';
import { ProductionContent } from '@warehouse/model/production-content.model';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { InputDialogComponent } from '@otuicontainer/dialog/input-dialog/input-dialog.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-production-order-edit',
    templateUrl: './production-order-edit.component.html',
    styleUrls: ['./production-order-edit.component.css', ]
})
export class ProductionOrderEditComponent extends CRUDDialogScreenBase<ProductionOrder> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductionOrder>;
    @ViewChild(InputDialogComponent, {static: true}) partialComplete: InputDialogComponent;

    @Input() tolerancePct: number;
    contentsLoading: boolean;
    contentList: any;
    public formGroup: FormGroup;
    public activeItem: ProductionOrder;
    public reqQuantity: number;
    public partialCompleteQuantity: number;
    public initialCompleteQuantity = 0;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ProductionOrderService,
        public productionService: ProductionService,
        public formBuilder: FormBuilder,
    ) {
        super(messageService, translateService, dataService, 'Production Order');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductionOrderId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            Production: new FormControl(),
            Quantity: new FormControl(),
            CompletedQuantity: new FormControl(),
            StatusCode: new FormControl(),
            ProcessInstance: new FormControl(),
            PartialCompletion: new FormControl(),
            ProductionOrderCost: new FormControl(null),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    create() {
        this.currentItem.StatusCode = 1;
        super.create();
    }

    calcRequiredPackage (contentRow: ProductionContent) {
        // console.log(this.reqQuantity, (this.reqQuantity * contentRow.ShareRate / 100.0),
        //     ((this.reqQuantity * contentRow.ShareRate / 100.0) - contentRow.ProductionWarehouseStock) / contentRow.UnitWeight,
        //     Math.ceil(((this.reqQuantity * contentRow.ShareRate / 100.0) - contentRow.ProductionWarehouseStock) / contentRow.UnitWeight));
        contentRow.RequiredPackage = Math.ceil(((this.reqQuantity * contentRow.ShareRate / 100.0) - contentRow.ProductionWarehouseStock) / contentRow.UnitWeight);
        contentRow.Remnant = (contentRow.RequiredPackage * contentRow.UnitWeight) - ((this.reqQuantity * contentRow.ShareRate / 100.0) - contentRow.ProductionWarehouseStock);
        return contentRow;
    }

    onProductionChange(productionId) {
        this.container.mainForm.controls.Quantity.setValue(null);
        this.container.mainForm.controls.ProductionOrderCost.setValue(null);

        this.contentsLoading = true;
        this.productionService.ListProductionContentswithStocks(productionId).subscribe(result => {
            this.contentsLoading = false;
            this.contentList = JSON.parse(JSON.stringify(result));
            this.contentList.forEach (row => {
                const list = row.UnitWeightStr.split(';');
                row.UnitWeightList = [];
                row.UnitWeight = list[0];
                list.forEach(wrow => {
                    row.UnitWeightList.push({value: parseFloat(wrow.trim())});
                });
                row = this.calcRequiredPackage(row);
            });
        }, error => {
            this.messageService.error(error.error);
            console.log(error);
            this.contentsLoading = false;
        });
    }

    public createFormGroup(dataItem: any): FormGroup {

        let fg: FormGroup = null;
        fg = this.formBuilder.group({
            UnitWeight: new FormControl(dataItem.UnitWeight, [Validators.required, Validators.nullValidator]),
            AllocatedPackage: new FormControl(dataItem.AllocatedPackage),
            AllocatedQuantity: new FormControl(dataItem.AllocatedQuantity),
        });
        return fg;
    }

    public cellClickHandler({ sender, rowIndex, columnIndex, dataItem, isEdited }) {

        if (this.modeContext && !isEdited && this.activeItem.StatusCode === 1) {
            sender.editCell(rowIndex, columnIndex, this.createFormGroup(dataItem));
        }

    }

    public cellCloseHandler(args: any) {
        const { formGroup, dataItem, column } = args;
        if (!formGroup.valid) {
            args.preventDefault();
        } else if (formGroup.dirty) {
            if (args.column.field === 'UnitWeight' && formGroup.value.UnitWeight) {
                dataItem.UnitWeight = formGroup.value.UnitWeight;
            } else if (args.column.field === 'AllocatedPackage' && formGroup.value.AllocatedPackage) {
                dataItem.AllocatedPackage = formGroup.value.AllocatedPackage;
                dataItem.AllocatedQuantity = dataItem.AllocatedPackage * dataItem.UnitWeight;
            } else if (args.column.field === 'AllocatedQuantity' && formGroup.value.AllocatedQuantity) {
                dataItem.AllocatedQuantity = formGroup.value.AllocatedQuantity;
                dataItem.AllocatedPackage = dataItem.AllocatedQuantity / dataItem.UnitWeight;
            }
        }
    }

    public onUnitWeightChange(newUnitWeight, dataItem) {
        dataItem.UnitWeight = newUnitWeight;
        dataItem = this.calcRequiredPackage(dataItem);
    }

    public onQuantityChange(quantity: number) {
        this.reqQuantity = quantity;
        let cost = 0;
        if (this.contentList) {
            this.contentList.forEach (row => {
                row = this.calcRequiredPackage(row);
                // cost += row.RequiredPackage * row.UnitWeight * row.UnitCost;
                cost += this.reqQuantity * row.ShareRate / 100 * row.UnitCost;
            });
        }
        this.container.mainForm.controls.ProductionOrderCost.setValue(cost);
    }

    review() {
        if (this.container.currentItem.actionChoice === 'Kısmi Tamamlandı') {
            this.container.hideProgress();
            this.partialComplete.caption = `${'Tamamlanan Miktar'}`;
            this.partialComplete.show();
        } else if (this.container.currentItem.actionChoice === 'Tamamlandı') {
            this.container.hideProgress();
            this.partialComplete.caption = `${'Tamamlanan Miktar'}`;
            this.partialComplete.show();
        } else {
            const cl = JSON.parse(JSON.stringify(this.contentList));
            cl.forEach(row => {
                row.UnitWeightList = null;
            });
            this.container.currentItem.contents = cl;
            super.review();
        }
    }

    onActionPartialInput(event) {
        if ((this.initialCompleteQuantity + this.partialCompleteQuantity) > this.container.currentItem.Quantity) {
            this.messageService.warning('Tamamlanan miktar, toplam talep edilen miktarı aşmaktadır.');
        } else if (this.container.currentItem.actionChoice === 'Tamamlandı' && (this.initialCompleteQuantity + this.partialCompleteQuantity) < (this.container.currentItem.Quantity * (1 - this.tolerancePct))) {
            this.messageService.warning(`Fire miktarı %${this.tolerancePct * 100} ve üstünde olamaz`);
        } else {
            this.container.currentItem.PartialCompletion = this.partialCompleteQuantity;
            this.container.currentItem.CompletedQuantity = (this.initialCompleteQuantity + this.partialCompleteQuantity);
            this.partialComplete.hide();
            super.review();
        }
    }

    onSubmit() {
        if (this.container.currentItem.actionChoice === 'Gönderildi' && this.activeItem && this.activeItem.StatusCode === 1) {
            if (this.contentList.some(content => content.UnitWeight === null
                                                || content.AllocatedPackage === null
                                                || content.AllocatedPackage < content.RequiredPackage
                                                || content.AllocatedQuantity === null
                                                || content.AllocatedQuantity < (content.RequiredPackage * content.UnitWeight))) {
                this.messageService.warning(this.translateService.instant('Allocation fileds must be equal or greater than required quantities'));
            } else {
                super.onSubmit();
            }
        } else {
            super.onSubmit();
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
