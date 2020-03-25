import { Component, OnInit, ViewChild, OnDestroy, AfterViewInit } from '@angular/core';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { DomSanitizer } from '@angular/platform-browser';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { ZetImageComponent, PhotoStatus } from '../zet-image/zet-image.component';
import { Subscription, Subject } from 'rxjs';
import { ZetImage } from '@reconciliation/model/reconciliation.model';

@Component({
  selector: 'ot-zet-image-view',
  templateUrl: './zet-image-view.component.html',
  styleUrls: ['./zet-image-view.component.css']
})
export class ZetImageViewComponent extends MainScreenBase implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  @ViewChild(ZetImageComponent, {static: false}) camera: ZetImageComponent;

  photoUploadedSubscription: Subscription;
  reconciliationId: number;
  zetPhotos = [];
  zetImageLoading = false;

  constructor(
      messageService: GrowlMessageService,
      translateService: TranslateService,
      public reconciliationService: ReconciliationService,
      public utility: OTUtilityService) {
      super(messageService, translateService);
  }

  createEmptyItem() {
    return null;
    // throw new Error('Method not suported.');
  }

  getBreadcrumbItems() {
    return null;
    // return [{Caption: 'ZetImageView' }, {Caption: 'ZetImageView', RouterLink: '/reconciliation/ZetImageView'}];
  }

  refreshData() {
    this.zetImageLoading = true;
    this.reconciliationService.listZetImages(this.reconciliationId).subscribe( zetImages => {
      this.zetPhotos = zetImages.sort((a, b) => a.CreateDate > b.CreateDate ? -1 : a.CreateDate > b.CreateDate ? 1 : 0);
      this.zetImageLoading = false;
    });
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.photoUploadedSubscription = this.camera.onPhotoUploaded.subscribe(
      photo => {
        console.log('photoUploadSubscribe: ', photo);
        this.refreshData();
    });
  }

  ngOnDestroy(): void {
    if (this.photoUploadedSubscription) {
      this.photoUploadedSubscription.unsubscribe();
    }
  }

  onDialogClose(event) {
    if (this.camera.cameraStatus === PhotoStatus.CamOpen) {
      this.camera.closeCamera();
    }
    this.camera.cameraStatus = PhotoStatus.StandBy;
  }

  deletePhoto(zetImage: ZetImage) {
    this.reconciliationService.deleteZetImage(zetImage).subscribe( result => {
      if (result) {
        this.messageService.success(this.translateService.instant(`Image deleted saved`));
        this.refreshData();
      } else {
        this.messageService.error(this.translateService.instant(`Deletion process failed`));
      }
    });
  }
}
