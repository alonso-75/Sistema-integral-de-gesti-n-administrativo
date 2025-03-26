// incidentes.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

interface Incidente {
  id: number;
  referencia: string;
  titulo: string;
  fecha: Date;
  tipo: string;
  severidad: 'Bajo' | 'Medio' | 'Alto' | 'Crítico';
  estado: 'Abierto' | 'En Investigación' | 'En Revisión' | 'Cerrado';
  responsable: string;
  departamento: string;
  prioridad: 'Baja' | 'Media' | 'Alta' | 'Urgente';
}

@Component({
  selector: 'app-incidentes',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: 'histo-ince.component.html',
})
export class IncidentesComponent implements OnInit {
  // Datos y Filtros
  incidentesList: Incidente[] = [];
  filteredIncidentes: Incidente[] = [];
  pagedIncidentes: Incidente[] = [];

  // Filtros
  fechaDesde?: string;
  fechaHasta?: string;
  estadoFiltro: string = '';
  tipoFiltro: string = '';
  severidadFiltro: string = '';
  departamentoFiltro: string = '';
  responsableFiltro: string = '';
  prioridadFiltro: string = '';
  searchText = '';

  // Paginación
  currentPage = 1;
  itemsPerPage = 10;
  totalPages = 1;

  ngOnInit() {
    this.loadDummyData();
    this.filterIncidentes();
  }

  private loadDummyData() {
    this.incidentesList = [
      {
        id: 1,
        referencia: 'INC-2024-001',
        titulo: 'Caída de andamio',
        fecha: new Date(2024, 2, 15),
        tipo: 'Accidente',
        severidad: 'Crítico',
        estado: 'En Investigación',
        responsable: 'Juan Pérez',
        departamento: 'Operaciones',
        prioridad: 'Urgente'
      },
      {
        id: 2,
        referencia: 'INC-2024-002',
        titulo: 'Fuga química',
        fecha: new Date(2024, 2, 14),
        tipo: 'Ambiental',
        severidad: 'Alto',
        estado: 'En Revisión',
        responsable: 'María Rodríguez',
        departamento: 'Producción',
        prioridad: 'Alta'
      },
      // Agrega más datos de prueba aquí
    ];
  }

  filterIncidentes() {
    this.filteredIncidentes = this.incidentesList.filter(incidente => {
        const fechaIncidente = new Date(incidente.fecha);
        const startDate = this.fechaDesde ? new Date(this.fechaDesde) : null;
        const endDate = this.fechaHasta ? new Date(this.fechaHasta) : null;

        return (
          (!startDate || fechaIncidente >= startDate) &&
          (!endDate || fechaIncidente <= endDate) &&
          (!this.estadoFiltro || incidente.estado === this.estadoFiltro) &&
          (!this.tipoFiltro || incidente.tipo === this.tipoFiltro) &&
          (!this.severidadFiltro || incidente.severidad === this.severidadFiltro) &&
          (!this.departamentoFiltro || incidente.departamento === this.departamentoFiltro) &&
          (!this.responsableFiltro || incidente.responsable === this.responsableFiltro) &&
          (!this.prioridadFiltro || incidente.prioridad === this.prioridadFiltro) &&
          (incidente.referencia.toLowerCase().includes(this.searchText?.toLowerCase() || '') ||
           incidente.titulo.toLowerCase().includes(this.searchText?.toLowerCase() || ''))
        );
      });

      this.totalPages = Math.ceil(this.filteredIncidentes.length / this.itemsPerPage);
      this.updatePagination();
  }

  updatePagination() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    this.pagedIncidentes = this.filteredIncidentes.slice(startIndex, startIndex + this.itemsPerPage);
  }

  clearFilters() {
    this.fechaDesde = undefined;
    this.fechaHasta = undefined;
    this.estadoFiltro = '';
    this.tipoFiltro = '';
    this.severidadFiltro = '';
    this.departamentoFiltro = '';
    this.responsableFiltro = '';
    this.prioridadFiltro = '';
    this.searchText = '';
    this.filterIncidentes();
  }

  // Métodos para resumen estadístico
  get totalIncidentes(): number {
    return this.filteredIncidentes.length;
  }

  get enProceso(): number {
    return this.filteredIncidentes.filter(i =>
      i.estado === 'En Investigación' || i.estado === 'En Revisión').length;
  }

  get criticos(): number {
    return this.filteredIncidentes.filter(i => i.severidad === 'Crítico').length;
  }

  get resueltos(): number {
    return this.filteredIncidentes.filter(i => i.estado === 'Cerrado').length;
  }

  // Métodos de paginación
  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.updatePagination();
    }
  }

  nextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.updatePagination();
    }
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.updatePagination();
    }
  }

  deleteIncidente(incidente: Incidente) {
    this.incidentesList = this.incidentesList.filter(i => i.id !== incidente.id);
    this.filterIncidentes();
  }

  exportarIncidentes() {
    // Implementar lógica de exportación
  }
}
