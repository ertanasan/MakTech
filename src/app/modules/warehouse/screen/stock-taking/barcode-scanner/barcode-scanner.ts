
import { Component, OnInit, ViewChild, AfterViewInit, OnDestroy, ElementRef, HostListener } from '@angular/core';

import { BarecodeScannerLivestreamComponent, BarecodeScannerLivestreamOverlayComponent } from 'ngx-barcode-scanner';

import { StockTakingService } from '@warehouse/service/stock-taking.service';
import { StockTakingScheduleService } from '@warehouse/service/stock-taking-schedule.service';
import { StorageZonesService } from '@warehouse/service/storage-zones.service';
import { ProductBarcodeService } from '@product/service/product-barcode.service';
import { StockTakingSchedule } from '@warehouse/model/stock-taking-schedule.model';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { StockTaking, ScannedItem } from '@warehouse/model/stock-taking.model';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ProductService } from '@product/service/product.service';
import { Observable, Subject, Subscription } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';
import { first } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import { StorageZones } from '@warehouse/model/storage-zones.model';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { AlphaEntryComponent } from '@otuidataentry/alpha-entry/alpha-entry.component';
import { InputDialogComponent } from '@otuicontainer/dialog/input-dialog/input-dialog.component';
import { NumericEntryComponent } from '@otuidataentry/numeric-entry/numeric-entry.component';
import 'rxjs/add/observable/fromEvent';
import { OVERLAY_KEYBOARD_DISPATCHER_PROVIDER } from '@angular/cdk/overlay/typings/keyboard/overlay-keyboard-dispatcher';


@Component({
    selector: 'barcode-scanner',
    templateUrl: './barcode-scanner.html',
    styleUrls: ['./barcode-scanner.css', ]
})
export class BarcodeScannerComponent extends ListScreenBase<StockTaking> implements OnInit, AfterViewInit, OnDestroy {

 
    // @ViewChild(BarecodeScannerLivestreamComponent, {static: false}) barecodeScanner: BarecodeScannerLivestreamComponent;
    @ViewChild('barcodeTextEntry' , {static: false}) barcodeTextEntry: AlphaEntryComponent;
    @ViewChild('numEntry_numberOfPackages' , {static: false}) numEntry_numberOfPackages: NumericEntryComponent;
    @ViewChild('numEntry_totalWeight' , {static: false}) numEntry_totalWeight: NumericEntryComponent;
    @ViewChild(InputDialogComponent, {static: true}) manualEntry: InputDialogComponent;

    // _keyEvent = '';
    // index = 1;
    @HostListener('document:keypress', ['$event'])
    keyEvent(event) {
        this.handleKeyboardEvent(event);
    }

    // subscription: Subscription;
    // subs2: Subscription;
    // subs3: Subscription;

    barcodetext;
    barcodeCheckMessage = '';
    barcodeCheckLabelColor = this.utility.getColor('danger');
    zoneId;
    scheduleId;
    isReplace = false;
    isCameraOpen = false;
    cameraFlagChanged$ = new Subject<boolean>();
    cameraSubscription: Subscription;
    schedules: StockTakingSchedule[];
    zones: StorageZones[];
    screenNo = 1;
    readList: ScannedItem[];
    barcodetextScanner: string;
    tempString = '';

    contextState$: Observable<OTContext>;
    contextInfo;
    isManualEntry = false;

    packageQuantity: number;
    packageUnit: string;
    numberOfPackages: number;
    totalWeight: number;
    productName: string;
    valueChangeProcessStarted = false;
    onKeyTwiceFireControl = true;
    eventInfo: string = '';
    selectedScheduleName: string;

    constructor(messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: StockTakingService,
        public stockTakingScheduleService: StockTakingScheduleService,
        public stockTakingService: StockTakingService,
        public zoneService: StorageZonesService,
        public productBarcodeService: ProductBarcodeService,
        public productService: ProductService,
        private store: Store<fromApp.AppState>,
        public utility: OTUtilityService) {
            super(messageService, translateService);
            this.contextState$ = this.store.select('context');
    }

    createEmptyModel(): StockTaking {
        return new StockTaking();
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Barcode Scanner' }, {Caption: 'Stock Taking', RouterLink: '/warehouse/BarcodeScanner'}];
    }

    refreshList() {

    }

    ngOnInit() {

        // this.subscription = Observable.fromEvent(document, 'keypress').subscribe(e => {
        //     this.handleKeyboardEvent(e);
        // });

        // this.subs2 = Observable.fromEvent(document, 'keydown').subscribe(e => {
        //     // this.handleKeyboardEvent(e);
        //     // this.eventInfo = 'KeyDown : ' + JSON.stringify(e);
        // });

        // this.subs3 = Observable.fromEvent(document, 'keyup').subscribe(e => {
        //     // this.handleKeyboardEvent(e);
        //     console.log(e.type);
        //     console.log(JSON.stringify(e));
        //     this.eventInfo += e;
        // });

        // this.subscription = Observable.fromEvent(document, 'input').subscribe(e => {
        //     // this.handleKeyboardEvent(e);
        //     // this.eventInfo = 'Input : ' + JSON.stringify(e);
        // });

        // this.subs3 = Observable.fromEvent(document, 'textInput').subscribe(e => {
        //     this.barcodeCheckMessage = 'TextInput : ' + JSON.stringify(e);
        // });

        this.contextState$.pipe(first()).subscribe(
            context => {
                this.contextInfo = context;
            }
        );
        this.zoneService.listAllAsync().subscribe(list => this.zones = list);
        if (!this.productBarcodeService.completeList) {
            this.productBarcodeService.listAll();
        }
        this.stockTakingScheduleService.ActiveSchedules().subscribe(list => this.schedules = list);
        if (!this.productService.completeList) {
            this.productService.listAll();
        }
        this.readList = [];
    }

    ngAfterViewInit() {
        // this.cameraSubscription = this.cameraFlagChanged$.subscribe( flag => flag ? this.barecodeScanner.start() : this.barecodeScanner.stop());
    }

    ngOnDestroy() {
        // if (this.barecodeScanner && this.barecodeScanner.isStarted) {
        //     this.barecodeScanner.stop();
        // }
        // this.subscription.unsubscribe();
        if (this.cameraSubscription) {
            this.cameraSubscription.unsubscribe();
        }
    }

    checkDigitControl(barcode: string) {
        if (this.barcodetext.length <= 0) { return false; }
        if (barcode.length !== 13) { return false; }
        let vsum = 0;
        for (let i = 0; i < 12; i++) {
            vsum +=  i % 2 === 0 ? parseInt(barcode[i], 10) : parseInt(barcode[i], 10) * 3;
        }
        const checkdigit = (10 - (vsum % 10)) % 10;
        return checkdigit === parseInt(barcode[12], 10) ? true : false;
    }

    addCheckDigit() {
        let vsum = 0;
        for (let i = 0; i < 12; i++) {
            vsum +=  i % 2 === 0 ? parseInt(this.barcodetext[i], 10) : parseInt(this.barcodetext[i], 10) * 3;
        }
        const checkdigit = (10 - (vsum % 10)) % 10;
        this.barcodetext += checkdigit.toString();
    }

    onValueChanges(value) {
        if (!this.valueChangeProcessStarted) {
            this.valueChangeProcessStarted = true;
        } else {
            return;
        }

        // this.barecodeScanner.stop();

        if (!this.scheduleId) {
            this.barcodeCheckMessage = this.translateService.instant('Schedule must be selected') + '!';
            this.clearBarcode(1);
            this.valueChangeProcessStarted = false;
            return;
        }

        if (!this.zoneId) {
            this.barcodeCheckMessage = this.translateService.instant('Zone must be selected') + '!';
            this.clearBarcode(1);
            this.valueChangeProcessStarted = false;
            return;
        }

        // elle 4 digit terazi kodu girildiyse
        if (this.isManualEntry && value.length === 4) {
            this.barcodetext = `290${value}00000`;
        } else {
            this.barcodetext = value;
        }

        if (this.barcodetext.length === 12) {
            this.addCheckDigit();
        }
        // barcodetext = '2902012001311';

        if (!this.checkDigitControl(this.barcodetext)) {
            this.barcodeCheckMessage = this.translateService.instant('Wrong barcode format') + '!';
            this.clearBarcode(1);
            this.valueChangeProcessStarted = false;
            return;
        }

        let productBarcode: string;
        if (this.barcodetext.substring(0, 3) === '290') {
            productBarcode = this.barcodetext.substring(0, 7);
        } else {
            productBarcode = this.barcodetext;
        }
        const f = this.productBarcodeService.completeList.filter(row => row.BarcodeText === productBarcode);
        if (f.length > 0) {
            const p = this.productService.completeList.filter(row => row.ProductId === f[0].Product);
            let weight = 1;
            if (this.barcodetext.substring(0, 3) === '290') {
                weight = parseInt(this.barcodetext.substring(7, 12), 10) / 1000.0;
            }

            if (this.isManualEntry) {
                this.manualEntry.caption = `${'Elle Giriş'} - ${p[0].Name}`;
                this.packageQuantity = p[0].PackageQuantity;
                this.packageUnit = (p[0].Unit === 1) ? 'KG' : 'ADET';
                this.numberOfPackages = 1;
                this.totalWeight = p[0].PackageQuantity;
                this.productName = p[0].Name;
                // console.log(p[0]);
                this.manualEntry.show();
                this.numEntry_numberOfPackages.focus();
                this.valueChangeProcessStarted = false;
            } else {
                this.stockTakingService.InsertFromBarcodeReader(this.scheduleId, this.zoneId, this.isReplace ? 1 : 2, this.barcodetext, -1).subscribe(res => {
                    const scannedItem = new ScannedItem();
                    const selectedZone = this.zones.filter(row => row.StorageZonesId === this.zoneId);
                    scannedItem.ProductName = `${p[0].Name} - ${selectedZone[0].ZoneName}`;
                    scannedItem.ScannedValue = weight;
                    scannedItem.FinalValue = res;
                    scannedItem.ScanTime = new Date();
                    this.readList.unshift(scannedItem);
                    this.valueChangeProcessStarted = false;
                }, error => {
                    this.messageService.error(error);
                    this.valueChangeProcessStarted = false;
                });
                this.clearBarcode(0);
            }
        } else {
            this.messageService.error(this.translateService.instant(`No product found with ${this.barcodetext} barcode `) + '!');
            this.valueChangeProcessStarted = false;
        }
    }

    onScheduleSelected(event) {
        this.screenNo = 2;
        this.clearBarcode(0);
        this.selectedScheduleName = this.schedules.filter(row => row.StockTakingScheduleId === this.scheduleId)[0].ScheduleFullName;
        setTimeout(() => {
            this.barcodeTextEntry.focus();
        }, 1000);

    }

    onZoneSelected(event) {
        this.clearBarcode(0);
    }

    clearBarcode(delaySeconds = 2) {
        setTimeout(() => {
            this.barcodeCheckMessage = '';
            this.barcodetext = '';
            this.barcodeCheckLabelColor = this.utility.getColor('danger');
        }, delaySeconds * 1000);
    }

    onReplaceChanged(action) {
        if (action === 1) {
            this.isReplace = true;
        } else {
            this.isReplace = false;
        }
        this.barcodeTextEntry.focus();
    }

    onCameraChanged() {
        this.isCameraOpen = !this.isCameraOpen;
        this.cameraFlagChanged$.next(this.isCameraOpen);
    }

    onZoneChanged(vzoneId) {
        this.zoneId = vzoneId;
        this.barcodeTextEntry.focus();
    }

    onManualEntryChanged() {
        this.isManualEntry = !this.isManualEntry;
        setTimeout(() => {
            if (this.isManualEntry) {
                this.barcodeTextEntry.focus();    
            }
        }, 100);
    }

    onActionManualEntry() {
        this.stockTakingService.InsertFromBarcodeReader(this.scheduleId, this.zoneId, this.isReplace ? 1 : 2, this.barcodetext, this.totalWeight).subscribe(res => {
            const scannedItem = new ScannedItem();
            const selectedZone = this.zones.filter(row => row.StorageZonesId === this.zoneId);
            scannedItem.ProductName = `${this.productName} - ${selectedZone[0].ZoneName}`;
            scannedItem.ScannedValue = this.totalWeight;
            scannedItem.FinalValue = res;
            scannedItem.ScanTime = new Date();
            this.readList.unshift(scannedItem);
        }, error => {
            this.messageService.error(error);
        });
        this.manualEntry.hide();
        this.clearBarcode(0);
        if (this.isManualEntry) {
            this.barcodeTextEntry.focus();
        }
    }

    onNumberofPackagesChange() {
        this.totalWeight = Math.round(this.packageQuantity * this.numberOfPackages * 1000) / 1000;
    }

    onTotalWeightChange() {
        this.numberOfPackages = this.totalWeight / this.packageQuantity;
    }

    // onScanClicked() {
    //     this.barecodeScanner.start();
    //     setTimeout(() => {
    //         this.barecodeScanner.stop();
    //     }, 20000);
    // }

    onKey(event) {
        // console.log(event.target.value, this.barcodetext, this.onKeyTwiceFireControl);
        const vLength = event.target.value.length;
        if ((vLength === 13 || vLength === 12) && this.onKeyTwiceFireControl) {
            this.onKeyTwiceFireControl = false;
            setTimeout(() => {
                // console.log('1', (new Date()).toString());
                this.onKeyTwiceFireControl = true;
                this.onValueChanges(event.target.value);
            }, 500);
        }
    }

    onKeyEnter(barcodeText) {
        if (barcodeText.length === 4) {
            this.onValueChanges(barcodeText);
        }
    }

    handleKeyboardEvent(event) { 
        this.tempString += event.key;
        this.barcodeCheckMessage = this.tempString;
        this.eventInfo += event.key;
        setTimeout(() => {
            this.barcodeCheckMessage = '';
        }, 500);
        if (this.tempString.length === 12 || this.tempString.length === 13) {
            this.barcodetextScanner = this.tempString;
            this.tempString = '';
            this.onValueChanges(this.barcodetextScanner);
        }
        setTimeout(() => {
            this.tempString = '';
        }, 500);
    }

    onClickPlus() {
        this.numberOfPackages++;
        this.onNumberofPackagesChange();
    }

    onClickMinus() {
        this.numberOfPackages--;
        this.onNumberofPackagesChange();
    }
}
