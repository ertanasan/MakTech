import { Component, OnInit } from '@angular/core';
import { OTBase } from '@otcommon/ot-base';

@Component({
  selector: 'ot-base',
  templateUrl: './ot-base.component.html',
  styleUrls: ['./ot-base.component.css']
})
export class OTBaseComponent extends OTBase implements OnInit {

  constructor() {
    super();
  }

  ngOnInit() {
  }

}
