import { Component, OnInit, ViewChild, OnDestroy, ViewEncapsulation } from '@angular/core';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { Subject, Subscription } from 'rxjs';
import { ListParams } from '@otmodel/list-params.model';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { process } from '@progress/kendo-data-query';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'ot-product-stock-dialog',
  templateUrl: './product-stock-dialog.component.html',
  styleUrls: ['./product-stock-dialog.component.css']
})
export class ProductStockDialogComponent extends ListScreenBase<any> implements OnInit, OnDestroy {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  dataList: any;
  public activeList: any = {'data': [], 'total': 0};
  listParams: ListParams;
  onShow: Subject<any> = new Subject();
  showSubscription: Subscription;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public datePipe: DatePipe
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

  getFileName() {
    const d: Date = new Date();
    const d2 = this.datePipe.transform(d, 'yyyyMMdd');
    return `ProductStocks_${d2}.xlsx`;
  }

}
