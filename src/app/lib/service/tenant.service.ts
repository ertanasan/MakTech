import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Subject } from 'rxjs/Subject';
import { Organization } from '../../frame/organization/model/organization.model';
import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import * as ContextActions from '@otlib/auth/store/context.actions';

@Injectable({
    providedIn: 'root'
})
export class TenantService {
    baseRoute: string;
    tenantLoaded = new Subject<Organization[]>();
    tenantChanged = new Subject<{ TenantId: number, TenantKey: string }>();

    constructor(private httpClient: HttpClient, private readonly store: Store<fromApp.AppState>) {
        this.baseRoute = `${environment.baseRoute}/tenant`;
    }

    ChangeTenant(tenant: number) {
        this.httpClient.post<{ TenantId: number, TenantKey: string }>(`${this.baseRoute}/changetenant/${tenant}`, null)
            .subscribe((item: { TenantId: number, TenantKey: string }) => {
                this.store.dispatch(new ContextActions.SetTenant(item));
                this.tenantChanged.next(item);
            });
    }

    ListTenants() {
        this.httpClient.get<Organization[]>(`${this.baseRoute}/list`, { observe: 'body', responseType: 'json' })
            .subscribe(organizationList => {
                this.tenantLoaded.next(organizationList);
            });
    }
}
