import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
    selector: '[otNumberOnly]'
})
export class OTNumberOnlyDirective {

    constructor(private el: ElementRef) { }

    private specialKeys: Array<string> = ['Backspace', 'Tab', 'End', 'Home', 'Control'];
    private regex: RegExp = new RegExp(/^[0-9]+(\.[0-9]*){0,1}$/g);

    @Input() otNumberOnly = false;

    @HostListener('keydown', ['$event']) onKeyDown(event) {
        const e = <KeyboardEvent>event;
        if (this.otNumberOnly) {
            if (this.specialKeys.indexOf(event.key) !== -1) {
                return;
            }
            if (event.ctrlKey === true) {
                return;
            }
            // Do not use event.keycode this is deprecated.
            // See: https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent/keyCode
            const current: string = this.el.nativeElement.value;
            // We need this because the current value on the DOM element
            // is not yet updated with the value from this event
            const next: string = current.concat(event.key);
            if (next && !String(next).match(this.regex)) {
                event.preventDefault();
            }
        }
    }
    @HostListener('paste', ['$event']) onEvent(event) {
        if (this.otNumberOnly) {
            const data = event.clipboardData.getData('text');
            const current: string = this.el.nativeElement.value;
            const next: string = current.concat(data);
            if (next && !String(next).match(this.regex)) {
                event.preventDefault();
            }
        }
    }
}
