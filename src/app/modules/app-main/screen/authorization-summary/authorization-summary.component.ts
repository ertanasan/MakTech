import { Component, OnInit } from '@angular/core';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { UserService } from '@frame/security/service/user.service';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticationSummaryService } from '@app-main/service/authentication-summary.service';

@Component({
  selector: 'ot-authorization-summary',
  templateUrl: './authorization-summary.component.html',
  styleUrls: ['./authorization-summary.component.css']
})
export class AuthorizationSummaryComponent extends MainScreenBase implements OnInit {
  queryBy = 'Screen';
  public programList = [];
  public allScreenList = [];
  public allUserList = [];
  public screenList = [];
  public userList = [];
  selectedProgramId: any;
  selectedUserId: any;
  selectedScreenId: any;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public dataService: AuthenticationSummaryService,
    ) {
      super(messageService, translateService);
    }

  getBreadcrumbItems(): MenuItem[] {
    return [{Caption: 'Warehouse' }, {Caption: 'Authorization Summary', RouterLink: '/app-main/authorization-summary'}];
  }

  createEmptyItem() {
      throw new Error('Method not suported.');
  }

  refreshData() {
    switch (this.queryBy) {
      case 'User': {
        this.getScreenList(this.selectedUserId, this.selectedProgramId);
        break;
      }
      case 'Screen' : {
        this.getUserList(this.selectedScreenId, this.selectedProgramId);
        break;
      }
    }
  }

  getScreenList(userId, programId) {
    this.dataService.listScreens(userId, programId).subscribe(
      result => {
        // -1: for get all records (dropboxItems),  other values for get grid data
        userId === -1 ? this.allScreenList = result.Data : this.screenList = result.Data;
      }, error => {
        this.messageService.error(this.translateService.instant('Screen List cannot be retrieved'));
    });
  }

  getUserList(screenId, programId) {
    this.dataService.listUsers(screenId, programId).subscribe(
      result => {
        // -1: for get all records (dropboxItems),  other values for get grid data
        screenId === -1 ? this.allUserList = result.Data : this.userList = result.Data;
      }, error => {
        this.messageService.error(this.translateService.instant('User List cannot be retrieved'));
    });
  }

  ngOnInit() {
    this.dataService.listAllPrograms().subscribe(
      result => {
        this.programList = result.Data;
        this.selectedProgramId = result.Data.filter( p => p.PROGRAM_NM === 'OverStore Portal' )[0].PROGRAMID;
        this.getScreenList(-1, this.selectedProgramId);
        this.getUserList(-1, this.selectedProgramId);
      }, error => {
        this.messageService.error(this.translateService.instant('Program List cannot be retrieved'));
    });
    super.ngOnInit();
  }
}
