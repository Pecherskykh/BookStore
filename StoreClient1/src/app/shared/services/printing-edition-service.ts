import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {PrintingEditionModel} from '../models/PeintingEditions/printing-edition-model';
import {PrintingEditionsFilterModel} from 'src/app/shared/models/PeintingEditions/printing-editions-filter-model';
import { Observable } from 'rxjs';

@Injectable()

export class PrintingEditionService {

  constructor(private http: HttpClient) { }

  getData(element: PrintingEditionsFilterModel): Observable<PrintingEditionModel> {
    return this.http.post<PrintingEditionModel>(
      'https://localhost:44319/api/printingedition/getPrintingEditions',
      /*{
        categories: [
          1,
          2
        ],
        sortType: 6,
        minPrice: 0,
        maxPrice: 100,
        sortingDirection: 1,
        searchString: null,
        pageCount: 1,
        pageSize: 10
      }*/
      element
    );
  }
}
