import { Injectable } from '@angular/core';
import {from, Observable} from 'rxjs';

@Injectable()
export class OverstoreCommonMethods  {
    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    fullScreen() {
        document.body.requestFullscreen();
    }

    exitFullScreen() {
        document.exitFullscreen();
    }

    /* SECTION  image methods */
    compressImageFile(file: File, qualityLevel: number = 1, width: number = 600, imageType: string = 'png') {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        return from(observer => {
            reader.onload = ev => {
                const img = new Image();
                img.src = (ev.target as any).result;
                (img.onload = () => {
                    const elem = document.createElement('canvas'); // Use Angular's Renderer2 method
                    const scaleFactor = width / img.width;
                    elem.width = width;
                    elem.height = img.height * scaleFactor;
                    const ctx = <CanvasRenderingContext2D>elem.getContext('2d');
                    ctx.drawImage(img, 0, 0, width, img.height * scaleFactor);
                    ctx.canvas.toBlob(
                        blob => {
                            observer.next(
                                new File([blob], file.name, {
                                    type: 'image/' + imageType,
                                    lastModified: Date.now(),
                                }),
                            );
                        },
                        'image/' + imageType,
                        qualityLevel,
                    );
                });
                (reader.onerror = error => observer.error(error));
            };
        });
    }

    dataURLtoBlob(dataURL: string, imageType: string = 'png') {
        // Decode the dataURL
        const binary = atob(dataURL.split(',')[1]);
        // Create 8-bit unsigned array
        const array = [];
        for (let i = 0; i < binary.length; i++) {
            array.push(binary.charCodeAt(i));
        }
        // Return our Blob object
        return new Blob([new Uint8Array(array)], {type: 'image/' + imageType});
    }
    /*  Section Ends */
}
