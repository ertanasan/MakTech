import {Component, OnInit, ViewChild, OnDestroy, ElementRef} from '@angular/core';
import { GatheringComponent } from '../gathering.component';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { GatheringService } from '@warehouse/service/gathering.service';
import { GatheringDetailService } from '@warehouse/service/gathering-detail.service';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { ScrollViewComponent } from '@progress/kendo-angular-scrollview';
import { Subject, Subscription } from 'rxjs';
import { GatheringDetail } from '@warehouse/model/gathering-detail.model';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import {finalize, first} from 'rxjs/operators';
import {UnitService} from '@product/service/unit.service';
import {GatheringGridViewComponent} from '@warehouse/screen/gathering/gathering/gathering-grid-view/gathering-grid-view.component';

@Component({
  selector: 'ot-gathering-tablet-view',
  templateUrl: './gathering-tablet-view.component.html',
  styleUrls: ['./gathering-tablet-view.component.css']
})
export class GatheringTabletViewComponent implements OnInit, OnDestroy {
  @ViewChild(CustomDialogComponent, {static: true}) previewDialog: CustomDialogComponent;
  @ViewChild(GatheringGridViewComponent, { static: true}) gridView: GatheringGridViewComponent;
  @ViewChild(ScrollViewComponent, {static: false}) scrollView: ScrollViewComponent;
  @ViewChild('pageNumber', {static: true}) pageNumber: ElementRef;

  isPreviewDialogOpen = false;
  updateSubscription: Subscription;
  goToIndexFromGridViewSubscription: Subscription;

  isActualUnit = true;   // true: KG/QTY  false:PACKAGE

  constructor(
    public messageService: GrowlMessageService,
    public translateService: TranslateService,
    public gatheringService: GatheringService,
    public gatheringDetailService: GatheringDetailService,
    public utilityService: OverstoreCommonMethods,
    public unitService: UnitService
  ) { }

  ngOnInit() {
    this.updateSubscription = this.gatheringDetailService.onUpdate.subscribe(manuelEntry => {
      if (!manuelEntry && this.scrollView.activeIndex < this.gatheringDetailService.gatheringDetailList.length) {
        setTimeout(() => {
          if (this.scrollView.activeIndex + 1 < this.gatheringDetailService.gatheringDetailList.length) {
            this.scrollView.activeIndex++;
          }
        }, 300);
      }
    });

    this.goToIndexFromGridViewSubscription = this.gridView.goToGatherIndexButtonClicked.subscribe(index => {
      this.isPreviewDialogOpen = false;
      this.previewDialog.hide();
      this.scrollView.activeIndex = index;
    });
  }

  ngOnDestroy() {
    if (this.updateSubscription) {
      this.updateSubscription.unsubscribe();
    }

    if (this.goToIndexFromGridViewSubscription ) {
      this.goToIndexFromGridViewSubscription.unsubscribe();
    }
  }

  itemChanged(index, newItem) {
    this.gatheringDetailService.activeGatheringDetail = this.gatheringDetailService.gatheringDetailList[index];
  }

  gather(dataItem: GatheringDetail, value: number) {
    if (typeof(+value) === 'number') {
      this.gatheringDetailService.activeGatheringDetail = dataItem;
      this.gatheringDetailService.initialQuantity = this.gatheringDetailService.activeGatheringDetail.GatheredQuantity;
      this.gatheringDetailService.initialTime = JSON.parse(JSON.stringify(this.gatheringDetailService.activeGatheringDetail.GatheringTime));
      this.gatheringDetailService.activeGatheringDetail.GatheringTime = this.utilityService.addHours(new Date(), 3);
      this.gatheringDetailService.activeGatheringDetail.GatheredQuantity = this.isActualUnit ? value / this.gatheringDetailService.activeGatheringDetail.PackageUnit : value;

      this.gatheringDetailService.update(this.gatheringDetailService.activeGatheringDetail).subscribe(
        result => {
          this.gatheringDetailService.activeGatheringDetail.Proceed = true;
          const isManuelEntry = this.gatheringDetailService.activeGatheringDetail.GatheredQuantity !== this.gatheringDetailService.activeGatheringDetail.OrderQuantity && value !== 0;
          this.gatheringDetailService.onUpdate.next(isManuelEntry);
          // if (this.gatheringDetailService.gatheringDetailList.length === this.scrollView.activeIndex + 1) {
          //   this.previewDialog.show();
          // } else {
          //   this.scrollView.activeIndex += 1;
          // }
        },
        error => {
          this.messageService.error(this.translateService.instant('An error occurred while updating gatheringDetail') + ': ' + this.gatheringDetailService.activeGatheringDetail.ProductName);
          this.gatheringDetailService.activeGatheringDetail.GatheringTime = this.gatheringDetailService.initialTime;
          this.gatheringDetailService.activeGatheringDetail.GatheredQuantity = this.gatheringDetailService.initialQuantity;
      });
    } else {
      this.messageService.warning(this.translateService.instant('Data enterred must be number') + '!');
    }
  }

  onConfirm() {
    this.gatheringService.completeGathering().pipe(finalize(() => this.isPreviewDialogOpen = false)).subscribe(
      result => { this.gatheringService.onGatheringDone.next(null);
      },
      error => { this.messageService.error(this.translateService.instant('Could not be complete')); }
    );
  }

  onModify() {
    this.isPreviewDialogOpen = false;
    this.previewDialog.hide();
  }

  goToIndex(indexStr) {
    const index = +indexStr;
    if (typeof(index) !== 'number') {
      this.messageService.error(this.translateService.instant('Input is not in number format') + '!');
    }
    if (index < this.gatheringDetailService.gatheringDetailList.length) {
      if (index >= 0) {
        this.scrollView.activeIndex = index;
      } else {
        this.scrollView.activeIndex = 0;
      }
    } else {
      this.scrollView.activeIndex = this.gatheringDetailService.gatheringDetailList.length - 1;
    }
  }

}
