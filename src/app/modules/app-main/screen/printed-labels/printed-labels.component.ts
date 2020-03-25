import { Component, OnInit } from '@angular/core';
import { PriceLabelPrintService } from '@price/service/price-label-print.service';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { TranslateService } from '@ngx-translate/core';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { process } from '@progress/kendo-data-query';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { ListParams } from '@otmodel/list-params.model';
import { StoreService } from '@store/service/store.service';
import { DatePipe } from '@angular/common';
import { OTUtilityService } from '@otcommon/service/utility.service';

@Component({
  selector: 'ot-printed-labels',
  templateUrl: './printed-labels.component.html',
  styleUrls: ['./printed-labels.component.css']
})
export class PrintedLabelsComponent extends MainScreenBase implements OnInit {

  storeDetailListParams: any;
  storeDetailsLoading = false;
  labelDetails: any[] = [];
  labelDetailsLoading = false;

  selectedStore: string;
  chartColors = [];

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    private utility: OTUtilityService,
    public datePipe: DatePipe,
    public priceLabelPrintService: PriceLabelPrintService,
    public storeService: StoreService,
  ) {
    super(messageService, translateService);
    this.chartColors = this.utility.colors.map(c => c.hex);
  }

  getBreadcrumbItems(): MenuItem[] {
    return null;
  }

  createEmptyItem() {
    throw new Error('Method not suported.');
  }

  public refreshData() {
    this.storeDetailsLoading = true;
    this.priceLabelPrintService.listPrintedLabels().subscribe(
      list => {
        this.priceLabelPrintService.printedLabelsRawData = list.Data;
        this.storeDetailsLoading = false;
        this.priceLabelPrintService.printedLabelsActiveList = process(this.priceLabelPrintService.printedLabelsRawData, this.storeDetailListParams);
      },
      error => {
        this.storeDetailsLoading = false;
        this.messageService.error(`Unexpected error: ${error}`);
      }
    );
  }

  clearData() {
    // reset listParams
    this.storeDetailListParams = new ListParams();
    this.storeDetailListParams.pageable = false;
    this.storeDetailListParams.take = 1000;

    // reset parameters & data
    this.selectedStore = null;
    this.labelDetails = [];
  }

  ngOnInit() {
    if (!this.storeService.completeList) {
      this.storeService.listAll();
    }

    this.clearData();
    this.refreshData();
  }

  handleDataStateChange(state: DataStateChangeEvent) {
    if (state.sort) {
        this.storeDetailListParams.sort = state.sort;
    }
    // if (state.filter) {
    //     this.listParams.filter = state.filter;
    // }

    this.priceLabelPrintService.printedLabelsActiveList = process(this.priceLabelPrintService.printedLabelsRawData, this.storeDetailListParams);
  }

  onStoreSeriesClick(event) {
    this.selectedStore = event.category;
    this.labelDetailsLoading = true;
    this.priceLabelPrintService.getPrintedLabelDetails(event.dataItem.STORE).subscribe(
      list => {
        this.labelDetails = list.Data;
        this.labelDetailsLoading = false;
      },
      error => {
        this.labelDetailsLoading = false;
        this.messageService.error(`Unexpected error: ${error}`);
      }
    );
  }

  onReLoadData() {
    this.clearData();
    this.refreshData();
  }

  getPanelCaption(panelName: string) {
    let captionTxt = this.translateService.instant(panelName);
    if (this.selectedStore) {
      captionTxt += ' - ' + this.selectedStore;
    }
    return captionTxt;
  }

  getFileName(gridName: string) {
    const d: Date = new Date();
    const d2 = this.datePipe.transform(d, 'yyyyMMdd');
    return this.selectedStore !== null && gridName === 'labelDetails' ? `${gridName}_${this.selectedStore}_${d2}.xlsx` : `${gridName}_AllStores_${d2}.xlsx`;
  }

}
