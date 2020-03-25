import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'ot-print-pallet',
  templateUrl: './print-pallet.component.html',
  styleUrls: ['./print-pallet.component.scss']
})
export class PrintPalletComponent implements OnInit {
  @Input() storeName: string;
  @Input() palletNo: number;
  @Input() palletCount: number;
  @Input() gatheringUserName: string;
  controlUserName = '';
  @Input() qrCodeUrl: string;

  constructor() { }

  ngOnInit() {
  }

}
