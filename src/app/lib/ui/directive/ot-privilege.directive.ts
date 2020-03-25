import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';

// tslint:disable-next-line:directive-selector
@Directive({ selector: '[otPrivilege]' })
export class OTPrivilegeDirective {
    constructor(
        private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef,
        private privilegeCacheService: PrivilegeCacheService
    ) { }

    @Input() set otPrivilege(privilegeName: string) {
        this.privilegeCacheService.checkPrivilege(privilegeName).subscribe(
            result => {
                if (result) {
                    this.viewContainer.createEmbeddedView(this.templateRef);
                } else {
                    this.viewContainer.clear();
                }
            },
            error => {
                this.viewContainer.clear();
                console.error('OTPrivilegeDirective; privilege check failed.', error);
            }
        );
    }
}
