// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ComponentFactory, ComponentFactoryResolver, ViewContainerRef, OnDestroy, Type, Injector } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { DynamicComponentLoader } from '../../../../lib/ui/dynamic-component-loader/dynamic-component-loader.service';
import { Subscription } from 'rxjs/Subscription';
import { componentMap } from './component-map';
import { Subject } from 'rxjs';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { OTScreenBase } from '@otscreen-base/ot-screen-base';
import { InboxItem } from '@bpm-core/model/inboxitem.model';
import { InboxService } from '@bpm-core/service/inbox.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { BranchService } from '@frame/organization/service/branch.service';
import { GridDataResult, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { State } from '@ngrx/store';
import { OverStoreInboxItem } from '@warehouse/model/overstore-inbox-item.model';
import { OverStoreInboxService } from '@app-main/service/overstore-inbox.service';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-inbox',
    templateUrl: './inbox.component.html',
    styleUrls: ['./inbox.component.css' ],

})
export class InboxComponent extends ListScreenBase<OverStoreInboxItem> implements OnInit, OnDestroy {

    @ViewChild('reviewComponent', { static: true, read: ViewContainerRef }) reviewComponent;

    componentRef: any;
    componentSubscription: Subscription;
    actionSubscription: Subscription;
    screenModeSubscription: Subscription;
    selectedItem: OverStoreInboxItem;


    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: InboxService,
        public dynamicComponentLoader: DynamicComponentLoader,
        private injector: Injector,
        public utilityService: OTUtilityService,
        public branchService: BranchService,
        public overStoreInboxItemService: OverStoreInboxService
    ) {
        super(messageService, translateService);
        translateService.setDefaultLang('tr');
    }

    refreshList() {
        // this.dataService.list(this.listParams);
        this.overStoreInboxItemService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Inbox' }, { Caption: 'Inbox', RouterLink: '/OverBPMDemoMain/Inbox' }];
    }

    createEmptyModel(): OverStoreInboxItem {
        // return new InboxItem();
        return new OverStoreInboxItem();
    }

    ngOnInit() {
        // Fill reference lists
        this.listParams.dateFields.push('ActionStartDate');
        super.ngOnInit();
    }

    /*
    showReviewDialog(dataItem: InboxItem) {

        const screenParts = dataItem.ScreenReference.split('#');
        if (screenParts.length === 3) {
            this.createReviewComponent(dataItem.ActionId, screenParts[0], screenParts[1], screenParts[2]);
        } else {
            this.messageService.warning('Screen Reference is not well-formatted. Screen Reference is:' + dataItem.ScreenReference );
        }
    }*/

    showReviewDialog(dataItem: OverStoreInboxItem) {
        const screenParts = dataItem.ScreenReference.split('#');
        if (screenParts.length === 3) {
            this.createReviewComponent(dataItem.ActionId, screenParts[0], screenParts[1], screenParts[2]);
        } else {
            this.messageService.warning('Screen Reference is not well-formatted. Screen Reference is:' + dataItem.ScreenReference );
        }
    }

    createReviewComponent(actionId: number, moduleName: string, componentName: string, context: string): any {
        this.clearComponent();
        this.actionSubscription = this.dataService.readActionInfo(actionId).subscribe(actionInfo => {
            this.componentSubscription = this.dynamicComponentLoader
                .getComponentFactory(moduleName, componentMap[componentName], this.injector)
                .subscribe(componentFactory => {
                    const childActions = actionInfo['Choices'].join(';');
                    this.componentRef = this.reviewComponent.createComponent(componentFactory);
                    const screenRef = <OTScreenBase>this.componentRef._component;
                    screenRef.modeDefault = false;
                    screenRef.modeReview = true;
                    screenRef.modeContext = { childActions: childActions, id: context, actionId: actionId };
                    this.screenModeSubscription = screenRef.modeEvent.subscribe((data: any) => {
                        this.refreshList();
                    });
                    this.componentRef.changeDetectorRef.detectChanges();
                }, error => {
                    console.warn(error);
                });
        });
    }

    clearComponent() {
        this.reviewComponent.clear();
        if (this.componentRef) { this.componentRef.destroy(); }
        if (this.componentSubscription) {
            this.componentSubscription.unsubscribe();
        }
        if (this.actionSubscription) {
            this.actionSubscription.unsubscribe();
        }
        if (this.screenModeSubscription) {
            this.screenModeSubscription.unsubscribe();
        }
    }

    public onSelection(event): void {
        this.selectedItem = event.selectedRows[0].dataItem;
    }

    public onGridDoubleClick(event): void {
        if (this.selectedItem) {
            this.showReviewDialog(this.selectedItem);
        }
    }

    ngOnDestroy() {
        this.clearComponent();
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['ActionStartDate'];
        super.handleDataStateChange(state);
    }
}
