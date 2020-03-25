import { Component, OnInit, ViewChild, Input, OnDestroy } from '@angular/core';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { TranslateService } from '@ngx-translate/core';
import { GatheringService } from '@warehouse/service/gathering.service';
import { GatheringDetailService } from '@warehouse/service/gathering-detail.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import {Subject, Subscription} from 'rxjs';

@Component({
  selector: 'ot-gathering-grid-view',
  templateUrl: './gathering-grid-view.component.html',
  styleUrls: ['./gathering-grid-view.component.css']
})
export class GatheringGridViewComponent implements OnInit, OnDestroy {
  isActualUnit = true;   // true: KG/QTY  false:PACKAGE
  goToGatherIndexButtonClicked = new Subject<number>();

  constructor(
    public messageService: GrowlMessageService,
    public translateService: TranslateService,
    public gatheringService: GatheringService,
    public gatheringDetailService: GatheringDetailService,
    public utilityService: OverstoreCommonMethods
  ) { }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  // ilave : 2020-01-23
  onKgPackageChanged(stat) {
    this.isActualUnit = stat;
  }
}
