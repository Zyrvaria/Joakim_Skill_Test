import { Component } from '@angular/core';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css'],
})
export class TopBarComponent {
  loginFunction() {
    document.location.href = "https://test-login.softrig.com/connect/authorize?client_id=f6a294fc-ac05-4fdf-bd72-dd1f4d6cb157&redirect_uri=https://localhost:4200&response_type=code&prompt=login&scope=AppFramework profile openid offline_access";
  }
}
