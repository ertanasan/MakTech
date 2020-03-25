import { Component, OnInit, Input } from '@angular/core';
import { StorePackage } from '@price/model/store-package.model';
import { ProductPrice } from '@price/model/product-price.model';
import { PackageTypeService } from '@price/service/package-type.service';

@Component({
  selector: 'ot-product-price-print',
  templateUrl: './product-price-print.component.html',
  styleUrls: ['./product-price-print.component.css']
})
export class ProductPricePrintComponent implements OnInit {

  @Input() packageToPrint: any;
  @Input() packageStoresToPrint: StorePackage[];
  @Input() productsToPrint: ProductPrice[];
  approveDate: Date = new Date();
  department = 'SATIN ALMA DEPARTMANI';
  mainTitle = 'FİYAT PAKET DOKÜMANI';
  content = 'Yukarıda detayları verilen fiyat paketine göre fiyatları değişecek ürünler, uygulanacakları mağazalar ve geçerlilik süreleri ekteki tablolarda sunulmuştur.';
  author = 'Kübra ÖZCANBEY';
  approver = 'Murat TOPLU';

  constructor(public packageTypeService: PackageTypeService) { }

  ngOnInit() {
    this.packageTypeService.listAll();
  }

}
