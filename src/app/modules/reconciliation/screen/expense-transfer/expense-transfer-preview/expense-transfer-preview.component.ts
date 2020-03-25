import { Component, OnInit, ViewChild, OnDestroy, Input } from '@angular/core';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { Expense } from '@reconciliation/model/expense.model';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { ListParams } from '@otmodel/list-params.model';
import { Subject, Subscription } from 'rxjs';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { process } from '@progress/kendo-data-query';
import { ExpenseService } from '@reconciliation/service/expense.service';
import { CurrencyPipe } from '@angular/common';
import { ExpenseTransferListComponent } from '../expense-transfer-list/expense-transfer-list.component';

@Component({
  selector: 'ot-expense-transfer-preview',
  templateUrl: './expense-transfer-preview.component.html',
  styleUrls: ['./expense-transfer-preview.component.css']
})
export class ExpenseTransferPreviewComponent extends ListScreenBase<Expense> implements OnInit, OnDestroy {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  dataList: any;
  expenseList: any;
  totalAmt: string;
  public activeList: any = {'data': [], 'total': 0};
  listParams: ListParams;
  previewText = '';
  @Input() regionManagerId: number;
  onShow: Subject<any> = new Subject();
  showSubscription: Subscription;
  mainScreen: ExpenseTransferListComponent;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public dataService: ExpenseService,
    public currencyPipe: CurrencyPipe
  ) {
        super(messageService, translateService);
  }

  getBreadcrumbItems(): MenuItem[] {
    return null;
  }

  createEmptyModel() {
    return null;
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
      result => {
        this.dataList = result;
        this.expenseList = this.dataList.map(d => d.ExpenseId);
        this.totalAmt = this.currencyPipe.transform(result.reduce((acc, cur) => acc + cur.ExpenseAmount, 0), 'TRY', 'symbol-narrow', '1.2-2');
        this.previewText = this.translateService.instant(`Are you sure you want to transfer ${result.length} expense (${this.totalAmt}) listed below to Mikro?`);
        this.refreshList();
      }
    );
  }

  ngOnDestroy(): void {
    if (this.showSubscription) {
        this.showSubscription.unsubscribe();
    }
  }

  onMikroTransfer() {
    this.dataService.MikroTransfer(this.regionManagerId, this.expenseList).subscribe(
      result => {
          this.messageService.success(this.translateService.instant(`Transferred to Mikro, MBS-${result}`));
          this.mainScreen.onFilter();
          this.dialog.hide();
      }, error => {
          this.messageService.error(this.translateService.instant(`An error occured while transferring-${error}`));
    });
  }

  onCancel() {
    this.dialog.hide();
  }

}
