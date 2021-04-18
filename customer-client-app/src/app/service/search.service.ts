import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable , of } from 'rxjs';
import { ICustomer } from '../model/customer';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  url = "https://localhost:5001/customer";

  searchurl = "https://localhost:5001/customer/search";



  constructor(private http:HttpClient) { }

  

  getUser(id: string): Observable<ICustomer> {
    const userUrl = `${this.url}/${id}`;
    return this.http.get<ICustomer>(userUrl);
  }

  searchUsers(term: string): Observable<ICustomer[]> {
    if (!term.trim()) {      
      return of([]);
    }
    return this.http.get<ICustomer[]>(`${this.searchurl}/${term}`);
  }
}
