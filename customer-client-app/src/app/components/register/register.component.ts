import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validators } from '@angular/forms';
import { RegisterService } from 'src/app/service/register.service';
import { PasswordValidator } from 'src/app/Validator/password.validator';
import { Observable, Subject } from 'rxjs';



import {
   debounceTime, distinctUntilChanged, switchMap
 } from 'rxjs/operators';
import { IAddress } from 'src/app/model/address';
import { AddressService } from 'src/app/service/address.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  fulladdresses: Observable<IAddress[]>;

  private searchTerms = new Subject<string>();


  get firstName(){
    return this.registerationForm.get('firstname')
  }

  get lastName(){
    return this.registerationForm.get('lastname')
  }

  get mobile(){
    return this.registerationForm.get('mobile')
  }

  get email(){
    return this.registerationForm.get('email')
  }

  get userName(){
    return this.registerationForm.get('username')
  }

  get password(){
    return this.registerationForm.get('password')
  }
  
  constructor(private formBuilder: FormBuilder, private registerService: RegisterService,private addressService: AddressService) { }

  search(term: string): void {
    this.searchTerms.next(term);
  }

  registerationForm = this.formBuilder.group({
    firstname: ['', Validators.required],
    lastname: ['', Validators.required],
    mobile: ['', Validators.required],
    email: ['', Validators.required],
    username: ['', Validators.required],
    password: ['', Validators.required],
    confirmPassword: [''],
    customerAddress: this.formBuilder.group({
      AddressFull: [''],
      AddressLine1: [''],
      AddressLine2: [''],
      AddressLine3: [''],
      city: [''],
      state: [''],
      Postcode: [''],
      Country: [''],    
    })
  }, { validator: PasswordValidator });

  
  ngOnInit(): void {
    this.fulladdresses = this.searchTerms.pipe(      
      debounceTime(300),      
      distinctUntilChanged(),      
      switchMap((term: string) => this.addressService.searchAddress(term)),
    );
  }

  loadApiData(){
    this.registerationForm.patchValue({      
      customerAddress: {
        AddressFull: 'Bnyuty',
        AddressLine1: 'test one',
        AddressLine2: 'two',
        AddressLine3: 'three',
        city: 'jad',
        state: 'jjk',
        Postcode: '3556',
        Country: 'Sryik'
      }
    });
  }

  onSubmit(){
    console.log(this.registerationForm.value);
    this.registerService.register(this.registerationForm.value)    
    .subscribe(
      response => console.log("Success!", response),
      error => console.log("Error!", error)
    )
    this.registerationForm.reset();
  }

}
