// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ComponentFactory, ComponentFactoryResolver, ViewContainerRef, OnDestroy, Type } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs/Subscription';
import { componentMap } from './component-map';
import { Subject, Observable } from 'rxjs';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { OTScreenBase } from '@otscreen-base/ot-screen-base';
import { InboxFilter } from '@bpm-core/model/inboxfilter.model';
import { InboxService } from '@bpm-core/service/inbox.service';
import { DynamicComponentLoader } from '@otui/dynamic-component-loader/dynamic-component-loader.service';
import { WorkqueueItem } from '@bpm-core/model/workqueueitem.model';
import { OTUtilityService } from '@otcommon/service/utility.service';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-workqueue',
    templateUrl: './workqueue.component.html',
    styleUrls: ['./workqueue.component.css'],

})
export class WorkqueueComponent extends ListScreenBase<WorkqueueItem> implements OnInit, OnDestroy {

    @ViewChild('reviewComponent', { static: true, read: ViewContainerRef }) reviewComponent;
    startDateMax: Date;
    endDateMin: Date;

    componentRef: any;
    componentSubscription: Subscription;
    actionSubscription: Subscription;
    screenModeSubscription: Subscription;
    mainForm: FormGroup;
    inboxFilter = new InboxFilter();


    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: InboxService,
        public formBuilder: FormBuilder,
        public dynamicComponentLoader: DynamicComponentLoader,
        public utilityService: OTUtilityService
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (this.mainForm) {
            this.filter();
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [ { Caption: 'Workqueue', RouterLink: '/OverBpmDemoMain/Workqueue/Index' }];
    }

    createEmptyModel(): WorkqueueItem {
        return new WorkqueueItem();
    }

    createForm() {
        this.mainForm = this.formBuilder.group({
            Workqueue: new FormControl(),
            TaskType: new FormControl(),
            StartDate: new FormControl(),
            EndDate: new FormControl(),
            CustomerNo: new FormControl(),
        });
    }

    startDateChange($event) {
        this.endDateMin = new Date($event);
    }

    endDateChange($event) {
        this.startDateMax = new Date($event);
    }


    ngOnInit() {
        // Fill reference lists
        const d = new Date();
        d.setDate(d.getDate() - 30);
        super.ngOnInit();
        this.createForm();
        this.dataService.listWorkqueues();
        this.mainForm.patchValue({
            StartDate: d,
            EndDate: new Date(),
            TaskType: '1'
        });

        this.endDateMin = new Date(d);
        this.startDateMax = new Date();
    }

    filter() {
        this.inboxFilter = this.mainForm.value;
        this.dataService.filterWorkqueueItems(this.inboxFilter);
    }

    showReviewDialog(dataItem: WorkqueueItem) {
        this.clearComponent();
        const screenParts = dataItem.ScreenReference.split('#');
        if (screenParts.length === 3) {
           if (this.inboxFilter.TaskType === '1') {
            this.showActionDialog(dataItem, screenParts[0], screenParts[1], screenParts[2]);
           } else if (this.inboxFilter.TaskType === '2') {
            this.createReviewComponent(dataItem, 'TakeOn', screenParts[0], screenParts[1], screenParts[2] );
           } else {
            this.createReviewComponent(dataItem, null, screenParts[0], screenParts[1], screenParts[2] );
           }
        } else {
            this.messageService.warning('Screen Reference is not well-formatted. Screen Reference is:' + dataItem.ScreenReference );
        }
    }

    showActionDialog(dataItem: WorkqueueItem, moduleName: string, componentName: string, context: string) {
        this.actionSubscription = this.dataService.readActionInfo(dataItem.actionId).subscribe(actionInfo => {
            let childActions = actionInfo['Choices'].join(';');
            childActions = 'Release;' + childActions;
            this.createReviewComponent(dataItem, childActions, moduleName, componentName, context);
        });
    }

    createReviewComponent(dataItem: WorkqueueItem, childActions: string,  moduleName: string, componentName: string, context: string) {
        this.componentSubscription = this.dynamicComponentLoader
        .getComponentFactory(moduleName, componentMap[componentName])
        .subscribe(componentFactory => {
            this.componentRef = this.reviewComponent.createComponent(componentFactory);
            const screenRef = <OTScreenBase>this.componentRef._component;
            screenRef.modeDefault = false;
            screenRef.modeReview = true;
            screenRef.modeWorkqueue = true;
            screenRef.modeContext = { childActions: childActions, id: context, actionId: dataItem.ItemId };
            this.screenModeSubscription = screenRef.modeEvent.subscribe((data: any) => {
                this.refreshList();
            });
            this.componentRef.changeDetectorRef.detectChanges();
        }, error => {
            console.warn(error);
        });
    }
    clearComponent() {
        this.reviewComponent.clear();
        if (this.componentRef) {
            this.componentRef.destroy();
        }
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

    ngOnDestroy() {
        this.clearComponent();
    }

}
