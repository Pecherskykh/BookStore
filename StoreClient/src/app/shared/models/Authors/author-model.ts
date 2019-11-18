import { AuthorModelItem } from './author-model-item';

export class AuthorModel {
  items: Array<AuthorModelItem>;
  errors: Array<string>;
  isRemoved: boolean;
}
