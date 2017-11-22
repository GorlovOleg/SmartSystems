import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'broker',
    templateUrl: './broker.component.html'
})
export class BrokerComponent {
    public brokers: pBroker[];

    constructor(http: Http) {
        http.get('/api/Broker').subscribe(result => {
            this.brokers = result.json() as pBroker[];
        });
    }
}


interface pBroker {

    pBrokerId: number;
    FirstName: string;    
    LastName: string;
    Phone: string;
    Email: string;
    ImageUrl: string;
    pBrokerageId: string;
    LastUpdated: string;

}
