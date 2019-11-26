import { PrintingEditionSortType } from 'src/app/shared/enums/printing-edition-sort-type';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import {BaseFilterModel} from '../Base/base-filter-model';

export class PrintingEditionsFilterModel extends BaseFilterModel {
  Categories: Array<TypePrintingEdition>;
  SortType: PrintingEditionSortType;
  MinPrice: number;
  MaxPrice: number;
}
