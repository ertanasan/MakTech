import { Injectable } from '@angular/core';

@Injectable()
export class OTPrintingService {

  print(printContent: string, styles = '<link rel="stylesheet" type="text/css" href="style.css" />', width = 1000, height = 500) {
    if (width > (screen.width - 100)) {
      width = screen.width - 100;
    }
    if (height > (screen.height - 100)) {
      height = screen.height - 100;
    }
    const left = (screen.width / 2) - (width / 2);
    const top = (screen.height / 2) - (height / 2);
    const popupWindow = window.open('', '_blank', `width=${width},height=${height},scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no,top=${top},left=${left}`);

    popupWindow.document.open();
    popupWindow.document.write(`
            <html>
              <head>
                ${styles}
              </head>
              <body onload="window.print()">
                ${printContent}
              </body>
            </html>`
    );
    popupWindow.document.close();
  }
}
