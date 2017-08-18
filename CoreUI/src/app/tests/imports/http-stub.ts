import { Response, ResponseOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';

export class HttpStub {
    private resultMock = [
        {id: 0},
        {id: 1},
        {id: 2}
    ];

    get(url:string) {
        let response = new ResponseOptions({
            body: JSON.stringify(this.resultMock)
        });
        return Observable.of(new Response(response));
    }

}
