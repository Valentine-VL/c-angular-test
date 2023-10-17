import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from "rxjs";
import { Item } from '../models/Item'

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {

  items: Item[] = [];
  factorial: number = 0
  inputText: string = "";

  constructor(
    private http: HttpClient) { }

  private itemsUrl = 'http://localhost:5046/api/items';

  ngOnInit() {
    this.http.get<Item[]>(this.itemsUrl).subscribe(data => {
        this.items = data;
    })
  }

  addItem() {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    console.log(this.inputText)
    this.http.post<Item[]>(this.itemsUrl, JSON.stringify(this.inputText), httpOptions)
      .subscribe(response =>{})
    this.inputText = ""
    this.ngOnInit()
  }


  calculateFactorials(): void {
    this.items.forEach(item => {
      this.http
        .get<number>(`http://localhost:5046/api/items/calculate-factorials/${item.id}`)
        .subscribe(
          (result) => {
            const factorialDiv = document.getElementById(`factorial-for-${item.id}`);
            if (factorialDiv) {
              factorialDiv.textContent = `Factorial: ${result}`;
            }
          },
          (error) => {
            console.error(`Error calculating factorial for item ${item.name}`, error);
          }
        );
    });
  }

  title = 'Item List'

}
