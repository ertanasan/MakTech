import { Component, OnInit, ContentChildren, QueryList } from '@angular/core';
import { TabPageComponent } from '../tab-page/tab-page.component';

@Component({
    selector: 'ot-tab-strip',
    templateUrl: './tab-strip.component.html',
    styleUrls: ['./tab-strip.component.css']
})
export class TabStripComponent implements OnInit {
    @ContentChildren(TabPageComponent) tabPages: QueryList<TabPageComponent>;

    constructor() { }

    ngOnInit() {
    }

    selectTab(tab: TabPageComponent) {
        // // deactivate all tabs
        // this.tabPages.forEach(tab => tab.active = false);

        // // activate the tab the user has clicked on.
        // tab.active = true;
    }

}
