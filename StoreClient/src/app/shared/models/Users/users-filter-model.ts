import {UserSortType} from 'src/app/shared/enums/user-sort-type';
import {UserStatus} from 'src/app/shared/enums/user-status';
import {BaseFilterModel} from '../Base/base-filter-model';

export class UsersFilterModel extends BaseFilterModel {
  sortType: UserSortType;
  userStatus: UserStatus;
}
