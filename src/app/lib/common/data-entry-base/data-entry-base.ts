import { ValueAccessorBase } from './value-accessor-base';
import { OnInit, Input } from '@angular/core';
import { NgControl, ValidationErrors } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { Observable, of } from 'rxjs';
import { _ } from '@biesbjerg/ngx-translate-extract/dist/utils/utils';

export class DataEntryBase<T> extends ValueAccessorBase<T> implements OnInit {

    @Input() showCaption = true;
    @Input() captionWidth = 3;
    @Input() editorWidth = 9;
    @Input() captionBS: string;
    @Input() editorBS: string;
    @Input() caption: string;
    @Input() isReadOnly = false;
    @Input() disabled = false;
    @Input() autocomplete: string;
    @Input() customValidationMessage: string;
    @Input() placeholder: string;
    @Input() inGrid = false;
    @Input() otStyle: string;
    @Input() otClass: string;

    constructor(
        ngControl: NgControl,
        protected translateService: TranslateService
    ) {
        super(ngControl);
    }

    ngOnInit() {
    }

    getControlClasses() {
        const classes = {};
        if (this.ngControl) {
            classes['form-control'] = true;
        }
        if (this.otClass) {
            classes[this.otClass] = true;
        }
        return classes;
    }

    getValidationMessages(): Observable<Array<Observable<string>>> {
        if (this.customValidationMessage) {
            return of([of(this.customValidationMessage)]);
        }
        if (this.ngControl && this.ngControl.control.errors) {
            return of(Object.keys(this.ngControl.control.errors).map(k => this.getValidationMessage(this.ngControl.control.errors, k)));
        }
        return null;
    }

    getValidationMessage(validationError: ValidationErrors, key: string): Observable<string> {
        switch (key) {
            case 'required':
                return this.translateService.get(_('ValidationMessage-Required'));
            case 'pattern':
                return this.translateService.get(_('ValidationMessage-Pattern'));
            case 'minlength':
                return this.translateService.get(_('ValidationMessage-MinLength'), {value: validationError.minlength['requiredLength']});
            case 'maxlength':
                return this.translateService.get(_('ValidationMessage-MaxLength'), {value: validationError.maxlength['requiredLength']});
        }
        switch (typeof validationError[key]) {
            case 'string':
                return this.translateService.get((<string>validationError[key]));
            default:
                return this.translateService.get(_('ValidationMessage-Failed'), {message: key});
        }
    }
}
