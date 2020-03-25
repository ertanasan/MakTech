import { Component, OnInit, Input } from '@angular/core';
import { ProductPrice } from '@price/model/product-price.model';
import { StorePackage } from '@price/model/store-package.model';
import { PackageTypeService } from '@price/service/package-type.service';

@Component({
  selector: 'ot-price-package-print',
  templateUrl: './price-package-print.component.html',
  styleUrls: ['./price-package-print.component.css']
})
export class PricePackagePrintComponent implements OnInit {
  @Input() packageToPrint: any;
  @Input() packageVersionNo: number;
  @Input() packageStoresToPrint: StorePackage[];
  @Input() productsToPrint: ProductPrice[];
  @Input() approveDate: Date = new Date();
  @Input() department: string ;
  @Input() mainTitle: string;
  @Input() content: string;
  @Input() author: string;
  @Input() approver: string;

  constructor(public packageTypeService: PackageTypeService) {
   }

  ngOnInit() {
    this.packageTypeService.listAll();
  }

}
