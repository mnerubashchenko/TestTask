import { Component, ViewChild, Inject } from '@angular/core';
import CustomStore from "devextreme/data/custom_store";
import { DxDataGridComponent } from 'devextreme-angular';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { PostsService, IPost } from '..//services/posts.service';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent {
  public posts: IPost[];
  store: any;
  headers: HttpHeaders;
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;

  constructor(private postsService: PostsService, public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string) {

    this.asyncValidation = this.asyncValidation.bind(this);

    this.postsService.subject.subscribe(this.postsReceived);
    this.postsService.getPosts();

    this.headers = new HttpHeaders().set('content-type', 'application/json');

    this.store = new CustomStore({
      key: "idPost",
      load: () => this.posts,
      insert: (values) => this.http.post<any>(this.baseUrl + 'api/post/AddPost', JSON.stringify(values as IPost), { headers: this.headers }).subscribe(
        () => { this.postsService.getPosts(); }),
      update: (key, values) =>
        this.http.put<any>(this.baseUrl + 'api/post/UpdatePost', JSON.stringify(values as IPost), { headers: this.headers }).subscribe(
          () => { this.postsService.getPosts(); }),
      remove: (key) => this.http.delete<any>(this.baseUrl + 'api/post/DeletePost', { params: new HttpParams().set('idPost', key) }).subscribe(() => { this.postsService.getPosts(); })
    });
  }

  postsReceived = (data: IPost[]) => {
    this.posts = data;
    this.dataGrid.instance.refresh();
  }

  asyncValidation(params) {
    let cleanPostsValidate = this.posts.filter(item => item.idPost != params.data.idPost);
    let check = (cleanPostsValidate.find(item => item.namePost == params.value) != null) ? false : true;
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
