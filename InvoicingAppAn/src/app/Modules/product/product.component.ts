import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../shared/Services/product.service';
import { NgForm } from '@angular/forms';
import { Product } from '../../shared/Models/product.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {  
  
  public LCategories: Product[] = [];
  msgTitle = '';

  constructor(public productService: ProductService){}

  resetForm(form?: NgForm){
    if(form != null)
      this.resetForm();
    
    this.productService.formData = {
      id: 0,
      code: '',
      name: '',
      idcategory: 0,
      categoryname: ''
    };
  }

  onSubmit(form: NgForm){
    this.productService.postProduct(form.value)
    .subscribe(
      (res: any) => {
        this.resetForm(form);
        this.ngOnInit();
        this.msgTitle = 'Producto agregado';
      },
      (err: any) => {
        this.resetForm(form);
        this.msgTitle = 'error en el proceso';
      }
    );
  }

  ngOnInit(): void {
    this.productService.getProducts()
    .subscribe((data: Product[]) => {
      this.LCategories = data;
      console.log(`nombre:${ this.LCategories[1].name }`)
    }); 
  } 
  
  onDelete(id:number){
    if(confirm("Está seguro de eliminar este producto?")){
      this.productService.deleteProduct(id)
      .subscribe(
        (res: any) => {
          this.ngOnInit();
          this.msgTitle = 'Producto eliminado';
        },
        (err: any) => {
          this.msgTitle = 'error en el proceso';
        }
      )
    }
  }
}
