import { Component, OnInit, ViewChild, AfterContentInit, ViewContainerRef, ComponentFactoryResolver } from '@angular/core';
import { CirclesService } from '../services/circles.service';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { of, Observable } from 'rxjs';
import { Circle } from '../model/circle';
import { KonvaCircle } from '../model/konvaCircle';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { KonvaComponent } from 'ng2-konva';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public figures: GridDataResult = null;

  configStage: Observable<any> = null;

  public circles: Array<any> = [];

  public isDataAvailable: boolean = false;

  @ViewChild('stage') stage: KonvaComponent;
  @ViewChild('layer') layer: KonvaComponent;

  constructor(private circleService: CirclesService) { }

  ngOnInit(): void {

    this.configStage = of({
      width: 300,
      height: 300
    });

    this.circleService.getAll().subscribe(data => {
      this.figures = data;

      this.circles = data.data.
        map<Circle>(i => i).
        map((circle, index) => new BehaviorSubject(new KonvaCircle(100 * (index + 1), 100 * (index + 1), circle.height / 2, index % 2 == 0 ? "red" : "blue", "red", 4)));
        // hack: konva subscribes to new data only once
      this.isDataAvailable = true;

    });

  }

}
