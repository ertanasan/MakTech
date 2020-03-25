import {Component, OnInit, ViewChild} from '@angular/core';
import {ListParams} from '@otmodel/list-params.model';
import {CustomDialogComponent} from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import {GatheringDetail} from '@warehouse/model/gathering-detail.model';
import {GrowlMessageService} from '@otservice/growl-message.service';
import {TranslateService} from '@ngx-translate/core';
import {GatheringService} from '@warehouse/service/gathering.service';
import {GatheringPalletService} from '@warehouse/service/gathering-pallet.service';
import {GatheringDetailService} from '@warehouse/service/gathering-detail.service';
import {OverstoreCommonMethods} from '../../../../../../util/common-methods.service';
import {process} from '@progress/kendo-data-query';
import {DataStateChangeEvent} from '@progress/kendo-angular-grid';
import { Product } from '@product/model/product.model';
import swal from "sweetalert2";
import { OTUtilityService } from '@otcommon/service/utility.service';

@Component({
  selector: 'ot-control-grid-entry',
  templateUrl: './control-grid-entry.component.html',
  styleUrls: ['./control-grid-entry.component.scss']
})
export class ControlGridEntryComponent implements OnInit {
  @ViewChild(CustomDialogComponent, {static: true}) dataEntryDialog: CustomDialogComponent;
  isDataEntryDialogOpen = false;
  dataEntryDialogTitle = '';

  isActualUnit = true;   // true: KG/QTY  false:PACKAGE

  controlGridLP: ListParams;
  addingGatheringDetail: Product;

  constructor(
      public messageService: GrowlMessageService,
      public translateService: TranslateService,
      public gatheringService: GatheringService,
      public gatheringPalletService: GatheringPalletService,
      public gatheringDetailService: GatheringDetailService,
      public commonMethods: OverstoreCommonMethods,
      public utilityService: OTUtilityService,
  ) { }

  ngOnInit() {
    this.controlGridLP = new ListParams();
    this.controlGridLP.take = 1000;
    this.gatheringDetailService.prepareActiveControlDetailList(this.controlGridLP);
  }

  showDataEntryDialog(dataItem: GatheringDetail, entryType = 'Quantity') {
    if (!this.isDataEntryDialogOpen) {
      this.gatheringDetailService.activeGatheringDetail = dataItem;

      this.dataEntryDialogTitle = this.translateService.instant(this.isActualUnit ? 'Unit Amount' : 'Package Amount') + ' (' + this.gatheringDetailService.activeGatheringDetail.ProductName + ')';
      this.isDataEntryDialogOpen = true;
      this.dataEntryDialog.show();
    }
  }

  hideDataEntryDialog() {
    if (this.isDataEntryDialogOpen) {
      this.gatheringDetailService.activeGatheringDetail = null;
      this.isDataEntryDialogOpen = false;
      this.dataEntryDialogTitle = '';
      this.dataEntryDialog.hide();
    }
  }

  controlQtyChange(value: number) {
    if (typeof(+value) !== 'number') {
      this.messageService.error(this.translateService.instant('Data enterred must be number') + '!');
    } else if (+value < 0) {
      this.messageService.error(this.translateService.instant('Quantity can not be smaller than zero') + '!');
    } else {
      const controlQuantity =  +value / (this.isActualUnit ? this.gatheringDetailService.activeGatheringDetail.PackageUnit : 1);

      if (controlQuantity === this.gatheringDetailService.activeGatheringDetail.ControlQuantity) {
        return;
      } else if (controlQuantity === 0 && this.gatheringDetailService.activeGatheringDetail.GatheredQuantity > 0) {
        swal({
          title: this.translateService.instant('Zero Value'),
          text: this.translateService.instant(`Control quantity of ${this.gatheringDetailService.activeGatheringDetail.ProductName} will be Zero. Are you sure do you want to proceed?`),
          type: 'warning',
          showCancelButton: true,
          confirmButtonColor: this.utilityService.getColor('danger'),
          cancelButtonColor: this.utilityService.getColor('secondary'),
          confirmButtonText: this.translateService.instant('Proceed'),
          cancelButtonText: this.translateService.instant('Cancel')
        }).then((confirmResult) => {
          if (confirmResult.value) {
            this.gatheringDetailService.logControlZero(this.gatheringPalletService.activePallet.GatheringPalletId,
                this.gatheringDetailService.activeGatheringDetail.GatheringDetailId,
                this.gatheringDetailService.activeGatheringDetail.ControlQuantity);
            this.gatheringDetailService.activeGatheringDetail.ControlQuantity = controlQuantity;
            this.checkGatheringDetailAsControlled(this.gatheringDetailService.activeGatheringDetail, this.gatheringDetailService.activeGatheringDetail.ControlQuantity);
            this.hideDataEntryDialog();
          }
        });
      } else {
        this.gatheringDetailService.activeGatheringDetail.ControlQuantity = controlQuantity;
        this.checkGatheringDetailAsControlled(this.gatheringDetailService.activeGatheringDetail, this.gatheringDetailService.activeGatheringDetail.ControlQuantity);
      }
    }
  }

  checkGatheringDetailAsControlled(item: GatheringDetail, controlQty: number) {
    const prevQty = item.ControlQuantity;
    const prevTime = item.ControlTime;
    item.ControlTime = this.commonMethods.addHours(new Date(), 3);
    item.ControlQuantity = controlQty;
    this.gatheringDetailService.update(item).subscribe(
        result => {
          item.Proceed = true;
          // if (this.isDataEntryDialogOpen) {
          //   this.hideDataEntryDialog();
          // }
        },
        error => {
          item.ControlQuantity = prevQty;
          item.ControlTime = prevTime;
          this.messageService.error(this.translateService.instant('An error occurred while updating Gathering Detail'));
        }
    );
  }

  getButtonClasses(dataItem: GatheringDetail) {
    let classes = 'btn btn-lg btn-block';
    if (dataItem.Proceed) {
      classes += ' btn-secondary';
    } else {
      classes += dataItem.GatheredQuantity !== dataItem.OrderQuantity ? ' btn-warning' : ' btn-primary';
    }
    return classes;
  }

  addProductToControlList() {
    console.log(this.addingGatheringDetail);
    if (this.addingGatheringDetail && this.addingGatheringDetail.ProductId > 0) {

      this.gatheringDetailService.addProductToControlList(
        this.gatheringPalletService.activePallet.Gathering, 
        this.gatheringPalletService.activePallet.PalletNo, 
        this.addingGatheringDetail.ProductId).subscribe(() => {
          this.gatheringDetailService.listControlDetail(
            this.gatheringPalletService.activePallet.Gathering, 
            this.gatheringPalletService.activePallet.PalletNo).subscribe(() => {
            this.addingGatheringDetail = null;
            this.gatheringDetailService.prepareAddableControlDetailList(this.gatheringPalletService.activePallet.Gathering, 
              this.gatheringPalletService.activePallet.PalletNo);
          });
        });

    } else {
      this.messageService.error(this.translateService.instant('No product added') + '!');
    }
  }

  onKgPackageChanged(stat) {
    this.isActualUnit = stat;
  }

  handleDSCControlGrid(state: DataStateChangeEvent) {
    if (state.sort) {
      this.controlGridLP.sort = state.sort;
    }
    if (state.filter) {
      this.controlGridLP.filter = state.filter;
    }
    this.gatheringDetailService.prepareActiveControlDetailList(this.controlGridLP);
  }

}
