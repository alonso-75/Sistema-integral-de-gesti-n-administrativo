// src/app/components/pqr-view/pqr-view.component.ts
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-pqr-view',
  template: `
    <div class="p-4 bg-white rounded shadow">
      <h2 class="text-2xl font-bold mb-4">Detalles de PQR</h2>
      <div class="grid grid-cols-2 gap-4">
        <div><strong>Radicado:</strong> {{ pqr.id }}</div>
        <div><strong>Título:</strong> {{ pqr.title }}</div>
        <div><strong>Descripción:</strong> {{ pqr.description }}</div>
        <div><strong>Fecha:</strong> {{ pqr.date }}</div>
        <div><strong>Tipo:</strong> {{ pqr.type }}</div>
        <div><strong>Estado:</strong> {{ pqr.status }}</div>
        <div><strong>Prioridad:</strong> {{ pqr.priority }}</div>
      </div>
    </div>
  `
})
export class PqrViewComponent {
  @Input() pqr: any;
}