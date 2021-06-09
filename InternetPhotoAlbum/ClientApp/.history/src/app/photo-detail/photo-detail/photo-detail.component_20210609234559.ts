import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PhotoService } from 'src/app/services/photo.service';

@Component({
  selector: 'app-photo-detail',
  templateUrl: './photo-detail.component.html',
  styleUrls: ['./photo-detail.component.css']
})
export class PhotoDetailComponent implements OnInit {

  photo: Photo;
  constructor(
    private photoService: PhotoService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getPhoto()
  }

  getPhoto() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.photoService.getPhotoById(id).subscribe(result => {
      this.photo = result;
    }, error => console.error(error));
  }

}
