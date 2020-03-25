import { Component, OnInit, ViewChild, Input, OnDestroy } from '@angular/core';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { TranslateService } from '@ngx-translate/core';
import { GatheringService } from '@warehouse/service/gathering.service';
import { GatheringDetailService } from '@warehouse/service/gathering-detail.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { GatheringDetail } from '@warehouse/model/gathering-detail.model';
import {Subject, Subscription} from 'rxjs';
import { GatheringPalletService } from '@warehouse/service/gathering-pallet.service';
import {DataStateChangeEvent} from '@progress/kendo-angular-grid';
import {process} from '@progress/kendo-data-query';
import {ListParams} from '@otmodel/list-params.model';


@Component({
  selector: 'ot-gathering-grid-entry',
  templateUrl: './gathering-grid-entry.component.html',
  styleUrls: ['./gathering-grid-entry.component.css']
})
export class GatheringGridEntryComponent implements OnInit, OnDestroy {
  @ViewChild(CustomDialogComponent, {static: false}) gatheringDataEntryDialog: CustomDialogComponent;
  isDataEntryDialogOpen = false;
  dataEntryDialogTitle = '';
  isActualUnit = true;   // true: KG/QTY  false:PACKAGE

  detailGridLP: ListParams;

  constructor(
    public messageService: GrowlMessageService,
    public translateService: TranslateService,
    public gatheringService: GatheringService,
    public gatheringPalletService: GatheringPalletService,
    public gatheringDetailService: GatheringDetailService,
    public utilityService: OverstoreCommonMethods
  ) { }

  ngOnInit() {
    this.detailGridLP = new ListParams();
    this.detailGridLP.take = 1000;
    this.gatheringDetailService.prepareActiveGatheringDetailList(this.detailGridLP);
  }

  ngOnDestroy() {
  }

  showGatheringDataEntryDialog(dataItem: GatheringDetail, entryType = 'Quantity') {
    if (!this.isDataEntryDialogOpen) {
      this.gatheringDetailService.activeGatheringDetail = dataItem;
      this.dataEntryDialogTitle = this.translateService.instant(this.isActualUnit ? 'Unit Amount' : 'Package Amount') + ' (' + this.gatheringDetailService.activeGatheringDetail.ProductName + ')';
      this.isDataEntryDialogOpen = true;
      this.gatheringDataEntryDialog.show();
    }
  }

  hideGatheringDataEntryDialog() {
    if (this.isDataEntryDialogOpen) {
      this.gatheringDetailService.activeGatheringDetail = null;
      this.isDataEntryDialogOpen = false;
      this.dataEntryDialogTitle = '';
      this.gatheringDataEntryDialog.hide();
    }
  }

  gatheredQtyChange(value: number) {
    if (typeof(+value) !== 'number') {
      this.messageService.error(this.translateService.instant('Data enterred must be number') + '!');
    } else if (+value < 0) {
      this.messageService.error(this.translateService.instant('Quantity can not be smaller than zero') + '!');
    } else {
      this.gatheringDetailService.activeGatheringDetail.GatheredQuantity = +value / (this.isActualUnit ? this.gatheringDetailService.activeGatheringDetail.PackageUnit : 1);
      this.onGathered(this.gatheringDetailService.activeGatheringDetail, this.gatheringDetailService.activeGatheringDetail.GatheredQuantity);
    }
  }

  onGathered(item: GatheringDetail, gatheredQty: number) {
    const prevQty = item.GatheredQuantity;
    const prevTime = item.GatheringTime;
    item.GatheringTime = this.utilityService.addHours(new Date(), 3);
    item.GatheredQuantity = gatheredQty;
    this.gatheringDetailService.update(item).subscribe(
      result => {
        item.Proceed = true;
      },
      error => {
        item.GatheredQuantity = prevQty;
        item.GatheringTime = prevTime;
        this.messageService.error(this.translateService.instant('An error occurred while updating Gathering Detail'));
      }
    );
  }

  getButtonClasses(isProceed: boolean) {
    let classes = 'btn btn-lg btn-block';
    classes += isProceed ? ' btn-secondary ' : ' btn-primary';
    return classes;
  }

  onKgPackageChanged(stat) {
    this.isActualUnit = stat;
  }

  handleDSCDetailGrid(state: DataStateChangeEvent) {
    if (state.sort) {
      this.detailGridLP.sort = state.sort;
    }
    if (state.filter) {
      this.detailGridLP.filter = state.filter;
    }
    this.gatheringDetailService.prepareActiveGatheringDetailList(this.detailGridLP);
  }
}
