import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'ot-base-control',
  templateUrl: './base-control.component.html',
  styleUrls: ['./base-control.component.css']
})
export class BaseControlComponent implements OnInit {
  @Input() tabIndex: number;

  constructor() { }

  ngOnInit() {
  }

}
