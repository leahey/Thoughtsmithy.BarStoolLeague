import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Person } from '../shared/models/person.model';
import { Observable } from 'rxjs';

@Injectable()
export class PersonService {
  private headers: HttpHeaders;
  private accessPointUrl = 'https://localhost:44363/api/Person';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  public get(): Observable<Person[]> {
    return this.http.get<Person[]>(this.accessPointUrl, {headers: this.headers});
  }

  public getPersonById(personId: string): Observable<Person> {
    const params = new HttpParams().set('id', personId);
    const result = this.http.get<Person>(this.accessPointUrl + '/byId', {headers: this.headers, params});
    return result;
   }
}
