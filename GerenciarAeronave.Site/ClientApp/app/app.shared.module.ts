import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { DatePipe } from '@angular/common';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { FilterPipe } from './components/aeronave/grid/filter.pipe';

import { GridAeronaveComponent } from './components/aeronave/grid/grid.component';
import { CreateAeronave } from './components/aeronave/add/add.component';
import { AeronaveService } from './services/aeronave.service';
import { AutofocusDirective } from './components/helpers/focus-directive';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,

        GridAeronaveComponent,
        CreateAeronave,
        FilterPipe,
        AutofocusDirective,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule, //tive q add pra funcionar
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'exibir-aeronaves', component: GridAeronaveComponent },
            { path: 'criar-aeronave', component: CreateAeronave },
            { path: 'aeronave/editar/:id', component: CreateAeronave },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        AeronaveService,
        //CustomCurrencyPipe,
        //CustomDateFormatterPipe,
        //DatePipe
    ],
    exports: [
        FilterPipe,
    ],
})
export class AppModuleShared {
}