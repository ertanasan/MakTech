import { Component, OnInit, Input, TemplateRef, ContentChild, EventEmitter, Output, Self, Optional, Host } from '@angular/core';
import { NgControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { SearchService } from '@otservice/search-service.interface';

@Component({
    selector: 'ot-auto-complete-entry',
    templateUrl: './auto-complete-entry.component.html',
    styleUrls: ['./auto-complete-entry.component.css'],
})
export class AutoCompleteEntryComponent extends DataEntryBase<number> implements OnInit {
    @Input() dataList: any[] | Observable<any[]>;
    @Input() textField: string;
    @Input() valueField: string;
    @Input() searchService: SearchService;
    @Input() minimumFilterLength = 0;
    @Input() manualMode = false;
    @Input() searchAction = 'Search';

    @Output() onFilterChanged: EventEmitter<string> = new EventEmitter();

    @ContentChild('itemTemplate', { static: true }) itemTemplate: TemplateRef<any>;
    @ContentChild('noDataTemplate', { static: true }) noDataTemplate: TemplateRef<any>;
    @ContentChild('shortFilterTemplate', { static: true }) shortFilterTemplate: TemplateRef<any>;
    emptyDataTemplate: TemplateRef<any>;

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    filterChanged(value: string) {

        if (value.length >= this.minimumFilterLength) {
            if (this.manualMode) {
                this.onFilterChanged.emit(value);
                return;
            } else {
                if (!this.searchService) {
                    return;
                }
                const filter = {};
                filter['key'] = this.textField;
                filter['value'] = value;
                this.searchService.search([filter], this.searchAction);
                this.emptyDataTemplate = this.noDataTemplate;
            }
        } else {
            if (!this.manualMode) {
                this.searchService.activeList = { data: [], total: 0 };
                this.emptyDataTemplate = this.shortFilterTemplate;
            }
        }
    }

    valueChanged(value: any) {
        // this.value = value[this.valueField];
        console.log('AutoCompleteEntryComponent.valueChanged', value);
        // let valueObject = this.searchService.searchResult.find(i => i[this.textField] == value);
        // if (valueObject) {
        //   this.value = valueObject[this.valueField];
        // }
    }

}
