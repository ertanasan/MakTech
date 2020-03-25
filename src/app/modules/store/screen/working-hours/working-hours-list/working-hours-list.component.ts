// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { WorkingHours } from '@store/model/working-hours.model';
import { WorkingHoursService } from '@store/service/working-hours.service';
import { WorkingHoursEditComponent } from '@store/screen/working-hours/working-hours-edit/working-hours-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { DatePipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-working-hours-list',
    templateUrl: './working-hours-list.component.html',
    styleUrls: ['./working-hours-list.component.css', ]
})
export class WorkingHoursListComponent extends ListScreenBase<WorkingHours> implements AfterViewInit, OnInit {
    @ViewChild(WorkingHoursEditComponent, { static: true }) editScreen: WorkingHoursEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: WorkingHoursService,
        public storeService: StoreService,
        public userService: UserService,
        public datePipe: DatePipe,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Working Hours', RouterLink: '/store/working-hours'}];
    }

    createEmptyModel(): WorkingHours {
        return new WorkingHours();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.userService.completeList) {
            this.userService.listAll();
        }
        if (!this.storeService.completeList) {
            this.storeService.listAll();
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
    onFileSelected(event) {
        this.dataService.loading = true;
        const formData = new FormData();
        formData.append('file[]', event.target.files[0]);
        this.dataService.loadWorkingHoursFile(formData)
            .pipe(finalize(() => {
                this.dataService.loading = false;
                event.target.value = '';
                this.refreshList();
            }))
            .subscribe(result => {
                if (!result || result === '') {
                    this.messageService.success('Veriler sisteme başarılı bir şekilde aktarıldı.');
                } else {
                    this.messageService.error(result.toString());
                }
            }, (error: HttpErrorResponse) => {
                this.messageService.error(error.error.text);
            }
        );

    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
