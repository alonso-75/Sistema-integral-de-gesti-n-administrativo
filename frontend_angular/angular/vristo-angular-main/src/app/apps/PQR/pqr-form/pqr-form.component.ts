// src/app/components/pqr-form/pqr-form.component.ts
import { Component } from '@angular/core';
import { PqrService } from '../pqrservicio.service';
import { Pqr } from '../pqr.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FileUploadWithPreview } from 'file-upload-with-preview';
import { FlatpickrDefaultsInterface } from 'angularx-flatpickr';

@Component({
    selector: 'app-pqr-form',
    templateUrl: './pqr-form.component.html',
})
export class PqrFormComponent {
    tiposolicitud: any[] = [
        '',
        'ACCION DE TUTELA',
        'PERMISO',
        'DERECHO DE PETICION',
        'CERTIFICADO',
        'INFORMACION',
        'INSIDENTE DESACATO',
        'QUERELLA',
        'FALLO',
        'PROCESOS JUDICIALES',
    ];
    dependecias: any[] = [
        'JURIDICA',
        'CONTOL INTERNO',
        'DESPACHO DELALACALDE',
        'GESTION SOCIAL',
        'SECRETARIA DE GOBIERNO',
        'SECRETARIA DE HACIENDA',
        'SECRETARIA DE PLANEACION',
        'SECRETARIA DE SALUD',
        'SECRETARIA GENERAL',
        'SEC-GOB-COMISARIA',
        'SEC-GOB-DISCAPACIDAD',
        'SEC-GOB-FAMILIAS EN ACCION',
        'SEC-GOB-GESTION DE RIESGO',
        'SEC-GOB-INSPECCION',
        'SEC-GOB-VICTIMAS',
        'SEC-GOB-DEPORTE',
        'SEC-GOB-ICBF',
        'SEC-GOB-ADULTO MAYOR',
        'SEC-GOB-SISBEN',
        'SEC-GOB-TRANSITO',
        'SEC-GOB-CONTABILIDAD',
        'SEC-GOB-PRESUPUESTO',
        'SEC-GOB-TESORERIA',
        'SEC-GOB-UMATA',
        'SEC-GOB-ARCHIVO',
        'SEC-GOB-CONTRATACION',
        'SEC-GOB-TALENTO HUMANO',





        
    ];
    codeArr: any = [];
    basic: FlatpickrDefaultsInterface;
    pqrForm: FormGroup<any>;
    form1!: FormGroup;
    input6: any[];

    pqr: Omit<Pqr, 'id' | 'fecha'> = {
        tipo: '',
        descripcion: '',
    };

    constructor(
        private pqrService: PqrService,
        private fb: FormBuilder,
    ) {
        this.basic = {
            dateFormat: 'Y-m-d',
            // position: this.store.rtlClass === 'rtl' ? 'auto right' : 'auto left',
            monthSelectorType: 'dropdown',
        };
    }
    ngOnInit() {
        this.form1 = this.fb.group({
            date1: ['2022-07-05'],
        });
        // single image upload
        new FileUploadWithPreview('myFirstImage', {
            images: {
                baseImage: '/assets/images/file-preview.svg',
                backgroundImage: '',
            },
        });
    }
    onSubmit() {
        throw new Error('Method not implemented.');
    }

    submitPqr() {
        if (this.pqr.tipo && this.pqr.descripcion) {
            this.pqrService.addPqr(this.pqr);
            alert('PQR enviada con éxito');
            this.pqr = { tipo: '', descripcion: '' }; // Reset form
        } else {
            alert('Por favor, complete todos los campos.');
        }
    }
}
