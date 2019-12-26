import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Person } from '../shared/models/person.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class PersonService {
  private headers: HttpHeaders;
  private accessPointUrl = 'https://localhost:44363/api/Person';

  constructor(private httpClient: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  public get(): Observable<Array<Person>> {
    const persons = this.httpClient
      .get<Person[]>(this.accessPointUrl, {headers: this.headers});
    const result = persons.pipe(map(arrayData =>
        arrayData.map(data => new Person().deserialize(data))));
    return result;
  }

  public getPersonById(personId: string): Observable<Person> {
    const params = new HttpParams().set('id', personId);
    const result = this.httpClient.get<Person>(this.accessPointUrl + '/byId', {headers: this.headers, params});
    return result;
   }
}
