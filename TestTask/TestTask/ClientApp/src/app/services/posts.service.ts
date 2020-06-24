import { Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Subject } from 'rxjs';

export interface IPost {
  idPost: string;
  namePost: string;
}

export class PostsService {
  posts: IPost[];
  subject = new Subject<IPost[]>();
  headers: HttpHeaders;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.headers = new HttpHeaders().set('content-type', 'application/json');
  }

  getPosts() {
    this.http.get<IPost[]>(this.baseUrl + 'api/post/GetPosts',
    ).subscribe(result => {
      this.posts = result as IPost[];
      this.subject.next(this.posts);
    }, error => console.error(error));
  }

}
