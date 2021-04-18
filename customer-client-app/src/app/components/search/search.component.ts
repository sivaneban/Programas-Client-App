import { Component, OnInit } from '@angular/core';
import { ICustomer } from 'src/app/model/customer';
import { SearchService } from 'src/app/service/search.service';
import { Observable, Subject } from 'rxjs';
import {
  debounceTime, distinctUntilChanged, switchMap
} from 'rxjs/operators';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  users: Observable<ICustomer[]>;

  private searchTerms = new Subject<string>();

  constructor(private searchService: SearchService) { }

  search(term: string): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void  {
    this.users = this.searchTerms.pipe(      
      debounceTime(300),      
      distinctUntilChanged(),      
      switchMap((term: string) => this.searchService.searchUsers(term)),
    );
  }

}
