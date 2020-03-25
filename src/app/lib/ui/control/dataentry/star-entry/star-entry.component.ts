import { Component, OnInit, Optional, Self, AfterViewInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'ot-star-entry',
  templateUrl: './star-entry.component.html',
  styleUrls: ['./star-entry.component.scss']
})
export class StarEntryComponent extends DataEntryBase<number> {
  @Input() starCount = 0;
  @Output() getStarValue: EventEmitter<any> = new EventEmitter();
  @ViewChild('starDiv', { static: true }) myDiv;
  constructor(
    @Optional() @Self() ngControl: NgControl,
    translateService: TranslateService,
  ) {
    super(ngControl, translateService);
  }

  getStyle(index: number) {
    if (index <= this.value) {
      return { color: '#5867DD' };
    } else {
      return { color: '#ECECEC' };
    }
  }

  setValueAndEmit(index) {
    if (index === this.value) {
      index = 0;
    }
    this.getStarValue.emit(index);
    super.setValue(index);
  }

}
