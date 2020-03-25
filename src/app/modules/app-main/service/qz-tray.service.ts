import { Injectable } from '@angular/core';
import { Observable, from } from 'rxjs';
// import * as qz from 'qz-tray';
// import { sha256 } from 'sha.js';

@Injectable({
  providedIn: 'root'
})
export class QzTrayService {

  // constructor() {
  //   // Override sha256 & RSVP libraries
  //   qz.api.setSha256Type(data => sha256(data));
  //   qz.api.setPromiseType(resolver => new Promise(resolver));
  // }
  //
  // // Connect QZ Tray websocket
  // connectPrinter(): Observable<any> {
  //   return from(qz.websocket.connect());
  // }
  //
  // // Disconnect QZ Tray websocket
  // disconnectPrinter(): void {
  //   qz.websocket.disconnect();
  // }
  //
  // // Print data to chosen printer
  // printData(printer: string, data: any): void {
  //   this.connectPrinter().subscribe(() => {
  //     this.printDataAsync(printer, data).subscribe(() => this.disconnectPrinter());
  //   });
  // }
  //
  // printDataAsync (printer: string, data: any): Observable<any> {
  //   const config = qz.configs.create(printer);
  //   return from(qz.print(config, data));
  // }
  //
  // // Get the list of printers connected
  // listPrinters(): Observable<string[]> {
  //   return <Observable<string[]>>from(qz.websocket.connect()
  //       .then(() => qz.printers.find())
  //       .catch(err => console.log('QZ-listPrinters error: ', err))
  //   );
  // }
  //
  // // Get the SPECIFIC connected printer
  // getPrinterByName(printerName: string): Observable<string> {
  //   return <Observable<string>>from(
  //       qz.websocket.connect()
  //           .then(() => qz.printers.find(printerName))
  //           .catch(err => console.log('QZ-getPrinterByName error: ', err))
  //   );
  // }
}
