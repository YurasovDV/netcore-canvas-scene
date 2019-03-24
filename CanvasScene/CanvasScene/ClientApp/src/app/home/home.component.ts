import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FiguresService } from '../services/figures.service';
import { Figure } from '../model/figure';
import { KonvaFigure } from '../model/konvaFigure';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { FilterParams } from '../model/filterParams';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  configStage: BehaviorSubject<any> = null;

  public figuresForCanvas: Array<BehaviorSubject<KonvaFigure>> = [];

  public figuresViewForGrid: GridDataResult = null;

  public isDataAvailable: boolean = false;

  public filter: FilterParams;

  constructor(private figuresService: FiguresService, private changeDetector: ChangeDetectorRef) {
    this.filter = new FilterParams();
  }

  ngOnInit(): void {

    this.configStage = new BehaviorSubject<any>({
      width: 300,
      height: 300
    });

    this.reloadAll();
  }

  private reloadAll() {
    this.figuresService.getAll().subscribe(gridDataResult => this.fillDataSources(gridDataResult));
  }

  private reloadByFilter() {
    this.figuresService.getBy(this.filter).subscribe(gridDataResult => this.fillDataSources(gridDataResult));
  }

  public fillDataSources(data) {
    data.data.forEach(v => { (<Figure>v).inCanvas = false; });
    this.figuresViewForGrid = data;

    if (this.isDataAvailable) {
      this.refreshCanvas(null);
    }
    else {
      this.isDataAvailable = true;
    }
  }

  public refreshCanvas(figureChanged: Figure) {
    // обертка игнорирует новые элементы в коллекции, поэтому проще пересоздавать канвас, а не работать именно с изменившейся фигурой
    this.clearCanvas();

    this.rebuildCanvasSource();

    this.showCanvas()
  }

  private clearCanvas() {
    this.isDataAvailable = false;
  }

  private rebuildCanvasSource() {
    this.figuresForCanvas = this.figuresViewForGrid.data.
      filter(f => (<Figure>f).inCanvas).
      map((figure, index) => new BehaviorSubject(new KonvaFigure(100 * (index + 1), 100 * (index + 1), 4, (<Figure>figure).height / 2, "red", "red", 4)));
  }

  private showCanvas() {
    this.changeDetector.detectChanges();
    this.isDataAvailable = true;
  }

}
