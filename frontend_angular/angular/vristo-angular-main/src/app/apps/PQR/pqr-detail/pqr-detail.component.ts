// src/app/components/pqr-detail/pqr-detail.component.ts
import { Component, Input } from '@angular/core';
import { Pqr } from '../pqr.model';

@Component({
  selector: 'app-pqr-detail',
  templateUrl: './pqr-detail.component.html',
})
export class PqrDetailComponent {
  @Input() pqr!: Pqr;
}