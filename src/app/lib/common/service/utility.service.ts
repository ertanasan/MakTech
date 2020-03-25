import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class OTUtilityService {

    colors = [
        { name: 'primary', hex: '#20a8d8'},
        { name: 'secondary', hex: '#c8ced3'},
        { name: 'success', hex: '#4dbd74'},
        { name: 'danger', hex: '#f86c6b'},
        { name: 'warning', hex: '#ffc107'},
        { name: 'info', hex: '#63c2de'},
        { name: 'light', hex: '#f0f3f5'},
        { name: 'dark', hex: '#2f353a'},
    ];

    additionalColors = [
        { name: 'blue', hex: '#20a8d8'},
        { name: 'yellow', hex: '#ffc107'},
        { name: 'indigo', hex: '#6610f2'},
        { name: 'purple', hex: '#6f42c1'},
        { name: 'pink', hex: '#e83e8c'},
        { name: 'red', hex: '#f86c6b'},
        { name: 'orange', hex: '#f8cb00'},
        { name: 'green', hex: '#4dbd74'},
        { name: 'teal', hex: '#20c997'},
        { name: 'cyan', hex: '#17a2b8'},
    ];

    grayColors = [
        { name: 'gray100', hex: '#f0f3f5'},
        { name: 'gray200', hex: '#e4e7ea'},
        { name: 'gray300', hex: '#c8ced3'},
        { name: 'gray400', hex: '#acb4bc'},
        { name: 'gray500', hex: '#8f9ba6'},
        { name: 'gray600', hex: '#73818f'},
        { name: 'gray700', hex: '#5c6873'},
        { name: 'gray800', hex: '#2f353a'},
        { name: 'gray900', hex: '#23282c'},
    ];

    getColor(colorName: string): string {
        const color = this.colors.filter(c => c.name === colorName);
        if (color.length) {
            return color[0].hex;
        } else {
            return this.colors[0].hex;
        }
    }

    toDate(value: any): Date {
        return value ? new Date(value) : null;
    }

    reviewDates(model: IDateEncloser) {
        for (const propertyName of model.getDatePropertyNames()) {
            model[propertyName] = this.toDate(model[propertyName]);
        }
    }

    mapGroupings(dataSource: any) {
        const resultData = {total: 0, data: []};
        resultData.total = dataSource.Total;
        dataSource.Data.forEach((element, index, array) => {
         resultData.data.push({
             aggregates: element.Aggregates,
             field: element.Member,
             items: element.Items,
             value: element.Key
            });

        });
        return resultData;
    }
}
