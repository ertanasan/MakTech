import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { environment } from 'environments/environment';

import { GridModule } from '@progress/kendo-angular-grid';

import { OTCommonModule } from '@otcommon/common.module';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { FinanceComponent } from '@finance/finance.component';
import { EstateRentPeriodListComponent } from '@finance/screen/estate-rent-period/estate-rent-period-list/estate-rent-period-list.component';
import { EstateRentPeriodEditComponent } from '@finance/screen/estate-rent-period/estate-rent-period-edit/estate-rent-period-edit.component';
import { EstateRentPeriodService } from '@finance/service/estate-rent-period.service';
import { ContractDraftVersionListComponent } from '@finance/screen/contract-draft-version/contract-draft-version-list/contract-draft-version-list.component';
import { ContractDraftVersionEditComponent } from '@finance/screen/contract-draft-version/contract-draft-version-edit/contract-draft-version-edit.component';
import { ContractDraftVersionService } from '@finance/service/contract-draft-version.service';
import { LandlordListComponent } from '@finance/screen/landlord/landlord-list/landlord-list.component';
import { LandlordEditComponent } from '@finance/screen/landlord/landlord-edit/landlord-edit.component';
import { LandlordService } from '@finance/service/landlord.service';
import { EstateRentListComponent } from '@finance/screen/estate-rent/estate-rent-list/estate-rent-list.component';
import { EstateRentEditComponent } from '@finance/screen/estate-rent/estate-rent-edit/estate-rent-edit.component';
import { EstateRentService } from '@finance/service/estate-rent.service';
import { RentPaymentPlanListComponent } from '@finance/screen/rent-payment-plan/rent-payment-plan-list/rent-payment-plan-list.component';
import { RentPaymentPlanEditComponent } from '@finance/screen/rent-payment-plan/rent-payment-plan-edit/rent-payment-plan-edit.component';
import { RentPaymentPlanService } from '@finance/service/rent-payment-plan.service';
import { EstateLandlordListComponent } from '@finance/screen/estate-landlord/estate-landlord-list/estate-landlord-list.component';
import { EstateLandlordEditComponent } from '@finance/screen/estate-landlord/estate-landlord-edit/estate-landlord-edit.component';
import { EstateLandlordService } from '@finance/service/estate-landlord.service';
import {DocumentModule} from '@document/document.module';
import { IntlService, CldrIntlService } from '@progress/kendo-angular-intl';
import { ContractParameterListComponent } from '@finance/screen/contract-parameter/contract-parameter-list/contract-parameter-list.component';
import { ContractParameterEditComponent } from '@finance/screen/contract-parameter/contract-parameter-edit/contract-parameter-edit.component';
import { ContractParameterService } from '@finance/service/contract-parameter.service';

const routes: Routes = [
  {
    'path': '',
    'component': FinanceComponent,
    'children': [
      {
        'path': 'EstateRentPeriod/Index',
        'component': EstateRentPeriodListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ContractDraftVersion/Index',
        'component': ContractDraftVersionListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Landlord/Index',
        'component': LandlordListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'EstateRent/Index',
        'component': EstateRentListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'RentPaymentPlan/Index',
        'component': RentPaymentPlanListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'EstateLandlord/Index',
        'component': EstateLandlordListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ContractParameter/Index',
        'component': ContractParameterListComponent,
        'pathMatch': 'full'
      }
    ]
  }
];

export function FinanceHttpLoaderFactory(httpClient: HttpClient, translationService: OTTranslationService) {
    return new OTTranslateLoader(httpClient, translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=FIN');
}

@NgModule({
    declarations: [
        FinanceComponent,
        EstateRentPeriodEditComponent,
        EstateRentPeriodListComponent,
        ContractDraftVersionEditComponent,
        ContractDraftVersionListComponent,
        LandlordEditComponent,
        LandlordListComponent,
        EstateRentEditComponent,
        EstateRentListComponent,
        RentPaymentPlanEditComponent,
        RentPaymentPlanListComponent,
        EstateLandlordEditComponent,
        EstateLandlordListComponent,
        ContractParameterEditComponent,
        ContractParameterListComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        TranslateModule,
        GridModule,
        OTCommonModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: FinanceHttpLoaderFactory,
                deps: [HttpClient, OTTranslationService]
            },
            isolate: true
        }),
        DocumentModule
    ],
    exports: [
        RouterModule
    ],
    providers: [
        EstateRentPeriodService,
        ContractDraftVersionService,
        LandlordService,
        EstateRentService,
        RentPaymentPlanService,
        EstateLandlordService,
        {
        provide: IntlService,
        useExisting: CldrIntlService,
        },
        ContractParameterService,
    ]
})
export class FinanceModule {}
