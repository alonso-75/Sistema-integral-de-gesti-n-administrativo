import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NavigationEnd, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { AppService } from 'src/app/service/app.service';

@Component({
    selector: 'app-atencion-ciudadano',
    templateUrl: './atencion-ciudadano.component.html',
    styleUrl: './atencion-ciudadano.component.css',
})
export class AtencionCiudadanoComponent {
    form: FormGroup;
    currentStep = 0;
    options = ['Orange', 'White', 'Purple'];
    input4: string | undefined;

    steps = [
        { label: 'Consultar Documento', controlName: 'documento' },
        { label: 'Informacion General', controlName: 'informacionpersonal' },
        { label: 'Motivo de Visita', controlName: 'motivovisita' },
        { label: 'Confirmación', controlName: 'confirmation' },
    ];

    constructor(private fb: FormBuilder) {}

    ngOnInit() {
        this.form = this.fb.group({
            documento: this.fb.group({
                tipodocumento: ['', [Validators.required, Validators.minLength(2)]],
                numerodocumento: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(10)]],
            }),
            informacionpersonal: this.fb.group({
                Primernombre: ['', [Validators.required]],
                Segundonombre: [''],
                Primerapellido: ['', Validators.required],
                Segundoapellido: ['', Validators.required],
                Genero: ['', Validators.required],
                Fechadenacimiento: ['', Validators.required],
                pertenenciaetnica: ['', Validators.required],
                Tipodepoblacion: ['', Validators.required],
                Correoelectronico: ['',[Validators.required,Validators.email]],
                Telefonosdecontacto: ['', Validators.required],
                Direccion: ['', Validators.required],
            }),
            motivovisita: this.fb.group({
                Tipodeatencion: ['', Validators.required],
                Fechadelaatencion: ['', Validators.required],
                Asunto: ['', Validators.required],
                Descripcion: ['', Validators.required],
                Atendidopor: ['', Validators.required],
                DependenciaoSecretaríaqueatiende: ['', Validators.required],
                Oficinaoprogramaqueatiende: ['', Validators.required],
            }),
            confirmation: this.fb.group({
                termsAccepted: [false, Validators.requiredTrue],
            }),
        });
    }

    passwordMatchValidator(g: FormGroup) {
        return g.get('password').value === g.get('confirmPassword').value ? null : { mismatch: true };
    }

    onNext() {
        if (this.currentStep < this.steps.length - 1 && this.isStepValid(this.currentStep)) {
            this.currentStep++;
        }
    }

    onPrevious() {
        if (this.currentStep > 0) {
            this.currentStep--;
        }
    }

    onSubmit() {
        if (this.form.valid) {
            console.log('Formulario enviado:', this.form.value);
            // Aquí iría la lógica para enviar el formulario al servidor
        } else {
            console.log('Formulario inválido');
            this.form.markAllAsTouched();
        }
    }

    isStepValid(index: number): boolean {
        const stepControl = this.form.get(this.steps[index].controlName);
        return stepControl.valid && stepControl.touched;
    }

    getFormErrorMessage(controlName: string, errorType: string): string {
        const control = this.form.get(controlName);
        if (control && control.hasError(errorType) && (control.touched || control.dirty)) {
            switch (errorType) {
                case 'required':
                    return 'Este campo es requerido.';
                case 'email':
                    return 'Por favor, ingrese un email válido.';
                case 'minlength':
                    return `Debe tener al menos ${control.errors['minlength'].requiredLength} caracteres.`;
                case 'pattern':
                    return 'Formato inválido.';
                default:
                    return 'Este campo es inválido.';
            }
        }
        return '';
    }
}
