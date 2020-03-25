// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { PackageVersion } from '@price/model/package-version.model';
import { PackageVersionService } from '@price/service/package-version.service';
import { PackageVersionEditComponent } from '@price/screen/package-version/package-version-edit/package-version-edit.component';
import { UserService } from '@frame/security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-package-version-list',
    templateUrl: './package-version-list.component.html',
    styleUrls: ['./package-version-list.component.css', ]
})
export class PackageVersionListComponent extends ListScreenBase<PackageVersion> implements AfterViewInit {
    @ViewChild(PackageVersionEditComponent, {static: true}) editScreen: PackageVersionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: PackageVersionService,
        public userService: UserService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.subscribe(
                list => {
                    this.dataList = JSON.parse(JSON.stringify(list));
                    this.dataList = [];
                    let add = true;
                    list.forEach(r => {
                        if (!r.ActiveFlag && add) {
                            r.UpdateEnabled = true;
                            (<PackageVersion[]>this.dataList).push(r);
                            add = false;
                        } else if (r.ActiveFlag) {
                            r.UpdateEnabled = false;
                            (<PackageVersion[]>this.dataList).push(r);
                            add = false;
                        }
                    });
                    this.dataLoading = false;
                },
                error => {
                    this.dataLoading = false;
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Price' }, {Caption: 'Package Version', RouterLink: '/price/package-version'}];
    }

    createEmptyModel(): PackageVersion {
        return new PackageVersion();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
        // this.createEnabled = false;
        // this.readEnabled = false;
        // this.deleteEnabled = false;
    }

}
