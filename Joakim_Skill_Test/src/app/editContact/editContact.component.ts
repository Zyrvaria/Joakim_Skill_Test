import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ApiService } from './../api.service'

import { Contact, contacts } from '../contacts';

@Component({
  selector: 'app-editContact',
  templateUrl: './editContact.component.html',
  styleUrls: ['./editContact.component.css'],
})
export class EditContactComponent implements OnInit {
  contacts = contacts;
  contact: Contact | undefined;
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
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private apiService: ApiService
  ) { }
  updateContact(id: number, payload: ContactPayload) {
    this.http.get('/createContact?token=' + this.apiService.getServiceToken() + '&id=' + id + '&payload=' + payload, { responseType: "text" }).subscribe(result => {
      console.log(result);
      this.getContacts(); //running this to send the update through apiService that the contacts have changed
    }, error => console.error(error));
  }
  getContacts() {
    this.http.get<Contact[]>('/getContacts?token=' + this.apiService.getServiceToken()/*, { responseType: "text" }*/).subscribe(result => {
      this.apiService.setContacts(result);
    }, error => console.error(error));
  }
  ngOnInit(): void {
    this.apiService.contactStatusChanged.subscribe(status => this.contacts = status);
    //first get the contact id from the current route.
    const routeParams = this.route.snapshot.paramMap;
    const contactIdFromRoute = Number(routeParams.get('contactId'));

    //find the contact that correspond with the id provided in route.
    this.contact = this.contacts.find(
      (contact) => contact.ID === contactIdFromRoute
    );
    //making sure we have a contact, if we do fill in the form with what info we have
    if (this.contact) {
      this.checkoutForm.setValue({
        Name: this.contact.Info.Name,
        PhoneCountryCode: this.contact.Info.DefaultPhone.CountryCode,
        Number: this.contact.Info.DefaultPhone.Number,
        Description: this.contact.Info.DefaultPhone.Description,
        Email: this.contact.Info.DefaultEmail.EmailAddress,
        AddressLine1: this.contact.Info.InvoiceAddress.AddressLine1,
        AddressLine2: this.contact.Info.InvoiceAddress.AddressLine2,
        AddressLine3: this.contact.Info.InvoiceAddress.AddressLine3,
        City: this.contact.Info.InvoiceAddress.City,
        Country: this.contact.Info.InvoiceAddress.Country,
        CountryCode: this.contact.Info.InvoiceAddress.CountryCode,
        PostalCode: this.contact.Info.InvoiceAddress.PostalCode,
        Region: this.contact.Info.InvoiceAddress.Region,
      });
    }
  }
  onSubmit(id: number): void {
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
    console.warn('Your contact has been edited', this.checkoutForm.value);
    this.updateContact(id, payload);
    //sending the user back to the full contact list page
    this.router.navigate(['/']);
  }
}
//this is here to help format the payload from the creation form better
//payload format found here: https://developer.softrig.com/wiki/how-to/contacts
//I am making an assumptuion here that the payload would be the same for creation and updating
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
