import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SalesRepresentative } from '../models/sales-representative.model';
@Injectable({
  providedIn: 'root'
})
export class SalesRepService {
  private baseUrl = 'https://localhost:7128/api/SalesRep/'; // Replace with your API URL

  constructor(private http: HttpClient) {}

  // Updated getAll to accept filters as query params
  getAll(platform?: string, region?: string): Observable<SalesRepresentative[]> {
    let params = new HttpParams();
    if (platform) params = params.set('platform', platform);
    if (region) params = params.set('region', region);
    return this.http.get<SalesRepresentative[]>(this.baseUrl, { params });
  }

  getById(id: number): Observable<SalesRepresentative> {
    return this.http.get<SalesRepresentative>(`${this.baseUrl}${id}`);
  }

  create(rep: SalesRepresentative): Observable<SalesRepresentative> {
    return this.http.post<SalesRepresentative>(this.baseUrl, rep);
  }

  update(id: number, rep: SalesRepresentative): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}${id}`, rep);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}${id}`);
  }

  add(rep: Partial<SalesRepresentative>) {
    return this.http.post<SalesRepresentative>(this.baseUrl, rep);
  }
}