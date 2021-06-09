import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { getBaseUrl } from 'src/main';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  myApiUrl: string;
  constructor(private http: HttpClient) {
    this.myApiUrl = getBaseUrl();
  }

  getPhotos() {
    return this.http.get<Photo[]>(this.myApiUrl + 'photo');
  }

  getPhotoById(id: number) {
    return this.http.get<Photo>(this.myApiUrl + 'photo');
  }
}
