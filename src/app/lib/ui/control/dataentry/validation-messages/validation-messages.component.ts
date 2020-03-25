import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'ot-validation-messages',
  templateUrl: './validation-messages.component.html',
  styleUrls: ['./validation-messages.component.css']
})
export class ValidationMessagesComponent implements OnInit {
  @Input() messages: Array<string>;

  constructor() { }

  ngOnInit() {
  }

}
