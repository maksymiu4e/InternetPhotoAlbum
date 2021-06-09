import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public photos: Photo[];

  constructor(private photoService: PhotoService) {}

  hetPhotos(){
    this.photoService.getPhotos().subscribe(photos => this.photos = photos)
  }
}


