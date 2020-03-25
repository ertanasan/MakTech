// Angular
import { ChangeDetectorRef, Component, ElementRef, Input, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { MenuService } from '@otservice/menu.service';
import { Router } from '@angular/router';
import { NgbDropdown } from '@ng-bootstrap/ng-bootstrap';
import { staticViewQueryIds } from '@angular/compiler';

@Component({
	selector: 'kt-search-dropdown',
	templateUrl: './search-dropdown.component.html',
})
export class SearchDropdownComponent implements OnInit, OnDestroy {
	// Public properties

	// Set icon class name
	@Input() icon = 'flaticon2-search-1';

	// Set true to icon as SVG or false as icon class
	@Input() useSVG: boolean;

	@Input() type: 'brand' | 'success' | 'warning' = 'success';

	@ViewChild('searchInput', { static: true }) searchInput: ElementRef;

	@ViewChild(NgbDropdown, { static: true }) dropdown: NgbDropdown;

	menuItems = [];
	data: any[];
	result: any[];
	loading: boolean;
	private unsubscribe: Subscription[] = []; // Read more: => https://brianflove.com/2016/12/11/anguar-2-unsubscribe-observables/
	/**
	 * @ Lifecycle sequences => https://angular.io/guide/lifecycle-hooks
	 */

	constructor(private cdr: ChangeDetectorRef, private menuService: MenuService, private router: Router) {
		const menuSubscription = this.menuService.menuLoaded.subscribe(
			(items: any[]) => {
				this.menuItems = items;
			}
		);

		this.unsubscribe.push(
			router.events.subscribe(e => {
				this.dropdown.close();
			})
		);

		this.unsubscribe.push(menuSubscription);
	}

	ngOnDestroy(): void {
		this.unsubscribe.forEach(sb => sb.unsubscribe());
	}

	/**
	 * On init
	 */
	ngOnInit(): void {
		// simulate result from API
		// type 0|1 as separator or item
	}

	/**
	 * Search
	 * @param e: Event
	 */
	search(e) {
		this.data = [];
		if (e.target.value.length > 2) {
			this.loading = true;
			for (const menuItem of this.menuItems) {
				this.data = this.data.concat(this.searchMenuItem(menuItem, e.target.value));
			}
			this.loading = false;
			this.cdr.markForCheck();
		}
	}

	searchMenuItem(menuItem: any, phrase: string): any[] {
		let result = [];
		if (menuItem.submenu) {
			const subMenuResult = this.searchSubMenu(menuItem.submenu, phrase);
			if (subMenuResult.length > 0) {
				const resultItem = {
					text: menuItem.title,
					type: 0
				};
				result.push(resultItem);
			}
			result = result.concat(subMenuResult);
		}
		return result;
	}

	searchSubMenu(subMenu: any[], phrase: string): any[] {
		let result = [];
		for (const value of subMenu) {
			if ((<string>value.title.toLowerCase()).includes(phrase.toLowerCase())) {
				const resultItem = {
					icon: `<i class="${value.icon}" kt-font-primary>`,
					text: value.title,
					type: 1,
					page: value.page
				};
				result.push(resultItem);
			}
			if (value.submenu) {
				const subResult = this.searchSubMenu(value.submenu, phrase);
				result = result.concat(subResult);
			}
		}
		return result;
	}

	/**
	 * Clear search
	 *
	 * @param e: Event
	 */
	clear(e) {
		this.data = null;
		this.searchInput.nativeElement.value = '';
	}

	openChange() {
		setTimeout(() => this.searchInput.nativeElement.focus());
	}
}
