import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';

@Component({
  selector: 'ot-dashboard-router',
  templateUrl: './dashboard-router.component.html',
  styleUrls: ['./dashboard-router.component.scss']
})
export class DashboardRouterComponent implements OnInit {
  dashboardList: { name: string, caption: string, link: string[], privilegeName: string, show: boolean }[] = [
    { name: 'Sale Dashboard', caption: 'Satış' , link: ['/OverStoreMain/Dashboard/Index'], privilegeName: 'Open Home Page', show: true },
    { name: 'Warehouse Dashboard', caption: 'Depo', link: ['/Warehouse/WarehouseDashboard/Index'], privilegeName: 'Open Warehouse Home Page', show: true },
    { name: 'Helpdesk Dashboard', caption: 'Yardım Masası', link: ['/Helpdesk/HelpdeskDashboard/Index'], privilegeName: 'Open Helpdesk Home Page', show: true  },
    { name: 'Stock Dashboard', caption: 'Stok', link: ['/Warehouse/StockDashboard/Index'], privilegeName: 'Open Stock Home Page', show: true }, /*
    { name: 'HelpDesk Dashboard', caption: 'HD', link: ['/Warehouse/WdashboardHeavy'] },*/
  ];
  @Input() activeDashboard: 'Sale Dashboard';

  constructor(
      public router: Router,
      private privilegeCacheService: PrivilegeCacheService,

  ) { }

  ngOnInit() {
    this.dashboardList.forEach(row => {
      row.show = false;
      this.privilegeCacheService.checkPrivilege(row.privilegeName).subscribe( result => {
        if (result) row.show = true; 
      });
    });
    
  }

}
