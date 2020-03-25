import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { InputsModule } from '@progress/kendo-angular-inputs';
import { DropDownsModule, MultiSelectModule } from '@progress/kendo-angular-dropdowns';
import { PopupModule } from '@progress/kendo-angular-popup';
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { AlphaEntryComponent } from './alpha-entry/alpha-entry.component';
import { DateEntryComponent } from './date-entry/date-entry.component';
import { DropdownEntryComponent } from './dropdown-entry/dropdown-entry.component';
import { NumericEntryComponent } from './numeric-entry/numeric-entry.component';
import { RadioEntryComponent } from './radio-entry/radio-entry.component';
import { TextEntryComponent } from './text-entry/text-entry.component';
import { ValidationMessagesComponent } from './validation-messages/validation-messages.component';
import { CheckBoxComponent } from './check-box/check-box.component';
import { AutoCompleteEntryComponent } from './auto-complete-entry/auto-complete-entry.component';
import { TreeListEntryComponent } from './tree-list-entry/tree-list-entry.component';
import { OTCommandModule } from '../command/ot-command.module';
import { MaskedEntryComponent } from './masked-entry/masked-entry.component';
import { ButtonEntryComponent } from './button-entry/button-entry.component';
import { OTComplexModule } from '../complex/ot-complex.module';
import { DataEntryTemplateComponent } from './data-entry-template/data-entry-template.component';
import { RichEditComponent } from './rich-edit/rich-edit.component';
import { SwitchEntryComponent } from './switch-entry/switch-entry.component';
import { MultiSelectEntryComponent } from './multi-select-entry/multi-select-entry.component';
import { DropdownListFilterComponent } from './dropdown-list-filter/dropdown-list-filter.component';
import { DocumentEntryComponent } from './document-entry/document-entry.component';
import { FolderEntryComponent } from './folder-entry/folder-entry.component';
import { OTCoreModule } from '@otcore/core.module';
import { FileUploadComponent } from './file-upload/file-upload.component';
import { DateRangeComponent } from '@otuicontrol/complex/date-range/date-range.component';
import { StarEntryComponent } from './star-entry/star-entry.component';
import { OTDirectiveModule } from '@otui/directive/ot-directive.module';
import { TimeEntryComponent } from './time-entry/time-entry.component';
import { GridDateFilterComponent } from './grid-date-filter/grid-date-filter.component';

@NgModule({
    declarations: [
        DataEntryTemplateComponent,
        AlphaEntryComponent,
        DateEntryComponent,
        DropdownEntryComponent,
        NumericEntryComponent,
        RadioEntryComponent,
        TextEntryComponent,
        ValidationMessagesComponent,
        CheckBoxComponent,
        AutoCompleteEntryComponent,
        TreeListEntryComponent,
        MaskedEntryComponent,
        ButtonEntryComponent,
        RichEditComponent,
        SwitchEntryComponent,
        MultiSelectEntryComponent,
        DropdownListFilterComponent,
        DocumentEntryComponent,
        FolderEntryComponent,
        FileUploadComponent,
        DateRangeComponent,
        StarEntryComponent,
        TimeEntryComponent,
        GridDateFilterComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
        InputsModule,
        DropDownsModule,
        PopupModule,
        TreeViewModule,
        DateInputsModule,
        ButtonModule,
        OTCommandModule,
        OTComplexModule,
        CKEditorModule,
        MultiSelectModule,
        OTCoreModule,
        OTDirectiveModule
    ],
    exports: [
        AlphaEntryComponent,
        DropdownEntryComponent,
        NumericEntryComponent,
        CheckBoxComponent,
        AutoCompleteEntryComponent,
        TreeListEntryComponent,
        ButtonEntryComponent,
        MaskedEntryComponent,
        DateEntryComponent,
        RadioEntryComponent,
        RichEditComponent,
        SwitchEntryComponent,
        MultiSelectEntryComponent,
        DropdownListFilterComponent,
        TextEntryComponent,
        DocumentEntryComponent,
        FolderEntryComponent,
        DateRangeComponent,
        DataEntryTemplateComponent,
        StarEntryComponent,
        TimeEntryComponent,
        GridDateFilterComponent
    ]
})
export class OTDataEntryModule {}
