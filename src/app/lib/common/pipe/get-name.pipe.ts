import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'getName' })
export class GetNamePipe implements PipeTransform {
    transform(value: any, idPropertyName: string, valuePropertyName: string, valueArray: any[]): any {
        if (!(typeof value === 'undefined' || value === null) && valueArray) {
            const index = valueArray.map(v => v[idPropertyName]).indexOf(value);
            if (index > -1 && !(typeof valueArray[index] === 'undefined' || valueArray[index] === null)) {
                return valueArray[index][valuePropertyName];
            }
        }
        return `${idPropertyName}:${value}`;
    }
}
