import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { MikroTransferService } from '@sale/service/mikro-transfer.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { process } from '@progress/kendo-data-query';
import { DatePipe } from '@angular/common';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionTypeService } from '@sale/service/transaction-type.service';
import * as moment from 'moment';

@Component({
  selector: 'ot-mikro-transfer',
  templateUrl: './mikro-transfer.component.html',
  styleUrls: ['./mikro-transfer.component.css']
})
export class MikroTransferComponent extends ListScreenBase<any> implements OnInit {


  recList: any;
  recActiveList: any;
  startDate: Date;
  endDate: Date;
  checkDate: Boolean = false;
  mikroLoading: Boolean = false;

  constructor(messageService: GrowlMessageService,
              translateService: TranslateService,
              public dataService: MikroTransferService,
              public utilityService: OTUtilityService,
              public router: ActivatedRoute,
              public transactionTypeService: TransactionTypeService,
              public datePipe: DatePipe,
              public route: Router,
            ) {
     super(messageService, translateService);
     this.endDate = moment().subtract(1, 'months').endOf('month').toDate();
     this.startDate = moment().subtract(1, 'months').startOf('month').toDate();
  }

  createEmptyModel() {
  }

  getBreadcrumbItems(): MenuItem[] {
    return null;
  }

  refreshList() {
    if (this.recList) {
      this.recActiveList = process(this.recList, this.listParams);
    }

  }

  getRecList() {

    if (this.startDate && this.endDate) {

      const startDateString = this.datePipe.transform(this.startDate, 'yyyy-MM-dd');
      const endDateString = this.datePipe.transform(this.endDate, 'yyyy-MM-dd');

      this.mikroLoading = true;
      this.dataService.listData(startDateString, endDateString, this.checkDate ? 1 : 0).subscribe(result => {
        this.recList = result.Data;
        this.refreshList();
        this.mikroLoading = false;
      },
        error => {
          this.messageService.error(error);
          this.mikroLoading = false;
        });
    }
  }

  ngOnInit() {
    super.ngOnInit();
  }

  loadMikro(data) {
    this.dataService.loadMikro(this.datePipe.transform(data.TRANSACTION_DT, 'yyyy-MM-dd'), data.STOREID);

  }
}
