// app.config.ts
import {
  ApplicationConfig,
  importProvidersFrom,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideRouter } from '@angular/router';
import {
  BrowserAnimationsModule,
  provideAnimations,
} from '@angular/platform-browser/animations'; // تأكد من المسار ده
import {
  HTTP_INTERCEPTORS,
  provideHttpClient,
  withInterceptorsFromDi,
} from '@angular/common/http';

import { routes } from './app.routes';
import { NgxSpinnerModule } from 'ngx-spinner';
import { loaderInterceptor } from './interceptor/loader.interceptor';

import { provideToastr, ToastrModule } from 'ngx-toastr';
export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    { provide: HTTP_INTERCEPTORS, useClass: loaderInterceptor, multi: true },
    importProvidersFrom(
      NgxSpinnerModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot({
        timeOut: 1500,
        positionClass: 'toast-top-right',
        preventDuplicates: true,
        progressBar: true,
      })
    ),
    provideAnimations(),
  ],
};
