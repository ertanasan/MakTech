import {Component, OnDestroy, OnInit} from '@angular/core';
import {Product} from '@product/model/product.model';
import {PublicProductService} from '../../service/public-product.service';
import {finalize} from 'rxjs/operators';
import {ActivatedRoute, Route, Router} from '@angular/router';
import {Subscription} from 'rxjs';
import { ProductBarcode } from '@product/model/product-barcode.model';

@Component({
  selector: 'ot-product-info',
  templateUrl: './product-info.component.html',
  styleUrls: ['./product-info.component.scss']
})
export class ProductInfoComponent implements OnInit, OnDestroy {
  unsubscribe: Subscription[] = [];
  productInfoLoading = false;
  product: Product;
  scaleCode: string;

  constructor(public dataService: PublicProductService,
              public activeRoute: ActivatedRoute) {
  }

  ngOnInit() {
    const routeParamSubscription = this.activeRoute.paramMap.subscribe(
      params => this.refreshData(+params.get('productId'))
    );
    this.unsubscribe.push(routeParamSubscription);

    this.dataService.listAllStorageConditions();
    this.dataService.listAllCountries();
  }

  refreshData(productId: number) {
    this.productInfoLoading = true;
    this.dataService.getProductInfo(productId).pipe(finalize(() => this.productInfoLoading = false)).subscribe(
        result => {
          this.product = result;
          // tslint:disable-next-line:no-shadowed-variable
          this.dataService.listProductBarcodes(this.product.ProductId).subscribe( list => {
            const weightedProductBarcodes = list.filter(productBarcode => productBarcode.Product === this.product.ProductId && productBarcode.BarcodeText.substring(0, 3) === '290');
            if (weightedProductBarcodes.length > 0) {
              const barcode = weightedProductBarcodes[0].BarcodeText;
              this.scaleCode = barcode.substring(barcode.length - 4);
            }
          });
        }
    );
  }

  ngOnDestroy() {
    this.unsubscribe.forEach(sb => sb.unsubscribe());
  }

}
