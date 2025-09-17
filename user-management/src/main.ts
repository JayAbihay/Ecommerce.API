import { bootstrapApplication } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { provideRouter } from '@angular/router'; // 👈 importar router
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes'; // 👈 importar tus rutas

bootstrapApplication(AppComponent, {
  providers: [
    provideAnimations(),
    provideHttpClient(withFetch()),
    provideRouter(routes), // 👈 aquí inyectas ActivatedRoute y RouterLink
  ],
});
