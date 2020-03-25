import { HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { ButtonsModule } from '@progress/kendo-angular-buttons';

import { OTCommonModule } from '@otcommon/common.module';

import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { CashRegisterBrandService } from '@store/service/cash-register-brand.service';
import { CashRegisterModelService } from '@store/service/cash-register-model.service';
import { CityService } from '@store/service/city.service';
import { RegionManagersService } from '@store/service/region-managers.service';
import { StoreScalesService } from '@store/service/store-scales.service';
import { ScaleBrandService } from '@store/service/scale-brand.service';
import { ScaleModelService } from '@store/service/scale-model.service';
import { StoreService } from '@store/service/store.service';
import { TownService } from '@store/service/town.service';
import { StoreCashRegisterListComponent } from '@store/screen/store-cash-register/store-cash-register-list/store-cash-register-list.component';
import { StoreCashRegisterEditComponent } from '@store/screen/store-cash-register/store-cash-register-edit/store-cash-register-edit.component';
import { CashRegisterBrandListComponent } from '@store/screen/cash-register-brand/cash-register-brand-list/cash-register-brand-list.component';
import { CashRegisterBrandEditComponent } from '@store/screen/cash-register-brand/cash-register-brand-edit/cash-register-brand-edit.component';
import { CashRegisterModelListComponent } from '@store/screen/cash-register-model/cash-register-model-list/cash-register-model-list.component';
import { CashRegisterModelEditComponent } from '@store/screen/cash-register-model/cash-register-model-edit/cash-register-model-edit.component';
import { CityListComponent } from '@store/screen/city/city-list/city-list.component';
import { CityEditComponent } from '@store/screen/city/city-edit/city-edit.component';
import { RegionManagersListComponent } from '@store/screen/region-managers/region-managers-list/region-managers-list.component';
import { RegionManagersEditComponent } from '@store/screen/region-managers/region-managers-edit/region-managers-edit.component';
import { StoreScalesListComponent } from '@store/screen/store-scales/store-scales-list/store-scales-list.component';
import { StoreScalesEditComponent } from '@store/screen/store-scales/store-scales-edit/store-scales-edit.component';
import { ScaleBrandListComponent } from '@store/screen/scale-brand/scale-brand-list/scale-brand-list.component';
import { ScaleBrandEditComponent } from '@store/screen/scale-brand/scale-brand-edit/scale-brand-edit.component';
import { ScaleModelListComponent } from '@store/screen/scale-model/scale-model-list/scale-model-list.component';
import { ScaleModelEditComponent } from '@store/screen/scale-model/scale-model-edit/scale-model-edit.component';
import { StoreListComponent } from '@store/screen/store/store-list/store-list.component';
import { StoreEditComponent } from '@store/screen/store/store-edit/store-edit.component';
import { TownListComponent } from '@store/screen/town/town-list/town-list.component';
import { TownEditComponent } from '@store/screen/town/town-edit/town-edit.component';
import { BranchService } from '@frame/organization/service/branch.service';
import { PackageVersionService } from '@price/service/package-version.service';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { environment } from 'environments/environment';
import { IntlModule } from '@progress/kendo-angular-intl';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import 'hammerjs';
import '@progress/kendo-angular-intl/locales/en/all';
import '@progress/kendo-angular-intl/locales/tr/all';
import { WarehouseModule } from '@warehouse/warehouse.module';
import { StorePropertyService } from './service/store-property.service';
import { StorePropertyEditComponent } from './screen/store-property/store-property-edit/store-property-edit.component';
import { StorePropertyListComponent } from './screen/store-property/store-property-list/store-property-list.component';
import { StorePropertyTypeListComponent } from '@store/screen/store-property-type/store-property-type-list/store-property-type-list.component';
import { StorePropertyTypeEditComponent } from '@store/screen/store-property-type/store-property-type-edit/store-property-type-edit.component';
import { StorePropertyTypeService } from '@store/service/store-property-type.service';
import { StoreComponent } from '@store/store.component';
import { CashierEditComponent } from './screen/cashier/cashier-edit/cashier-edit.component';
import { CashierTemplateEditComponent } from './screen/cashier-template/cashier-template-edit/cashier-template-edit.component';
import { CashierListComponent } from './screen/cashier/cashier-list/cashier-list.component';
import { CashierTemplateListComponent } from './screen/cashier-template/cashier-template-list/cashier-template-list.component';
import { CashierService } from './service/cashier.service';
import { CashierTemplateService } from './service/cashier-template.service';
import { UsersStoresListComponent } from '@store/screen/users-stores/users-stores-list/users-stores-list.component';
import { UsersStoresEditComponent } from '@store/screen/users-stores/users-stores-edit/users-stores-edit.component';
import { UsersStoresService } from '@store/service/users-stores.service';
import { UserService } from '@frame/security/service/user.service';
import { TitleService } from '@frame/security/service/title.service';
import { BankListComponent } from '@store/screen/bank/bank-list/bank-list.component';
import { BankEditComponent } from '@store/screen/bank/bank-edit/bank-edit.component';
import { BankService } from '@store/service/bank.service';
import { PosListComponent } from '@store/screen/pos/pos-list/pos-list.component';
import { PosEditComponent } from '@store/screen/pos/pos-edit/pos-edit.component';
import { PosService } from '@store/service/pos.service';
import { StoreAccountsListComponent } from '@store/screen/store-accounts/store-accounts-list/store-accounts-list.component';
import { StoreAccountsEditComponent } from '@store/screen/store-accounts/store-accounts-edit/store-accounts-edit.component';
import { StoreAccountsService } from '@store/service/store-accounts.service';
import { StoreAccountTypeListComponent } from '@store/screen/store-account-type/store-account-type-list/store-account-type-list.component';
import { StoreAccountTypeEditComponent } from '@store/screen/store-account-type/store-account-type-edit/store-account-type-edit.component';
import { StoreAccountTypeService } from '@store/service/store-account-type.service';
import { EmployeeListComponent } from '@store/screen/employee/employee-list/employee-list.component';
import { EmployeeEditComponent } from '@store/screen/employee/employee-edit/employee-edit.component';
import { EmployeeService } from '@store/service/employee.service';
import { AccountingDepartmentService } from '@accounting/service/accounting-department.service';
import { StoreFixtureListComponent } from '@store/screen/store-fixture/store-fixture-list/store-fixture-list.component';
import { StoreFixtureEditComponent } from '@store/screen/store-fixture/store-fixture-edit/store-fixture-edit.component';
import { StoreFixtureService } from '@store/service/store-fixture.service';
import { FixtureService } from '@product/service/fixture.service';
import { PosMovementListComponent } from '@store/screen/pos-movement/pos-movement-list/pos-movement-list.component';
import { PosMovementEditComponent } from '@store/screen/pos-movement/pos-movement-edit/pos-movement-edit.component';
import { PosMovementService } from '@store/service/pos-movement.service';
import { FixtureBrandService } from '@product/service/fixture-brand.service';
import { FixtureModelService } from '@product/service/fixture-model.service';
import { WorkingHoursListComponent } from '@store/screen/working-hours/working-hours-list/working-hours-list.component';
import { WorkingHoursEditComponent } from '@store/screen/working-hours/working-hours-edit/working-hours-edit.component';
import { WorkingHoursService } from '@store/service/working-hours.service';


const routes: Routes = [
  {
    'path': '',
    'component': StoreComponent,
    'children': [
      {
        'path': 'StoreCashRegister/Index',
        'component': StoreCashRegisterListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'CashRegisterBrand/Index',
        'component': CashRegisterBrandListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'CashRegisterModel/Index',
        'component': CashRegisterModelListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'City/Index',
        'component': CityListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'RegionManagers/Index',
        'component': RegionManagersListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StoreScales/Index',
        'component': StoreScalesListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ScaleBrand/Index',
        'component': ScaleBrandListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ScaleModel/Index',
        'component': ScaleModelListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Store/Index',
        'component': StoreListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Town/Index',
        'component': TownListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StorePropertyType/Index',
        'component': StorePropertyTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Cashier/Index',
        'component': CashierListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'CashierTemplate/Index',
        'component': CashierTemplateListComponent,
        'pathMatch': 'full'
      },
      {
        'path': '',
        'component': StoreComponent,
        'children': []
      },
      {
        'path': 'UsersStores/Index',
        'component': UsersStoresListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Bank/Index',
        'component': BankListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Pos/Index',
        'component': PosListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StoreAccounts/Index',
        'component': StoreAccountsListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StoreAccountType/Index',
        'component': StoreAccountTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Employee/Index',
        'component': EmployeeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StoreFixture/Index',
        'component': StoreFixtureListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'PosMovement/Index',
        'component': PosMovementListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'WorkingHours/Index',
        'component': WorkingHoursListComponent,
        'pathMatch': 'full'
      }
    ]
  }
];

export function StoreHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
    return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=STR');
}

@NgModule({
    declarations: [
        StoreComponent,
        StoreCashRegisterEditComponent,
        StoreCashRegisterListComponent,
        CashRegisterBrandEditComponent,
        CashRegisterBrandListComponent,
        CashRegisterModelEditComponent,
        CashRegisterModelListComponent,
        CityEditComponent,
        CityListComponent,
        RegionManagersEditComponent,
        RegionManagersListComponent,
        StoreScalesEditComponent,
        StoreScalesListComponent,
        ScaleBrandEditComponent,
        ScaleBrandListComponent,
        ScaleModelEditComponent,
        ScaleModelListComponent,
        StoreEditComponent,
        StoreListComponent,
        TownEditComponent,
        TownListComponent,
        StorePropertyEditComponent,
        StorePropertyListComponent,
        StorePropertyTypeEditComponent,
        StorePropertyTypeListComponent,
        CashierEditComponent,
        CashierTemplateEditComponent,
        CashierListComponent,
        CashierTemplateListComponent,
        UsersStoresEditComponent,
        UsersStoresListComponent,
        BankEditComponent,
        BankListComponent,
        PosEditComponent,
        PosListComponent,
        StoreAccountsEditComponent,
        StoreAccountsListComponent,
        StoreAccountTypeEditComponent,
        StoreAccountTypeListComponent,
        EmployeeEditComponent,
        EmployeeListComponent,
        StoreFixtureEditComponent,
        StoreFixtureListComponent,
        PosMovementEditComponent,
        PosMovementListComponent,
        WorkingHoursEditComponent,
        WorkingHoursListComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        ButtonsModule,
        TranslateModule,
        IntlModule,
        DateInputsModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: StoreHttpLoaderFactory,
                deps: [HttpBackend, OTTranslationService]
            },
            isolate: true
        }),
        GridModule,
        OTCommonModule,
        WarehouseModule,
        FormsModule,
        ExcelModule,
    ],
    exports: [
        RouterModule
    ],
    providers: [
        StoreCashRegisterService,
        CashRegisterBrandService,
        CashRegisterModelService,
        CityService,
        RegionManagersService,
        StoreScalesService,
        ScaleBrandService,
        ScaleModelService,
        StoreService,
        TownService,
        BranchService,
        PackageVersionService,
        StorePropertyService,
        StorePropertyTypeService,
        CashierService,
        CashierTemplateService,
        UsersStoresService,
        UserService,
        TitleService,
        BankService,
        PosService,
        StoreAccountsService,
        StoreAccountTypeService,
        EmployeeService,
        AccountingDepartmentService,
        StoreFixtureService,
        FixtureService,
        PosMovementService,
        FixtureBrandService,
        FixtureModelService,
        WorkingHoursService,
    ]
})
export class StoreModule {}
