import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../shared/Services/category.service';
import { NgForm } from '@angular/forms';
import { Category } from '../../shared/Models/category.model';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})

export class CategoryComponent implements OnInit {  
 
  public LCategories: Category[] = [];
  msgTitle = '';

  constructor(public categoryService: CategoryService){}

  resetForm(form?: NgForm){
    if(form != null)
      this.resetForm();
    
    this.categoryService.formData = {
      id: 0,
      name: ''
    };
  }

  onSubmit(form: NgForm){
    this.categoryService.postCategory(form.value)
    .subscribe(
      (res: any) => {
        this.resetForm(form);
        this.ngOnInit();
        this.msgTitle = 'Categoría agregada';
      },
      (err: any) => {
        this.resetForm(form);
        this.msgTitle = 'error en el proceso';
      }
    );
  }

  ngOnInit(): void {
    this.categoryService.getCategories()
    .subscribe((data: Category[]) => {
      this.LCategories = data;
      console.log(`nombre:${ this.LCategories[1].name }`)
    }); 
  } 
  
  onDelete(id:number){
    if(confirm("Está seguro de eliminar esta categoría?")){
      this.categoryService.deleteCategory(id)
      .subscribe(
        (res: any) => {
          this.ngOnInit();
          this.msgTitle = 'Categoría eliminada';
        },
        (err: any) => {
          this.msgTitle = 'error en el proceso';
        }
      )
    }
  } 
}
