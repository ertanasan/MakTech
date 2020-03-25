import { Directive, ElementRef, Renderer2, Injector, ComponentFactoryResolver, ViewContainerRef, NgZone, Inject, OnInit, OnDestroy, Input, TemplateRef, ChangeDetectorRef, ApplicationRef } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { NgbTooltip, NgbTooltipConfig } from '@ng-bootstrap/ng-bootstrap';

@Directive({

    selector: '[otTooltip]'
})
export class OTTooltipDirective extends NgbTooltip implements OnInit, OnDestroy {

    constructor(
        elementRef: ElementRef<HTMLElement>,
        renderer: Renderer2,
        injector: Injector,
        componentFactoryResolver: ComponentFactoryResolver,
        viewContainerRef: ViewContainerRef,
        ngbTooltipConfig: NgbTooltipConfig,
        ngZone: NgZone,
        changeDetector: ChangeDetectorRef,
        applicationRef: ApplicationRef,
        @Inject(DOCUMENT) document: Document
    ) {
        super(elementRef, renderer, injector, componentFactoryResolver, viewContainerRef, ngbTooltipConfig, ngZone, document, changeDetector, applicationRef);
        this.placement = 'right';
    }

    @Input()
    set otTooltip(value: string | TemplateRef<any>) {
        this.ngbTooltip = value;
    }

    get otTooltip() {
        return this.ngbTooltip;
    }

    ngOnInit() {
        super.ngOnInit();
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }
}
