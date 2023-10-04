import { Injectable } from '@angular/core';
import { Product } from '../Models/product.model';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.dev';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  private baseUrl: string = environment.baseUrl;
  public formData: Product = new Product();

  constructor(private httpClient: HttpClient) { }

  get name(): string {
    return this.formData.name;
  }
  set name(name: string){
    this.formData.name = name;
  }

  getProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(`${ this.baseUrl }api/Product`);
  }

  postProduct(productData: Product){
    return this.httpClient.post(`${ this.baseUrl }api/Product`, productData);
  }

  deleteProduct(id:number){
    return this.httpClient.delete(`${ this.baseUrl }api/Product/${ id }`);
  }

}
