// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ViewChildren, QueryList, ElementRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreOrderDetailService } from '@warehouse/service/store-order-detail.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { ActivatedRoute } from '@angular/router';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { EditEvent } from '@progress/kendo-angular-grid';
import { OTPrintingService } from '@otservice/printing.service';
import { process } from '@progress/kendo-data-query';
import { DatePipe } from '@angular/common';
import { StoreService } from '@store/service/store.service';
import { GatheringService } from '@warehouse/service/gathering.service';
import { ProductCategoryService } from '@product/service/product-category.service';
import { SubgroupService } from '@product/service/subgroup.service';
import { SuperGroup1Service } from '@product/service/super-group1.service';
import { SuperGroup2Service } from '@product/service/super-group2.service';
import { SuperGroup3Service } from '@product/service/super-group3.service';
import { ProductCategory } from '@product/model/product-category.model';
import { Subgroup } from '@product/model/subgroup.model';



/*Section="ClassHeader"*/
@Component({
    selector: 'ot-load-order-list',
    templateUrl: './load-order-list.component.html',
    styleUrls: ['./load-order-list.component.css', ]
})
export class LoadOrderListComponent extends ListScreenBase<Product> implements OnInit {

    public formGroup: FormGroup;
    editedRowIndex: number;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProductService,
        public productService: ProductService,
        public categoryService: ProductCategoryService,
        public subGroupService: SubgroupService,
        public superGroup1Service: SuperGroup1Service,
        public superGroup2Service: SuperGroup2Service,
        public superGroup3Service: SuperGroup3Service,
        public route: ActivatedRoute,
        public formBuilder: FormBuilder,
        public datePipe: DatePipe,
    ) {
        super(messageService, translateService);
    }

    refreshList() {

        this.dataService.activeList = process(this.dataService.completeList, this.listParams);

    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Load Order List', RouterLink: '/warehouse/load-order'}];
    }

    createEmptyModel(): Product {
        return new Product();
    }


    ngOnInit() {
        
        if (!this.categoryService.completeList) this.categoryService.listAll();
        if (!this.superGroup1Service.completeList) this.superGroup1Service.listAll();
        if (!this.superGroup2Service.completeList) this.superGroup2Service.listAll();
        if (!this.superGroup3Service.completeList) this.superGroup3Service.listAll();
        
        
        this.subGroupService.listAllAsync().subscribe(subGroupList => {
            this.subGroupService.completeList = subGroupList;
            
            this.dataService.listAllAsync().subscribe(list => {
                list.forEach( row => {
                    const sg: Subgroup[] = subGroupList.filter(f => f.SubgroupID === row.Subgroup);
                    if (sg.length > 0) row.Category = sg[0].Category;
                });

                this.dataService.completeList = list;
                super.ngOnInit();
            });
        });
        

    }


    /*Section="CustomCodeRegion"*/
    //#region Customized

    public createFormGroup(dataItem: any): FormGroup {

        let fg: FormGroup = null;
        fg = this.formBuilder.group({
            LoadOrder: new FormControl(dataItem.LoadOrder),
        });
        return fg;
    }

    public editHandler({ sender, rowIndex, dataItem }: EditEvent): void {
        if (this.formGroup && !this.formGroup.valid) {
            return;
        }
        this.editedRowIndex = rowIndex;

        sender.editRow(rowIndex, this.formGroup);
    }

    public cellClickHandler({ sender, rowIndex, columnIndex, dataItem, isEdited }) {

        if (!isEdited) {
            sender.editCell(rowIndex, columnIndex, this.createFormGroup(dataItem));
        }

    }

    public cellCloseHandler(args: any) {

        const { formGroup, dataItem, column } = args;

        if (!formGroup.valid) {
            args.preventDefault();
        } else if (formGroup.dirty) {
            console.log(args);
            if (args.column.field === 'LoadOrder' && formGroup.value.LoadOrder) {
                dataItem.LoadOrder = formGroup.value.LoadOrder;
                console.log(dataItem);
                this.productService.update(dataItem).subscribe(result => {
                    
                }, error => {
                    this.messageService.error(error.err.message);
                })
            } 
        }

    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }


    //#endregion Customized

    /*Section="ClassFooter"*/
}

