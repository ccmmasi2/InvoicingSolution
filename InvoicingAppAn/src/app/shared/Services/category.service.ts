import { Injectable } from '@angular/core';
import { Category } from '../Models/category.model';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.dev';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {
 
  private baseUrl: string = environment.baseUrl;
  public formData: Category = new Category();

  constructor(private httpClient: HttpClient) { }

  get name(): string {
    return this.formData.name;
  }
  set name(name: string){
    this.formData.name = name;
  }

  getCategories(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(`${ this.baseUrl }api/Category`);
  }

  postCategory(categoryData: Category){
    return this.httpClient.post(`${ this.baseUrl }api/Category`, categoryData);
  }

  deleteCategory(id:number){
    return this.httpClient.delete(`${ this.baseUrl }api/Category/${ id }`);
  }

}
