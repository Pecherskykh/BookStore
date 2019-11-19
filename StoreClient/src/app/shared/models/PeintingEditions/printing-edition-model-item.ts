import {AuthorModel} from '../Authors/author-model';

export class PrintingEditionModelItem {
        id: number;
        title: string;
        description: string;
        price: number;
        productType: string;
        authors: AuthorModel;
}
