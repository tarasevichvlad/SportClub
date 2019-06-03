import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: User[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<User[]>(baseUrl + 'api/SampleData/Users').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface User {
  Name: string;
  Age: number;
  RankClub: number;
  NameClub: string;
}

