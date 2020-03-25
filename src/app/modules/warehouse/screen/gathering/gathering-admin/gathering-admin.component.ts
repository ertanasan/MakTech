import {Component, OnInit, ViewChild, AfterViewInit, ElementRef} from '@angular/core';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { GatheringService } from '@warehouse/service/gathering.service';
import { GatheringDetailService } from '@warehouse/service/gathering-detail.service';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { Gathering } from '@warehouse/model/gathering.model';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { UserService } from '@frame/security/service/user.service';
import { GatheringStatusService } from '@warehouse/service/gathering-status.service';
import { GatheringTypeService } from '@warehouse/service/gathering-type.service';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { GatheringAdminEditComponent } from './gathering-admin-edit/gathering-admin-edit.component';
import { GatheringControlList } from '@warehouse/model/gathering-control-list.model';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { ListParams } from '@otmodel/list-params.model';
import { HttpErrorResponse } from '@angular/common/http';
import {PricePackage} from '@price/model/price-package.model';
import {WaybillPrintoutComponent} from '@warehouse/screen/gathering/gathering-admin/waybill-printout/waybill-printout.component';
import {OTPrintingService} from '@otservice/printing.service';
import {OverStoreScreenPropertyService} from '@app-main/service/over-store-screen-property.service';
// import {QzTrayService} from '@app-main/service/qz-tray.service';

@Component({
  selector: 'ot-gathering-admin',
  templateUrl: './gathering-admin.component.html',
  styleUrls: ['./gathering-admin.component.css']
})
export class GatheringAdminComponent extends ListScreenBase<Gathering> implements OnInit, AfterViewInit {
  @ViewChild(GatheringAdminEditComponent, {static: true}) editScreen: GatheringAdminEditComponent;
  @ViewChild(CustomDialogComponent, {static: true}) orderGathering: CustomDialogComponent;
  @ViewChild('waybillPrintout', {static: true}) waybillPrintout: ElementRef;
  @ViewChild('waybillPrintoutContent' , {static: true}) waybillPrintoutContent: WaybillPrintoutComponent;

  shipmentStartDate: Date = new Date();
  shipmentEndDate: Date = new Date();
  gatheringControlActiveList: any;
  gatheringControlList: any;
  orderlistParams: ListParams = new ListParams();
  processStatusList = [{value: 10, text: 'Toplama Bekliyor'}, {value: 20, text: 'Toplanıyor'}, {value: 30, text: 'Kontrol Bekliyor'}, {value: 40, text: 'Kontrol Ediliyor'}, {value: 50, text: 'Kontrol Tamam'}];
  orderGatheringStatusList = [{value: 10, text: 'Toplama'}, {value: 20, text: 'Kontrol'}, {value: 30, text: 'Kontrol Tamam'}, {value: 40, text: 'Sevk Edildi'}];
  orderGatheringActiveList: any;
  orderGatheringList: any;
  selectedDataItem: GatheringControlList;
  dispatchDisable = true;
  shipmentDate: Date;

  // printout format parameters:
  productCountPerPage: number;
  pageArray = [];
  spaceBeforeHeaderArr = [];
  spaceAfterHeaderArr = [];
  headerTableColumnWidthArr = [];
  productTableColumnWidthArr = [];
  addressFieldLineLength: number;
  fontFamily = 'Arial';
  fontSize = '10px';
  printerName: string;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public gatheringService: GatheringService,
    public gatheringDetailService: GatheringDetailService,
    public utilityService: OverstoreCommonMethods,
    public gatheringStatusService: GatheringStatusService,
    public gatheringTypeService: GatheringTypeService,
    public screenPropertyService: OverStoreScreenPropertyService,
    public userService: UserService,
    public printingService: OTPrintingService,
    public datePipe: DatePipe,
    // public qzService: QzTrayService
  ) {
      super(messageService, translateService);
  }

  refreshList() {

    this.gatheringService.getGatheringControlList(this.datePipe.transform(this.shipmentDate, 'yyyy-MM-dd')).subscribe(result => {
      this.gatheringControlList = result;
      this.processData();
    },
    error => this.messageService.error(this.translateService.instant('Gathering data could not been retrieved') + '!'));
  }

  getBreadcrumbItems(): MenuItem[] {
    return [{Caption: 'Warehouse' }, {Caption: 'Gathering Admin Panel', RouterLink: '/warehouse/gathering-admin'}];
  }

  createEmptyModel(): Gathering {
    return new Gathering();
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

    this.processData();
  }

  orderHandleDataStateChange(state: DataStateChangeEvent) {
    this.orderlistParams.skip = state.skip;
    this.orderlistParams.take = state.take;

    if (state.sort) {
        this.orderlistParams.sort = state.sort;
    }
    if (state.filter) {
        this.orderlistParams.filter = state.filter;
    }
    if (state.group) {
        this.orderlistParams.group = state.group;
    }

    this.processOrderGathering();
  }

  processData() {
    this.gatheringControlActiveList = process(this.gatheringControlList, this.listParams);
  }

  processOrderGathering() {
    this.orderGatheringActiveList = process(this.orderGatheringList, this.orderlistParams);
  }

  ngOnInit() {

    const d = new Date();
    d.setDate(d.getDate() + 1);
    if (d.getDay() === 0) d.setDate(d.getDate() + 1);
    this.shipmentDate = d;

    this.userService.listAll();
    this.gatheringStatusService.listAll();
    this.gatheringTypeService.listAll();

    this.prepareWaybillPrintoutParameters();

    super.ngOnInit();
  }

  ngAfterViewInit() {
    this.editScreen.mainScreen = this;
    this.dialogs.push(this.editScreen);
  }

  transferButtonDisable(dataItem: GatheringControlList): boolean {
    return !(dataItem.Status === 3 && dataItem.PalletCount > 0 && dataItem.PalletCount === dataItem.ControlledPalletCount && dataItem.TypeCount > 0 && dataItem.TypeCount === dataItem.GatheredTypeCount);
  }

  onTransfer(dataItem: GatheringControlList) {
    this.selectedDataItem = dataItem;
    this.gatheringService.listOrderGathering(dataItem.StoreOrderId).subscribe(result => {
      this.orderGatheringList = result;
      this.processOrderGathering();
      this.orderGathering.caption = dataItem.OrderCodeName;
      this.dispatchDisable = this.transferButtonDisable(dataItem);
      this.orderGathering.show();
    });
  }

  onDispatch() {
    this.gatheringService.transferGathering(this.selectedDataItem.StoreOrderId).subscribe(result => {
      if (!result || result === 'OK') {
        this.messageService.success('Sevk edildi.');
      } else {
        this.messageService.error(result.toString());
      }
      this.refreshList();
      this.orderGathering.hide();
    }, error => {
        console.log('error ', error);
        this.messageService.error(error.error.text);
    });
  }

  prepareWaybillPrintoutParameters() {
      this.screenPropertyService.listScreenProperties().subscribe(
          result => {
              this.productCountPerPage = +(result.find(p => p.PropertyName === 'ProductCountPerPage').PropertyValue);
              this.addressFieldLineLength = +(result.find(p => p.PropertyName === 'AddressFieldLineLength').PropertyValue);
              this.fontSize = result.find(p => p.PropertyName === 'FontSize').PropertyValue;
              this.fontFamily = result.find(p => p.PropertyName === 'FontFamily').PropertyValue;

              const spaceBeforeHeader = +(result.find(p => p.PropertyName === 'SpaceBeforeHeader').PropertyValue);
              this.spaceBeforeHeaderArr = Array.from(Array(spaceBeforeHeader).keys());

              const spaceAfterHeader = +(result.find(p => p.PropertyName === 'SpaceAfterHeader').PropertyValue);
              this.spaceAfterHeaderArr = Array.from(Array(spaceAfterHeader).keys());

              const headerTableColumnWidth = result.find(p => p.PropertyName === 'HeaderTableColumnWidth').PropertyValue;
              this.headerTableColumnWidthArr =  headerTableColumnWidth.split(',').map(cw => cw + '%');
              // this.headerTableColumnWidthArr = this.headerTableColumnWidthArr.map(cw => cw + '%');

              const productTableColumnWidths = result.find(p => p.PropertyName === 'ProductTableColumnWidth').PropertyValue;
              this.productTableColumnWidthArr =  productTableColumnWidths.split(',').map(cw => cw + '%');
              // this.productTableColumnWidthArr = this.productTableColumnWidthArr;

              this.printerName = result.find(p => p.PropertyName === 'PrinterName').PropertyValue;
          }, error => {
              this.messageService.error(this.translateService.instant('Can not retrieved waybill printout page properties; default values assigned') + '!');
              this.productCountPerPage = 40;
              this.addressFieldLineLength = 40;

              const spaceBeforeHeader = 12;
              this.spaceBeforeHeaderArr = Array.from(Array(spaceBeforeHeader).keys());

              const spaceAfterHeader = 3;
              this.spaceAfterHeaderArr = Array.from(Array(spaceAfterHeader).keys());

              const headerTableColumnWidth = '11,33,33,10';
              this.headerTableColumnWidthArr =  headerTableColumnWidth.split(',');
              this.headerTableColumnWidthArr = this.headerTableColumnWidthArr.map(cw => cw + '%');

              const productTableColumnWidths = '2,5,5,12,12,45,10,5,4';
              this.productTableColumnWidthArr =  productTableColumnWidths.split(',');
              this.productTableColumnWidthArr = this.productTableColumnWidthArr.map(cw => cw + '%');

              this.printerName = 'OKI DATA CORP ML1120';
      });
  }

  onPrintWaybill() {
    const pageCount = Math.ceil(this.orderGatheringList.length / this.productCountPerPage);
    for (let i = 0; i < pageCount; i++) {
      this.pageArray.push(i);
    }
    this.waybillPrintoutContent.addressChanged.next(this.selectedDataItem.StoreAddress);
    this.showPrintDialog();
  }

  showPrintDialog() {
    const styles = `
      <style type="text/css" media="screen, print">
      @media print {
          @page
          {
             height: 280mm;
             width: 240mm;
             margin: 0.5cm 0.5cm 0.5cm 0.5cm;
          }
          * {
            font-family:  ${ this.fontFamily }, sans-serif;
            font-size: ${ this.fontSize };
          }
          table {
            margin-left: 3mm;
            margin-right: 3mm;
            width: 100%;
          }
          td {
                border-collapse: collapse;
                border: none;
                margin: 0;
                padding: 0;
          }
          .pagebreak {
              page-break-after: always;
          }
          .nopagebreak {
            page-break-after: avoid;
          }

       }
       </style>
    `;
    setTimeout(() => {
        this.printingService.print(this.waybillPrintout.nativeElement.innerHTML, styles, 1200, 700);
        /* const data = [{
            type: 'pixel',
            format: 'html',
            flavor: 'plain', //  'plain' if the data is raw HTML,  'file' if the data is html file
            data: this.waybillPrintout.nativeElement.innerHTML
        }];
        this.qzService.printData(this.printerName, data); */

        this.pageArray = [];
    }, 1000);
  }
}
