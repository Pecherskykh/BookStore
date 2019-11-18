import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {AuthorModel} from '../models/Authors/author-model';
import { Observable } from 'rxjs';

@Injectable()

export class AuthorService {

  constructor(private http: HttpClient) { }

  getData(): Observable<AuthorModel> {
    return this.http.post<AuthorModel>(
      'https://localhost:44319/api/author/getAuthor',
      {
        sortingDirection: 1,
        searchString: null,
        pageCount: 1,
        pageSize: 10
      }
    );
}
}
