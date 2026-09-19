import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';

import { RegisterRequest } from '../models/register-request';
import { LoginRequest } from '../models/login-request';
import { LoginResponse } from '../models/login-response';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);

  register(model: RegisterRequest) {
    return this.http.post(`${environment.apiUrl}/auth/register`, model);
  }

  login(model: LoginRequest) {
    return this.http.post<LoginResponse>(`${environment.apiUrl}/auth/login`, model);
  }

  getProfile() {
    return this.http.get<any>(`${environment.apiUrl}/auth/profile`);
  }
}
