import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class LoadingScreenService {

  private _loading = false;
  loadingStatus: Subject<boolean> = new Subject();
  public skipRoutes: string[] = [];

  get loading(): boolean {
    return this._loading;
  }

  set loading(value) {
    this._loading = value;
    this.loadingStatus.next(value);
  }

  startLoading() {
    this.loading = true;
  }

  stopLoading() {
    this.loading = false;
  }

  addSkipRoute(route: string) {
    this.skipRoutes.push(route);
  }

  addSkipRoutes(routes: string[]) {
    this.skipRoutes = this.skipRoutes.concat(routes);
  }
}
