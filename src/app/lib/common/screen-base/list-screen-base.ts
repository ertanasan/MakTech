import { Injectable, OnInit, OnDestroy, Input } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { TranslationChangeEvent } from '@ngx-translate/core';

import { DataStateChangeEvent } from '@progress/kendo-angular-grid';

import { ModelBase } from '@otmodel/model-base';
import { ListParams } from '@otmodel/list-params.model';
import { RelationId } from '@otmodel/relation-id.model';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TenantService } from '@otservice/tenant.service';
import { OTInjector } from '@otcommon/common.module';

const baseCommandColumnWidth = 28;
const singleCommandColumnWidth = 40;

@Injectable()
export abstract class ListScreenBase<T extends ModelBase> extends MainScreenBase implements OnInit, OnDestroy {
    public unsubscribe: Subscription[] = []; // Read more: => https://brianflove.com/2016/12/11/anguar-2-unsubscribe-observables/
    translateSubscription: Subscription;
    tenantChangedSubscription: Subscription;
    listParams: ListParams = new ListParams();
    useLocalData = false;
    calculatedCommandColumnWidth = 108;

    dataList$: Observable<T>;

    @Input() dataList: T[] | { data: T[], total: number };
    @Input() dataLoading = false;

    abstract refreshList();
    abstract createEmptyModel(): T;

    constructor(
        messageService: GrowlMessageService,
        protected translateService: TranslateService) {
        super(messageService, translateService);
    }

    filterList() {
    }

    ngOnInit() {
        this.refreshList();
        this.translateSubscription = this.translateService.onLangChange.subscribe((event: TranslationChangeEvent) => {
            this.refreshList();
            this.onLanguageChange(event);
        });
        this.tenantChangedSubscription = OTInjector.get(TenantService).tenantChanged.subscribe((item: { TenantId: number, TenantKey: string }) => {
            this.refreshList();
        });
    }

    ngOnDestroy() {
        if (this.translateSubscription) {
            this.translateSubscription.unsubscribe();
        }
        if (this.tenantChangedSubscription) {
            this.tenantChangedSubscription.unsubscribe();
        }
        this.unsubscribe.forEach(sb => sb.unsubscribe());
    }

    refreshData(id?: number | RelationId) {
        this.refreshList();
    }

    onLanguageChange(event: TranslationChangeEvent) {
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.skip = state.skip;
        this.listParams.take = state.take;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }
        this.refreshList();
    }

    createEmptyItem(): any {
        return this.createEmptyModel();
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.listParams.take = state.take;
        this.listParams.skip = state.skip;
        this.listParams.filter = state.filter;
        this.listParams.sort = state.sort;
        this.listParams.group = state.group;

        this.dataLoading = true;
        this.filterList();
        this.dataLoading = false;
    }

    // createEnabled property
    // tslint:disable-next-line:member-ordering
    private _createEnabled = true;
    @Input() set createEnabled(value: boolean) {
        this._createEnabled = value;
        this.calculateCommandColumnWidth();
    }
    get createEnabled(): boolean {
        return this._createEnabled;
    }

    // readEnabled property
    // tslint:disable-next-line:member-ordering
    private _readEnabled = false;
    @Input() set readEnabled(value: boolean) {
        this._readEnabled = value;
        this.calculateCommandColumnWidth();
    }
    get readEnabled(): boolean {
        return this._readEnabled;
    }

    // updateEnabled property
    // tslint:disable-next-line:member-ordering
    private _updateEnabled = true;
    @Input() set updateEnabled(value: boolean) {
        this._updateEnabled = value;
        this.calculateCommandColumnWidth();
    }
    get updateEnabled(): boolean {
        return this._updateEnabled;
    }

    // deleteEnabled property
    // tslint:disable-next-line:member-ordering
    private _deleteEnabled = true;
    @Input() set deleteEnabled(value: boolean) {
        this._deleteEnabled = value;
        this.calculateCommandColumnWidth();
    }
    get deleteEnabled(): boolean {
        return this._deleteEnabled;
    }

    @Input() set isViewOnly(value: boolean) {
        this.createEnabled = !value;
        this.updateEnabled = !value;
        this.deleteEnabled = !value;
        this.readEnabled = true;
    }

    get isViewOnly(): boolean {
        return this.readEnabled && !this.createEnabled && this.updateEnabled && this.deleteEnabled;
    }

    private calculateCommandColumnWidth() {
        let width = baseCommandColumnWidth;
        width += this._readEnabled ? singleCommandColumnWidth : 0;
        width += this._updateEnabled ? singleCommandColumnWidth : 0;
        width += this._deleteEnabled ? singleCommandColumnWidth : 0;
        this.calculatedCommandColumnWidth = width;
    }

    get commandColumnWidth(): number {
        this.calculateCommandColumnWidth();
        return this.calculatedCommandColumnWidth;
    }

    set commandColumnWidth(value: number) {
        this.calculatedCommandColumnWidth = value;
    }
}
