import { Component, OnInit, ViewChild, Input, OnDestroy } from '@angular/core';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { ModelBase } from '@otmodel/model-base';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { process } from '@progress/kendo-data-query';
import { ListParams } from '@otmodel/list-params.model';
import { Subject, Subscription } from 'rxjs';

@Component({
  selector: 'ot-expense-chart-item',
  templateUrl: './expense-chart-item.component.html',
  styleUrls: ['./expense-chart-item.component.css']
})

export class ExpenseChartItemComponent extends ListScreenBase<any> implements OnInit, OnDestroy {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  dataList: any;
  public activeList: any = {'data': [], 'total': 0};
  listParams: ListParams;
  onShow: Subject<any> = new Subject();
  showSubscription: Subscription;
  dashboardAuthorization = 'ST';

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
        this.dataList = result.list;
        this.dashboardAuthorization = result.auth;
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