import { Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Subject } from 'rxjs';

export interface IUser {
  IdUser: string;
  NameUser: string;
  SurnameUser: string;
  LastnameUser: string;
  PostId: string;
  DepId: string;
  TelUser: string;
  NationalityUser: string;
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
