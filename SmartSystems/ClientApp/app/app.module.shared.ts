import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './components/app/app.component'
import { HomeComponent } from './components/home/home.component';
import { UserComponent } from './components/user/user.component';
import { BrokerageBrokersComponent } from './components/brokeragebrokers/brokeragebrokers.component';
import { BrokerComponent } from './components/broker/broker.component';
import { BrokerageComponent } from './components/brokerage/brokerage.component';

import {
    ButtonModule,
    InputTextModule,
    PasswordModule,
    GrowlModule,
    DialogModule,
    FileUploadModule,
    DataTableModule,
    MenubarModule,
    TieredMenuModule,
    ToolbarModule,
    TabViewModule,
    PanelModule,
    InputSwitchModule,
    SharedModule


} from 'primeng/primeng';

import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { MenuComponent } from './components/app-menu/menu.component';
import { TopMenuComponent } from './components/app-menu/top-menu.component';
import { SideMenuComponent } from './components/app-menu/side-menu.component';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        MenuComponent,
        TopMenuComponent,
        SideMenuComponent,
        UserComponent,
        LoginComponent,
        RegisterComponent,
        BrokerageBrokersComponent,
        BrokerComponent,
        BrokerageComponent
    ],
    imports: [
        CommonModule,
        BrowserAnimationsModule,
        FormsModule,
        HttpModule,
        ButtonModule,
        InputTextModule,
        PasswordModule,
        GrowlModule,
        DialogModule,
        FileUploadModule,
        DataTableModule,
        MenubarModule,
        TieredMenuModule,
        ToolbarModule,
        TabViewModule,
        PanelModule,
        InputSwitchModule,
        SharedModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'brokeragebrokers', component: BrokerageBrokersComponent },
            { path: 'broker', component: BrokerComponent },
            { path: 'brokerage', component: BrokerageComponent },
            { path: '**', redirectTo: 'home' }
            
        ])
    ]
})
export class AppModuleShared {
}