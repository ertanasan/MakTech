import { Component, OnDestroy } from '@angular/core';
import { TenantService } from '@otservice/tenant.service';
import { Subscription, Observable } from 'rxjs';
import { Organization } from '@organization/model/organization.model';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { TranslateService } from '@ngx-translate/core';
import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import * as ContextActions from '@otlib/auth/store/context.actions';
import { OTContext } from '@otlib/auth/model/context.model';
import { environment } from 'environments/environment';

@Component({
	selector: 'kt-tenant-selector',
	templateUrl: './tenant-selector.component.html',
})
export class TenantSelectorComponent implements OnDestroy {
    private unsubscribe: Subscription[] = []; // Read more: => https://brianflove.com/2016/12/11/anguar-2-unsubscribe-observables/
    organizations: Organization[] = [];
    filterSettings: DropDownFilterSettings = {
        caseSensitive: false,
        operator: 'contains'
    };
    tenantId = 0;
    selectedTenant: Organization = null;
    context$: Observable<OTContext>;

    constructor(private tenantService: TenantService,
                private translateService: TranslateService,
                private readonly store: Store<fromApp.AppState>) {
        this.context$ = this.store.select('context');
        this.context$.subscribe(
            context => {
                this.tenantId = context.TenantId ? context.TenantId : 0;
                this.translateService.use(context.UserLanguage);
            }
        );
        const tenantSubscription = this.tenantService.tenantLoaded.subscribe(
			(items: any) => {
                if (items.Data.length > 0) {
                    const selectOrganization = new Organization();
                    selectOrganization.OrganizationId = 0;
                    selectOrganization.Name = this.translateService.instant('Select Organization');
                    const tenants = [selectOrganization];
                    tenants.push(...items.Data);
                    this.organizations = tenants;
                    this.selectedTenant = this.organizations.filter(organization => organization.OrganizationId === this.tenantId)[0];
                }
			}
		);
		this.unsubscribe.push(tenantSubscription);
    }

    ngOnDestroy(): void {
		this.unsubscribe.forEach(sb => sb.unsubscribe());
    }

    tenantSelected() {
        this.tenantService.ChangeTenant(this.selectedTenant.OrganizationId);
    }

    tenantSelectionEnabled() {
        return environment['tenantSelectionEnabled'] !== undefined && environment['tenantSelectionEnabled'];
    }
}
