import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  myApiUrl: string;
  constructor(private http: HttpClient) { 
    this.myApiUrl = getBaseUrl();
  }
}
