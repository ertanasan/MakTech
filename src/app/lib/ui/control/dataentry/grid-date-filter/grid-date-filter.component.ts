import { Component, OnInit, Input } from '@angular/core';
import { BaseFilterCellComponent, FilterService } from '@progress/kendo-angular-grid';
import { CompositeFilterDescriptor } from '@progress/kendo-data-query';

@Component({
    selector: 'ot-grid-date-filter',
    templateUrl: './grid-date-filter.component.html',
    styleUrls: ['./grid-date-filter.component.scss']
})
export class GridDateFilterComponent extends BaseFilterCellComponent implements OnInit {

    @Input() public filter: CompositeFilterDescriptor;

    @Input() public field: string;

    constructor(filterService: FilterService) {
        super(filterService);
    }

    ngOnInit() {
    }
    public get hasFilter(): boolean {
        return this.filtersByField(this.field).length > 0;
    }

    public clearFilter(): void {
        this.filterService.filter(
            this.removeFilter(this.field)
        );
    }
    public filterRange(start: Date): void {
        this.filter = this.removeFilter(this.field);

        const filters = [];
        start.setHours(start.getHours() + 3);
        if (start) {
            filters.push({
                field: this.field,
                operator: 'gte',
                value: start
            });

            const end = new Date(start);
            end.setDate(end.getDate() + 1);
            if (end) {
                filters.push({
                    field: this.field,
                    operator: 'lte',
                    value: end
                });
            }
            const root = this.filter || {
                logic: 'and',
                filters: []
            };

            if (filters.length) {
                root.filters.push(...filters);
            }

            this.filterService.filter(root);
        }

    }

}
