import { Component, ViewChild, Inject } from '@angular/core';
import CustomStore from "devextreme/data/custom_store";
import { DxDataGridComponent } from 'devextreme-angular';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { DepService, IDepartment } from '..//./services/dep.service';
import { TypesService, IType } from '..//services/types.service';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-departament',
  templateUrl: './departament.component.html',
  styleUrls: ['./departament.component.css']
})
export class DepartamentComponent {
  public deps: IDepartment[];
  public types: IType[];
  store: any;
  headers: HttpHeaders;
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;

  constructor(private depService: DepService, private typesService: TypesService, public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string) {

    sessionStorage.setItem("locale", 'ru');

    this.asyncValidationFullName = this.asyncValidationFullName.bind(this);

    this.asyncValidationShortName = this.asyncValidationShortName.bind(this);

    this.depService.subject.subscribe(this.depsReceived);
    this.depService.getDeps();

    this.typesService.subject.subscribe(this.typesReceived);
    this.typesService.getTypes();

    this.headers = new HttpHeaders().set('content-type', 'application/json');

    this.store = new CustomStore({
      key: "idDep",
      load: () => this.deps,
      insert: (values) => this.http.post<any>(this.baseUrl + 'api/dep/AddDepartament', JSON.stringify(values as IDepartment), { headers: this.headers }).subscribe(
        () => { this.depService.getDeps(); }),
      update: (key, values) =>
        this.http.put<any>(this.baseUrl + 'api/dep/UpdateDepartament', JSON.stringify(values as IDepartment), { headers: this.headers }).subscribe(
          () => { this.depService.getDeps(); }),
      remove: (key) => this.http.delete<any>(this.baseUrl + 'api/dep/DeleteDepartament', { params: new HttpParams().set('idDep', key) }).subscribe(() => { this.depService.getDeps(); })
    });
  }

  depsReceived = (data: IDepartment[]) => {
    this.deps = data;
    this.dataGrid.instance.refresh();
  }

  typesReceived = (data: IType[]) => {
    this.types = data;
    this.dataGrid.instance.refresh();
  }

  asyncValidationFullName(params) {
    let cleanDepsValidate = this.deps.filter(item => item.idDep != params.data.idDep);
    let check = (cleanDepsValidate.find(item => item.fullNameDep == params.value) != null) ? false : true;
    return new Promise((resolve) => {
      resolve(check === true);
    });
  }

  asyncValidationShortName(params) {
    let cleanDepsValidate = this.deps.filter(item => item.idDep != params.data.idDep);
    let check = (cleanDepsValidate.find(item => item.shortNameDep == params.value) != null) ? false : true;
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
