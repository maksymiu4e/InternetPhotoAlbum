import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getBaseUrl } from 'src/main';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  photos: string;
  myApiUrl: string;
  constructor(private http: HttpClient) {
    this.myApiUrl = getBaseUrl();
  }

  getPhotos(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.myApiUrl + 'photo').subscribe(result => {
      this.photos = result;
    }, error => console.error(error));
  }

}
