// Angular
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatProgressBarModule, MatProgressSpinnerModule } from '@angular/material';

// Portlet
import { PortletComponent } from './portlet.component';
import { PortletHeaderComponent } from './portlet-header.component';
import { PortletBodyComponent } from './portlet-body.component';
import { PortletFooterComponent } from './portlet-footer.component';
import { CoreModule } from '@otlib/metronic/core/core.module';

@NgModule({
	imports: [
		CommonModule,
		CoreModule,
		MatProgressSpinnerModule,
		MatProgressBarModule
	],
	declarations: [
		PortletComponent,
		PortletHeaderComponent,
		PortletBodyComponent,
		PortletFooterComponent,
	],
	exports: [
		PortletComponent,
		PortletHeaderComponent,
		PortletBodyComponent,
		PortletFooterComponent,
	]
})
export class PortletModule {
}
