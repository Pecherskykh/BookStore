import {PrintingEditionModelItem} from './printing-edition-model-item';
import { BaseModel } from '../Base/base-model';

export class PrintingEditionModel extends BaseModel {
  countPrintingEditions: number;
  items: Array<PrintingEditionModelItem>;
}
