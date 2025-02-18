// src/app/components/pqr-edit/pqr-edit.component.ts
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-pqr-edit',
  template: `
    <form [formGroup]="pqrForm" (ngSubmit)="onSubmit()" class="p-4 bg-white rounded shadow">
      <h2 class="text-2xl font-bold mb-4">Editar PQR</h2>
      <div class="grid grid-cols-2 gap-4">
        <div>
          <label for="title" class="block mb-1">Título:</label>
          <input id="title" formControlName="title" class="w-full p-2 border rounded">
        </div>
        <div>
          <label for="description" class="block mb-1">Descripción:</label>
          <textarea id="description" formControlName="description" class="w-full p-2 border rounded"></textarea>
        </div>
        <div>
          <label for="type" class="block mb-1">Tipo:</label>
          <select id="type" formControlName="type" class="w-full p-2 border rounded">
            <option value="Petition">Petition</option>
            <option value="Complaint">Complaint</option>
            <option value="Claim">Claim</option>
          </select>
        </div>
        <div>
          <label for="status" class="block mb-1">Estado:</label>
          <select id="status" formControlName="status" class="w-full p-2 border rounded">
            <option value="Pending">Pending</option>
            <option value="In Progress">In Progress</option>
            <option value="Resolved">Resolved</option>
          </select>
        </div>
        <div>
          <label for="priority" class="block mb-1">Prioridad:</label>
          <select id="priority" formControlName="priority" class="w-full p-2 border rounded">
            <option value="Low">Low</option>
            <option value="Medium">Medium</option>
            <option value="High">High</option>
          </select>
        </div>
      </div>
      <div class="mt-4">
        <button type="submit" class="px-4 py-2 bg-blue-500 text-white rounded">Guardar cambios</button>
      </div>
    </form>
  `
})
export class PqrEditComponent {
  @Input() pqr: any;
  @Output() save = new EventEmitter<any>();

  pqrForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.pqrForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      type: ['', Validators.required],
      status: ['', Validators.required],
      priority: ['', Validators.required]
    });
  }

  ngOnInit() {
    if (this.pqr) {
      this.pqrForm.patchValue(this.pqr);
    }
  }

  onSubmit() {
    if (this.pqrForm.valid) {
      this.save.emit(this.pqrForm.value);
    }
  }
}