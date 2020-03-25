import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {ListScreenBase} from '@otscreen-base/list-screen-base';
import {OverStoreTask} from '@app-main/model/over-store-task.model';
import {OverStoreTaskType} from '@app-main/model/over-store-task-type.model';
import {GrowlMessageService} from '@otservice/growl-message.service';
import {TranslateService} from '@ngx-translate/core';
import {OTUtilityService} from '@otcommon/service/utility.service';
import {OverStoreTaskTypeService} from '@app-main/service/over-store-task-type.service';
import {MenuItem} from '@otuicontrol/menu/menuitem';
import {OverStoreTaskEditComponent} from '@app-main/screen/over-store-task/over-store-task-edit/over-store-task-edit.component';
import {OverStoreTaskTypeEditComponent} from '@app-main/screen/over-store-task-type/over-store-task-type-edit/over-store-task-type-edit.component';

@Component({
    selector: 'ot-over-store-task-type',
    templateUrl: './over-store-task-type-list.component.html',
    styleUrls: ['./over-store-task-type-list.component.scss']
})
export class OverStoreTaskTypeListComponent extends ListScreenBase<OverStoreTaskType> implements OnInit, AfterViewInit {
    @ViewChild('editScreen', {static: true}) editScreen: OverStoreTaskTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: OverStoreTaskTypeService,
    ) {
        super(messageService, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

  ngAfterViewInit() {
    this.editScreen.mainScreen = this;
    this.dialogs.push(this.editScreen);
  }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'OverStoreMain'}, {
            Caption: 'OverStoreTaskType',
            RouterLink: '/over-store-main/over-store-task-type-list'
        }];
    }

    createEmptyModel(): OverStoreTaskType {
        return new OverStoreTaskType();
    }

}
