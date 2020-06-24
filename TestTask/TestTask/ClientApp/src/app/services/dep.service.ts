import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Subject } from 'rxjs';

export interface IDepartment {
  IdDep: string;
  FullNameDep: string;
  ShortNameDep: string;
  TypeId: string;
}

export class DepService {
  deps: IDepartment[];
  subject = new Subject<IDepartment[]>();
  headers: HttpHeaders;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.headers = new HttpHeaders().set('content-type', 'application/json');
  }

  getDeps() {
    this.http.get<IDepartment[]>(this.baseUrl + 'api/dep/GetDepartments',
    ).subscribe(result => {
      this.deps = result as IDepartment[];
      this.subject.next(this.deps);
    }, error => console.error(error));
  }

}
