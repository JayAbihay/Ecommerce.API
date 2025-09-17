import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-show-case',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './show-case.component.html',
  styleUrls: ['./show-case.component.css'], // ✅ correct
})
export class ShowCaseComponent {}
