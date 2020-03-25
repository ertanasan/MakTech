import {Component, ElementRef, Input, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {CustomDialogComponent} from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import {GatheringPalletPhotoService} from '@warehouse/service/gathering-pallet-photo.service';
import {GatheringPalletPhoto} from '@warehouse/model/gathering-pallet-photo.model';
import {OTUtilityService} from '@otcommon/service/utility.service';
import {GatheringPallet} from '@warehouse/model/gathering-pallet.model';
import {GatheringService} from '@warehouse/service/gathering.service';
import {UserService} from '@security/service/user.service';
import {MainScreenBase} from '@otscreen-base/main-screen-base';
import {MenuItem} from '@otuicontrol/menu/menuitem';
import {GrowlMessageService} from '@otservice/growl-message.service';
import {TranslateService} from '@ngx-translate/core';
import {Subject, Subscription} from 'rxjs';
import {StoreOrder} from '@warehouse/model/store-order.model';
import {saveAs} from '@progress/kendo-file-saver';
import {OverstoreCommonMethods} from '../../../../../../util/common-methods.service';

enum CameraStatus { CamOpen = 1, Taken, StandBy }

@Component({
  selector: 'ot-pallet-photo',
  templateUrl: './pallet-photo.component.html',
  styleUrls: ['./pallet-photo.component.scss']
})
export class PalletPhotoComponent extends MainScreenBase implements OnInit, OnDestroy {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  @ViewChild('video', {static: false}) video: ElementRef;
  @ViewChild('canvas', {static: false}) canvas: ElementRef;

  @Input() calledFrom: string;  // GATHERINGCONTROL or STOREORDER
  @Input() gatheringPallet: GatheringPallet;
  showExistingPhotos = false;
  storeOrder: number;

  onShow = new Subject<GatheringPallet | StoreOrder>();
  unsubscribe = [];

  palletPhotoList: GatheringPalletPhoto[] = [];
  palletPhoto: GatheringPalletPhoto;
  photoIndex = 0;
  capturedPhoto: any;
  cameraStatus: CameraStatus = CameraStatus.StandBy;
  photoArea = {'width': 600, 'height': 450, 'widthHeightRatio': 1.33 };

  compressQualityLevel = 0.6;
  qualitySelectionButtons = [ { text: 'low',    value: 0.6 },
                              { text: 'medium', value: 0.8 },
                              { text: 'high',   value: 1.0 }];

  constructor(messageService: GrowlMessageService,
              translateService: TranslateService,
              public gatheringPalletPhotoService: GatheringPalletPhotoService,
              public gatheringService: GatheringService,
              public userService: UserService,
              public utility: OTUtilityService,
              public commonMethods: OverstoreCommonMethods) {
    super(messageService, translateService);
  }

  ngOnInit() {
    if (!this.userService.completeList) {
      this.userService.listAll();
    }

    this.unsubscribe.push(this.onShow.subscribe(model => {
      if (this.calledFrom === 'GATHERINGCONTROL') {
        this.gatheringPallet = <GatheringPallet>model;
        this.gatheringService.read(this.gatheringPallet.Gathering).subscribe(g => {
          this.dialog.caption = g.StoreOrderName + ' ' + this.translateService.instant('Photo List');
          this.storeOrder = g.StoreOrder;
        });
      } else if (this.calledFrom === 'STOREORDER') {
        this.dialog.caption = (<StoreOrder>model).OrderCode + ' ' + this.translateService.instant('Photo List');
        this.storeOrder = (<StoreOrder>model).StoreOrderId;
      }
    }));
  }

  ngOnDestroy() {
    if (this.cameraStatus === CameraStatus.CamOpen) {
      this.closeCamera();
    }

    this.unsubscribe.forEach(s => s.unsubscribe());
  }

  createEmptyItem(): any {
  }

  getBreadcrumbItems(): MenuItem[] {
    return [];
  }

  refreshData() {
    if (this.storeOrder) {
      this.gatheringPalletPhotoService.listPalletPhoto(this.storeOrder, this.gatheringPallet ? this.gatheringPallet.GatheringPalletId : null).subscribe( photos => {
        this.palletPhotoList = photos.sort((a, b) => a.CreateDate > b.CreateDate ? -1 : a.CreateDate < b.CreateDate ? 1 : 0);
      });
    }
  }

  getPhotoByIndex(increment: number = 0) {
    if (this.storeOrder) {
        this.photoIndex += increment;
        this.gatheringPalletPhotoService.getPhotoByIndex(this.storeOrder, this.photoIndex, this.gatheringPallet ? this.gatheringPallet.GatheringPalletId : null).subscribe(
            result => this.palletPhoto = result
        );
    }
  }

  onDialogClose(event) {
    if (this.cameraStatus === CameraStatus.CamOpen) {
      this.closeCamera();
    }
    this.cameraStatus = CameraStatus.StandBy;
    this.storeOrder = null;
    this.gatheringPallet = null;

    this.showExistingPhotos = false;
    this.palletPhoto = null;
    this.photoIndex = 0;
  }

  openCamera() {
    const videoConfig = {
      constraints : {
        width: this.photoArea.width,
        height: this.photoArea.height,
        // aspectRatio: { min: this.photoArea.widthHeightRatio, max: this.photoArea.widthHeightRatio },
        facingMode: 'environment',
      }
    };

    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
      // navigator.mediaDevices.getUserMedia({ video: true }).then(stream => {
      navigator.mediaDevices.getUserMedia({ video: videoConfig.constraints })
          .then(stream => {
            this.video.nativeElement.srcObject = stream;
            this.video.nativeElement.play();
            this.cameraStatus = CameraStatus.CamOpen;

          })
          .catch(err => {
            console.log('err: ', err);
            this.messageService.error(this.translateService.instant('Camera access failure'));
          });
    }
  }

  closeCamera() {
    this.video.nativeElement.srcObject.getTracks()[0].stop();
  }

  capture() {
    this.canvas.nativeElement.getContext('2d').drawImage(this.video.nativeElement,
                                                                0,
                                                                0,
                                                                this.photoArea.width,
                                                                this.photoArea.height);
    this.cameraStatus = CameraStatus.Taken;
    this.capturedPhoto = this.canvas.nativeElement.toDataURL('image/jpeg', this.compressQualityLevel);
    // console.log('this.capturedPhotoSize: ', this.commonMethods.dataURLtoBlob(this.capturedPhoto, 'jpeg').size);
    this.closeCamera();
  }

  uploadPhoto() {
    const gatheringPalletPhoto = new GatheringPalletPhoto();
    gatheringPalletPhoto.PhotoContent = this.capturedPhoto;
    gatheringPalletPhoto.GatheringPallet = this.gatheringPallet.GatheringPalletId;
    this.gatheringPalletPhotoService.uploadPhoto(gatheringPalletPhoto).subscribe( result => {
      if (result) {
        this.messageService.success(this.translateService.instant(`Image successfully saved`));
        this.cameraStatus = CameraStatus.StandBy;
        this.getPhotoByIndex(1);
      } else {
        this.messageService.error(this.translateService.instant(`Saving process failed`));
      }
    });
  }

  deletePhoto(palletPhoto: GatheringPalletPhoto) {
    this.gatheringPalletPhotoService.deletePhoto(palletPhoto.GatheringPalletPhotoId).subscribe( result => {
      if (result) {
        this.messageService.success(this.translateService.instant(`Image deleted`));
        this.getPhotoByIndex(-1);
      } else {
        this.messageService.error(this.translateService.instant(`Deletion process failed`));
      }
    });
  }

  downloadPhoto(palletPhoto: GatheringPalletPhoto) {
    try {
      saveAs(palletPhoto.PhotoContent, this.storeOrder + '_' + palletPhoto.GatheringTypeName + '_pallet' + palletPhoto.PalletNo + '.jpg');
      this.messageService.success(this.translateService.instant('Download Success'));
    } catch {
      this.messageService.error(this.translateService.instant('Download Failed'));
    }
  }

    onShowPhotoBtnClicked() {
        this.showExistingPhotos = !this.showExistingPhotos;
        if (this.showExistingPhotos) {
            this.getPhotoByIndex(0);
        }
    }
}
