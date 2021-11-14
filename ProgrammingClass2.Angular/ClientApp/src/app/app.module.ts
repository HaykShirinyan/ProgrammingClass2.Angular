import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ProductListComponent } from './products/list/product-list.component';
import { CreateProductComponent } from './products/create/create-product.component';
import { EditProductComponent } from './products/edit/edit-product.component';
import { CreateCurrencyComponent } from './currencies/create/create-currency.component';
import { CurrencyListComponent } from './currencies/list/currency-list.component';
import { EditCurrencyComponent } from './currencies/edit/edit-currency.component';
import { ProductTypeListComponent } from './productType/list/product-type-list.component';
import { CreateProductTypeComponent } from './productType/create/create-product-type.component';
import { EditProductTypeComponent } from './productType/edit/edit-product-type.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductListComponent,
    CurrencyListComponent,
    CreateProductComponent,
    EditProductComponent,
    CreateCurrencyComponent,
    EditCurrencyComponent,
    ProductTypeListComponent,
    CreateProductTypeComponent,
    EditProductTypeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      // Erb mer website-i URL lini /products, ProductListComponent component piti ogtagorcvi
      { path: 'products', component: ProductListComponent },
      { path: 'products/create', component: CreateProductComponent },
      { path: 'products/edit/:id', component: EditProductComponent },
      { path: 'currencies/create', component: CreateCurrencyComponent },
      { path: 'currencies', component: CurrencyListComponent },
      { path: 'currencies/edit/:id', component: EditCurrencyComponent },
      { path: 'product-types', component: ProductTypeListComponent },
      { path: 'product-types/create', component: CreateProductTypeComponent },
      { path: 'product-types/edit/:id', component: EditProductTypeComponent }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
