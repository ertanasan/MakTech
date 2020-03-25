import { Component, OnInit, Input, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { faStar as faStarSolid, faBan } from '@fortawesome/free-solid-svg-icons';
import { faStar as faStarRegular } from '@fortawesome/free-regular-svg-icons';
import { IconProp, IconDefinition } from '@fortawesome/fontawesome-svg-core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

@Component({
    selector: 'ot-rating-entry',
    templateUrl: './rating-entry.component.html',
    styleUrls: ['./rating-entry.component.css'],
})
export class RatingEntryComponent extends DataEntryBase<number> implements OnInit {
    // @Input() value: number;
    @Input() spacing = '6px';
    @Input() height = '25px';
    // @Input() icon = 'Star';     // FOR NOW, ONLY STAR ICON IS AVAILABLE
    @Input() color = 'orange';
    @Input() numberOfStars = 5;

    iconFilled: IconProp;
    iconEmpty: IconProp;
    activeIconsArray = [];
    starArray: number[] = [];
    rating: number;

    @Input() isHoverEnabled = true;

    // CANCEL ICON
    // @Input() isCancelIconEnable = true;
    @Input() cancelIconColor = 'red';
    cancelIcon = faBan;
    @Input()  cancelIconSpacing = '0px';
    isCancelIconVisible = false;

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        this.generateStarArray();
        this.iconFilled = faStarSolid;
        this.iconEmpty = faStarRegular;
        this.rating = this.value ? +this.value : 0;
        this.fillStars(this.rating);

        this.starArray.forEach( star => {
            if (this.rating >= (star + 1)) {
                this.activeIconsArray[star] = this.iconFilled;
            } else {
                this.activeIconsArray[star] = this.iconEmpty;
            }
        });
    }

    private generateStarArray() {
        this.starArray = Array.apply(null, {length: this.numberOfStars}).map(Number.call, Number);
    }

    fillStars(noOfFilledStars) {
        for (let i = 0; i < this.numberOfStars; i++) {
            if (i < noOfFilledStars) {
                this.activeIconsArray[i] = this.iconFilled;
            } else {
                this.activeIconsArray[i] = this.iconEmpty;
            }
        }
    }

    private onIconClicked(starIndex) {
        if (!this.isReadOnly) {
            if (this.isHoverEnabled) {
                this.rating = starIndex + 1;
                this.value = starIndex + 1;
                this.isHoverEnabled = false;
            } else {
                this.isHoverEnabled = true;
            }
        }
    }

    private onMouseEnter(starIndex) {
        if (!this.isReadOnly && this.isHoverEnabled) {
            this.fillStars(starIndex + 1);
        }
    }

    private onMouseLeave(starIndex) {
        if (!this.isReadOnly && this.isHoverEnabled) {
            this.fillStars(this.rating);
        }
    }

    private onCancelClicked() {
        this.rating = 0;
        this.value = null;
        this.isHoverEnabled = true;
        this.fillStars(this.rating);
    }

    private onCancelMouseEnter() {
        if (this.rating) {
            this.isCancelIconVisible = true;
        }
    }

    private onCancelMouseLeave() {
        this.isCancelIconVisible = false;
    }
}
