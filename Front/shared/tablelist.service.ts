
import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Tablelist,test} from './tablelist.model';
import {HttpHeaders} from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class TablelistService {

  constructor(private http:HttpClient) { }
  formData:Tablelist = new Tablelist();
  testData:test = new test();
  list:test[];
  
  readonly  baseUrl = 'http://localhost:57645/api/test';
  readonly  ComboBoxUrl = 'http://localhost:57645/api/combobox';
  httpOptions={
    headers: new HttpHeaders({
      'Content-type':'applicaion/json',
      'Access-Control-Allow-Origin':'*'
    })
  };
  getComboBox(){
    return (this.http.get(this.ComboBoxUrl));
  }
  postTablelist(){
    return (this.http.post(this.baseUrl,this.testData));
  }
  putTablelist(){
    return (this.http.put(`${this.baseUrl}/${this.testData.id}`,this.testData));
  } 
  deleteTablelist(id:number){
    return (this.http.delete(`${this.baseUrl}/${id}` ));
  } 
  get(){
    this.http.get(this.baseUrl).toPromise().then(
      res => {this.list = res as test[]});
  }
  refreshList() {
    this.http.get(this.baseUrl)
      .toPromise()
      .then(res =>this.list = res as test[]);
  }
  

}
