import {AuthorModel} from '../Authors/author-model';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';

export class PrintingEditionModelItem {
        id: number;
        title: string;
        description: string;
        price: number;
        productType: TypePrintingEdition;
        authors: AuthorModel;
}
