import { Component, OnInit } from '@angular/core';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {

  constructor(private photoService: PhotoService) { }

  ngOnInit() {
    this.getPhotos()
  }

  getPhotos() {
    this.photoService.getPhotos()
  }
}


