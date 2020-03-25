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
  selector: 'ot-expense-grid-item',
  templateUrl: './expense-grid-item.component.html',
  styleUrls: ['./expense-grid-item.component.css']
})
export class ExpenseGridItemComponent extends ListScreenBase<ExpenseDetailItem> implements OnInit, OnDestroy {
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
    return new ExpenseDetailItem();
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


class ExpenseDetailItem extends ModelBase {
  public ITEMID = 0;
  public STORE_NM: string;
  public EXPENSETYPE_NM: string;
  public MANAGER_NM: string;
  public EXPENSE_DT: Date;
  public EXPENSE_AMT: number;

  constructor() {
      super();
  }
  setId(id: number) {this.ITEMID = id; }
  getId(): number  { return this.ITEMID; }
}
