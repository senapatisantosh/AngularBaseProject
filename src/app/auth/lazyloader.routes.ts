import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth.component';
import { VisionDashboardComponent } from '../vision-dashboard/vision-dashboard.component';

export const appRoutes: Routes = [{
    path: '', component: AuthComponent, children: [
        { path: 'dashboard', component: VisionDashboardComponent }
    ]
}];
