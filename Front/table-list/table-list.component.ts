import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Tablelist, test } from 'app/shared/tablelist.model';
import { TablelistService} from '../shared/tablelist.service';

@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrls: ['./table-list.component.css']
})
export class TableListComponent implements OnInit {

  constructor(public service:TablelistService) { }
  comboList= [];
  ngOnInit():void {
    this.service.get();
    this.service.getComboBox()
    .subscribe(res => this.comboList = res as []);
  }
 
  populateForm(selectedRecord:test){
    
    this.service.testData = selectedRecord ;
  }
  DeleteOn(id:number){
    if (confirm('Are You Sure You Want To Delete?'))
    {
      this.service.deleteTablelist(id)
      .subscribe(
      res =>{
        this.service.refreshList();
        
      },
      err =>{console.log(err)}
    )
    }
    
  }

  OnSubmit(form:NgForm){
    
    if(this.service.testData.id == 0)
     this.insertRecord(form);
    else
     this.updateRecord(form); 
  }

  insertRecord(form:NgForm){
    this.service.postTablelist().subscribe(
      res=>{
        this.resetForm(form)
        this.service.refreshList();
      },
      err=>{
        console.log(err);
      }
  );
  }
  updateRecord(form:NgForm){
    this.service.putTablelist().subscribe(
      res=>{
        this.resetForm(form);
        this.service.refreshList();
      },
      err=>{
        console.log(err);
      }
  );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.testData = new test();
  }
  
}
