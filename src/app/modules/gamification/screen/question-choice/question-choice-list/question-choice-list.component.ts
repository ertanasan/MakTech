// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { QuestionChoice } from '@gamification/model/question-choice.model';
import { QuestionChoiceService } from '@gamification/service/question-choice.service';
import { QuestionChoiceEditComponent } from '@gamification/screen/question-choice/question-choice-edit/question-choice-edit.component';
import { finalize } from 'rxjs/operators';
import { process } from '@progress/kendo-data-query';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-question-choice-list',
    templateUrl: './question-choice-list.component.html',
    styleUrls: ['./question-choice-list.component.css', ]
})
export class QuestionChoiceListComponent extends ListScreenBase<QuestionChoice> implements AfterViewInit {
    @ViewChild(QuestionChoiceEditComponent, {static: true}) editScreen: QuestionChoiceEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: QuestionChoiceService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.pipe(
                finalize(() => this.dataLoading = false)
            ).subscribe(
                list => {
                    this.dataList = process(list.Data, this.listParams);
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Gamification' }, {Caption: 'Question Choice', RouterLink: '/gamification/question-choice'}];
    }

    createEmptyModel(): QuestionChoice {
        return new QuestionChoice();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
