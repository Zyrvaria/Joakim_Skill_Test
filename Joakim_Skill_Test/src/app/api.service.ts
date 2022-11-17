import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, RouterModule, Routes, Router } from '@angular/router';
import { Location } from '@angular/common';
import { EventEmitter, Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class ApiService {
  tokenStatusChanged: EventEmitter<any> = new EventEmitter();
  private myToken: any;
  contactStatusChanged: EventEmitter<any> = new EventEmitter();
  private myContacts: any;
  constructor() { }
  getServiceToken(): any {
    return this.myToken;
  }
  setServiceToken(value: any) {
    this.myToken = value;
    this.tokenStatusChanged.emit(value);
  }
  getContacts(): any {
    return this.myContacts;
  }
  setContacts(value: any) {
    this.myContacts = value;
    this.tokenStatusChanged.emit(value);
  }
}
