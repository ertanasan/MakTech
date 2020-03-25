import { Pipe, PipeTransform, LOCALE_ID } from '@angular/core';
import { formatNumber } from '@angular/common';

@Pipe({ name: 'otCurrency' })
export class OTCurrencyPipe implements PipeTransform {
    transform(value: number, symbol: string = 'TL', locale = 'tr', rightSymbol = true): any {
        const result = formatNumber(value, locale, '1.2-2');
        if (rightSymbol) {
            return result + ' ' + symbol;
        } else {
            return symbol + result;
        }
    }
}
