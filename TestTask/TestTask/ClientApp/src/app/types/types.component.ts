import { Component, ViewChild, Inject } from '@angular/core';
import CustomStore from "devextreme/data/custom_store";
import { DxDataGridComponent } from 'devextreme-angular';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { TypesService, IType } from '..//services/types.service';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-types',
  templateUrl: './types.component.html',
  styleUrls: ['./types.component.css']
})
export class TypesComponent {
  public types: IType[];
  store: any;
  headers: HttpHeaders;
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;

  constructor(private typesService: TypesService, public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string) {

    this.asyncValidation = this.asyncValidation.bind(this);

    this.typesService.subject.subscribe(this.typesReceived);
    this.typesService.getTypes();

    this.headers = new HttpHeaders().set('content-type', 'application/json');
    this.store = new CustomStore({
      key: "idType",
      load: () => this.types,
      insert: (values) => this.http.post<any>(this.baseUrl + 'api/type/AddType', JSON.stringify(values as IType), { headers: this.headers }).subscribe(
        () => { this.typesService.getTypes(); }),
      update: (key, values) =>
        this.http.put<any>(this.baseUrl + 'api/type/UpdateType', JSON.stringify(values as IType), { headers: this.headers }).subscribe(
          () => { this.typesService.getTypes(); }),
      remove: (key) => this.http.delete<any>(this.baseUrl + 'api/type/DeleteType', { params: new HttpParams().set('idType', key) }).subscribe(() => { this.typesService.getTypes(); })
    });
  }

  asyncValidation(params) {
    let cleanTypesValidate = this.types.filter(item => item.idType != params.data.idType);
    let check = (cleanTypesValidate.find(item => item.nameType == params.value) != null) ? false : true;
    return new Promise((resolve) => {
      resolve(check === true);
    });
  }

  typesReceived = (data: IType[]) => {
    this.types = data;
    this.dataGrid.instance.refresh();
  }

  onRowUpdating(e) {
    for (var property in e.oldData) {
      if (!e.newData.hasOwnProperty(property)) {
        e.newData[property] = e.oldData[property];
      }
    }
  }

}
