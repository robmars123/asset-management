import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Asset } from '../../models/asset';
import { map } from 'rxjs/internal/operators/map';
import { Observable } from 'rxjs/internal/Observable';

interface Result{
  messages: string;
  result: any;
  successful: boolean
}
@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  assets: Asset[] = [];
  constructor(private http: HttpClient) {}
    
  ngOnInit(): void{
      this.getAssets();
    }

    getAssets(){
     return this.http.get<Result>('http://localhost:5107/api/Assets').pipe(map(val => val.result));
    }
}
