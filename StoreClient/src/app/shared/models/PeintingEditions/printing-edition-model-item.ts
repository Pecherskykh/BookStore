import {AuthorModel} from '../Authors/author-model';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { Currencys } from '../../enums/currencys';
import { BaseModel } from '../Base/base-model';

export class PrintingEditionModelItem extends BaseModel {
        id: number;
        title: string;
        description: string;
        price: number;
        productType: TypePrintingEdition;
        currencys: Currencys;
        authors: AuthorModel;
}
