import { Component, OnInit, OnDestroy, ViewEncapsulation, ViewChild, AfterViewInit } from '@angular/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { GatheringService } from '@warehouse/service/gathering.service';
import { GatheringDetailService } from '@warehouse/service/gathering-detail.service';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { OTScreenBase } from '@otscreen-base/ot-screen-base';
import { GatheringPalletService } from '@warehouse/service/gathering-pallet.service';
import { GatheringPallet } from '@warehouse/model/gathering-pallet.model';
import { GatheringTypeService } from '@warehouse/service/gathering-type.service';
import { ListParams } from '@otmodel/list-params.model';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid/dist/es2015/main';
import { process } from '@progress/kendo-data-query';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import {GatheringPalletPhotoService} from '@warehouse/service/gathering-pallet-photo.service';
import {PalletPhotoComponent} from '@warehouse/screen/gathering/gathering-control/pallet-photo/pallet-photo.component';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, BehaviorSubject } from 'rxjs';
import { BarecodeScannerLivestreamComponent } from 'ngx-barcode-scanner';
import { ZXingScannerComponent } from '@zxing/ngx-scanner';
import { BarcodeFormat } from '@zxing/library';
import {ControlGridEntryComponent} from '@warehouse/screen/gathering/gathering-control/control-grid-entry/control-grid-entry.component';
import { UserService } from '@frame/security/service/user.service';
import { GetNamePipe } from '@otcommon/pipe/get-name.pipe';

@Component({
  selector: 'ot-gathering-control',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './gathering-control.component.html',
  styleUrls: ['./gathering-control.component.css']
})
export class GatheringControlComponent extends OTScreenBase implements OnInit, OnDestroy, AfterViewInit {

  @ViewChild('getConsent', {static: true}) getConsent: CustomDialogComponent;
  @ViewChild('palletPhotoDialog', {static: true}) palletPhotoDialog: PalletPhotoComponent;
  @ViewChild('barecodeScanner', {static: false}) barecodeScanner: ZXingScannerComponent;
  @ViewChild('controlGridEntry', {static: true}) controlGridEntry: ControlGridEntryComponent;

  intervalHolder: any;
  lightButtonCaption = this.translateService.instant('Control Light Product');
  heavyButtonCaption = this.translateService.instant('Control Heavy Product');
  completeButtonCaption = this.translateService.instant('Complete');
  controlCompleteList: any;
  controlList: any;
  controlActiveList: any;
  listParams: ListParams = new ListParams();

  screenNo = 1;
  selectedGatheringType: number;
  selectedStatus = 1;
  consentMessage: string;
  controlPalletId: any;
  isCameraOpen: boolean;
  qrResultString: string;

  availableDevices: MediaDeviceInfo[];
  hasDevices: boolean;
  currentDevice: MediaDeviceInfo = null;
  formatsEnabled: BarcodeFormat[] = [
    BarcodeFormat.CODE_128,
    BarcodeFormat.DATA_MATRIX,
    BarcodeFormat.EAN_13,
    BarcodeFormat.QR_CODE,
  ];
  torchEnabled = false;
  torchAvailable$ = new BehaviorSubject<boolean>(false);
  tryHarder = false;
  hasPermission: boolean;

  clearResult(): void {
    this.qrResultString = null;
  }

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public gatheringService: GatheringService,
    public gatheringTypeService: GatheringTypeService,
    public gatheringPalletService: GatheringPalletService,
    public gatheringDetailService: GatheringDetailService,
    public route: ActivatedRoute,
    public router: Router,
    public userService: UserService,
    public gatheringPalletPhotoService: GatheringPalletPhotoService,
    public utilityService: OverstoreCommonMethods,
    public getNamePipe: GetNamePipe,
    ) {
      super(messageService, translateService);
   }

  refreshActiveControlList(cb) {
    this.gatheringPalletService.ActiveControlPallets().subscribe(result => {
      this.controlCompleteList = result;
      cb();
    });
  }

  onCamerasFound(devices: MediaDeviceInfo[]): void {
    this.availableDevices = devices;
    // console.log(this.availableDevices);
    this.hasDevices = Boolean(devices && devices.length);
    this.currentDevice = this.availableDevices[0];
  }

  onCodeResult(resultString: string) {
    // console.log(resultString);
    this.qrResultString = resultString;
    this.isCameraOpen = false;
    const l = this.qrResultString.split('/');
    this.router.navigate(['/Warehouse/GatheringControl', l[l.length-1]]);
  }

  onDeviceSelectChange(selected: string) {
    // console.log(selected);
    const device = this.availableDevices.find(x => x.deviceId === selected);
    this.currentDevice = device || null;
  }

  onHasPermission(has: boolean) {
    this.hasPermission = has;
  }

  onTorchCompatible(isCompatible: boolean): void {
    this.torchAvailable$.next(isCompatible || false);
  }

  toggleTorch(): void {
    this.torchEnabled = !this.torchEnabled;
  }

  toggleTryHarder(): void {
    this.tryHarder = !this.tryHarder;
  }

  ngOnInit() {
    // this.listParams.take = 8;
    this.controlPalletId = this.route.snapshot.params['controlPalletId'];
    if (this.controlPalletId) {
      this.gatheringPalletService.read(this.controlPalletId).subscribe(result => {
        // console.log(result, this.controlPalletId);
        if (result && result.GatheringPalletId.toString() === this.controlPalletId.toString()) {
          this.onStartControlClick(result) ;
        }
      });
    }

    if (!this.gatheringTypeService.completeList) {
      this.gatheringTypeService.listAll();
    }

    if (!this.userService.completeList) {
      this.userService.listAll();
    }
  }

  ngAfterViewInit() {
  }

  onTypeChanged(checked, gatheringType) {
    if (checked) {
      this.selectedGatheringType = gatheringType; // gatheringType.GatheringTypeId;
      this.refreshActiveControlList(() => {
        this.filterControlList();
      });
    }
  }

  onCameraChanged() {
    this.isCameraOpen = !this.isCameraOpen;
  }

  onStatusChanged(checked, stat) {
    if (checked) {
      this.selectedStatus = stat;
      this.refreshActiveControlList(() => {
        this.filterControlList();
      });
    }
  }

  filterControlList() {
    if (this.selectedGatheringType > 0) {
      this.controlList = this.controlCompleteList.filter(row => (row.GatheringTypeId === this.selectedGatheringType && row.GatheringPalletStatus ===  this.selectedStatus));
      this.controlActiveList = process(this.controlList, this.listParams);
    }
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
    this.controlActiveList = process(this.controlList, this.listParams);
  }

  ngOnDestroy() {
  }

  clearControllingPalletData() {
    this.gatheringPalletService.activePallet = null;
    this.gatheringService.processingGatheringControl = null;
    this.gatheringDetailService.controlDetailList = [];
    this.gatheringDetailService.controlDetailActiveList = null;
  }

  onStartControlClick(dataItem: GatheringPallet) {
    this.gatheringPalletService.StartControl(dataItem.GatheringPalletId, 'N').subscribe(resultStartControl => {
      this.gatheringPalletService.activePallet = dataItem;
      if (resultStartControl === 1) {
        this.messageService.warning('Bu sipariş sevk edilmiş, kontrolünü yapamazsınız.');
        this.clearControllingPalletData();
      } else if (resultStartControl === 2) {
        this.consentMessage = `Bu sipariş şu an ${this.getNamePipe.transform(dataItem.ControlUser, 'UserId', 'UserFullName', this.userService.completeList)} tarafından kontrol ediliyor. Üzerinize almak istiyor musunuz?`;
        this.getConsent.caption = 'Kontrol ediliyor';
        this.getConsent.show();
      } else if (resultStartControl === 3) {
        this.consentMessage = `Bu sipariş ${this.getNamePipe.transform(dataItem.ControlUser, 'UserId', 'UserFullName', this.userService.completeList) } tarafından kontrol edilmiş. Tekrar mı kontrol etmek istiyorsunuz?`;
        this.getConsent.caption = 'Kontrol tamamlanmış';
        this.getConsent.show();
      } else {
        this.gatheringService.read(dataItem.Gathering).subscribe(resultRead => {
          this.gatheringService.processingGatheringControl = resultRead;
          this.gatheringDetailService.listControlDetail(dataItem.Gathering, dataItem.PalletNo).subscribe(() => {
              this.gatheringDetailService.prepareAddableControlDetailList(dataItem.Gathering, dataItem.PalletNo);
            this.screenNo = 2;
          });
        });
      }
    });
  }

  onConsent() {
    this.gatheringPalletService.StartControl(this.gatheringPalletService.activePallet.GatheringPalletId, 'Y').subscribe(resultStartControl => {
      this.gatheringService.read(this.gatheringPalletService.activePallet.Gathering).subscribe(resultRead => {
        this.gatheringService.processingGatheringControl = resultRead;
        this.gatheringDetailService.listControlDetail(this.gatheringPalletService.activePallet.Gathering, this.gatheringPalletService.activePallet.PalletNo).subscribe(resultListControlDetail => {
          this.screenNo = 2;
          this.getConsent.hide();
        });
      });
    });
  }

  onCancelConsert() {
    this.getConsent.hide();
    this.clearControllingPalletData();
  }

  onAbort() {
    this.gatheringPalletService.activePallet.GatheringPalletStatus = 1; // beklemede
    this.gatheringPalletService.activePallet.ControlUser = null;
    this.gatheringPalletService.activePallet.Control = null;
    this.gatheringPalletService.update(this.gatheringPalletService.activePallet).subscribe(result => {
      this.messageService.warning('Kontrol işlemi iptal edildi.');
      this.refreshActiveControlList(() => {
        this.filterControlList();
      });
      setTimeout(() => {
        this.clearControllingPalletData();
        this.screenNo = 1;
      }, 500);
    },
    error => { this.messageService.error(this.translateService.instant('Could not be suspended')); });
  }

  onComplete() {
    const unCheckedCnt = this.gatheringDetailService.controlDetailList.map(gd => gd.Proceed).filter(p => !p).length;
    if (unCheckedCnt === 0) {
      this.gatheringPalletService.activePallet.GatheringPalletStatus = 9; // tamamlandı
      this.gatheringPalletService.activePallet.ControlEndTime = this.utilityService.addHours(new Date(), 3);
      this.gatheringPalletService.update(this.gatheringPalletService.activePallet).subscribe(result => {
        this.messageService.success('Kontrol işlemi tamamlandı.');
        this.refreshActiveControlList(() => {
          this.filterControlList();
        });
        setTimeout(() => {
          this.clearControllingPalletData();
          this.screenNo = 1;
        }, 500);
      },
      error => { this.messageService.error(this.translateService.instant('Could not be suspended')); });
    } else {
      this.messageService.error(this.translateService.instant(`There are ${unCheckedCnt} records which have not been checked`) + '!');
    }
  }

  showPalletPhotoDialog(dataItem: GatheringPallet) {
    this.palletPhotoDialog.onShow.next(dataItem);
    this.palletPhotoDialog.dialog.show();
  }

}
