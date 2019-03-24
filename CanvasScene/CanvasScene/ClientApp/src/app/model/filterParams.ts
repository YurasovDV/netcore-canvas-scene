export class FilterParams {
  // public static readonly notSet: number = -1;

  public name: string;
  public widthMin: string;
  public widthMax: string;

  constructor() {
    this.name = '';
    this.widthMin = '';
    this.widthMax = '';
  }

  public getRequest(): string {
    var url: string = '';
    var anyParamsAdded: boolean = false;

    if (this.name != '' && this.name != null) {
      url += `${anyParamsAdded ? '&' : '?'}name=${this.name}`;
      anyParamsAdded = true;
    }

    if (this.widthMin != '' && this.widthMin != null) {
      url += `${anyParamsAdded ? '&' : '?'}widthMin=${this.widthMin}`;
      anyParamsAdded = true;
    }

    if (this.widthMax != '' && this.widthMax != null) {
      url += `${anyParamsAdded ? '&' : '?'}widthMax=${this.widthMax}`;
      anyParamsAdded = true;
    }

    return url;
  }
}
