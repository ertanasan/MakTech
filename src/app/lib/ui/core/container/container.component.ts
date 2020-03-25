import { Component, OnInit } from '@angular/core';

import { BaseControlComponent } from '../base-control/base-control.component';

@Component({
  selector: 'ot-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent extends BaseControlComponent implements OnInit {

  constructor() {
    super();
  }

  ngOnInit() {
  }

}
