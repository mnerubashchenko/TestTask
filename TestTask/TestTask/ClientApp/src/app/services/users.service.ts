import { Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Subject } from 'rxjs';

export interface IUser {
  idUser: string;
  nameUser: string;
  surnameUser: string;
  lastnameUser: string;
  postId: string;
  depId: string;
  telUser: string;
  nationalityUser: string;
}

export interface ICountry {
  idCountry: string;
  countryName: string;
}

export class UsersService {
  users: IUser[];
  subject = new Subject<IUser[]>();
  headers: HttpHeaders;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.headers = new HttpHeaders().set('content-type', 'application/json');
  }

  getUsers() {
    this.http.get<IUser[]>(this.baseUrl + 'api/user/GetUsers',
    ).subscribe(result => {
      this.users = result as IUser[];
      this.subject.next(this.users);
    }, error => console.error(error));
  }

}
