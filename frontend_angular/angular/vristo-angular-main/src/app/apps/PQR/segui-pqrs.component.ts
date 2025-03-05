// segui-pqrs.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { faSearch, faDownload, faTimes, faEllipsisV, faChevronLeft, faChevronRight } from '@fortawesome/free-solid-svg-icons';

interface Pqr {
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
  selector: 'app-segui-pqrs',
  standalone: true,
  imports: [CommonModule, FormsModule,],
  templateUrl: './segui-pqrs.component.html',
})
export class SeguiPqrsComponent implements OnInit {
  // Iconos
  faSearch = faSearch;
  faDownload = faDownload;
  faTimes = faTimes;
  faEllipsisV = faEllipsisV;
  faChevronLeft = faChevronLeft;
  faChevronRight = faChevronRight;

  // Datos y Filtros
  pqrsList: Pqr[] = [];
  filteredPqrs: Pqr[] = [];
  pagedPqrs: Pqr[] = [];
  fechaInicial?: string;
  fechaFinal?: string;
  searchText = '';

  // Paginación
  currentPage = 1;
  itemsPerPage = 10;
  totalPages = 1;

  ngOnInit() {
    this.loadDummyData();
    this.filterPqrs();
  }

  private loadDummyData() {
    this.pqrsList = [
      {
        id: 1,
        numero: 'PQR-2024-001',
        fechaRadicacion: new Date(2024, 1, 15),
        tipo: 'Petición',
        estado: 'En Proceso',
        diasRestantes: 8,
        asignadoA: 'Juan Silva',
        asignadoIniciales: 'JS'
      },
      {
        id: 2,
        numero: 'PQR-2024-002',
        fechaRadicacion: new Date(2024, 1, 14),
        tipo: 'Queja',
        estado: 'Resuelta',
        diasRestantes: 0,
        asignadoA: 'Ana Martínez',
        asignadoIniciales: 'AM'
      },
      // Agrega más datos de prueba aquí
    ];
  }

  filterPqrs() {
    this.filteredPqrs = this.pqrsList.filter(pqr => {
      const fechaPqr = new Date(pqr.fechaRadicacion);
      const startDate = this.fechaInicial ? new Date(this.fechaInicial) : null;
      const endDate = this.fechaFinal ? new Date(this.fechaFinal) : null;

      const dateInRange = (!startDate || fechaPqr >= startDate) &&
                         (!endDate || fechaPqr <= endDate);
      const matchesSearch = pqr.numero.toLowerCase().includes(this.searchText.toLowerCase()) ||
                           pqr.asignadoA.toLowerCase().includes(this.searchText.toLowerCase());

      return dateInRange && matchesSearch;
    });

    this.totalPages = Math.ceil(this.filteredPqrs.length / this.itemsPerPage);
    this.updatePagination();
  }

  updatePagination() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    this.pagedPqrs = this.filteredPqrs.slice(startIndex, startIndex + this.itemsPerPage);
  }

  clearFilters() {
    this.fechaInicial = undefined;
    this.fechaFinal = undefined;
    this.searchText = '';
    this.filterPqrs();
  }

  // Métodos para resumen
  get totalPqrs(): number {
    return this.filteredPqrs.length;
  }

  get resueltas(): number {
    return this.filteredPqrs.filter(p => p.estado === 'Resuelta').length;
  }

  get enProceso(): number {
    return this.filteredPqrs.filter(p => p.estado === 'En Proceso').length;
  }

  get vencidas(): number {
    return this.filteredPqrs.filter(p => p.estado === 'Vencida').length;
  }

  // Navegación de paginación
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

  deletePqr(pqr: Pqr) {
    this.pqrsList = this.pqrsList.filter(p => p.id !== pqr.id);
    this.filterPqrs();
  }

  exportarPqrs() {
    // Implementar lógica de exportación
  }
}
