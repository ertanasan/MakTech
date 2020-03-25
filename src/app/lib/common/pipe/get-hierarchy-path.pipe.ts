import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'getHierarchyPath' })
export class GetHierarchyPath implements PipeTransform {
    transform(value: any, idProperty: string, nameProperty: string, parentProperty: string, valueArray: any[], pathSeparator: string = ' > '): any {
        if (value != null && valueArray !== undefined) {
            const index = valueArray.map(v => v[idProperty]).indexOf(value);

            const firstParent = valueArray[index];
            const hierarchy = [];
            // Call recursive getParents method
            this.fillHierarchyList(hierarchy, firstParent, idProperty, parentProperty, valueArray);

            console.log('hierarchy list', hierarchy);

            let hierarchyPath = firstParent[nameProperty];
            for (const item of hierarchy) {
                hierarchyPath = `${item[nameProperty]}${pathSeparator}${hierarchyPath}`;
            }
            return hierarchyPath;
        } else {
            return '';
        }
    }

    fillHierarchyList(hierarchy: any[], item: any, idProperty: string, parentProperty: string, valueArray: any[]) {
        // Find the parent item of the current item
        const parentIndex = valueArray.map(v => v[idProperty]).indexOf(item[parentProperty]);
        console.log('parent index:', parentIndex);
        if (parentIndex >= 0) {
            const parentItem = valueArray[parentIndex];
            hierarchy.push(parentItem);
            this.fillHierarchyList(hierarchy, parentItem, idProperty, parentProperty, valueArray);
        }
    }
}
