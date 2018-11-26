import { Component, Inject, Pipe, PipeTransform } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { AeronaveService } from '../../../services/aeronave.service';

@Component({
    selector: 'gridAeronave',
    templateUrl: './grid.component.html',
    styleUrls: ['./grid.component.css']
})

export class GridAeronaveComponent {

    public lstAeronave: AeronaveData[];
    public searchString: string;

    constructor(public http: Http, private _router: Router, private _aeronaveService: AeronaveService) {

        this.getAeronaves();
    }

    getAeronaves() {
        this._aeronaveService.getAeronaves()
            .subscribe(data => this.lstAeronave = data)
    }

    delete(aeronaveId: any) {
        var confirm = window.confirm("Deseja excluir a Aeronave: " + aeronaveId);

        if (confirm) {
            this._aeronaveService.deleteAeronave(aeronaveId).subscribe((data) => {
                this.getAeronaves();
            }, error => console.error(error))
        }
    }
}

interface AeronaveData {
    id: number;
    modelo: string;
    dataCriacao: string;
    quantidadeDePassageiros: number;
}