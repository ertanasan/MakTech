
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { PartialsModule } from './views/partials/partials.module';
import { ThemeModule } from './views/theme/theme.module';
import {
	DataTableService,
	KtDialogService,
	LayoutConfigService,
	LayoutRefService,
	MenuAsideService,
	MenuConfigService,
	MenuHorizontalService,
	PageConfigService,
	SplashScreenService,
	SubheaderService
} from './core/_base/layout';
import { LayoutConfig } from 'app/theme/layout.config';

export function initializeLayoutConfig(appConfig: LayoutConfigService) {
	//  initialize app by loading default demo layout config
	return () => {
		appConfig.resetConfig();
		if (appConfig.getConfig() === null) {
			appConfig.loadConfigs(new LayoutConfig().configs);
		}
	};
}

@NgModule({
    declarations: [

    ],
    imports: [
    ],
    exports: [
        PartialsModule,
        ThemeModule
    ],
    providers: [
        LayoutConfigService,
		LayoutRefService,
		MenuConfigService,
		PageConfigService,
		KtDialogService,
		DataTableService,
        SplashScreenService,
        {
			// layout config initializer
			provide: APP_INITIALIZER,
			useFactory: initializeLayoutConfig,
			deps: [LayoutConfigService], multi: true
        },

		// template services
		SubheaderService,
		MenuHorizontalService,
		MenuAsideService
    ]
})
export class OTMetronicModule { }
