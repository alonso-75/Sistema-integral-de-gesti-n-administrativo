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
    codeArr: any = [];
        basic: FlatpickrDefaultsInterface;
    
    toggleCode = (name: string) => {
        if (this.codeArr.includes(name)) {
            this.codeArr = this.codeArr.filter((d: string) => d != name);
        } else {
            this.codeArr.push(name);
        }
    };
    pqrForm: FormGroup<any>;
    form1!: FormGroup;
    onSubmit() {
        throw new Error('Method not implemented.');
    }
    pqr: Omit<Pqr, 'id' | 'fecha'> = {
        tipo: '',
        descripcion: '',
    };

    constructor(private pqrService: PqrService, private fb:FormBuilder) {

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
