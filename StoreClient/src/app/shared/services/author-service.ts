import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {AuthorModel} from '../models/Authors/author-model';
import {AuthorModelItem} from '../models/Authors/author-model-item';
import { Observable } from 'rxjs';
import {BaseFilterModel} from 'src/app/shared/models/Base/base-filter-model';

@Injectable()

export class AuthorService {

  constructor(private http: HttpClient) { }

  getData(element: BaseFilterModel): Observable<AuthorModel> {
    return this.http.post<AuthorModel>(
      'https://localhost:44319/api/author/getAuthor',
      /*{
        sortingDirection: 1,
        searchString: null,
        pageCount: 1,
        pageSize: 10
      }*/
      element
    );
}

getAll(): Observable<AuthorModel> {
  return this.http.get<AuthorModel>('https://localhost:44319/api/author/getAllAuthors');
}

  create(element: AuthorModelItem) {
    return this.http.post('https://localhost:44319/api/author/create', element);
  }

  update(element: AuthorModelItem) {
    return this.http.post('https://localhost:44319/api/author/update', element);
  }

  remove(element: AuthorModelItem) {
    return this.http.post('https://localhost:44319/api/author/remove', element);
  }
}
