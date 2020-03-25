import { Component, OnInit } from '@angular/core';
// import { faLightbulb, faComments } from '@fortawesome/free-solid-svg-icons';
import { faLightbulb } from '@fortawesome/free-regular-svg-icons';

import { PrivilegeCacheService } from '@otservice/privilege-cache.service';
// import { SuggestionEditComponent } from '@announcement/screen/suggestion/suggestion-edit/suggestion-edit.component';

@Component({
  selector: 'ot-theme',
  templateUrl: './theme.component.html',
  styleUrls: ['./theme.component.scss']
})
export class ThemeComponent implements OnInit {
  faLightbulb = faLightbulb;
  iconVisible = false;

  constructor(private privilegeCacheService: PrivilegeCacheService) { }

  ngOnInit() {
    this.privilegeCacheService.checkPrivilege('ANN-Create Suggestion').subscribe(
      result => {
          this.iconVisible = result;
    });
  }

  onSuggestionIconClick() {
  }

}
