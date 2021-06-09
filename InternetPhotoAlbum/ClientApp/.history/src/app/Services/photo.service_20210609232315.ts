import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  constructor() { 
    this.myApiUrl = getBaseUrl();
  }
}
