import { AuthorModelItem } from './author-model-item';

export class AuthorModel {
  pageAmount: number;
  items: Array<AuthorModelItem>;
  errors: Array<string>;
  isRemoved: boolean;
}
