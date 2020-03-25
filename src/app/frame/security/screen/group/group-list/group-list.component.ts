// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Group } from '@security/model/group.model';
import { GroupService } from '@security/service/group.service';
import { GroupEditComponent } from '@security/screen/group/group-edit/group-edit.component';
import { Organization } from '@organization/model/organization.model';
import { OrganizationService } from '@organization/service/organization.service';
import { ActivatedRoute } from '@angular/router';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-group-list',
    templateUrl: './group-list.component.html',
    styleUrls: ['./group-list.component.css', ]
})
export class GroupListComponent extends ListScreenBase<Group> implements AfterViewInit, OnInit {
    @ViewChild(GroupEditComponent, {static: true}) editScreen: GroupEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: GroupService,
        public organizationService: OrganizationService,
        private route: ActivatedRoute
    ) {
        super(messageService, translateService);
        if (route.snapshot.data['isViewOnly']) {
            this.isViewOnly = true;
        }
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Security' }, {Caption: 'Group', RouterLink: '/security/group'}];
    }

    createEmptyModel(): Group {
        return new Group();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.organizationService.completeList) {
            this.organizationService.listAll();
        }
        super.ngOnInit();
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
