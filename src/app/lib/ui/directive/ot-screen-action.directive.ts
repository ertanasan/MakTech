import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';

@Directive({ selector: '[otScreenAction]' })
export class OTScreenActionDirective {
    constructor(
        private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef,
        private privilegeCacheService: PrivilegeCacheService
    ) { }

    @Input() set otScreenAction(moduleScreenAction: string) {
        const parts = moduleScreenAction.split('.', 3);
        this.privilegeCacheService.checkScreenAction(parts[0], parts[1], parts[2]).subscribe(
            result => {
                if (result) {
                    this.viewContainer.createEmbeddedView(this.templateRef);
                } else {
                    this.viewContainer.clear();
                }
            },
            error => {
                this.viewContainer.clear();
                console.error('OTScreenActionDirective; privilege check failed.', error);
            }
        );
    }
}
