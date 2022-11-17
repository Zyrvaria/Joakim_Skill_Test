import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ContactListComponent } from './contactList/contactList.component';
import { EditContactComponent } from './editContact/editContact.component';
import { AddContactComponent } from './addContact/addContact.component';
import { ApiService } from './api.service'
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    ContactListComponent,
    EditContactComponent,
    AddContactComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ContactListComponent },
      { path: 'contacts/:contactId', component: EditContactComponent },
      { path: 'addContact', component: AddContactComponent },
    ]),
  ],
  providers: [
    ApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
