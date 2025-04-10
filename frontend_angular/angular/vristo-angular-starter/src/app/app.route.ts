import { Routes } from '@angular/router';

// dashboard
import { IndexComponent } from './index';
import { AppLayout } from './layouts/app-layout';
import { AuthLayout } from './layouts/auth-layout';
import { AtencionCiudadanoComponent } from './components/atencion-ciudadano/atencion-ciudadano.component';

export const routes: Routes = [
    {
        path: '',
        component: AppLayout,
        children: [
            // dashboard
            { path: '', component: IndexComponent, data: { title: 'Sales Admin' } },
        ],
    },

    {
        path: '',
        component: AuthLayout,
        children: [],
    },
    //navegacion 
    {
        path: 'Home',
        component: AppLayout,
        children: [
            // dashboard
            { path: '', component: IndexComponent, data: { title: 'Sales Admin' } },
            { path:'Atencion-Ciudadano',component: AtencionCiudadanoComponent,}
        ],
    },


];
