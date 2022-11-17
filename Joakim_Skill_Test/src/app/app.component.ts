import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterModule, Routes, Router } from '@angular/router';
import { Location } from '@angular/common';
import { ApiService } from './api.service'
import { Contact } from './contacts';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  private token?: string;

  constructor(private location: Location, private route: ActivatedRoute, private http: HttpClient, private apiService: ApiService) {}
  async ngOnInit() {
    const currentURL = this.location.path();
    const splitURL = currentURL.split('&');
    if (splitURL[0] != "") {
      this.getToken(splitURL[0]);
    }
  }
  getToken(code: string) {
    this.http.get('/getToken' + code, { responseType: "text" }).subscribe(result => {
      this.apiService.setServiceToken(result);
      console.log(result);
    }, error => console.error(error));
  }
  title = 'Joakim_Skill_Test';
}
