// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { GroupUser } from '@security/model/group-user.model';
import { GroupUserService } from '@security/service/group-user.service';
import { GroupUserEditComponent } from '@security/screen/group-user/group-user-edit/group-user-edit.component';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { Group } from '@security/model/group.model';
import { GroupService } from '@security/service/group.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-group-user-list',
    templateUrl: './group-user-list.component.html',
    styleUrls: ['./group-user-list.component.css']
})
export class GroupUserListComponent extends ListScreenBase<GroupUser> implements AfterViewInit, OnInit {
    @ViewChild(GroupUserEditComponent, { static: true }) editScreen: GroupUserEditComponent;
    @Input() organization: number;
    public groupList: Group[] = [];
    public userList: User[] = [];
    public activeUsers: User[] = [];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: GroupUserService,
        public groupService: GroupService,
        public userService: UserService,
        public groupUserService: GroupUserService
    ) {
        super(messageService, translateService);
        this.updateEnabled = false;
    }

    refreshList() {
        this.listParams.queryParams.clear();
        this.listParams.queryParams.set('leftId', this.leftRelationId);
        this.listParams.queryParams.set('rightId', this.rightRelationId);
        this.dataLoading = true;
        this.dataService.listAsync(this.listParams).subscribe(
            listResult => {
                listResult.Data.forEach(data => {
                    this.userService.read(data.User).subscribe(u => { data.EMail = u.EMail; });
                });
                this.dataList = listResult.Data;
                this.dataLoading = false;
            },
            error => {
                this.dataLoading = false;
                this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
            }
        );

        if (!this.leftRelationId) {
            if (this.organization) {
                this.groupService.listByOrganization(this.organization).subscribe(result => {
                    this.groupList = result;
                });
            } else {
                this.groupService.listAllAsync().subscribe(result => {
                    this.groupList = result;
                });
            }
        }
        if (!this.rightRelationId) {
            if (this.organization) {
                this.userService.listByOrganization(this.organization, this.leftRelationId).subscribe(user => {
                    this.listParams.queryParams.clear();
                    this.listParams.queryParams.set('leftId', this.leftRelationId);
                    this.listParams.queryParams.set('rightId', this.rightRelationId);
                    this.groupUserService.listAsync(this.listParams).subscribe(groupUser => {
                        this.userList = user;

                        for (let i = 0; i < groupUser.Data.length; i++) {
                            for (let j = 0; j < user.length; j++) {
                                if (groupUser.Data[i].User === user[j].UserId) {
                                    this.activeUsers.push(user[j]);
                                    this.userList.splice(user.indexOf(user[j]), 1);
                                }
                            }
                        }
                    });

                });
            } else {
                this.userService.listAllAsync().subscribe(result => {
                    this.userList = result;
                });
            }
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Security' }, { Caption: 'Group User', RouterLink: '/security/group-user' }];
    }

    createEmptyModel(): GroupUser {
        const groupUser = new GroupUser();
        if (this.leftRelationId > 0) {
            groupUser.Group = this.leftRelationId;
        }
        if (this.rightRelationId > 0) {
            groupUser.User = this.rightRelationId;
        }
        return groupUser;
    }

    ngOnInit() {
        // Fill reference lists
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    // tslint:disable-next-line:member-ordering
    @Input() minimumUserCount = 0;

    getUserCount() {
        return (<GroupUser[]>this.dataList).length;
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
