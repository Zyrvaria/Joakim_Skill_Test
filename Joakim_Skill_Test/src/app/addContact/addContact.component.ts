import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ApiService } from './../api.service'

import { Contact } from '../contacts';

@Component({
  selector: 'app-addContact',
  templateUrl: './addContact.component.html',
  styleUrls: ['./addContact.component.css'],
})
export class AddContactComponent implements OnInit {
  checkoutForm = this.formBuilder.group({
    Name: '',
    PhoneCountryCode: '',
    Number: '',
    Description: '',
    Email: '',
    AddressLine1: '',
    AddressLine2: '',
    AddressLine3: '',
    City: '',
    Country: '',
    CountryCode: '',
    PostalCode: '',
    Region: '',
  });
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private apiService: ApiService
  ) { }
  ngOnInit(): void {}
  onSubmit(): void {
    //process contact data here
    const payload: ContactPayload = {
      Info: {
        Name: this.checkoutForm.value.Name ?? "",
        InvoiceAddress: {
          AddressLine1: this.checkoutForm.value.AddressLine1 ?? "",
          AddressLine2: this.checkoutForm.value.AddressLine2 ?? "",
          AddressLine3: this.checkoutForm.value.AddressLine3 ?? "",
          City: this.checkoutForm.value.City ?? "",
          Country: this.checkoutForm.value.Country ?? "",
          CountryCode: this.checkoutForm.value.CountryCode ?? "",
          PostalCode: this.checkoutForm.value.PostalCode ?? "",
        },
        DefaultPhone: {
          CountryCode: this.checkoutForm.value.PhoneCountryCode ?? "",
          Description: this.checkoutForm.value.Description ?? "",
          Number: this.checkoutForm.value.Number ?? "",
        },
        DefaultEmail: {
          EmailAddress: this.checkoutForm.value.Email ?? "",
        },
      }
    };
    console.warn('Your contact has been added', this.checkoutForm.value);
    this.createContact(payload);
    //sending the user back to the full contact list page
    this.router.navigate(['/']);
  }
  createContact(payload: ContactPayload) {
    this.http.get('/createContact?token=' + this.apiService.getServiceToken() + '&payload=' + payload, { responseType: "text" }).subscribe(result => {
      console.log(result);
      this.getContacts(); //running this to send the update through apiService that the contacts have changed
    }, error => console.error(error));
  }
  getContacts() {
    this.http.get<Contact[]>('/getContacts?token=' + this.apiService.getServiceToken()/*, { responseType: "text" }*/).subscribe(result => {
      this.apiService.setContacts(result);
    }, error => console.error(error));
  }
}
//this is here to help format the payload from the creation form better
//payload format found here: https://developer.softrig.com/wiki/how-to/contacts
export interface ContactPayload {
  Info: {
    Name: string;
    InvoiceAddress: {
      AddressLine1: string;
      AddressLine2: string;
      AddressLine3: string;
      City: string;
      Country: string;
      CountryCode: string;
      PostalCode: string;
    };
    DefaultPhone: {
      CountryCode: string;
      Description: string;
      Number: string;
    };
    DefaultEmail: {
      EmailAddress: string;
    };
  };
}
