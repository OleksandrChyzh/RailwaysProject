// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-home',
//   templateUrl: './home.component.html',
//   styleUrls: ['./home.component.css']
// })
// export class HomeComponent { }

import { Component } from '@angular/core';
import { SearchComponent } from '../components/search/search.component';
import { WelcomeComponent } from '../components/welcome/welcome.component';
import { FeatureListComponent } from '../components/feature-list/feature-list.component';

@Component({
  standalone: true,
  selector: 'app-home',
  imports: [SearchComponent, WelcomeComponent, FeatureListComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {}
