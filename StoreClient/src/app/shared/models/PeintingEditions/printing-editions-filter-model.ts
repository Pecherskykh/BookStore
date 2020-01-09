import { PrintingEditionSortType } from 'src/app/shared/enums/printing-edition-sort-type';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import {BaseFilterModel} from '../Base/base-filter-model';
import { Currencys } from '../../enums/currencys';

export class PrintingEditionsFilterModel extends BaseFilterModel {
  categories: Array<TypePrintingEdition>;
  sortType: PrintingEditionSortType;
  minPrice: number;
  maxPrice: number;
  currency: Currencys;
}
