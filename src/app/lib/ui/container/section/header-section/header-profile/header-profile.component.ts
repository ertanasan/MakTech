
import { take } from 'rxjs/operators';
import { Component, OnInit, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromApp from '@otlib/store/app.reducers';
import * as fromAuth from '@otlib/auth/store/auth.reducers';
import * as AuthActions from '@otlib/auth/store/auth.actions';

@Component({
    selector: '.ot-header-profile',
    templateUrl: './header-profile.component.html',
    styleUrls: ['./header-profile.component.css']
})
export class HeaderProfileComponent implements OnInit {

    authState: Observable<fromAuth.State>;
    userFullName: string;
    userEmail: string;
    gender: string;
    public userName: string;
    @Input() mainModule: string;
    constructor(private store: Store<fromApp.AppState>) { }

    ngOnInit() {
        this.store.select('auth').pipe(take(1)).subscribe((authState: fromAuth.State) => {
            this.userFullName = authState.userFullName;
            this.userEmail = authState.userEmail;
            this.userName = authState.userName;
            this.gender = authState.gender;
        });
    }

    onLogout() {
        this.store.dispatch(new AuthActions.Logout());
    }

}
