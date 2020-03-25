import { Injectable } from "@angular/core";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";
import { finalize } from "rxjs/operators";
import { LoadingScreenService } from "@otservice/loading-screen.service";
import { Router } from '@angular/router';


@Injectable()
export class LoadingScreenInterceptor implements HttpInterceptor {

  activeRequests = 0;

  /**
   * URLs for which the loading screen should not be enabled
   */
  skippUrls = [
    '/refreshToken',
    '/fetchContext',
    '/ListInboxSummary',
    '/program/menu',
    '/Parameter/Translation'
  ];

  constructor(private loadingScreenService: LoadingScreenService, private router: Router) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let displayLoadingScreen = true;
    // console.log('loading intercepted');
    for (const skippUrl of this.skippUrls) {
      if (new RegExp(skippUrl).test(request.url)) {
        displayLoadingScreen = false;
        break;
      }
    }
    for (const skipRoute of this.loadingScreenService.skipRoutes) {
      if (new RegExp(skipRoute).test(this.router.url)) {
        displayLoadingScreen = false;
        break;
      }
    }
    if (displayLoadingScreen) {
      if (this.activeRequests === 0) {
        this.loadingScreenService.startLoading();
      }
      this.activeRequests++;

      return next.handle(request).pipe(
        finalize(() => {
          this.activeRequests--;
          if (this.activeRequests === 0) {
            this.loadingScreenService.stopLoading();
          }
        })
      );
    } else {
      return next.handle(request);
    }
  }
}
