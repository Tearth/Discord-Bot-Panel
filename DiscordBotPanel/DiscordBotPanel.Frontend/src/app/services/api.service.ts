import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
    private apiUrl: string = "http://localhost:4000/api/";

    constructor(private http: HttpClient) {

    }

    public get<T>(endpoint: string) : Observable<T> {
        return this.http.get<T>(this.apiUrl + endpoint);
    }

    public post<T>(endpoint: string, payload: string) : Observable<T> {
        return this.http.post<T>(this.apiUrl + endpoint, payload);
    }
}
