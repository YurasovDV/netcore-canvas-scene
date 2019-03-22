import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FiguresService } from '../services/figures.service';
import { Figure } from '../model/figure';
import { KonvaFigure } from '../model/konvaFigure';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { GridDataResult } from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  configStage: BehaviorSubject<any> = null;

  public figuresForCanvas: Array<BehaviorSubject<KonvaFigure>> = [];

  public figuresViewForGrid: GridDataResult = null;

  public isDataAvailable: boolean = false;

  constructor(private figuresService: FiguresService, private changeDetector: ChangeDetectorRef) { }

  ngOnInit(): void {

    this.configStage = new BehaviorSubject<any>({
      width: 300,
      height: 300
    });

    this.figuresService.getAll().subscribe(data => {
      data.data.forEach(v => { (<Figure>v).inCanvas = false; });
      this.figuresViewForGrid = data;
      this.isDataAvailable = true;
    });
  }

  checkValue(figureChanged: Figure) {
  // обертка игнорирует новые элементы в коллекции, поэтому проще пересоздавать канвас, а не работать именно с изменившейся фигурой
    this.clearCanvas();

    this.figuresForCanvas = this.figuresViewForGrid.data.
      filter(f => (<Figure>f).inCanvas).
        map((figure, index) => new BehaviorSubject(new KonvaFigure(100 * (index + 1), 100 * (index + 1), 4, (<Figure>figure).height / 2, "red", "red", 4)));

    this.refreshCanvas()
  }

  clearCanvas() {
    this.isDataAvailable = false;
  }

  refreshCanvas() {
    this.changeDetector.detectChanges();
    this.isDataAvailable = true;
  }
}
