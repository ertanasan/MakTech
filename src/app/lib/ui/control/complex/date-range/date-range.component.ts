import { Component, OnInit, Optional, Self, Input } from '@angular/core';
import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { TranslateService } from '@ngx-translate/core';
import { NgControl } from '@angular/forms';

@Component({
  selector: 'ot-date-range',
  templateUrl: './date-range.component.html',
  styleUrls: ['./date-range.component.css']
})
export class DateRangeComponent extends DataEntryBase<string> implements OnInit {

  @Input() start: Date;
  @Input() end: Date;

  constructor(
    @Optional() @Self() ngControl: NgControl,
    translateService: TranslateService,
  ) {
    super(ngControl, translateService);
  }

  ngOnInit() {
    super.ngOnInit();
  }

}
