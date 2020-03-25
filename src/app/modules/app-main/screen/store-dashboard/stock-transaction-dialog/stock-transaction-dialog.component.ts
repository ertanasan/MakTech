import { Component, OnInit, ViewChild, Input, OnDestroy } from '@angular/core';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { ListParams } from '@otmodel/list-params.model';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ModelBase } from '@otmodel/model-base';
import { process } from '@progress/kendo-data-query';
import { Subscription, Subject } from 'rxjs';

@Component({
  selector: 'ot-stock-transaction-dialog',
  templateUrl: './stock-transaction-dialog.component.html',
  styleUrls: ['./stock-transaction-dialog.component.css']
})
export class StockTransactionDialogComponent extends ListScreenBase<StockTransaction> implements OnInit, OnDestroy {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  dataList: any;
  public activeList: any = {'data': [], 'total': 0};
  listParams: ListParams;
  onShow: Subject<any> = new Subject();
  showSubscription: Subscription;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
  ) {
        super(messageService, translateService);
  }

  getBreadcrumbItems(): MenuItem[] {
    return null;
  }

  createEmptyModel() {
    return new StockTransaction();
    // throw new Error('Method not suported.');
  }

  handleDataStateChange(state) {
    // this.listParams.skip = state.skip;
    if (state.sort) {
        this.listParams.sort = state.sort;
    }
    if (state.filter) {
        this.listParams.filter = state.filter;
    }
    if (state.group) {
        this.listParams.group = state.group;
    }

    this.refreshList();
  }

  refreshList() {
    if (this.dataList) {
      this.activeList = process(this.dataList, this.listParams);
    }
  }

  ngOnInit() {
    this.listParams = new ListParams();
    this.listParams.take = 1000;
    this.listParams.pageable = false;

    this.showSubscription = this.onShow.subscribe(
      list => {
        this.dataList = list;
        this.refreshList();
      }
    );
  }

  ngOnDestroy(): void {
    if (this.showSubscription) {
        this.showSubscription.unsubscribe();
    }
  }

}


class StockTransaction extends ModelBase {
  public STOREID = 0;
  public STORE_NM: string;
  public CATEGORY_NM: string;
  public PRODUCT_NM: string;
  public TRANSACTION_DT: Date;
  public TRANSACTIONTYPE_NM: string;
  public QUANTITY_QTY: number;
  public STOCK: number;

  constructor() {
      super();
  }
  setId(id: number) {this.STOREID = id; }
  getId(): number  { return this.STOREID; }
}
