import {UserSortType} from 'src/app/shared/enums/user-sort-type';
import {UserStatus} from 'src/app/shared/enums/user-status';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';

export class UsersFilterModel {
  sortType: UserSortType;
  userStatus: UserStatus;
  sortingDirection: SortingDirection;
  searchString: string;
  pageCount: number;
  pageSize: number;
}
