import { Component, ViewChild, OnInit, AfterViewInit, EventEmitter } from '@angular/core';
import { TranslateService, TranslationChangeEvent } from '@ngx-translate/core';
import { ListParams } from '@otmodel/list-params.model';
import { StockTrackingDialogComponent } from './stock-tracking-dialog/stock-tracking-dialog.component';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';



//import { StockTracking } from '@warehouse/model/stock-tracking.model';
import { StockTrackingService } from '@warehouse/service/stock-tracking.service';
import { StockTakingEditComponent } from '@warehouse/screen/stock-taking/stock-taking-edit/stock-taking-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { ProductService } from '@product/service/product.service';
import { DatePipe } from '@angular/common';
import { DataStateChangeEvent, PageChangeEvent, EditEvent, GridDataResult } from '@progress/kendo-angular-grid';
import { process, SortDescriptor } from '@progress/kendo-data-query';
import { StorageZonesService } from '@warehouse/service/storage-zones.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
@Component({
  selector: 'ot-stock-tracking',
  templateUrl: './stock-tracking.component.html',
  styleUrls: ['./stock-tracking.component.css']
})
export class StockTrackingComponent implements OnInit {
  @ViewChild(StockTrackingDialogComponent, {static: true}) stockTrackingDialog: StockTrackingDialogComponent;
  
  product; startDate; endDate;
  selectedProductId;
  listParams;
  chartColors=[];
  constructor(
    public messageService: GrowlMessageService,
    public translateService: TranslateService,
    public utilityService: OTUtilityService,
    public dataService: StockTrackingService,
    public storeService: StoreService,
    public productService: ProductService,
    public storageZoneService: StorageZonesService,
    public formBuilder: FormBuilder,
    public datePipe: DatePipe,
    public route: ActivatedRoute,
    
  ) {
    this.listParams = new ListParams();
    this.listParams.take = 1000;
    this.chartColors = this.utilityService.colors.map(c => c.hex);
  }

  getList() {
    this.dataService.listStocktracking(new Date()).subscribe(list => {
      this.dataService.stockTracking = list;
    }, error => {
      this.messageService.error(error.message);
    });
  }

  ngOnInit() {
    this.getList();
    if (!this.productService.completeList) {
      this.productService.listAll();
    }
  }

  onProductChange(event) {

    this.dataService.listStocktrackingProducts(this.selectedProductId, new Date(new Date().setDate(-30)), new Date()).subscribe(
      result => {
        this.dataService.stocktTackingProducts = result;
      }, error => {
        this.messageService.error(`Unexpected error: ${error}`);
      });

  }

  onStockBubbleClick(event) {
    this.selectedProductId = event.dataItem.PRODUCTID;
  }

  onShowProductStockListDialog() {
    if (this.dataService.stockTracking) {
      this.stockTrackingDialog.onShow.next(this.dataService.stockTracking.Data);
      this.stockTrackingDialog.dialog.show();
    } else {
      this.messageService.warning(this.translateService.instant('No data retrieved for product stock'));
    }
  }
}
