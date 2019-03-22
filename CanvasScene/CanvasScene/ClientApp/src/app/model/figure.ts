export class Figure {

  public inCanvas: boolean;

  constructor(public id: number,
    public name: string,
    public width: number,
    public height: number,
    public depth: number) {

    this.inCanvas = false;
  }

}
