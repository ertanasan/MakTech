import { Component, OnInit, Input, ContentChild, TemplateRef } from '@angular/core';

@Component({
  selector: 'ot-sortable-list',
  templateUrl: './sortable-list.component.html',
  styleUrls: ['./sortable-list.component.css']
})
export class SortableListComponent implements OnInit {
  @ContentChild(TemplateRef, {static: true}) itemTemplate: TemplateRef<any>;

  @Input() items = [];
  @Input() itemClass = 'item';
  @Input() activeItemClass = 'item';

  constructor() { }

  ngOnInit() {
  }

}
