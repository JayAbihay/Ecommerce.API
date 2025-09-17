import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';
import { UsersService } from './services/users.service';
import { ShowCaseComponent } from './products/show-case/show-case.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatToolbarModule,
    RouterModule,
    RouterLinkActive,
    ShowCaseComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  constructor(public usersService: UsersService, private router: Router) {}

  logout() {
    this.usersService.logout();
    this.router.navigate(['products', 'showcase']);
  }
}
