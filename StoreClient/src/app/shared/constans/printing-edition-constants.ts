import { Currencys } from '../enums/currencys';

// tslint:disable-next-line: no-namespace
export namespace PrintingEditionConstants {
  export const typePrintingEditionItems: string[] = ['book', 'magazine', 'newspaper'];
  export const currencys: string[] = [
    Currencys[Currencys.AUD],
    Currencys[Currencys.BYN],
    Currencys[Currencys.EUR],
    Currencys[Currencys.GBP],
    Currencys[Currencys.PLN],
    Currencys[Currencys.UAH],
    Currencys[Currencys.USD]
  ];
  export const maxPrice: number = 1000;
}
