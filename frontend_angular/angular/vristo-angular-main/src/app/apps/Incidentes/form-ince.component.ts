import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FlatpickrDefaultsInterface } from 'angularx-flatpickr';

@Component({
  selector: 'app-form-ince',
  templateUrl: './form-ince.component.html',
})
export class FormInceComponent implements OnInit {

  basic: FlatpickrDefaultsInterface;
  incidenteForm: FormGroup;
  referenciaGenerada: string = '';

  constructor(private fb: FormBuilder) {
    this.incidenteForm = this.fb.group({
      titulo: ['', Validators.required],
      tipo: ['', Validators.required],
      referencia: [{ value: '', disabled: true }],
    });

    this.basic = {
        dateFormat: 'Y-m-d',
        // position: this.store.rtlClass === 'rtl' ? 'auto right' : 'auto left',
        monthSelectorType: 'dropdown',
    };
  }


  ngOnInit(): void {
    this.generarReferencia();
  }

  generarReferencia(): void {
    const fecha = new Date();
    const año = fecha.getFullYear();
    const numeroAleatorio = Math.floor(Math.random() * 1000).toString().padStart(3, '0');
    this.referenciaGenerada = `INC-${año}-${numeroAleatorio}`;
    this.incidenteForm.patchValue({ referencia: this.referenciaGenerada });
  }

  guardarIncidente(): void {
    if (this.incidenteForm.invalid) {
      alert('Por favor, complete todos los campos obligatorios.');
      return;
    }

    const incidenteData = this.incidenteForm.value;
    console.log('Reporte de incidente:', incidenteData);
    alert('Reporte de incidente enviado correctamente');
    this.limpiarFormulario();
  }

  limpiarFormulario(): void {
    this.incidenteForm.reset();
    this.generarReferencia();
  }
}

