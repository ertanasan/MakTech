import {NG_VALIDATORS, FormControl} from '@angular/forms';
import { Directive } from '@angular/core';

@Directive({
  // tslint:disable-next-line:directive-selector
  selector: '[otFolderRequired][ngModel]',
  providers: [
    {
      provide: NG_VALIDATORS,
      useValue: folderValidator,
      multi: true
    }
  ]
})

export class OTFolderRequiredDirective {

}

export function folderValidator(control: FormControl) {
  const folderHandle = control.value;
  if (folderHandle && folderHandle.documents && folderHandle.documents.length === 0) {
    return false;
  }
  return null;
}
