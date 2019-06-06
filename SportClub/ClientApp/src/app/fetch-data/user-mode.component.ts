import {Component, Inject, OnInit} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-fetch-data',
  templateUrl: './user-mode.component.html'
})
export class UserModeComponent implements OnInit{
  public users: User[] = [];
  public newUser: User = new User();
  private baseUrl: string;

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http.get<User[]>(baseUrl + 'api/SampleData/Users').subscribe(result => {
      result.forEach(user =>  {
        this.users.push(user)});
    }, error => console.error(error));
  }

  public ngOnInit(): void
  {

  }

  add()
  {
    this.http.post<User>(this.baseUrl + 'api/SampleData/AddUser', this.newUser).subscribe(user => {this.users.push(user); this.newUser.clear()});
  }
}

export class User {
  id: number;
  name: string;
  age: number;
  rankClub: number;
  nameClub: string;

  clear()
  {
    this.name = "";
    this.age = null;
    this.nameClub = "";
    this.rankClub = null;
  }
}

