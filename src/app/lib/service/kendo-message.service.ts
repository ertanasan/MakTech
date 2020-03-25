import { Injectable, ɵConsole } from '@angular/core';
import { MessageService } from '@progress/kendo-angular-l10n';

const data = {
    tr: {
        rtl: false,
        messages: {
            /*** GRID MESSAGES
            ************************************************************/
            // 'kendo.grid.groupPanelEmpty': '',
            'kendo.grid.noRecords': 'Kayıt bulunamadı.',
            'kendo.grid.pagerFirstPage': 'İlk Sayfa',
            'kendo.grid.pagerLastPage': 'Son Sayfa',
            'kendo.grid.pagerPreviousPage': 'Önceki',
            'kendo.grid.pagerNextPage': 'Sonraki',
            'kendo.grid.pagerPage': 'Sayfa',
            'kendo.grid.pagerItemsPerPage': 'Sayfadaki Kayıt Sayısı',
            'kendo.grid.pagerOf': '/',
            'kendo.grid.pagerItems': 'Kayıt',
            'kendo.grid.filter': 'Filtre',
            'kendo.grid.filterEqOperator': 'Eşit',
            'kendo.grid.filterNotEqOperator': 'Eşit değil',
            'kendo.grid.filterIsNullOperator': 'Hiç değer gelmeyenler',
            'kendo.grid.filterIsNotNullOperator': 'Değer gelenler',
            'kendo.grid.filterIsEmptyOperator': 'Boşluklar',
            'kendo.grid.filterIsNotEmptyOperator': 'Boşluk olmayanlar',
            'kendo.grid.filterStartsWithOperator': 'İle başlayan',
            'kendo.grid.filterContainsOperator': 'İçeren',
            'kendo.grid.filterNotContainsOperator': 'İçermeyen',
            'kendo.grid.filterEndsWithOperator': 'İle biten',
            'kendo.grid.filterGteOperator': 'Eşit veya büyüktür',
            'kendo.grid.filterGtOperator': 'Büyüktür',
            'kendo.grid.filterLteOperator': 'Eşit veya küçüktür',
            'kendo.grid.filterLtOperator': 'Küçüktür',
            'kendo.grid.filterIsTrue': 'Var',
            'kendo.grid.filterIsFalse': 'Yok',
            'kendo.grid.filterBooleanAll': 'Tümü',
            'kendo.grid.filterAfterOrEqualOperator': 'Eşit veya sonrası',
            'kendo.grid.filterAfterOperator': 'Sonrası',
            'kendo.grid.filterBeforeOperator': 'Öncesi',
            'kendo.grid.filterBeforeOrEqualOperator': 'Eşit veya öncesi',
            'kendo.grid.filterFilterButton': 'Filtrele',
            'kendo.grid.filterClearButton': 'Temizle',
            'kendo.grid.filterAndLogic': 'İle',
            'kendo.grid.filterOrLogic': 'Ya da',
            'kendo.grid.loading': 'Yükleniyor',
            'kendo.grid.columnMenu': 'Sütun Menüsü',
            'kendo.grid.columns': 'Sütunlar',
            // 'kendo.grid.lock': '',
            // 'kendo.grid.unlock': '',
            'kendo.grid.sortable': 'Sıralanabilir',
            'kendo.grid.sortAscending': 'Artan',
            'kendo.grid.sortDescending': 'Azalan',
            'kendo.grid.sortedAscending': 'Artan',
            'kendo.grid.sortedDescending': 'Azalan',
            'kendo.grid.sortedDefault': 'Varsayılan Sıralama',
            // 'kendo.grid.columnsApply': '',
            // 'kendo.grid.columnsReset': '',

             /*** DROPDOWN MESSAGES
            ************************************************************/
            'kendo.dropdown.noDataText': 'Kayıt yok',
            'kendo.dropdown.clearTitle': 'Başlığı temizle',

            /*** DATEINPUTS/DATEPICKER/TIMEPICKER MESSAGES
            ************************************************************/
           'kendo.datepicker.today': 'Bugün',
           'kendo.datepicker.toggle': 'Takvimden seç',
           'kendo.dateinput.decrement': 'Azalt',
           'kendo.dateinput.increment': 'Arttır',
           'kendo.dateinput.accept': 'Onayla',
            // 'kendo.dateinput.acceptLabel': 'Onayla Metni',
           'kendo.dateinput.cancel': 'İptal',
            // 'kendo.dateinput.cancelLabel': 'İptal Metni',
           'kendo.dateinput.now': 'Şimdi',
            // 'kendo.dateinput.nowLabel': 'Şimdi Metni',
           'kendo.dateinput.toggle': 'Değiştir',

            /*** NUMERICTEXTBOX MESSAGES
            ************************************************************/
           'kendo.numerictextbox.decrement': 'Azalt',
           'kendo.numerictextbox.increment': 'Arttır',

           /*** SLIDER MESSAGES
            ************************************************************/
           'kendo.slider.decrement': 'Azalt',
           'kendo.slider.increment': 'Arttır',
            // 'kendo.slider.dragHandle': 'Basılı tut',

           /*** SWITCH MESSAGES
            ************************************************************/
           'kendo.switch.on': 'Açık',
           'kendo.switch.off': 'Kapalı',
        }
    },
    en: {
        rtl: false,
        messages: { }
    },
    de: {
        rtl: false,
        messages: {}
    }
};

@Injectable({
    providedIn: 'root'
})
export class OTKendoMessageService extends MessageService {

    constructor() {
        super();
    }

    public set language(value: string) {
        const lang = data[value];
        if (lang) {
          this.localeId = value;
          this.notify();
        }
      }

      public get language(): string {
        return this.localeId;
      }

      private localeId = 'tr';
      private get messages(): any {
        const lang = data[this.localeId];

        if (lang) {
          return lang.messages;
        }
      }

      public get(key: string): string {
        return this.messages[key];
      }
}
