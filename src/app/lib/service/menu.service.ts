import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { MenuItem } from '../ui/control/menu/menuitem';
import { Subject } from 'rxjs/Subject';

declare let mLayout: any;
@Injectable()
export class MenuService {

    menuLoaded = new Subject<any[]>();

    constructor(private httpClient: HttpClient) {
    }

    read() {
        this.httpClient.get<MenuItem>(environment.baseRoute + '/program/menu', { observe: 'body', responseType: 'json' })
            .subscribe(menu => {
                const menuItems = [];
                for (const firstLevelMenuItem of menu.Items) {
                    let moduleMenu;
                    if (firstLevelMenuItem.Items && firstLevelMenuItem.Items.length > 0) {
                        moduleMenu = {
                            name: firstLevelMenuItem.Caption,
                            url: firstLevelMenuItem.RouterLink && firstLevelMenuItem.RouterLink !== '' ? firstLevelMenuItem.RouterLink : `/${firstLevelMenuItem.Caption}`,
                            path: `/${firstLevelMenuItem.Caption}`,
                            icon: firstLevelMenuItem.Icon,
                            children: []
                        };
                        for (const secondLevelMenuItem of firstLevelMenuItem.Items) {
                            let secondLevelMenu;
                            if (secondLevelMenuItem.Items && secondLevelMenuItem.Items.length > 0) {
                                secondLevelMenu = {
                                    name: secondLevelMenuItem.Caption,
                                    url: secondLevelMenuItem.RouterLink && secondLevelMenuItem.RouterLink !== '' ? secondLevelMenuItem.RouterLink : `${moduleMenu.path}/${secondLevelMenuItem.Caption}`,
                                    path: `${moduleMenu.path}/${secondLevelMenuItem.Caption}`,
                                    icon: secondLevelMenuItem.Icon,
                                    children: []
                                };
                                for (const thirdLevelMenuItem of secondLevelMenuItem.Items) {
                                    const thirdLevelMenu = {
                                        name: thirdLevelMenuItem.Caption,
                                        url: thirdLevelMenuItem.RouterLink && thirdLevelMenuItem.RouterLink !== '' ? thirdLevelMenuItem.RouterLink : `${secondLevelMenu.path}/${thirdLevelMenuItem.Caption}`,
                                        path: `${secondLevelMenu.path}/${thirdLevelMenuItem.Caption}`,
                                        icon: thirdLevelMenuItem.Icon
                                    };
                                    secondLevelMenu.children.push(thirdLevelMenu);
                                }
                            } else {
                                secondLevelMenu = {
                                    name: secondLevelMenuItem.Caption,
                                    url: secondLevelMenuItem.RouterLink && secondLevelMenuItem.RouterLink !== '' ? secondLevelMenuItem.RouterLink : `${moduleMenu.path}/${secondLevelMenuItem.Caption}`,
                                    path: `${moduleMenu.path}/${secondLevelMenuItem.Caption}`,
                                    icon: secondLevelMenuItem.Icon || 'fa fa-circle'
                                };
                            }
                            moduleMenu.children.push(secondLevelMenu);
                        }
                    } else {
                        moduleMenu = {
                            name: firstLevelMenuItem.Caption,
                            url: firstLevelMenuItem.RouterLink && firstLevelMenuItem.RouterLink !== '' ? firstLevelMenuItem.RouterLink : `/${firstLevelMenuItem.Caption}`,
                            path: `/${firstLevelMenuItem.Caption}`,
                            icon: firstLevelMenuItem.Icon
                        };
                    }
                    menuItems.push(moduleMenu);
                }
                this.menuLoaded.next(menuItems.slice());
            });
    }

    readForMetronic() {
        this.httpClient.get<MenuItem>(environment.baseRoute + '/program/menu', { observe: 'body', responseType: 'json' })
            .subscribe(menu => {
                const menuItems = [];
                for (const firstLevelMenuItem of menu.Items) {
                    let moduleMenu;
                    if (firstLevelMenuItem.Items && firstLevelMenuItem.Items.length > 0) {
                        if ( firstLevelMenuItem.RouterLink && firstLevelMenuItem.RouterLink !== '' ) {
                            moduleMenu = {
                                title: firstLevelMenuItem.Caption,
                                page: firstLevelMenuItem.RouterLink ,
                                // bullet: 'dot',
                                icon: firstLevelMenuItem.Icon,
                            };
                        } else {
                            moduleMenu = {
                                title: firstLevelMenuItem.Caption,
                                root: true,
                                page: `/${firstLevelMenuItem.Caption}`,
                                // bullet: 'dot',
                                icon: firstLevelMenuItem.Icon,
                                submenu: []
                            };
                        }
                        for (const secondLevelMenuItem of firstLevelMenuItem.Items) {
                            let secondLevelMenu;
                            if (secondLevelMenuItem.Items && secondLevelMenuItem.Items.length > 0) {
                                secondLevelMenu = {
                                    title: secondLevelMenuItem.Caption,
                                    page: secondLevelMenuItem.RouterLink && secondLevelMenuItem.RouterLink !== '' ? secondLevelMenuItem.RouterLink : `${moduleMenu.path}/${secondLevelMenuItem.Caption}`,
                                    // bullet: 'dot',
                                    // page: `${moduleMenu.path}/${secondLevelMenuItem.Caption}`,
                                    icon: secondLevelMenuItem.Icon,
                                    submenu: []
                                };
                                for (const thirdLevelMenuItem of secondLevelMenuItem.Items) {
                                    const thirdLevelMenu = {
                                        title: thirdLevelMenuItem.Caption,
                                        page: thirdLevelMenuItem.RouterLink && thirdLevelMenuItem.RouterLink !== '' ? thirdLevelMenuItem.RouterLink : `${secondLevelMenu.path}/${thirdLevelMenuItem.Caption}`,
                                        // page: `${secondLevelMenu.path}/${thirdLevelMenuItem.Caption}`,
                                        icon: thirdLevelMenuItem.Icon
                                    };
                                    secondLevelMenu.submenu.push(thirdLevelMenu);
                                }
                            } else {
                                secondLevelMenu = {
                                    title: secondLevelMenuItem.Caption,
                                    page: secondLevelMenuItem.RouterLink && secondLevelMenuItem.RouterLink !== '' ? secondLevelMenuItem.RouterLink : `${moduleMenu.path}/${secondLevelMenuItem.Caption}`,
                                    // page: `${moduleMenu.path}/${secondLevelMenuItem.Caption}`,
                                    icon: secondLevelMenuItem.Icon || 'fa fa-circle'
                                };
                            }
                            moduleMenu.submenu.push(secondLevelMenu);
                        }
                    } else {
                        moduleMenu = {
                            title: firstLevelMenuItem.Caption,
                            page: firstLevelMenuItem.RouterLink && firstLevelMenuItem.RouterLink !== '' ? firstLevelMenuItem.RouterLink : `/${firstLevelMenuItem.Caption}`,
                            // path: `/${firstLevelMenuItem.Caption}`,
                            icon: firstLevelMenuItem.Icon
                        };
                    }
                    menuItems.push(moduleMenu);
                }
                this.menuLoaded.next(menuItems.slice());
            });
    }
}
