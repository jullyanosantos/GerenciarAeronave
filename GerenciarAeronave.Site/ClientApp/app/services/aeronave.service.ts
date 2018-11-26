import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class AeronaveService {

    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = "http://localhost:54087/"; //baseUrl;
    }

    getAeronaves() {
        return this._http.get(this.myAppUrl + 'api/aeronave/list-all')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getAeronaveById(id: number) {
        return this._http.get(this.myAppUrl + "api/aeronave/get-aeronave/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveAeronave(aeronave: object) {
        return this._http.post(this.myAppUrl + 'api/aeronave/save-aeronave', aeronave)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateAeronave(aeronave: object) {
        return this._http.put(this.myAppUrl + 'api/aeronave/update-aeronave', aeronave)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteAeronave(id: number) {
        return this._http.delete(this.myAppUrl + "api/aeronave/delete-aeronave/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}