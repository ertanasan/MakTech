import { Component, OnInit } from '@angular/core';
import { OTBaseComponent } from '../base/ot-base.component';

@Component({
  selector: 'ot-base-app',
  templateUrl: './base-app.component.html',
  styleUrls: ['./base-app.component.css']
})
export class BaseAppComponent extends OTBaseComponent implements OnInit {

  constructor() {
      super();
  }

  ngOnInit() {
  }

}
