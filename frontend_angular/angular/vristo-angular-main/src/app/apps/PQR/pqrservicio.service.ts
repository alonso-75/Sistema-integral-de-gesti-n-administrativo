// src/app/services/pqr.service.ts
import { Injectable } from '@angular/core';
import { Pqr } from './pqr.model';

@Injectable({
  providedIn: 'root',
})
export class PqrService {
  private pqrList: Pqr[] = [];
  private idCounter = 1;

  addPqr(pqr: Omit<Pqr, 'id' | 'fecha'>): Pqr {
    const newPqr: Pqr = { id: this.idCounter++, fecha: new Date(), ...pqr };
    this.pqrList.push(newPqr);
    return newPqr;
  }

  getPqrList(): Pqr[] {
    return this.pqrList;
  }
}