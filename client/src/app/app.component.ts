import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  title = 'pending travels...';
  users: any;


  constructor(private http: HttpClient) {

  }


  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users').subscribe({ // observables are lazy, so we need to subscribe to them
      next: users => {
        this.users = users;
      },
      error: error => {
        console.error('There was an error!', error);
      },
      complete: () => {
        console.log('Completed!');
      }
    });
  }
}