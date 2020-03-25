import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';

import { TreeViewComponent } from '@progress/kendo-angular-treeview';

@Component({
    selector: 'ot-tree-list',
    templateUrl: './tree-list.component.html',
    styleUrls: ['./tree-list.component.css']
})
export class TreeListComponent implements OnInit {
    private MAX_LEVEL = 10;

    @Input() nodes = [];
    @Input() textField: string;
    @Input() childrenField: string;
    @Input() checkable: any = true;
    @Input() selectable: any = true;
    @Input() multiple = true;

    @Output() checkedChange: EventEmitter<any[]> = new EventEmitter();

    checkedKeys = [];
    public checkedNodes = [];

    constructor() { }

    ngOnInit() {
    }

    handleCheckChange(event: string[]) {
        this.checkedKeys = event;
        this.checkedNodes = [];
        // Split locator with _ and use these as indices
        event.forEach(item => {
            const locators = item.split('_').map(i => +i);
            this.checkedNodes.push(this.findNode(this.nodes, locators, 1));
        });

        this.checkedChange.emit(this.checkedNodes);
    }
    private findNode(nodes: any[], locators: number[], level: number): any {
        if (level > this.MAX_LEVEL) {
            throw Error('Maximum recursion exceed for the tree list.');
        }
        if (locators.length === 1) {
            return nodes[locators[0]];
        }
        return this.findNode(nodes[locators[0]][this.childrenField], locators.slice(1), level + 1);
    }

    public clear() {
        this.checkedKeys = [];
        this.checkedNodes = [];
    }

}
