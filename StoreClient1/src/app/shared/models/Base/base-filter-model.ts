import {SortingDirection} from 'src/app/shared/enums/sorting-direction';

export class BaseFilterModel {
  sortingDirection: SortingDirection;
  searchString: string;
  pageCount: number;
  pageSize: number;
}
