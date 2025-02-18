// src/app/components/pqr-list/pqr-list .component.ts
import { Component, OnInit } from '@angular/core';
import { Pqr } from '../pqr.model';
import { PqrService } from '../pqrservicio.service';

@Component({
  selector: 'app-pqr-list',
  templateUrl: './pqr-list.component.html',
})
export class PqrListComponent implements OnInit {

  search1 = '';
  datatable1Cols = [
    { field: 'id', title: 'Radicado' },
    { field: 'title', title: 'title' },
    { field: 'description', title: 'description' },
    { field: 'date', title: 'date' },
    { field: 'email', title: 'Email' },
    { field: 'type', title: 'type' },
    { field: 'status', title: 'Status' },
    { field: 'priority', title: 'priority' },
    { field: 'action', title: 'Action', sort: false, headerClass: 'justify-center' },
];
rows = [
  {
    id: 1,
    title: "Solicitud de Cambio de Dirección",
    description:
      "Caroline Jensen solicita actualizar su dirección a 529 Scholes Street, Temperanceville, código postal 5235.",
    status: "Pending",
    date: "2024-02-18",
    type: "Petition",
    priority: "Low",
  },
  {
    id: 2,
    title: "Queja por Servicio Inactivo",
    description:
      "Celeste Grant reporta que su servicio está inactivo desde el 19/11/2023. Solicita reactivación inmediata.",
    status: "In Progress",
    date: "2024-02-17",
    type: "Complaint",
    priority: "High",
  },
  {
    id: 3,
    title: "Reclamo por Cobro Excesivo",
    description: "Tillman Forbes reclama un cobro excesivo en su última factura. Solicita revisión y ajuste.",
    status: "Pending",
    date: "2024-02-16",
    type: "Claim",
    priority: "Medium",
  },
  {
    id: 4,
    title: "Solicitud de Información sobre Planes",
    description: "Daisy Whitley solicita información detallada sobre los planes disponibles para su área.",
    status: "Resolved",
    date: "2024-02-15",
    type: "Petition",
    priority: "Low",
  },
  {
    id: 5,
    title: "Queja por Mala Atención al Cliente",
    description: "Weber Bowman presenta una queja formal por mala atención recibida el 24/02/2023.",
    status: "In Progress",
    date: "2024-02-14",
    type: "Complaint",
    priority: "High",
  },
  {
    id: 6,
    title: "Solicitud de Cancelación de Servicio",
    description: "Buckley Townsend solicita la cancelación de su servicio actual sin penalización.",
    status: "Pending",
    date: "2024-02-13",
    type: "Petition",
    priority: "Medium",
  },
  {
    id: 7,
    title: "Reclamo por Falla en el Servicio",
    description: "Latoya Bradshaw reclama por interrupciones frecuentes en el servicio durante el último mes.",
    status: "In Progress",
    date: "2024-02-12",
    type: "Claim",
    priority: "High",
  },
  {
    id: 8,
    title: "Solicitud de Upgrade de Plan",
    description: "Kate Lindsay solicita información para hacer un upgrade de su plan actual.",
    status: "Resolved",
    date: "2024-02-11",
    type: "Petition",
    priority: "Low",
  },
  {
    id: 9,
    title: "Queja por Cobro de Servicio No Solicitado",
    description: "Marva Sandoval reporta un cobro por un servicio que asegura no haber solicitado.",
    status: "Pending",
    date: "2024-02-10",
    type: "Complaint",
    priority: "Medium",
  },
  {
    id: 10,
    title: "Reclamo por Demora en Instalación",
    description: "Decker Russell reclama por una demora excesiva en la instalación de su nuevo servicio.",
    status: "In Progress",
    date: "2024-02-09",
    type: "Claim",
    priority: "High",
  },
];
  pqrList: Pqr[] = [];

  constructor(private pqrService: PqrService) {}
  ngOnInit() {
    this.rows = this.rows.map((row) => {
        return {
            ...row,
            status: this.randomStatus(),
            statusColor: this.randomColor(),
        };
    });
}

formatDate(date: any) {
    if (date) {
        const dt = new Date(date);
        const month = dt.getMonth() + 1 < 10 ? '0' + (dt.getMonth() + 1) : dt.getMonth() + 1;
        const day = dt.getDate() < 10 ? '0' + dt.getDate() : dt.getDate();
        return day + '/' + month + '/' + dt.getFullYear();
    }
    return '';
}

randomColor() {
    const color = ['primary', 'secondary', 'success', 'danger', 'warning', 'info'];
    const random = Math.floor(Math.random() * color.length);
    return color[random];
}

randomStatus() {
    const status = ['PAID', 'APPROVED', 'FAILED', 'CANCEL', 'SUCCESS', 'PENDING', 'COMPLETE'];
    const random = Math.floor(Math.random() * status.length);
    return status[random];
}
}