import { Component, OnInit, ViewChild, AfterViewInit, Input } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreOrder } from '@warehouse/model/store-order.model';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { StoreOrderStatusService } from '@warehouse/service/store-order-status.service';
import { finalize } from 'rxjs/operators';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'ot-store-order-history',
  templateUrl: './store-order-history.component.html',
  styleUrls: ['./store-order-history.component.css']
})
export class StoreOrderHistoryComponent extends CRUDDialogScreenBase<StoreOrder> implements OnInit, AfterViewInit  {
  @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreOrder>;

  currentItem: StoreOrder;
  @Input() viewDetails: boolean;
  @Input() history: any;
  @Input() currentTime: Date;
  @Input() isStore: boolean;

  constructor(
      messageService: GrowlMessageService,
      translateService: TranslateService,
      public utilityService: OTUtilityService,
      public dataService: StoreOrderService,
      public storeService: StoreService,
      public storeOrderStatusService: StoreOrderStatusService,
      private datePipe: DatePipe
  ) {
      super(messageService, translateService, dataService, 'Store Order');
  }

  createForm() {
      this.container.mainForm = this.container.formBuilder.group({
          StoreOrderId: new FormControl(),
          Event: new FormControl(),
          Organization: new FormControl(),
          Deleted: new FormControl(),
          CreateDate: new FormControl(),
          UpdateDate: new FormControl(),
          CreateUser: new FormControl(),
          UpdateUser: new FormControl(),
          CreateChannel: new FormControl(),
          CreateBranch: new FormControl(),
          CreateScreen: new FormControl(),
          Store: new FormControl(),
          StoreName: new FormControl(),
          OrderCode: new FormControl(),
          Status: new FormControl(),
          OrderDate: new FormControl(),
          ShipmentDate: new FormControl(),
          OrderValue: new FormControl(),
      });
  }

  ngOnInit() {
      super.ngOnInit();

  }

  ngAfterViewInit() {


  }

  /*Section="CustomCodeRegion"*/
  //#region Customized

  doCreate() {
      let restAction = 'Create';
      if (this.container.leftRelationId > 0) {
          restAction = 'AddLeft';
      } else if (this.container.rightRelationId > 0) {
          restAction = 'AddRight';
      }

      // Make the REST call
      this.currentItem.Event = 1047;
      this.currentItem.OrderValue = 1;
      // this.currentItem.Organization = 1;
      this.dataService.create(this.currentItem, restAction).pipe(
          finalize(() => this.container.hideProgress())
      ).subscribe(
          model => {
              this.messageService.success(this.translateService.instant(this.createSuccessMessage, {0: this.translateService.instant(this.modelName)}));
              this.mainScreen.refreshData(this.currentItem.getId());
              this.container.hide();
          },
          error => {
              this.messageService.error(this.translateService.instant(this.createFailMessage, {0: this.translateService.instant(this.modelName), 1: error}));
          }
      );
  }

  create() {
      let lastOrderEntry: number;
      if ((<Store[]>this.storeService.userStores).length === 1) {
          lastOrderEntry = this.storeService.userStores[0].LastOrderEntry;
      } else {
          lastOrderEntry = 16;
      }
      const d = new Date(this.currentTime);
      if (d.getHours() >= lastOrderEntry && this.isStore) {
          this.messageService.error(`Son sipariş giriş ve onaylama saati : ${lastOrderEntry}.`);
          this.container.hide();
          return;
      }
      const shipmentDate = this.datePipe.transform(this.currentItem.ShipmentDate, 'yyyy-MM-dd');
      // o güne ait sipariş önceden var mı?
      this.dataService.getOrderofDay(this.currentItem.Store, shipmentDate).subscribe( result => {
          const order: any = result;
          if (order.StoreOrderId > 0 && this.isStore) {
              this.messageService.error(`${this.currentItem.ShipmentDate.toLocaleDateString()} tarihinde önceden girilmiş bir siparişiniz var ona giriş yapınız. Sipariş No : ${order.StoreOrderId}`);
              this.container.hide();
          } else {
              this.doCreate();
          }
      });

  }

  pad(num, size) {
    let s = num + '';
    while (s.length < size) {
        s = '0' + s;
    }
    return s;
  }

  dateToString(d: Date): string {
    const year = d.getFullYear();
    const month = d.getMonth() + 1;
    const day = d.getDate();
    return `${year}${this.pad(month, 2)}${this.pad(day, 2)}`;
  }

  addHours(_datetime, _hour) {
    const d = new Date(_datetime);
    d.setHours(d.getHours() + _hour);
    return d;
  }

  onStoreChange(event) {
      const selectedStore = this.storeService.userStores.filter(r => r.StoreId === event)[0];
      this.container.mainForm.controls.OrderCode.setValue(`${selectedStore.Name}-${this.dateToString(this.container.mainForm.controls.OrderDate.value)}`);
      this.dataService.getShipmentDay(event).subscribe(result => {
        const d = new Date(<Date> result);
        this.container.mainForm.controls.ShipmentDate.setValue(this.addHours(d, 12));
      });
  }
  //#endregion Customized

  /*Section="ClassFooter"*/
}
