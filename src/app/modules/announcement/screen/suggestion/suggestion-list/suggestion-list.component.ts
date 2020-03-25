// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Subscription, Observable } from 'rxjs';
import { finalize, first } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { UserService } from '@frame/security/service/user.service';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';

import { Suggestion } from '@announcement/model/suggestion.model';
import { SuggestionService } from '@announcement/service/suggestion.service';
import { SuggestionEditComponent } from '@announcement/screen/suggestion/suggestion-edit/suggestion-edit.component';
import { SuggestionStatusService } from '@announcement/service/suggestion-status.service';
import { SuggestionTypeService } from '@announcement/service/suggestion-type.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { OTContext } from '@otlib/auth/model/context.model';
import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import { ProcessHistoryComponent } from '@app-main/screen/process-history/process-history.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-suggestion-list',
    templateUrl: './suggestion-list.component.html',
    styleUrls: ['./suggestion-list.component.css', ]
})
export class SuggestionListComponent extends ListScreenBase<Suggestion> implements OnInit, AfterViewInit {
    @ViewChild(SuggestionEditComponent, {static: true}) editScreen: SuggestionEditComponent;
    // @ViewChild(SuggestionHistoryComponent, {static: true}) historyScreen: SuggestionHistoryComponent;
    @ViewChild(ProcessHistoryComponent, {static: true}) historyScreen: ProcessHistoryComponent;

    routerSubscription: Subscription;
    private fromTheme = false;
    public suggestionAdmin = false;
    public printList: any[];
    public contextState$: Observable<OTContext>;
    public contextInfo: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        private route: ActivatedRoute,
        public utilityService: OTUtilityService,
        public dataService: SuggestionService,
        public userService: UserService,
        private privilegeCacheService: PrivilegeCacheService,
        public suggestionStatusService: SuggestionStatusService,
        public suggestionTypeService: SuggestionTypeService,
        private store: Store<fromApp.AppState>,
    ) {
        super(messageService, translateService);
        this.translateService.setDefaultLang('tr');
        this.allData = this.allData.bind(this);
        this.routerSubscription = this.route.params.subscribe(
            params => {
                if (params.from === 'theme') {
                    this.fromTheme = true;
                }
            }
        );
        this.contextState$ = this.store.select('context');
    }

    refreshList() {
        this.listParams.queryParams.set('suggestionAdmin', this.suggestionAdmin);
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Announcement' }, {Caption: 'Suggestion', RouterLink: '/announcement/suggestion'}];
    }

    createEmptyModel(): Suggestion {
        const model = new Suggestion();
        model.CreateUser = this.contextInfo.User.Id;
        return model;
    }

    ngOnInit() {
        this.readEnabled = true;
        this.suggestionStatusService.listAll();
        this.suggestionTypeService.listAll();
        this.userService.listAll();
        setTimeout(() => {
            this.privilegeCacheService.checkPrivilege('ANN-ListAll Suggestion').subscribe(
                result => {
                    this.suggestionAdmin = result;
                    this.listParams.queryParams.set('suggestionAdmin', this.suggestionAdmin);
                    this.listParams.take = 1000;
                    this.dataService.listAsync(this.listParams).pipe(
                        finalize(() => super.ngOnInit())
                        ).subscribe(list => {
                            this.printList = list.Data;
                            this.printList.forEach(row => {
                                const createUser = this.userService.completeList.filter(r => r.UserId === row.CreateUser);
                                if (createUser.length) {
                                    row.CreateUser = createUser[0].UserFullName;
                                }
                            });
                            this.listParams.take = 10;
                    });
            });
        }, 10);

        this.contextState$.pipe(first()).subscribe(
            context => {
                this.contextInfo = context;
            }
        );
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
        if (this.fromTheme) {
            this.showDialog(this.editScreen, 'Create');
        }

        if (this.modeReview && !this.isEmbedded) {
            const suggestionId = this.modeContext.id;
            this.dataService.read(suggestionId).subscribe(suggestion => {
                this.editScreen.modeContext = this.modeContext;
                this.editScreen.modeReview = true;
                const dataItem = Object.assign(this.createEmptyItem(), suggestion);
                this.showDialog(this.editScreen, 'Review', dataItem );
            });
        }
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any)  {
        if (actionName === 'ShowHistory') {
            // this.dataService.GetHistoryData(dataItem.SuggestionId).subscribe(
            //     result => {
            //         if (result.length) {
            //             this.historyScreen.title = this.getNamePipe.transform(dataItem.CreateUser, 'UserId', 'UserFullName', this.userService.completeList) + ' (' + dataItem.SuggestionId.toString() + ') ' + this.translateService.instant('Action History');
            //             this.historyScreen.historyData = result;
            //             this.historyScreen.processStatus = this.getNamePipe.transform(result[0].ProcessStatusCode, 'value', 'text', this.processStatus);
            //             this.historyScreen.suggestionStatus = this.getNamePipe.transform(dataItem.Status, 'SuggestionStatusId', 'StatusName', this.suggestionStatusService.completeList);
            //             this.historyScreen.dialog.show();
            //         } else {
            //             this.messageService.warning(this.translateService.instant('No history record found'));
            //         }
            //     }, error => {
            //         this.messageService.error(this.translateService.instant('An error occurred while getting history records'));
            //     }
            // );
            // return;
            this.historyScreen.ProcessInstanceId = dataItem.ProcessInstance;
            this.historyScreen.dialog.show();
        } else if (actionName === 'Create') {
            this.editScreen.suggestionTextEditable = true;
            this.editScreen.suggestionRatingEditable = false;
            this.editScreen.suggestionTypeEditable = false;
            this.editScreen.suggestionRatingOnlyVisible = false;
            this.editScreen.suggestionPreviousCommentVisible = false;
            this.editScreen.suggestionActionCommentEnable = false;
            this.editScreen.suggestionStatusVisible = false;
            super.showDialog(target, actionName);
        } else if (actionName === 'Read') {
            this.editScreen.suggestionTextEditable = false;
            this.editScreen.suggestionRatingEditable = false;
            this.editScreen.suggestionTypeEditable = false;
            this.editScreen.suggestionRatingOnlyVisible = false;
            this.editScreen.suggestionPreviousCommentVisible = dataItem.Status >= 2 && dataItem.PreviousActionComment !== null;
            this.editScreen.suggestionActionCommentEnable = false;
            this.editScreen.previousActionCommentCaption = this.translateService.instant(dataItem.Status === 3 ? 'Suggestion User Note' : 'Evaluator Note');
            this.editScreen.suggestionStatusVisible = dataItem.Status > 1;
            super.showDialog(target, actionName, dataItem);
        } else {
            this.editScreen.suggestionTextEditable = dataItem.Status <= 2;
            this.editScreen.suggestionRatingEditable = this.suggestionAdmin || (this.editScreen.modeContext && dataItem.Status === 3);
            this.editScreen.suggestionTypeEditable = this.suggestionAdmin || (this.editScreen.modeContext && dataItem.Status === 3);
            this.editScreen.suggestionRatingOnlyVisible = dataItem.Status > 3;
            this.editScreen.suggestionPreviousCommentVisible = dataItem.Status >= 2 && dataItem.PreviousActionComment !== null;
            this.editScreen.previousActionCommentCaption = this.translateService.instant(dataItem.Status === 3 ? 'Suggestion User Note' : 'Evaluator Note');
            this.editScreen.suggestionActionCommentEnable = this.editScreen.modeContext && dataItem.Status >= 2 && dataItem.Status <= 3;
            this.editScreen.suggestionStatusVisible = dataItem.Status > 1;
            super.showDialog(target, actionName, dataItem);
        }
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['CreateDate', 'UpdateDate'];
        super.handleDataStateChange(state);
    }

    allData() {
        return { data: this.printList, total: this.printList.length };
    }
    //#endregion Customized


    /*Section="ClassFooter"*/
}
