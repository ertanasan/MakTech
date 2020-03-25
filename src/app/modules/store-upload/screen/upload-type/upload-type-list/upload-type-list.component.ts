// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { UploadType } from '@store-upload/model/upload-type.model';
import { UploadTypeService } from '@store-upload/service/upload-type.service';
import { UploadTypeEditComponent } from '@store-upload/screen/upload-type/upload-type-edit/upload-type-edit.component';

/*Section="ClassHeader"*/
@Component({
  selector: 'ot-upload-type-list',
  templateUrl: './upload-type-list.component.html',
  styleUrls: ['./upload-type-list.component.css',
  ]
})
export class UploadTypeListComponent extends ListScreenBase<UploadType> implements AfterViewInit {
    @ViewChild(UploadTypeEditComponent, {static: true}) editScreen: UploadTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: UploadTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'StoreUpload' }, {Caption: 'Upload Type', RouterLink: '/store-upload/upload-type'}];
    }

    createEmptyModel(): UploadType {
        return new UploadType();
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
