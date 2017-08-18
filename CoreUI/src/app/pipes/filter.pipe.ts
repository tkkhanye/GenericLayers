import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

    transform(arr: any[], filterBy: string): any[] {
        if (!arr || !filterBy)
            return arr;
        var filteredArr = arr.filter(x => {
            return this.compareObj(x, filterBy);
        });
        return filteredArr;
    }

    private compareObj(obj:any, filterBy:string){
        var filterRow = false;
        if (obj === undefined || obj === null)
            return true;
        for (var prop in obj){
            if (prop === undefined || prop === null)
                continue;
            if (obj[prop] == null || obj[prop] == undefined)
                continue;
            if (obj.hasOwnProperty(prop)) {                
                if (typeof obj[prop] === 'object'){
                    filterRow = this.compareObj(obj[prop], filterBy);
                    if (filterRow)
                        return true;
                }
                var val = obj[prop] + '';
                if (val.toLowerCase().indexOf(filterBy) >= 0)
                    return true;
            }
        }
        return filterRow;
    }
}

