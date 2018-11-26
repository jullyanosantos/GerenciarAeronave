import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { GridAeronaveComponent } from '../grid/grid.component';
import { AeronaveService } from '../../../services/aeronave.service';

@Component({
    selector: 'CreateAeronave',
    templateUrl: './add.component.html'
})

export class CreateAeronave implements OnInit {

    aeronaveForm: FormGroup;
    title: string = "Cadastrar";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _aeronaveService: AeronaveService, private _router: Router) {

        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.aeronaveForm = this._fb.group({
            id: 0,
            modelo: ['', [Validators.required]],
            dataCriacao: [''],
            quantidadeDePassageiros: ['', [Validators.required]],
        })

        if (this.id == undefined || this.id == 0)
            this.aeronaveForm.controls['dataCriacao'].setValue(new Date().toLocaleString().substring(0, 10));
    }

    ngOnInit() {

        if (this.id > 0) {
            this.title = "Editar";
            debugger
            this._aeronaveService.getAeronaveById(this.id)
                .subscribe(resp => this.aeronaveForm.setValue(resp)
                    , error => this.errorMessage = error);
        }
        else {
            if (this.dataCriacao)
                this.dataCriacao.get(new Date().toISOString().split('T')[0]);
        }
    }

    save() {

        debugger
        if (!this.aeronaveForm.valid) {
            return;
        }

        //alert(this.title);
        if (this.title == "Cadastrar") {
            this._aeronaveService.saveAeronave(this.aeronaveForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/exibir-aeronaves']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Editar") {

            debugger
            this._aeronaveService.updateAeronave(this.aeronaveForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/exibir-aeronaves']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/exibir-aeronaves']);
    }

    get modelo() { return this.aeronaveForm.get('modelo'); }
    get dataCriacao() { return this.aeronaveForm.get('dataCriacao'); }
    get quantidadeDePassageiros() { return this.aeronaveForm.get('quantidadeDePassageiros'); }
}