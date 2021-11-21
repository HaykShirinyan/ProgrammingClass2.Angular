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
import { ProductTypeListComponent } from './product-types/list/product-type-list.component';
import { CurrencyListComponent } from './currencies/list/currency-list.component';
import { CreateProductTypeComponent } from './product-types/create/create-product-type.component';
import { EditProductTypeComponent } from './product-types/edit/edit-product-type.component';
import { CreateCurrencyComponent } from './currencies/create/create-currency.component';
import { EditCurrencyComponent } from './currencies/edit/edit-currency.component';
import { UnitOfMeasureListComponent } from './unit-of-measures/list/unit-of-measure-list.component';
import { CreateUnitOfMeasureComponent } from './unit-of-measures/create/create-unit-of-measure.component';
import { CreateColorComponent } from './colors/create/create-color.component';
import { EditColorComponent } from './colors/edit/edit-color.component';
import { ColorListComponent } from './colors/list/color-list.component';
import { BrandListComponent } from './brand/list/brand-list.component';
import { CreateBrandComponent } from './brand/create/create-brand.component';
import { EditBrandComponent } from './brand/edit/edit-brand.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductTypeListComponent,
    CurrencyListComponent,
    ProductListComponent,
    CreateProductComponent,
    EditProductComponent,
    CreateProductTypeComponent,
    EditProductTypeComponent,
    CreateCurrencyComponent,
    EditCurrencyComponent,
    UnitOfMeasureListComponent,
    CreateUnitOfMeasureComponent,
    CreateColorComponent,
    EditColorComponent,
    ColorListComponent,
    BrandListComponent,
    CreateBrandComponent,
    EditBrandComponent
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

      { path: 'product-types', component: ProductTypeListComponent },
      { path: 'product-types/create', component: CreateProductTypeComponent },
      { path: 'product-types/edit/:id', component: EditProductTypeComponent },

      { path: 'currencies', component: CurrencyListComponent },
      { path: 'currencies/create', component: CreateCurrencyComponent },
      { path: 'currencies/edit/:id', component: EditCurrencyComponent},

      { path: 'unit-of-measures', component: UnitOfMeasureListComponent },
      { path: 'unit-of-measures/create', component: CreateUnitOfMeasureComponent },

      { path: 'colors', component: ColorListComponent },
      { path: 'colors/create', component: CreateColorComponent },
      { path: 'colors/edit/:id', component: EditColorComponent },

      { path: 'brands', component: BrandListComponent },
      { path: 'brands/create', component: CreateBrandComponent },
      { path: 'brands/edit/:id' , component: EditBrandComponent}
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
