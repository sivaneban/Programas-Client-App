import { Component, OnInit } from '@angular/core';
import { ICustomer } from 'src/app/model/customer';
import { SearchService } from 'src/app/service/search.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {

  user: ICustomer;

  constructor(private route: ActivatedRoute, private searchService: SearchService) { }

  ngOnInit() {
    this.getUser();
  }

  getUser(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.searchService.getUser(id)
      .subscribe(user => this.user = user);
  }

}
