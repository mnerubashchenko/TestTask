import { Component } from '@angular/core';
import { DepService, IDepartment } from '..//./services/dep.service';
import { TypesService, IType } from '..//services/types.service';

@Component({
  selector: 'app-departament',
  templateUrl: './departament.component.html',
  styleUrls: ['./departament.component.css']
})
export class DepartamentComponent {
  public deps: IDepartment[];
  public types: IType[];
  constructor(private depService: DepService, private typesService: TypesService) {

    this.depService.subject.subscribe(this.depsReceived);
    this.depService.getDeps();

    this.typesService.subject.subscribe(this.typesReceived);
    this.typesService.getTypes();
  }

  depsReceived = (data: IDepartment[]) => {
    this.deps = data;
  }

  typesReceived = (data: IType[]) => {
    this.types = data;
  }

}
