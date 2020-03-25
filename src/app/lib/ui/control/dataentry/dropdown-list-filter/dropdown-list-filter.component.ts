import { Component, Input, EventEmitter, Output } from '@angular/core';

import { CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { FilterService, BaseFilterCellComponent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'ot-dropdown-list-filter',
    templateUrl: './dropdown-list-filter.component.html'
})
export class DropdownListFilterComponent extends BaseFilterCellComponent {


    @Input() filter: CompositeFilterDescriptor;
    @Input() data: any[];
    @Input() textField: string;
    @Input() valueField: string;
    @Input() memberField: string;
    @Input() itemFilter = true;
    selectedValue: number = null;
    @Output() valueChange: EventEmitter<any> = new EventEmitter();

    constructor(filterService: FilterService,
                public translateService: TranslateService) {
        super(filterService);
    }

    public filterSettings: DropDownFilterSettings = {
        caseSensitive: false,
        operator: 'contains'
    };

    public get defaultItem(): any {
        return {
            [this.textField]: this.translateService.instant('Select item...'),
            [this.valueField]: null
        };
    }

    public onChange(value: any): void {
        this.selectedValue = value;
        this.applyFilter(
            value === null ? // value of the default item
                this.removeFilter(this.memberField) : // remove the filter
                this.updateFilter({ // add a filter for the field with the value
                    field: this.memberField,
                    operator: 'eq',
                    value: value
                })
        ); // update the root filter
        this.valueChange.emit(value);

    }
}
