import {Component, HostBinding, Input} from '@angular/core';

@Component({
    selector: 'ot-sidebar-nav',
    templateUrl: './ot-sidebar-nav.component.html',
    styleUrls: ['./ot-sidebar-nav.component.css']
})


export class OTSidebarNavComponent {

    @Input() navItems: Array<any>;
    @HostBinding('class.sidebar-nav') true;
    @HostBinding('attr.role') role;

    constructor() {
    }

    isDivider(navItem) {
        return !!navItem.divider;
    }

    isTitle(navItem) {
        return !!navItem.title;
    }

    isHasChild(navItem) {
        return navItem.hasOwnProperty('children') && navItem.children.length > 0;
    }

}
