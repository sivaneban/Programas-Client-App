import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable , of } from 'rxjs';
import { IAddress } from '../model/address';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  url = "https://localhost:5001/address/search";

  constructor(private http:HttpClient) { }

  getAddress(id: number): Observable<IAddress> {
    const userUrl = `${this.url}/${id}`;
    return this.http.get<IAddress>(userUrl);
  }

  searchAddress(term: string): Observable<IAddress[]> {
    if (!term.trim()) {      
      return of([]);
    }
    return this.http.get<IAddress[]>(`${this.url}/${term}`);
  }
}
