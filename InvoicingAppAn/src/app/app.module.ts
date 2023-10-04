import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CategoryComponent } from './Modules/category/category.component';
import { CategoryService } from './shared/Services/category.service';
import { ProductComponent } from './Modules/product/product.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ListDataComponent } from './modules/list-data/list-data.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    ProductComponent,
    ListDataComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [CategoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
