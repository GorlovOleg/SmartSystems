import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MenuItem } from 'primeng/primeng';
import { UserComponent } from '../../components/user/user.component';

var temp = false;


@Injectable()
export class MenuService {

    getDefaultMenu2(): MenuItem[] {
        return [
            {
                label: 'Home',
                icon: 'fa fa-fw fa-home', routerLink: ['/']
            },
            {
                label: 'Reports Public', icon: 'fa fa-fw fa-sitemap',
                items: [
                ]
            }
        ];
    }

    getDefaultMenu(): MenuItem[]
    {
        return [
            {
                label: 'Home',
                icon: 'fa fa-fw fa-home', routerLink: ['/']
            },
            {
                label: 'Reports', icon: 'fa fa-fw fa-sitemap',
                items: [
                    {
                        label: 'BrokerageBrokers',
                        icon: 'fa fa-fw fa-list-ol', routerLink: ['/brokeragebrokers']
                    },
                    //{
                    //    label: 'Broker',
                    //    icon: 'fa fa-fw fa-list-ol', routerLink: ['/broker']
                    //},
                    {
                        label: 'Brokerage',
                        icon: 'fa fa-fw fa-list-ol', routerLink: ['/brokerage']
                    },
                
                ]
            }
        ];


    }


}