// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-feature-list',
//   imports: [],
//   templateUrl: './feature-list.component.html',
//   styleUrl: './feature-list.component.css'
// })
// export class FeatureListComponent {

// }

import { Component } from '@angular/core';
import { FeatureComponent } from '../feature/feature.component'; // Додаємо імпорт

@Component({
  standalone: true,
  selector: 'app-feature-list',
  imports: [FeatureComponent], // Реєструємо FeatureComponent
  templateUrl: './feature-list.component.html',
  styleUrls: ['./feature-list.component.css']
})
export class FeatureListComponent {}
// export class FeatureListComponent {
//   constructor() {
//     console.log('FeatureListComponent працює!');
//   }
// }
