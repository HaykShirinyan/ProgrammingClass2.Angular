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
import { UnitOfMeasureListComponent } from './unit-of-measures/list/unit-of-measure-list.component';
import { CreateUnitOfMeasureComponent } from './unit-of-measures/create/create-unit-of-measure.component';
import { LoadingSpinnerComponent } from './shared/components/loading-spinner.component';

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
    UnitOfMeasureListComponent,
    CreateUnitOfMeasureComponent,
    LoadingSpinnerComponent
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
      { path: 'products/create', component: CreateProductComponent, canActivate: [AuthorizeGuard] },
      { path: 'products/edit/:id', component: EditProductComponent, canActivate: [AuthorizeGuard] },

      { path: 'unit-of-measures', component: UnitOfMeasureListComponent },
      { path: 'unit-of-measures/create', component: CreateUnitOfMeasureComponent, canActivate: [AuthorizeGuard] }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
