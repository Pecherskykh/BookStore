import { UserModelItem } from './user-model-item';
import { BaseModel } from '../Base/base-model';

export class UserModel extends BaseModel {
  count: number;
  items: Array<UserModelItem>;
}
