import { BaseModel } from '../Base/base-model';

export class UserModelItem extends BaseModel {
  id: number;
  userName: string;
  email: string;
  status: boolean;
  firstName: string;
  lastName: string;
  newPassword: string;
  currentPassword: string;
  role: string;
  photo: string;
}
