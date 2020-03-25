import { Component, OnInit } from '@angular/core';
import { AlertService } from '../service/index';

@Component({
    selector: 'app-alert',
    templateUrl: './alert.component.html'
})

export class AlertComponent implements OnInit {
    message: any;

    constructor(private _alertService: AlertService) {
    }

    ngOnInit() {
        this._alertService.getMessage().subscribe(message => {
            this.message = message;
        });
    }
}