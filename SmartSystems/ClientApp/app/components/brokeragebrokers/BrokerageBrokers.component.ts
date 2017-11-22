import { Component } from '@angular/core';
import { Http } from "@angular/http";

@Component({
    selector: 'brokeragebrokers',
    template: require('./brokeragebrokers.component.html')
})

export class BrokerageBrokersComponent {
    public brokerages: pBrokerage[] = [];
    public brokers: pBrokers[] = [];

    Title: string;
    activeRow: string = "0";

    constructor(public http: Http) {
        this.Title = "Brokerage includes Brokers";
        this.getBrokerageBrokersData();
    }

    getBrokerageBrokersData() {

        this.http.get('/api/BrokerageBrokers/Brokerage').subscribe(result => {
            this.brokerages = result.json() as pBrokerage[];
        });
    }


    getBrokers(pBrokerageId) {
        this.http.get('/api/BrokerageBrokers/Brokers/' + pBrokerageId).subscribe(result => {
            this.brokers = result.json() as pBrokers[];
        });
        this.activeRow = pBrokerageId;
    }
}

//--- Brokerage
export interface pBrokerage {
    pBrokerageId: number;
    pBrokerageName: string;
    Street: string;
    City: string;
    PostalCode: string;
    Phone: string;
    Website: string;

}
//-- Brokers
export interface pBrokers {
    pBrokerId: number;
    FirstName: string;
    LastName: string;
    Phone: string;
    Email: string;
    ImageUrl: string;
    pBrokerageId: string;

}