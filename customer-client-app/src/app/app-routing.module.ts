import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { SearchComponent } from './components/search/search.component';
import { CustomerDetailsComponent } from './components/customer-details/customer-details.component';
const routes: Routes = [
  {path: 'register', component:  RegisterComponent },
  {path: 'search', component:  SearchComponent },
  { path: 'detail/:id', component: CustomerDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
