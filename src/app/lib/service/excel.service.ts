import { Injectable } from '@angular/core';
import * as FileSaver from 'file-saver';
import * as XLSX from 'xlsx';
import { TranslateService } from '@ngx-translate/core';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Injectable()
export class OTExcelService {

    constructor(public translateService: TranslateService) {
    }

    public exportAsExcelFile(json: any[], excelFileName: string): void {

        const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);

        // translate colum headers
        const range = XLSX.utils.decode_range(worksheet['!ref']);
        for (let columnRef = range.s.r; columnRef <= range.e.r; ++columnRef) {
            const address = XLSX.utils.encode_col(columnRef) + '1'; // first row of column.
            if (worksheet[address]) {
                worksheet[address].v = this.translateService.instant(worksheet[address].v);
            }
        }
        // create workbook
        const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
        const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

        const localizeName = this.translateService.instant(excelFileName);
        this.saveAsExcelFile(excelBuffer, localizeName);
    }

    private saveAsExcelFile(buffer: any, fileName: string): void {
        const data: Blob = new Blob([buffer], {
            type: EXCEL_TYPE
        });

        FileSaver.saveAs(data, fileName  + ' ' + new Date().getTime()  + EXCEL_EXTENSION);
    }

}
