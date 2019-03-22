import { Component, OnInit, ViewChild} from '@angular/core';
import { FiguresService } from '../services/figures.service';
import { of, Observable } from 'rxjs';
import { Figure } from '../model/figure';
import { KonvaFigure } from '../model/konvaFigure';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { KonvaComponent } from 'ng2-konva';
import { GridDataResult } from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  configStage: Observable<any> = null;

  public figures: Array<any> = [];


  public figuresViewForGrid: GridDataResult = null;

  public isDataAvailable: boolean = false;

  @ViewChild('stage') stage: KonvaComponent;
  @ViewChild('layer') layer: KonvaComponent;

  constructor(private figuresService: FiguresService) { }

  ngOnInit(): void {

    this.configStage = of({
      width: 300,
      height: 300
    });

    this.figuresService.getAll().subscribe(data => {

      this.figuresViewForGrid = data;

      this.figures = data.data.
        map<Figure>(i => i).
        map((figure, index) => new BehaviorSubject(new KonvaFigure(100 * (index + 1), 100 * (index + 1), figure.height / 2, index % 2 == 0 ? "red" : "blue", "red", 4)));
        // hack: konva subscribes to new data only once
      this.isDataAvailable = true;

    });

  }

}
