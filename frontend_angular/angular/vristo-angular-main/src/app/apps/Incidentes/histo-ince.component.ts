import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

interface Incidente {
  id: number;
  numero: string;
  fechaRadicacion: Date;
  tipo: 'Petición' | 'Queja' | 'Reclamo';
  estado: 'Resuelta' | 'En Proceso' | 'Vencida';
  diasRestantes: number;
  asignadoA: string;
  asignadoIniciales: string;
}

@Component({
  selector: 'app-histo-ince',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './histo-ince.component.html',
})
export class HistoInceComponent implements OnInit {
  incidentesList: Incidente[] = [];
  filteredIncidentes: Incidente[] = [];
  pagedIncidentes: Incidente[] = [];

  fechaInicial?: string;
  fechaFinal?: string;
  searchText = '';

  currentPage = 1;
  itemsPerPage = 10;
  totalPages = 0;

  ngOnInit(): void {
    this.loadDummyData();
    this.filterIncidentes();
  }

  private loadDummyData() {
    this.incidentesList = [
      {
        id: 1,
        numero: 'Incidencias-2024-001',
        fechaRadicacion: new Date(2024, 1, 15),
        tipo: 'Petición',
        estado: 'En Proceso',
        diasRestantes: 8,
        asignadoA: 'Juan Silva',
        asignadoIniciales: 'JS',
      },
      {
        id: 2,
        numero: 'Incidencias-2024-002',
        fechaRadicacion: new Date(2024, 1, 14),
        tipo: 'Queja',
        estado: 'Resuelta',
        diasRestantes: 0,
        asignadoA: 'Ana Martínez',
        asignadoIniciales: 'AM',
      },
    ];
  }

  filterIncidentes() {
    this.filteredIncidentes = this.incidentesList.filter((inc) => {
      const fechaIncidente = new Date(inc.fechaRadicacion);
      const startDate = this.fechaInicial ? new Date(this.fechaInicial) : null;
      const endDate = this.fechaFinal ? new Date(this.fechaFinal) : null;

      const dateInRange =
        (!startDate || fechaIncidente >= startDate) &&
        (!endDate || fechaIncidente <= endDate);
      const matchesSearch =
        inc.numero.toLowerCase().includes(this.searchText.toLowerCase()) ||
        inc.asignadoA.toLowerCase().includes(this.searchText.toLowerCase());

      return dateInRange && matchesSearch;
    });

    this.totalPages = Math.ceil(this.filteredIncidentes.length / this.itemsPerPage);
    this.updatePagination();
  }

  updatePagination() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    this.pagedIncidentes = this.filteredIncidentes.slice(
      startIndex,
      startIndex + this.itemsPerPage
    );
  }

  clearFilters() {
    this.fechaInicial = undefined;
    this.fechaFinal = undefined;
    this.searchText = '';
    this.filterIncidentes();
  }

  searchIncidente(value: string) {
    this.searchText = value;
    this.filterIncidentes();
  }

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
    this.incidentesList = this.incidentesList.filter((inc) => inc.id !== incidente.id);
    this.filterIncidentes();
  }

  get totalIncidentes(): number {
    return this.filteredIncidentes.length;
  }

  get resueltas(): number {
    return this.filteredIncidentes.filter((inc) => inc.estado === 'Resuelta').length;
  }

  get enProceso(): number {
    return this.filteredIncidentes.filter((inc) => inc.estado === 'En Proceso').length;
  }

  get vencidas(): number {
    return this.filteredIncidentes.filter((inc) => inc.estado === 'Vencida').length;
  }

  exportIncidentes() {
    // Implementar lógica de exportación si es necesario
    console.log('Exportando incidencias...');
  }
}
