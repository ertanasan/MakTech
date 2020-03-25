import {Component, OnInit, ViewChild, ViewEncapsulation, OnDestroy, ElementRef, ChangeDetectorRef} from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { GatheringService } from '@warehouse/service/gathering.service';
import { GatheringDetailService } from '@warehouse/service/gathering-detail.service';
import { OTScreenBase } from '@otscreen-base/ot-screen-base';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { GatheringTabletViewComponent } from './gathering-tablet-view/gathering-tablet-view.component';
import { Subscription } from 'rxjs';
import { DeviceDetectorService } from 'ngx-device-detector';
import {GatheringTypeService} from '@warehouse/service/gathering-type.service';
import {Gathering} from '@warehouse/model/gathering.model';
import {ListParams} from '@otmodel/list-params.model';
import {DataStateChangeEvent} from '@progress/kendo-angular-grid';
import {process} from '@progress/kendo-data-query';
import {UserService} from '@security/service/user.service';
import {CustomDialogComponent} from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import {GatheringStatusService} from '@warehouse/service/gathering-status.service';
import {OTPrintingService} from '@otservice/printing.service';
import {PrintPalletComponent} from '@warehouse/screen/gathering/gathering/print-pallet/print-pallet.component';
import {GatheringPalletService} from '@warehouse/service/gathering-pallet.service';
import {GatheringPallet} from '@warehouse/model/gathering-pallet.model';
import {Router} from '@angular/router';
import { GatheringGridEntryComponent } from './gathering-grid-entry/gathering-grid-entry.component';
import {finalize} from 'rxjs/operators';

export enum ProductGatheringGroup { Heavy = 1, Light = 2 }

@Component({
  selector: 'ot-gathering',
  templateUrl: './gathering.component.html',
  styleUrls: ['./gathering.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class GatheringComponent extends OTScreenBase implements OnInit, OnDestroy {
  @ViewChild(GatheringTabletViewComponent, {static: false}) tabletViewComponent: GatheringTabletViewComponent;
  @ViewChild(GatheringGridEntryComponent, {static: false}) gridEntryComponent: GatheringGridEntryComponent;
  @ViewChild('getConsent', {static: true}) getConsent: CustomDialogComponent;
  @ViewChild('printPalletDialog', {static: true}) printPalletDialog: CustomDialogComponent;
  @ViewChild('palletPrintContent', {static: true}) palletPrintContent: ElementRef;

  listParams: ListParams = new ListParams();
  activeGatheringList: any;
  selectedType: ProductGatheringGroup;
  selectedStatus = 1;

  intervalHolder: any;
  gatheringDetailUpdateSubscription: Subscription = new Subscription();
  gatheringCompletedSubscription: Subscription = new Subscription();

  lightButtonCaption = this.translateService.instant('Gather Light Product');
  heavyButtonCaption = this.translateService.instant('Gather Heavy Product');
  completeButtonCaption = this.translateService.instant('Complete');
  consentMessage: string;
  printingGathering: Gathering;
  palletArray: GatheringPallet[] = [];
  printPalletArray: GatheringPallet[] = [];
  printPalletDialogTitle = '';
  completeUrl = '';
  // shortUrl = '';

  deviceInfo = null;
  isMobile = false;

  // ilave değişkenler 
  listEntryFlag = false;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public gatheringService: GatheringService,
    public gatheringDetailService: GatheringDetailService,
    public gatheringTypeService: GatheringTypeService,
    public gatheringStatusService: GatheringStatusService,
    public gatheringPalletService: GatheringPalletService,
    public userService: UserService,
    public utilityService: OverstoreCommonMethods,
    private changeDetectorRef: ChangeDetectorRef,
    private printingService: OTPrintingService,
    // public router: Router,
    private deviceService: DeviceDetectorService) {
      super(messageService, translateService);
      this.deviceInfo = this.deviceService.getDeviceInfo();
      this.isMobile = this.deviceService.isMobile();
      // const isTablet = this.deviceService.isTablet();
      // const isDesktopDevice = this.deviceService.isDesktop();
   }

  ngOnInit() {
    // this.updateStatsForOperatingUsers();
    // this.intervalHolder = setInterval(() => {
    //   if (!this.gatheringService.processingGathering) { this.updateStats(); }
    // }, 60000);

    // this.listParams.take = 8;

    this.gatheringDetailUpdateSubscription = this.gatheringDetailService.onUpdate.subscribe(result => this.countProceedPercentage());
    this.gatheringCompletedSubscription = this.gatheringService.onGatheringDone.subscribe(() => {
      this.clearGatheringData();
      // this.updateStatsForOperatingUsers();
      if (this.tabletViewComponent && this.tabletViewComponent.isPreviewDialogOpen) {
        this.tabletViewComponent.previewDialog.hide();
      }
      this.listActiveGatherings();
    });

    if (!this.gatheringTypeService.completeList) {
      this.gatheringTypeService.listAll();
    }

    if (!this.gatheringStatusService.completeList) {
      this.gatheringStatusService.listAll();
    }

    if (!this.userService.completeList) {
      this.userService.listAll();
    }

    this.completeUrl = window.location.href;
    // this.shortUrl = this.router.url;
  }

  ngOnDestroy() {
    if (this.gatheringDetailUpdateSubscription) {
      this.gatheringDetailUpdateSubscription.unsubscribe();
    }
    if (this.gatheringCompletedSubscription) {
      this.gatheringCompletedSubscription.unsubscribe();
    }
    // if (this.intervalHolder) {
    //   clearInterval(this.intervalHolder);
    // }
    this.clearGatheringData();
  }

  handleDataStateChange(state: DataStateChangeEvent) {
    this.listParams.skip = state.skip;
    this.listParams.take = state.take;
    if (state.sort) {
      this.listParams.sort = state.sort;
    }
    if (state.filter) {
      this.listParams.filter = state.filter;
    }
    if (state.group) {
      this.listParams.group = state.group;
    }
    this.activeGatheringList = process(this.gatheringService.activeGatherings, this.listParams);
  }

  // updateStatsForOperatingUsers() {
  //   this.updateStats('forOperators');
  // }

  // updateStats(purpose: string = 'forReporting') {
  //   this.gatheringService.getGatheringPoolStats(purpose).subscribe(
  //     result => {
  //       this.lightButtonCaption = this.translateService.instant('Gather Light Product') + ' (' + (this.gatheringService.poolStats.WaitingLightCount + this.gatheringService.poolStats.ProcessingLightCount) + ')';
  //       if (this.gatheringService.poolStats.OnHoldLightCount) { this.lightButtonCaption += ' (' + this.gatheringService.poolStats.OnHoldLightCount + ')'; }
  //
  //       this.heavyButtonCaption = this.translateService.instant('Gather Heavy Product') + ' (' + (this.gatheringService.poolStats.WaitingHeavyCount + this.gatheringService.poolStats.ProcessingHeavyCount) + ')';
  //       if (this.gatheringService.poolStats.OnHoldHeavyCount) { this.heavyButtonCaption += ' (' + this.gatheringService.poolStats.OnHoldHeavyCount + ')'; }
  //     }, error => this.messageService.warning(this.translateService.instant('Gathering Stats can not be retrieved') + '!')
  //   );
  // }

  clearGatheringData() {
    this.gatheringService.processingGathering = null;
    this.gatheringService.gatheringForConsentDialog = null;
    this.gatheringDetailService.gatheringDetailList = [];
    this.gatheringDetailService.gatheringDetailActiveList = null;
  }

  onAbort() {
    this.gatheringService.abortGathering().subscribe(
      result => { this.gatheringService.onGatheringDone.next(null); },
      error => { this.messageService.error(this.translateService.instant('Could not be suspendend')); }
    );
  }

  onComplete() {
    if (this.tabletViewComponent && !this.tabletViewComponent.isPreviewDialogOpen) {
      this.tabletViewComponent.isPreviewDialogOpen = true;
      this.tabletViewComponent.previewDialog.show();
    }
  }

  onGridComplete() {
    this.gatheringService.completeGathering().subscribe(
        result => { this.gatheringService.onGatheringDone.next(null);
        },
        error => { this.messageService.error(this.translateService.instant('Could not be complete')); }
    );
  }

  getCompleteBtnColor() {
    return this.gatheringService.gatheredProductsPercentage === 100 ? 'success' : 'primary';
  }

  countProceedPercentage() {
    const gatherredCnt = this.gatheringDetailService.gatheringDetailList.filter(gd => gd.Proceed).length;
    const totalCnt = this.gatheringDetailService.gatheringDetailList.length ;
    this.gatheringService.gatheredProductsPercentage = 100 * gatherredCnt / totalCnt;
    if (this.gatheringService.gatheredProductsPercentage === 100) {
      this.completeButtonCaption = this.translateService.instant('Complete') + ' (' + gatherredCnt + '/' + totalCnt + ')';
    } else {
      this.completeButtonCaption = this.translateService.instant('Preview') + ' (' + gatherredCnt + '/' + totalCnt + ')';
    }
  }

  startGathering(gathering: Gathering) {
    this.clearGatheringData();
    this.gatheringService.startGathering(gathering.GatheringId, 'N').subscribe(resultStartGathering => {
      this.gatheringService.gatheringForConsentDialog = gathering;
      if (resultStartGathering === 1) {
        this.messageService.warning('Bu sipariş sevk edilmiş, toplama yapamazsınız.');
        this.clearGatheringData();
      } else if (resultStartGathering === 2) {
        this.consentMessage = `Bu sipariş şu an ${gathering.GatheringUserName} tarafından kontrol ediliyor. Üzerinize almak istiyor musunuz?`;
        this.getConsent.caption = 'Toplanıyor';
        this.getConsent.show();
      } else if (resultStartGathering === 3) {
        this.consentMessage = `Bu sipariş ${gathering.GatheringUserName} tarafından toplanmış. Tekrar mı kontrol etmek istiyorsunuz?`;
        this.getConsent.caption = 'Toplama tamamlanmış';
        this.getConsent.show();
      } else if (resultStartGathering === 4) {
        this.messageService.warning('Bu siparişe ilişkin paletlerde kontrol işlemi başlamış olanlar bulunmaktadır, toplama yapamazsınız.');
        this.clearGatheringData();
      } else {
        this.gatheringService.read(gathering.GatheringId).subscribe(resultRead => {
          this.gatheringService.processingGathering = resultRead;
          this.gatheringDetailService.listGatheringDetail(this.gatheringService.processingGathering.GatheringId).subscribe(
              list => this.countProceedPercentage(),
              error => {
                this.messageService.error(this.translateService.instant('An error occurred, can not retrieve GatheringDetails'));
                this.clearGatheringData();
              });
        });
      }
    });
  }

  listActiveGatherings() {
    if (this.selectedType) {
        this.gatheringService.listActiveGatherings(this.selectedType, this.selectedStatus).subscribe(list => {
        this.gatheringService.activeGatherings = list;
        this.activeGatheringList = process(this.gatheringService.activeGatherings, this.listParams);
      }, error => this.messageService.error(this.translateService.instant('An error occurred, can not retrieve GatheringList')));
    }
  }

  onProductGroupTypeChange(checked: boolean, type: ProductGatheringGroup) {
    if (checked) {
      this.selectedType = type;
      this.listActiveGatherings();
    }
  }

  onStatusChanged(checked: boolean, status: number) {
    if (checked) {
      this.selectedStatus = status;
      this.listActiveGatherings();
    }
  }

  onCancelConsert() {
    this.getConsent.hide();
    this.clearGatheringData();
    this.listActiveGatherings();
  }

  onConsent() {
    this.gatheringService.startGathering(this.gatheringService.gatheringForConsentDialog.GatheringId, 'Y').subscribe(resultStartGather => {
      this.gatheringService.read(this.gatheringService.gatheringForConsentDialog.GatheringId).subscribe(resultRead => {
        this.gatheringService.processingGathering = resultRead;
        this.gatheringDetailService.listGatheringDetail(this.gatheringService.processingGathering.GatheringId).subscribe(resultListGatheringDetail => {
          this.getConsent.hide();
        });
      });
    });
  }

  showPrintPalletDialog(gathering: Gathering) {
    this.printingGathering = gathering;
    this.printPalletDialogTitle = gathering.StoreOrderName + ' ' + this.translateService.instant('Print Pallet');
    this.gatheringPalletService.listPalletByGatheringId(gathering.GatheringId).subscribe(
        list => {
          this.palletArray = list;
          this.printPalletDialog.show();
        }, error => {
          this.messageService.error(this.translateService.instant('Pallet info can not be retrieved') + '!');
    });
  }

  onCancelPrint() {
    this.clearPrintPalletVariables();
    this.printPalletDialog.hide();
  }

  printPallet(palletToPrint?: GatheringPallet) {
    if (palletToPrint) {
      this.printPalletArray.push(palletToPrint);
    } else {
      this.printPalletArray = this.palletArray;
    }
    const styles = `
      <style type="text/css" media="screen, print">
          @page {
             margin: 2mm 2mm 2mm 2mm;
             height: 75mm;
             width: 105mm;
          }
          @media print {
              body {-webkit-print-color-adjust: exact;}
          }
          table {
              height: 71mm;
              width: 101mm;
              /*border-top: 1mm solid darkorange;
              border-left: 1mm solid darkorange;
              border-spacing: 0;*/
              text-align: center;
          }
          .row-header {
              height: 10%;
              font-size: 20px;
              /*background-color: darkred;
              color: white;*/
          }
          .row-content {
              height: 35%;
              font-size: 30px;
          }
          /*table tr.row-header > td {
              border-right: 1mm solid darkorange;
              border-spacing: 0;
          }
          table tr.row-content > td {
              border-bottom: 1mm solid darkorange;
              border-right: 1mm solid darkorange;
              border-spacing: 0;
          }*/
       </style>
    `;
    setTimeout(() => {
      this.printingService.print(this.palletPrintContent.nativeElement.innerHTML, styles, 800, 566);
      this.printPalletDialog.hide();
      this.clearPrintPalletVariables();
    }, 500);
    // setTimeout(() => this.clearPrintPalletVariables(), 3000);
  }

  clearPrintPalletVariables() {
    this.gatheringDetailService.activeGatheringDetail = null;
    this.printingGathering = null;
    this.printPalletArray = [];
    this.palletArray = [];
  }

  /* region ilave taylan 2020-01-23*/
  onListEntryButtonChange() {
    this.listEntryFlag = !this.listEntryFlag;
    this.countProceedPercentage();
  }
  /* region ilave son */
}
