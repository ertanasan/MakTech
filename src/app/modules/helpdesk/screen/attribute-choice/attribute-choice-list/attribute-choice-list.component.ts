// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { AttributeChoice } from '@helpdesk/model/attribute-choice.model';
import { AttributeChoiceService } from '@helpdesk/service/attribute-choice.service';
import { AttributeChoiceEditComponent } from '@helpdesk/screen/attribute-choice/attribute-choice-edit/attribute-choice-edit.component';
import { finalize } from 'rxjs/operators';
import { process } from '@progress/kendo-data-query';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-attribute-choice-list',
    templateUrl: './attribute-choice-list.component.html',
    styleUrls: ['./attribute-choice-list.component.css', ]
})
export class AttributeChoiceListComponent extends ListScreenBase<AttributeChoice> implements AfterViewInit {
    @ViewChild(AttributeChoiceEditComponent, {static: true}) editScreen: AttributeChoiceEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: AttributeChoiceService,
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
                    this.dataService.activeList.data = list.Data;
                    this.dataService.activeList.total = list.Total;
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Attribute Choice', RouterLink: '/helpdesk/attribute-choice'}];
    }

    createEmptyModel(): AttributeChoice {
        const model = new AttributeChoice();
        model.Attribute = this.masterId;
        return model;
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
