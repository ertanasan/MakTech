import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { BaseAppComponent } from '@otui/core/base-app/base-app.component';
import { MenuService } from '@otservice/menu.service';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute } from '@angular/router';
import { ToasterConfig } from 'angular2-toaster';
import { Store } from '@ngrx/store';

import * as fromApp from '@otlib/store/app.reducers';
import { Observable } from 'rxjs/Observable';
import { OTContext } from '@otlib/auth/model/context.model';

import { environment } from 'environments/environment';

@Component({
    selector: 'ot-enterprise-layout',
    templateUrl: './enterprise-layout.component.html',
    styleUrls: ['./enterprise-layout.component.css']
})
export class EnterpriseLayoutComponent extends BaseAppComponent implements OnInit, OnDestroy {

    @Input() wideLogo: string;
    @Input() narrowLogo: string;
    @Input() mainModule: string;
    subcriptionList: Subscription = new Subscription();
    contextState$: Observable<OTContext>;
    menuItems = [];
    menuLoading = false;
    environment = environment;
    today = new Date();
    contextUserId = 0;

    sidebarMinimized = false;
    private changes: MutationObserver;
    public element: HTMLElement = document.body;
    public toasterconfig: ToasterConfig =
        new ToasterConfig({
            tapToDismiss: true,
            timeout: 5000,
            positionClass: 'toast-top-center',
            limit: 5
        });

    constructor(
        private menuService: MenuService,
        private translateService: TranslateService,
        private route: ActivatedRoute,
        private readonly store: Store<fromApp.AppState>,
       ) {
        super();
        this.changes = new MutationObserver((mutations) => {
            this.sidebarMinimized = document.body.classList.contains('sidebar-minimized');
        });

        this.changes.observe(<Element>this.element, {
            attributes: true
        });

        this.contextState$ = this.store.select('context');
    }

    ngOnInit() {
        this.subcriptionList.add(this.menuService.menuLoaded.subscribe(
            (items: any[]) => {
                this.menuItems = items;
                this.menuLoading = false;
            }
        ));

        this.subcriptionList.add(this.contextState$.subscribe(
            context => {
                if (context.User.Id > 0 && this.contextUserId !== context.User.Id ) {
                    this.contextUserId = context.User.Id;
                    this.menuLoading = true;
                    this.menuService.read();
                }
            }
        ));
    }

    ngOnDestroy() {
        this.subcriptionList.unsubscribe();
    }
}
