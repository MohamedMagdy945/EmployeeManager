import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, finalize, Observable } from 'rxjs';
import { LoadingService } from '../services/loading.service';

@Injectable()
export class loaderInterceptor implements HttpInterceptor {
  constructor(private _services: LoadingService) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    this._services.loading();
    return next.handle(request).pipe(
      delay(100),
      finalize(() => {
        this._services.hideLoader();
      })
    );
  }
}
