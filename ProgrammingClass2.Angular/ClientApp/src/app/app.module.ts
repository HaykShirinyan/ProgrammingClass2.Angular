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
import { ProductTypeListComponent } from './productTypes/list/productType-list.component';
import { CurrencyListComponent } from './currencies/list/currency-list.component';
import { CreateCurrenyComponent } from './currencies/create/create-currency.component';
import { EditCurrencyComponent } from './currencies/edit/edit-currency.component';
import { CreateProductTypeComponent } from './productTypes/create/create-productType.component';
import { EditProductTypeComponent } from './productTypes/edit/edit-productType.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductListComponent,
    CreateProductComponent,
    EditProductComponent,
    ProductTypeListComponent,
    CreateProductTypeComponent,
    EditProductTypeComponent,
    DeleteProductTypeComponent,
    CurrencyListComponent,
    CreateCurrenyComponent,
    EditCurrencyComponent
    DeleteCurrencyComponent
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
      { path: 'productTypes', component: ProductTypeListComponent },
      { path: 'productTypes/create', component: CreateProductTypeComponent },
      { path: 'productTypes/edit/:id', component: EditProductTypeComponent },
      { path: 'productTypes/delete/:id', component: DeleteProductTypeComponent },
      { path: 'currencies', component: CurrencyListComponent },
      { path: 'currencies/create', component: CreateCurrenyComponent },
      { path: 'currencies/edit/:id', component: EditCurrencyComponent },
      { path: 'currencies/delete/:id', component: DeleteCurrencyComponent },

    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
