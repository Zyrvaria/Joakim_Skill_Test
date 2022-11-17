import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from './../api.service'

import { contacts } from '../contacts';
import { Contact } from '../contacts';

@Component({
  selector: 'app-contactList',
  templateUrl: './contactList.component.html',
  styleUrls: ['./contactList.component.css'],
})
export class ContactListComponent implements OnInit {
  selectedFilter = '';
  contacts = contacts;
  constructor(private http: HttpClient, private apiService: ApiService) {
    
  }
  
  getContacts() {
    this.http.get<Contact[]>('/getContacts?token=' + this.apiService.getServiceToken()).subscribe(result => {
      this.apiService.setContacts(result);
    }, error => console.error(error));
  }
  getContactsWithFilter(filter: string) {
    this.http.get<Contact[]>('/getContactsWithFilter?token=' + this.apiService.getServiceToken() + filter).subscribe(result => {
      this.apiService.setContacts(result);
      
    }, error => console.error(error));
  }
  deleteContact(id: number) {
    //double check that the user didn't just misclick
    if (confirm('Do you sure you want to delete this contact?')) {
      this.http.get('/deleteContact?token=' + this.apiService.getServiceToken() + '&id=' + id, { responseType: "text" }).subscribe(result => {
      }, error => console.error(error));
    }
  }
  onSelected(value: string): void {
    this.selectedFilter = value;
  }

  filterContacts(filterList: any, filter: any) {
    var url: string = '';
    //use a switch statement to see what we need to filter for
    switch (filterList.value) {
      case '1': {
        //no filter
        break;
      }
      case '2': {
        //name filter
        url += `&filter=contains(Info.Name,'${filter.value}')`;
        break;
      }
      case '3': {
        //phone number filter
        url += `&filter=contains(Info.DefaultPhone.Number,'${filter.value}')`;
        break;
      }
      case '4': {
        //email filter
        url += `&filter=contains(Info.DefaultEmail.EmailAddress,'${filter.value}')`;
        break;
      }
      case '5': {
        //country filter
        url += `&filter=contains(Info.InvoiceAddress.Country,'${filter.value}')`;
        break;
      }
      default: {
        console.log('Something broke');
        break;
      }
    }
    console.log(url);
    if (url != '') {
      this.getContactsWithFilter(url);
    }
    else {
      this.getContacts();
    }
  }
  ngOnInit(): void {
    this.apiService.contactStatusChanged.subscribe(status => this.contacts = status);
    this.contacts = this.apiService.getContacts();
  }
}
