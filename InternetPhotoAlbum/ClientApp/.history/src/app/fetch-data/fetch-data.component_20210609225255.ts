import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public photos: Photos[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Photos[]>(baseUrl + 'photo').subscribe(result => {
      this.photos = result;
    }, error => console.error(error));
  }
}

interface Photos {
  id: number;
  userId: number;
  content: [];
  title: string;
  creationDate: Date;
}
