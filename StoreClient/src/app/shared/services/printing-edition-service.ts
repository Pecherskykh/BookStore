import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {PrintingEditionModel} from '../models/PeintingEditions/printing-edition-model';
import {PrintingEditionsFilterModel} from 'src/app/shared/models/PeintingEditions/printing-editions-filter-model';
import { Observable } from 'rxjs';
import { PrintingEditionModelItem } from '../models/PeintingEditions/printing-edition-model-item';

@Injectable()

export class PrintingEditionService {

  constructor(private http: HttpClient) { }

  getData(element: PrintingEditionsFilterModel): Observable<PrintingEditionModel> {
    return this.http.post<PrintingEditionModel>(
      'https://localhost:44319/api/printingedition/getPrintingEditions',
      element
    );
  }

  create(element: PrintingEditionModelItem) {
    return this.http.post('https://localhost:44319/api/printingedition/create', element);
  }

  update(element: PrintingEditionModelItem) {
    return this.http.post('https://localhost:44319/api/printingedition/update', element);
  }

  remove(element: PrintingEditionModelItem) {
    return this.http.post('https://localhost:44319/api/printingedition/remove', element);
  }

  findById(id: number): Observable<PrintingEditionModelItem> {
    return this.http.get<PrintingEditionModelItem>(`https://localhost:44319/api/printingedition/findById?id=${id}`);
  }
}
