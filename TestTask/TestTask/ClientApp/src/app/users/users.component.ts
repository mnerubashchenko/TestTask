import { Component, ViewChild, Inject } from '@angular/core';
import CustomStore from "devextreme/data/custom_store";
import { DxDataGridComponent } from 'devextreme-angular';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { UsersService, IUser, ICountry } from '..//./services/users.service';
import { PostsService, IPost } from '..//services/posts.service';
import { DepService, IDepartment } from '..//services/dep.service';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {
  public users: IUser[];
  public posts: IPost[];
  public deps: IDepartment[];
  public countries: ICountry[];
  store: any;
  headers: HttpHeaders;
  fioPattern: any = /^[А-Яа-я]+$/;
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;

  constructor(private depService: DepService, private postsService: PostsService, private usersService: UsersService,
    public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {

    this.http.get<any>(this.baseUrl + 'api/country/GetCountries').subscribe(result => this.countries = result);

    sessionStorage.setItem("locale", 'ru');

    this.asyncValidation = this.asyncValidation.bind(this);

    this.usersService.subject.subscribe(this.usersReceived);
    this.usersService.getUsers();

    this.depService.subject.subscribe(this.depsReceived);
    this.depService.getDeps();

    this.postsService.subject.subscribe(this.postsReceived);
    this.postsService.getPosts();

    this.headers = new HttpHeaders().set('content-type', 'application/json');

    setTimeout(() => {
      this.store = new CustomStore({
        key: "idUser",
        load: () => this.users,
        insert: (values) => this.http.post<any>(this.baseUrl + 'api/user/AddUser', JSON.stringify(values as IUser), { headers: this.headers }).subscribe(
          () => { this.usersService.getUsers(); }),
        update: (key, values) =>
          this.http.put<any>(this.baseUrl + 'api/user/UpdateUser', JSON.stringify(values as IUser), { headers: this.headers }).subscribe(
            () => { this.usersService.getUsers(); }),
        remove: (key) => this.http.delete<any>(this.baseUrl + 'api/user/DeleteUser', { params: new HttpParams().set('idUser', key) }).subscribe(() => { this.usersService.getUsers(); })
      });
    }, 700);
  }

  depsReceived = (data: IDepartment[]) => {
    this.deps = data;
    this.dataGrid.instance.refresh();
  }

  postsReceived = (data: IPost[]) => {
    this.posts = data;
    this.dataGrid.instance.refresh();
  }

  usersReceived = (data: IUser[]) => {
    this.users = data;
    this.dataGrid.instance.refresh();
  }

  asyncValidation(params) {
    let cleanUsersValidate = this.users.filter(item => item.idUser != params.data.idUser);
    let check = (cleanUsersValidate.find(item => item.telUser == params.value) != null) ? false : true;
    return new Promise((resolve) => {
      resolve(check === true);
    });
  }

  onRowUpdating(e) {
    for (var property in e.oldData) {
      if (!e.newData.hasOwnProperty(property)) {
        e.newData[property] = e.oldData[property];
      }
    }
  }

}
