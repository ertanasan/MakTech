import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { PricePackageService } from '@price/service/price-package.service';
import { ListParams } from '@otmodel/list-params.model';
import { PackagePerformance } from '@price/model/package-performans-model';
import { process } from '@progress/kendo-data-query';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { PricePackage } from '@price/model/price-package.model';

@Component({
  selector: 'ot-campaign-performance',
  templateUrl: './campaign-performance.component.html',
  styleUrls: ['./campaign-performance.component.css']
})
export class CampaignPerformanceComponent extends MainScreenBase implements OnInit {

  // activePackages: PricePackage[];
  // packageLP = new ListParams();
  fourPackages: PricePackage[] = [ new PricePackage()
                                 , new PricePackage()
                                 , new PricePackage()
                                 , new PricePackage()];                               // shown 4 packages

  loadingArr = [false, false, false, false];                                // loading status of 4 widget data
  packagePerformansArr: PackagePerformance[] = [new PackagePerformance()
                                              , new PackagePerformance()
                                              , new PackagePerformance()
                                              , new PackagePerformance()];    // array of 4 widget data
  selectedPerformance: PackagePerformance;

  pckgPerfActiveList: { data: any[], total: number } = { data: [], total: 0 };
  pckgPerfLP = new ListParams();

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public datePipe: DatePipe,
    public utility: OTUtilityService,
    public pricePackageService: PricePackageService
  ) {
    super(messageService, translateService);
  }

  createEmptyItem( ) { throw new Error('Method not implemented'); }

  getBreadcrumbItems() { return null; }

  refreshData() {

  }

  ngOnInit() {
    // this.excludeInactives();
    // this.pricePackageService.listAsync(this.packageLP).subscribe(
    // this.pricePackageService.listAllAsync().subscribe(
    //   list => {
    //     this.activePackages = list.filter(row => row.PackageName !== 'GENEL FİYATLAR' && row.PackageType === 4);
    //     for (let i = this.activePackages.length - 1; i > this.activePackages.length - 5; i--) {
    //       this.getPackagePerformance(this.activePackages[i].PackageId, i);
    //     }
    // });
    this.pricePackageService.listAll();
    this.pricePackageService.completeListChanged.subscribe(
      list => {
        const tempLength = this.pricePackageService.completeListExceptGeneral.length;
        for (let i = tempLength - 1; i > tempLength - 5; i--) {
          this.getPackagePerformance(this.pricePackageService.completeListExceptGeneral[i].PackageId, tempLength - 1 - i);
        }
      }
    );
  }

  // excludeInactives() {
  //   this.packageLP.filter.logic = 'or';
  //   this.packageLP.filter.filters.push( {field: 'ActiveStores', operator: 'gt', value: 0 } );
  //   const fifteenDaysBefore = new Date();
  //   fifteenDaysBefore.setDate(fifteenDaysBefore.getDate() - 15);
  //   this.packageLP.filter.filters.push( {field: 'CreateDate', operator: 'gt', value: fifteenDaysBefore.toDateString() } );
  // }

  updateFourPackages(packageId: number, widgetIndex: number) {
    this.fourPackages[widgetIndex] = this.pricePackageService.completeList.filter(p => p.PackageId === packageId)[0];
  }

  getPackagePerformance(pckgId: number, widgetIndex: number) {
    if (this.loadingArr[widgetIndex]) {
      return;
    }
    this.loadingArr[widgetIndex] = true;
    this.pricePackageService.getPackagePerformance(pckgId).subscribe(
      result => {
        this.updateFourPackages(pckgId, widgetIndex);
        this.packagePerformansArr[widgetIndex] = result;
        this.loadingArr[widgetIndex] = false;
      },
      error => {
        this.loadingArr[widgetIndex] = false;
        this.messageService.error(this.translateService.instant(`The performance indicator of the ${ pckgId } packageId can not be retrived from backend`));
      }
    );
  }

  listPerformanceDetails(widgetIndex: number) {
    this.selectedPerformance = this.packagePerformansArr[widgetIndex];
    this.pckgPerfLP.take = 1000;
    this.pckgPerfActiveList = process(this.packagePerformansArr[widgetIndex].PerformanceDetailsGrid, this.pckgPerfLP);
  }

  getFileName() {
    const d: Date = new Date();
    const d2 = this.datePipe.transform(d, 'yyyyMMdd');
    return `Package_${this.selectedPerformance.PackageId}_PerformanceReport_${d2}.xlsx`;
  }

  onPackageChange(pckgId: any, widgetIndex: number) {
    if (typeof(pckgId) === 'object') {
      return;
    } else if (pckgId === this.fourPackages[widgetIndex].PackageId) {
      console.log('same');
      return;
    } else {
      this.getPackagePerformance(pckgId, widgetIndex);
    }
  }
}
