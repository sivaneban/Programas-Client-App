import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  url ='https://localhost:5001/customer';

  constructor(private http: HttpClient) { }

  register(userData){
    return this.http.post<any>(this.url, userData);
  }
}
