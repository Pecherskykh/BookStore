import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthorModel } from '../models/Authors/author-model';
import { AuthorModelItem } from '../models/Authors/author-model-item';
import { Observable } from 'rxjs';
import { BaseFilterModel } from 'src/app/shared/models/Base/base-filter-model';
import { environment } from 'src/environments/environment';
import { BaseModel } from '../models/Base/base-model';

@Injectable()

export class AuthorService {

  constructor(private http: HttpClient) { }

  getData(element: BaseFilterModel): Observable<AuthorModel> {
    return this.http.post<AuthorModel>(
      'https://localhost:44319/api/author/getAuthor',
      element
    );
}

  getAll(): Observable<AuthorModel> {
    return this.http.get<AuthorModel>(`${environment.apiUrl}author/getAllAuthors`);
  }

  create(element: AuthorModelItem): Observable<BaseModel> {
    return this.http.post<BaseModel>(`${environment.apiUrl}author/create`, element);
  }

  update(element: AuthorModelItem): Observable<BaseModel> {
    return this.http.post<BaseModel>(`${environment.apiUrl}author/update`, element);
  }

  remove(element: AuthorModelItem): Observable<BaseModel> {
    return this.http.post<BaseModel>(`${environment.apiUrl}author/remove`, element);
  }
}
