import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';

export class OrderItemModelItem {
    count: number;
    orderId: number;
    printingEditionId: number;
    unitPrice: number;
    //type: TypePrintingEdition;
    title: string;
}
