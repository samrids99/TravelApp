import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  title = 'trips pending...';
  users: any;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users')
      .subscribe({
        next: (users) => {
          this.users = users;
        },
        complete: () => {}
      })
  }

}
