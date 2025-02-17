// src/app/components/pqr-list/pqr-list .component.ts
import { Component, OnInit } from '@angular/core';
import { Pqr } from '../pqr.model';
import { PqrService } from '../pqrservicio.service';

@Component({
  selector: 'app-pqr-list',
  templateUrl: './pqr-list.component.html',
})
export class PqrListComponent implements OnInit {
  pqrList: Pqr[] = [];

  constructor(private pqrService: PqrService) {}

  ngOnInit() {
    this.pqrList = this.pqrService.getPqrList();
  }
}