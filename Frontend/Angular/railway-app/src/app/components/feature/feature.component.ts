// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-feature',
//   imports: [],
//   templateUrl: './feature.component.html',
//   styleUrl: './feature.component.css'
// })
// export class FeatureComponent {

// }

import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-feature',
  templateUrl: './feature.component.html',
  styleUrls: ['./feature.component.css']
})
export class FeatureComponent {
  @Input() icon: string = '';
  @Input() title: string = '';
  @Input() text: string = '';
}
