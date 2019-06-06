import {HttpClient} from "@angular/common/http";
import {Component, Inject} from "@angular/core";
import {Trainer} from "src/app/trainer-mode/trainer-mode.component";
import { User } from "../fetch-data/user-mode.component"

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public users: User[] = [];
  public newUser: User = new User();
  private baseUrl: string;
  public trainer: Trainer[] = [];
  public newTrainer: Trainer = new Trainer();

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

    CounterComponent.postGetAll(this.http, this.baseUrl + 'api/SampleData/Users', this.users);
    CounterComponent.postGetAll(this.http, this.baseUrl + 'api/SampleData/Trainers', this.trainer);
  }

  addUser()
  {
    this.postAdd("api/SampleData/AddUser", this.newUser, this.users);
  }


  addTrainer()
  {
    this.postAdd("api/SampleData/AddTrainer", this.newTrainer, this.trainer);
  }

  removeUser(id: number)
  {
    this.postDelete('api/SampleData/DeleteUser', id, this.users);
  }

  removeTrainer(id: number)
  {
    this.postDelete('api/SampleData/DeleteTrainer', id, this.trainer);
  }

  private postAdd<T extends User | Trainer>(url: string, item: T, array: Array<T>)
  {
    this.http.post(this.baseUrl + url, item).subscribe(result => {
      array.push(result as T); item.clear()
    }, error => console.error(error));
  }

  private static postGetAll<T extends User | Trainer>(http: HttpClient, url: string, array: Array<T>)
  {
    http.get<T[]>(url).subscribe(results => {
      results.forEach(result => {
        array.push(result as T)});
    }, error => console.error(error));
  }

  private postDelete<T extends User | Trainer>(url: string, id:number, array: Array<T>)
  {
    let item = array.filter(trainer => trainer.id == id)[0];
    let indexOf = array.indexOf(item);
    this.http.post<T>(this.baseUrl + url, item)
    .subscribe(tr =>
    {
      if(tr.id == item.id)
        array.splice(indexOf, 1)
    }, error => console.error(error));
  }
}
