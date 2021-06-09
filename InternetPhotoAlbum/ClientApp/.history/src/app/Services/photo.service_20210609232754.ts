import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getBaseUrl } from 'src/main';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  myApiUrl: string;
  constructor(private http: HttpClient) {
    this.myApiUrl = getBaseUrl();
  }

  getPhotos(): Observable<Photo[]> {
return this.http.get<Photo[]>(this.myApiUrl + 'photo')
  }


  http.get<Photo[]> (baseUrl + 'photo').subscribe(result => {
    this.photos = result;
  }, error => console.error(error));
}
