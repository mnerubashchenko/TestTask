import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { DepartamentComponent } from './departament/departament.component';
import { DepService } from './services/dep.service';
import { TypesService } from './services/types.service';
import { PostsService } from './services/posts.service';
import { UsersService } from './services/users.service';
import { DxDataGridModule } from 'devextreme-angular';
import { locale, loadMessages } from 'devextreme/localization';
import { TypesComponent } from './types/types.component';
import { PostsComponent } from './posts/posts.component';
import { UsersComponent } from './users/users.component';

declare var require: any;
let messagesDe = require("devextreme/localization/messages/de.json"),
  messagesJa = require("devextreme/localization/messages/ja.json"),
  messagesRu = require("devextreme/localization/messages/ru.json");

loadMessages(messagesRu);
loadMessages(messagesDe);
loadMessages(messagesJa);

locale(navigator.language);


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DepartamentComponent,
    TypesComponent,
    PostsComponent,
    UsersComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DxDataGridModule,
    RouterModule.forRoot([
      { path: '', component: DepartamentComponent, pathMatch: 'full' },
      { path: 'types', component: TypesComponent },
      { path: 'posts', component: PostsComponent },
      { path: 'users', component: UsersComponent },
    ])
  ],
  providers: [DepService,
    TypesService,
    PostsService,
    UsersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
