import {HttpClient} from "@angular/common/http";
import {Component, Inject} from "@angular/core";

@Component({
  selector: 'app-trainer-mode',
  templateUrl: './trainer-mode.component.html',
})
export class TrainerModeComponent{
  public trainer: Trainer[] = [];
  public newTrainer: Trainer = new Trainer();
  private baseUrl: string;

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http.get<Trainer[]>(baseUrl + 'api/SampleData/Trainers').subscribe(result => {
      result.forEach(trainer =>  {
        this.trainer.push(trainer)});
    }, error => console.error(error));
  }

  add()
  {
    this.http.post<Trainer>(this.baseUrl + 'api/SampleData/AddTrainer', this.newTrainer).subscribe(trainer => {this.trainer.push(trainer); this.newTrainer.clear()});
  }

  remove(id: number)
  {
    let trainer = this.trainer.filter(trainer => trainer.id == id)[0];
    let indexOf = this.trainer.indexOf(trainer);
    this.http.post<Trainer>(this.baseUrl + 'api/SampleData/DeleteTrainer', trainer)
    .subscribe(tr =>
    {
      if(tr.id == trainer.id)
        this.trainer.splice(indexOf, 1)
    });
  }
}

export class Trainer {
  id: number;
  name: string;
  rank: number;

  clear()
  {
    this.name = "";
    this.rank = null;
  }
}
