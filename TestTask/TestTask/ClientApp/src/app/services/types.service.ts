import { Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Subject } from 'rxjs';

export interface IType {
  IdType: string;
  NameType: string;
}

export class TypesService {
  types: IType[];
  subject = new Subject<IType[]>();
  headers: HttpHeaders;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.headers = new HttpHeaders().set('content-type', 'application/json');
  }

  getTypes() {
    this.http.get<IType[]>(this.baseUrl + 'api/type/GetTypes',
    ).subscribe(result => {
      this.types = result as IType[];
      this.subject.next(this.types);
    }, error => console.error(error));
  }

}
