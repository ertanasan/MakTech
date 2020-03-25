import { Component, OnInit, ElementRef, ViewChild, Input, AfterViewInit } from '@angular/core';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { ZetImage } from '@reconciliation/model/reconciliation.model';
import { Subject } from 'rxjs';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { ListParams } from '@otmodel/list-params.model';

export enum PhotoStatus { CamOpen = 1, Taken, StandBy }

@Component({
  selector: 'ot-zet-image',
  templateUrl: './zet-image.component.html',
  styleUrls: ['./zet-image.component.css']
})
export class ZetImageComponent extends MainScreenBase implements OnInit {

  @ViewChild('video', {static: true}) video: ElementRef;
  @ViewChild('canvas', {static: true}) canvas: ElementRef;
  // @ViewChild('dummyParagraphContainer') dummyParagraphContainer: ElementRef;
  photoArea = {'width': 300, 'height': 400, 'widthHeightRatio': 0.75 };
  zetPhoto: any;
  cameraStatus = PhotoStatus.StandBy;
  @Input() reconciliationId = 1;
  selectedCashRegisterId;
  onPhotoUploaded: Subject<any> = new Subject();

  constructor(
      messageService: GrowlMessageService,
      translateService: TranslateService,
      public reconciliationService: ReconciliationService,
      public cashRegisterService: StoreCashRegisterService) {
      super(messageService, translateService);
  }

  createEmptyItem() {}

  getBreadcrumbItems() {
    return [{Caption: 'ZetImage' }, {Caption: 'ZetImage', RouterLink: '/reconciliation/ZetImage'}];
  }

  refreshData() {}

  ngOnInit() {
    // window.addEventListener('orientationchange', this.setPhotArea, false);
    // window.addEventListener('resize', this.setPhotArea, false);
  }

  listCashRegisters(storeId) {
    const crLP = new ListParams();
    crLP.filter.filters.push( {field: 'Store', operator: 'eq', value: storeId} );
    this.cashRegisterService.list(crLP);
  }

  // setPhotoArea() {
  //   console.log('width', document.getElementById('dummyParagraphContainer').clientWidth);
  //   // this.zetImageViewScreen.camera.setPhotoArea(document.getElementById('dummyParagrah').clientWidth);
  //   this.photoArea.width = document.getElementById('dummyParagraphContainer').clientWidth;
  //   this.photoArea.height = this.photoArea.width / this.photoArea.widthHeightRatio;
  // }

  openCamera() {

    // const browser = <any>navigator;
    // browser.getUserMedia = (browser.getUserMedia ||
    //   browser.webkitGetUserMedia ||
    //   browser.mozGetUserMedia ||
    //   browser.msGetUserMedia);

    // this.setPhotoArea();

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
        this.cameraStatus = PhotoStatus.CamOpen;

      })
      .catch(err => {
        this.messageService.error(this.translateService.instant('Camera access failure'));
      });
    }
  }

  closeCamera() {
    this.video.nativeElement.srcObject.getTracks()[0].stop();
  }

  capture() {
    this.canvas.nativeElement.getContext('2d').drawImage(this.video.nativeElement, 0, 0);
    this.cameraStatus = PhotoStatus.Taken;
    this.zetPhoto = this.canvas.nativeElement.toDataURL('image/png');
    this.closeCamera();
  }

  uploadPhoto() {
    const zetImage = new ZetImage();
    zetImage.Photo = this.zetPhoto;
    zetImage.Reconciliation = this.reconciliationId;
    zetImage.CashRegister = this.selectedCashRegisterId;
    this.reconciliationService.uploadZetImage(zetImage).subscribe( result => {
      if (result) {
        this.messageService.success(this.translateService.instant(`Image successfully saved`));
        this.onPhotoUploaded.next(this.zetPhoto);
        this.cameraStatus = PhotoStatus.StandBy;
      } else {
        this.messageService.error(this.translateService.instant(`Saving process failed`));
      }
    });
  }
}
