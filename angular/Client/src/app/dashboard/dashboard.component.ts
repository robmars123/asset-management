import { AsyncPipe, DecimalPipe } from '@angular/common';
import { Component, PipeTransform, inject } from '@angular/core';
import { Observable, startWith, map } from 'rxjs';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbHighlight } from '@ng-bootstrap/ng-bootstrap';
import { DashboardService } from '../services/dashboard-service/dashboard.service';
import { Asset } from '../models/asset';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [DecimalPipe, AsyncPipe, ReactiveFormsModule, NgbHighlight, FormsModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  providers: [DecimalPipe],
})
export class DashboardComponent {
  assetList: any[];
  filteredList: any;
	filter: string;

	constructor(private dashboardService: DashboardService) {	}

  ngOnInit(): void {
    this.getAssets();
    this.filteredList = this.assetList;
  }

  //Populate the table by calling the dashboard service
  getAssets(): void{
    this.dashboardService.getAssets().subscribe(val => this.assetList = val);
  }


  //search
  filterResults(event: any) {
    let text = event.target.value;
    if (!text) {
      this.filteredList = this.assetList;
      return;
    }
    this.filteredList = this.assetList.filter((asset) =>
      asset?.description.toLowerCase().includes(text.toLowerCase()),
    );
  }
}





