import { Component, ViewChild } from '@angular/core';
import { toggleAnimation } from 'src/app/shared/animations';
import Swal from 'sweetalert2';
import { NgxCustomModalComponent } from 'ngx-custom-modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
    templateUrl: './list-pqrs.html',
    animations: [toggleAnimation],
    styleUrls: ['./list-pqrs.css'],
})
export class listPqrsComponent {
    formVentanilla: FormGroup
  today = new Date().toISOString().split("T")[0]
    constructor(public fb: FormBuilder) {}
    @ViewChild('addTaskModal') addTaskModal!: NgxCustomModalComponent;
    @ViewChild('viewTaskModal') viewTaskModal!: NgxCustomModalComponent;
    defaultParams = {
        id: null,
        title: '',
        description: '',
        descriptionText: '',
        assignee: '',
        path: '',
        tag: '',
        priority: 'low',
    };

    selectedTab = '';
    isShowTaskMenu = false;

    params!: FormGroup;
    allTasks = [
        {
            id: 1,
            title: 'Reunión con Shaun Park a las 4:50pm',
            date: 'Ago, 07 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: 'equipo',
            priority: 'media',
            assignee: 'John Smith',
            path: '',
            status: '',
        },
        {
            id: 2,
            title: 'Reunión de equipo en Starbucks',
            date: 'Ago, 06 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: 'equipo',
            priority: 'baja',
            assignee: 'John Smith',
            path: 'profile-15.jpeg',
            status: '',
        },
        {
            id: 3,
            title: 'Reunión con Lisa para discutir detalles del proyecto',
            date: 'Ago, 05 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: 'actualización',
            priority: 'media',
            assignee: 'John Smith',
            path: 'profile-1.jpeg',
            status: 'completa',
        },
        {
            id: 4,
            title: 'Descarga completa',
            date: 'Ago, 04 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: '',
            priority: 'baja',
            assignee: 'John Smith',
            path: 'profile-16.jpeg',
            status: '',
        },
        {
            id: 5,
            title: 'Llamada con el Gerente de Marketing',
            date: 'Ago, 03 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: 'actualización',
            priority: 'alta',
            assignee: 'John Smith',
            path: 'profile-5.jpeg',
            status: 'importante',
        },
        {
            id: 6,
            title: 'Nuevo usuario registrado',
            date: 'Ago, 02 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: '',
            priority: 'media',
            assignee: '',
            path: '',
            status: 'importante',
        },
        {
            id: 7,
            title: 'Corregir problemas en el nuevo proyecto',
            date: 'Ago, 01 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: 'equipo',
            priority: 'media',
            assignee: 'John Smith',
            path: 'profile-17.jpeg',
            status: '',
        },
        {
            id: 8,
            title: 'Revisar toda la funcionalidad',
            date: 'Ago, 07 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: 'actualización',
            priority: 'media',
            assignee: 'John Smith',
            path: 'profile-18.jpeg',
            status: 'importante',
        },
        {
            id: 9,
            title: 'Revisar repositorio',
            date: 'Ago, 07 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: 'equipo',
            priority: 'media',
            assignee: 'John Smith',
            path: 'profile-20.jpeg',
            status: 'completa',
        },
        {
            id: 10,
            title: 'Tareas eliminadas',
            date: 'Ago, 08 2020',
            description:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            descriptionText:
                'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi pulvinar feugiat consequat. Duis lacus nibh, sagittis id varius vel, aliquet non augue. Vivamus sem ante, ultrices at ex a, rhoncus ullamcorper tellus. Nunc iaculis eu ligula ac consequat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum mattis urna neque, eget posuere lorem tempus non. Suspendisse ac turpis dictum, convallis est ut, posuere sem. Etiam imperdiet aliquam risus, eu commodo urna vestibulum at. Suspendisse malesuada lorem eu sodales aliquam.',
            tag: 'equipo',
            priority: 'media',
            assignee: 'John Smith',
            path: 'profile-15.jpeg',
            status: 'eliminada',
        },
        // Continúa con el resto de las tareas traducidas...
    ];
    filteredTasks: any = [];
    pagedTasks: any = [];
    searchTask = '';
    selectedTask: any = this.defaultParams;
    isPriorityMenu: any = null;
    isTagMenu: any = null;

    pager = {
        currentPage: 1,
        totalPages: 0,
        pageSize: 10,
        startIndex: 0,
        endIndex: 0,
    };

    editorOptions = {
        toolbar: [[{ header: [1, 2, false] }], ['bold', 'italic', 'underline', 'link'], [{ list: 'ordered' }, { list: 'bullet' }], ['clean']],
    };

    ngOnInit() {

        this.formVentanilla = this.fb.group({
            radicacion: ["", Validators.required],
            fechaRecibo: [this.today, Validators.required],
            remitente: ["", Validators.required],
            tipoSolicitud: ["", Validators.required],
            asunto: ["", Validators.required],
            folios: ["", [Validators.required, Validators.min(1)]],
            recibido: ["", Validators.required],
            razon: [""],
            responsable: ["", Validators.required],
            fechaEntrega: [this.today, Validators.required],
            fechaVencimiento: [this.today, Validators.required],
            fechaSalida: [this.today],
            diasFaltantes: [{ value: "Días faltantes", disabled: true }],
            cumplimiento: [""],
          })
        this.searchTasks();
    }

    initForm() {
        this.params = this.fb.group({
            id: [null],
            title: ['', Validators.required],
            description: [''],
            descriptionText: [''],
            assignee: [''],
            path: [''],
            tag: [''],
            priority: ['low'],
        });
    }

    searchTasks(isResetPage = true) {
        if (isResetPage) {
            this.pager.currentPage = 1;
        }
        let res;
        if (this.selectedTab === 'complete' || this.selectedTab === 'important' || this.selectedTab === 'trash') {
            res = this.allTasks.filter((d) => d.status === this.selectedTab);
        } else {
            res = this.allTasks.filter((d) => d.status != 'trash');
        }

        if (this.selectedTab === 'team' || this.selectedTab === 'update') {
            res = res.filter((d) => d.tag === this.selectedTab);
        } else if (this.selectedTab === 'alta' || this.selectedTab === 'media' || this.selectedTab === 'baja') {
            res = res.filter((d) => d.priority === this.selectedTab);
        }
        this.filteredTasks = res.filter((d) => d.title?.toLowerCase().includes(this.searchTask));
        this.getPager();
    }

    getPager() {
        setTimeout(() => {
            if (this.filteredTasks.length) {
                this.pager.totalPages = this.pager.pageSize < 1 ? 1 : Math.ceil(this.filteredTasks.length / this.pager.pageSize);
                if (this.pager.currentPage > this.pager.totalPages) {
                    this.pager.currentPage = 1;
                }
                this.pager.startIndex = (this.pager.currentPage - 1) * this.pager.pageSize;
                this.pager.endIndex = Math.min(this.pager.startIndex + this.pager.pageSize - 1, this.filteredTasks.length - 1);
                this.pagedTasks = this.filteredTasks.slice(this.pager.startIndex, this.pager.endIndex + 1);
            } else {
                this.pagedTasks = [];
                this.pager.startIndex = -1;
                this.pager.endIndex = -1;
            }
        });
    }

    setPriority(task: any, name: string = '') {
        let item = this.filteredTasks.find((d: { id: any }) => d.id === task.id);
        item.priority = name;
        this.searchTasks(false);
    }

    setTag(task: any, name: string = '') {
        let item = this.filteredTasks.find((d: { id: any }) => d.id === task.id);
        item.tag = name;
        this.searchTasks(false);
    }

    tabChanged(type: any = null) {
        this.selectedTab = type;
        this.searchTasks();
        this.isShowTaskMenu = false;
    }

    taskComplete(task: any = null) {
        let item = this.filteredTasks.find((d: { id: any }) => d.id === task.id);
        item.status = item.status === 'complete' ? '' : 'complete';
        this.searchTasks(false);
    }

    setImportant(task: any = null) {
        let item = this.filteredTasks.find((d: { id: any }) => d.id === task.id);
        item.status = item.status === 'important' ? '' : 'important';
        this.searchTasks(false);
    }

    viewTask(item: any = null) {
        this.selectedTask = item;
        setTimeout(() => {
            this.viewTaskModal.open();
        });
    }

    addEditTask(task: any = null) {
        this.isShowTaskMenu = false;

        this.addTaskModal.open();
        this.initForm();

        if (task) {
            this.params.setValue({
                id: task.id,
                title: task.title,
                description: task.description,
                descriptionText: task.descriptionText,
                assignee: task.assignee,
                path: task.path,
                tag: task.tag,
                priority: task.priority,
            });
        }
    }

    deleteTask(task: any, type: string = '') {
        if (type === 'delete') {
            let currtask = this.allTasks.find((d: any) => d.id === task.id);
            currtask!.status = 'trash';
        }
        if (type === 'deletePermanent') {
            this.allTasks = this.allTasks.filter((d: any) => d.id != task.id);
        } else if (type === 'restore') {
            let currtask = this.allTasks.find((d: any) => d.id === task.id);
            currtask!.status = '';
        }
        this.searchTasks(false);
    }

    saveTask() {
        if (!this.params.value.title) {
            this.showMessage('Title is required.', 'error');
            return;
        }

        if (this.params.value.id) {
            //update task
            this.allTasks = this.allTasks.map((d: any) => {
                if (d.id === this.params.value.id) {
                    d = { ...d, ...this.params.value };
                    d.descriptionText = this.params.value.descriptionText; //this.quillEditorObj.getText();
                }
                return d;
            });
            this.searchTasks();
        } else {
            //add task
            const maxid = this.allTasks.length ? this.allTasks.reduce((max, obj) => (obj.id > max ? obj.id : max), this.allTasks[0].id) : 0;

            const today = new Date();
            const dd = String(today.getDate()).padStart(2, '0');
            const mm = String(today.getMonth());
            const yyyy = today.getFullYear();
            const monthNames: any = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

            let task = this.params.value;
            task.id = maxid + 1;
            task.descriptionText = this.params.value.descriptionText; //this.quillEditorObj.getText();
            task.date = monthNames[mm] + ', ' + dd + ' ' + yyyy;

            this.allTasks.splice(0, 0, task);
            this.searchTasks();
        }

        this.showMessage('Task has been saved successfully.');
        this.addTaskModal.close();
    }

    showMessage(msg = '', type = 'success') {
        const toast: any = Swal.mixin({
            toast: true,
            position: 'top',
            showConfirmButton: false,
            timer: 3000,
            customClass: { container: 'toast' },
        });
        toast.fire({
            icon: type,
            title: msg,
            padding: '10px 20px',
        });
    }

    setDiscriptionText(event: any) {
        this.params.patchValue({ descriptionText: event.text });
    }

    getTasksLength(type: string) {
        return this.allTasks.filter((task) => task.status == type).length;
    }
    onSubmit() {
        if (this.formVentanilla.valid) {
          console.log(this.formVentanilla.value)
          // Implement form submission logic here
        } else {
          // Mark all fields as touched to trigger validation messages
          Object.keys(this.formVentanilla.controls).forEach((key) => {
            this.formVentanilla.get(key)?.markAsTouched()
          })
        }
      }

    cancel() {
        this.formVentanilla.reset()
        // Add any additional cancel logic here
      }
}
