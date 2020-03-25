// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Suggestion } from '@announcement/model/suggestion.model';
import { SuggestionService } from '@announcement/service/suggestion.service';
import { SuggestionStatusService } from '@announcement/service/suggestion-status.service';
import { SuggestionTypeService } from '@announcement/service/suggestion-type.service';
import { UserService } from '@frame/security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-suggestion-edit',
    templateUrl: './suggestion-edit.component.html',
    styleUrls: ['./suggestion-edit.component.css', ]
})
export class SuggestionEditComponent extends CRUDDialogScreenBase<Suggestion> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Suggestion>;
    suggestionTextEditable = true;
    suggestionStatusVisible = false;
    suggestionTypeEditable = false;
    suggestionRatingEditable = false;
    suggestionRatingOnlyVisible = false;
    suggestionPreviousCommentVisible = false;
    suggestionActionCommentEnable = false;
    previousActionCommentCaption = 'Evaluator Note';


    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: SuggestionService,
        public suggestionStatusService: SuggestionStatusService,
        public suggestionTypeService: SuggestionTypeService,
        public userService: UserService,
    ) {
        super(messageService, translateService, dataService, 'Suggestion');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SuggestionId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            SuggestionText: new FormControl(),
            ProcessInstance: new FormControl(),
            BranchName: new FormControl(),
            Status: new FormControl(),
            Type: new FormControl(),
            InnovativenessRating: new FormControl(),
            FeasibilityRating: new FormControl(),
            AddedValueRating: new FormControl(),
            PreviousActionComment: new FormControl(),
            ActionComment: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        if (this.container.actionName === 'Create') {
            this.container.currentItem.Status = 3;
        } else {
            this.container.currentItem.actionComment = this.container.form.value.ActionComment;
        }
        super.onSubmit();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
