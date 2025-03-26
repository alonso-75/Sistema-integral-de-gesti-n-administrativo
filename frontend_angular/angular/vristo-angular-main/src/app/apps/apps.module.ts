import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

// shared module
import { SharedModule } from 'src/shared.module';

import { ScrumboardComponent } from './scrumboard';
import { ContactsComponent } from './contacts';
import { NotesComponent } from './notes';
import { TodolistComponent } from './todolist';
import { InvoicePreviewComponent } from './invoice/preview';
import { InvoiceAddComponent } from './invoice/add';
import { InvoiceEditComponent } from './invoice/edit';
import { CalendarComponent } from './calendar';
import { ChatComponent } from './chat';
import { MailboxComponent } from './mailbox';
import { InvoiceListComponent } from './invoice/list';
import { FormularioComponent } from './AtencionCiudadano/formulario';
import { atencionDatatableComponent } from './AtencionCiudadano/atencion-table';
import { AgendarEquiposComponent } from './PrestamosEquipos/agendarequipos';
import { GestionarInsumosComponent } from './PrestamosEquipos/gestionarinsumos-tables';
import { FormularioInconvenientesComponent } from './Incidentes/formularioinconientes';
import { listPqrsComponent } from './PQR/list-pqrs';
import { SeguiPqrsComponent } from './PQR/segui-pqrs.component';
import { FormInceComponent } from './Incidentes/form-ince.component';
import { IncidentesComponent } from './Incidentes/histo-ince.component';

const routes: Routes = [
    { path: 'apps/chat', component: ChatComponent, data: { title: 'Chat' } },
    { path: 'apps/mailbox', component: MailboxComponent, data: { title: 'Mailbox' } },
    { path: 'apps/scrumboard', component: ScrumboardComponent, data: { title: 'Scrumboard' } },
    { path: 'apps/contacts', component: ContactsComponent, data: { title: 'Contacts' } },
    { path: 'apps/notes', component: NotesComponent, data: { title: 'Notes' } },
    { path: 'apps/todolist', component: TodolistComponent, data: { title: 'Todolist' } },
    { path: 'apps/invoice/list', component: InvoiceListComponent, data: { title: 'Invoice List' } },
    { path: 'apps/invoice/preview', component: InvoicePreviewComponent, data: { title: 'Invoice Preview' } },
    { path: 'apps/invoice/add', component: InvoiceAddComponent, data: { title: 'Invoice Add' } },
    { path: 'apps/invoice/edit', component: InvoiceEditComponent, data: { title: 'Invoice Edit' } },
    { path: 'apps/calendar', component: CalendarComponent, data: { title: 'Calendar' } },
    { path: 'Atencion-Ciudadano/Formulario-Ingreso', component: FormularioComponent, data: { title: 'Atencion Formulario' } },
    { path: 'Atencion-Ciudadano/Consultar-Ingreso', component: atencionDatatableComponent, data: { title: 'Consultar Ingreso' } },
    { path: 'Prestamos/Agendar', component: AgendarEquiposComponent, data: { title: 'Agendar Insumos' } },
    { path: 'Prestamos/Gestionar', component: GestionarInsumosComponent, data: { title: 'Gestionar Insumos' } },
    { path: 'Incidencias/Formulario', component: FormularioInconvenientesComponent, data: { title: 'Formulario Incidentes' } },
    { path: 'Pqrs/Lista', component: listPqrsComponent, data: { title: 'Componente Pqrs' } },
    { path: 'Pqrs/segui',component:SeguiPqrsComponent, data:{title:'Seguir Pqrs'} },
    {path:  'incidencias/form-ince',component: FormInceComponent, data:{title:'Formularion de incidentes'}},
    {path:  'incidencias/historial',component: IncidentesComponent, data:{title:'Historial de incidentes'}},
];

@NgModule({
    imports: [RouterModule.forChild(routes), CommonModule, SharedModule.forRoot()],
    declarations: [
        ChatComponent,
        ScrumboardComponent,
        ContactsComponent,
        NotesComponent,
        TodolistComponent,
        InvoiceListComponent,
        InvoicePreviewComponent,
        InvoiceAddComponent,
        InvoiceEditComponent,
        CalendarComponent,
        MailboxComponent,
        FormularioComponent,
        atencionDatatableComponent,
        AgendarEquiposComponent,
        GestionarInsumosComponent,
        FormularioInconvenientesComponent,
        listPqrsComponent,

    ],
})
export class AppsModule {}
