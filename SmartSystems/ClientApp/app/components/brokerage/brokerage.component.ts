import { Component } from '@angular/core';
import { Http } from '@angular/http';
import {
    ButtonModule,
    GrowlModule,
    Message
} from 'primeng/primeng';

//import { GalleriaModule } from 'primeng/primeng';


@Component({
    selector: 'brokerage',
    templateUrl: './brokerage.component.html'
})
export class BrokerageComponent {
    public brokerages: pBrokerage[];

    public msgs: Message[] = [];

    public incrementCounter() {
        //this.currentCount++;
        this.msgs.push(
            {
                summary: '...',

                //detail: this.currentCount.toString()
            });

    }

    constructor(http: Http) {
        http.get('/api/Brokerage').subscribe(result => {
            this.brokerages = result.json() as pBrokerage[];
        });
    }
}


interface pBrokerage {

    pBrokerageId: number;
    pBrokerageName: string;
    Street: string;
    City: string;
    PostalCode: string;
    Phone: string;
    Website: string;
    LastUpdated: string;

}
