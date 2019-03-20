import { Component, OnInit } from '@angular/core';
import { CirclesService } from '../services/circles.service';
import { GridDataResult } from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public figures: GridDataResult = null;
  constructor(private circleService: CirclesService) {
    

  }

  ngOnInit(): void {
    this.circleService.getAll().subscribe(data => { this.figures = data; });
  }
}
