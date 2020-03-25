import { ComponentFactory, Inject, Injectable, Injector, NgModuleFactoryLoader, Type } from '@angular/core';
import { Observable ,  from as ObservableFromPromise ,  throwError as ObservableThrow } from 'rxjs';

import { DYNAMIC_COMPONENT, DYNAMIC_COMPONENT_MANIFESTS, DynamicComponentManifest } from './dynamic-component-manifest';

@Injectable()
export class DynamicComponentLoader {

    constructor(
        @Inject(DYNAMIC_COMPONENT_MANIFESTS) private manifests: DynamicComponentManifest[],
        private loader: NgModuleFactoryLoader,
        private injector: Injector,
    ) { }

    /** Retrieve a ComponentFactory, based on the specified componentId (defined in the DynamicComponentManifest array). */
    getComponentFactory<T>(componentId: string, componentType: Type<any>, injector?: Injector): Observable<ComponentFactory<T>> {
        const manifest = this.manifests
            .find(m => m.componentId === componentId);
        if (!manifest) {
            return ObservableThrow(`DynamicComponentLoader: Unknown componentId "${componentId}"`);
        }
        const p = this.loader.load(manifest.loadChildren)
            .then(ngModuleFactory => {
                const moduleRef = ngModuleFactory.create(injector || this.injector);
                return moduleRef.componentFactoryResolver.resolveComponentFactory<T>(componentType);
            });

        return ObservableFromPromise(p);
    }
}
