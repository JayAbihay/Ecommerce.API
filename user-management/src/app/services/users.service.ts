import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationResponse } from '../models/authentication-response';
import { Register } from '../models/register';
import { environment } from '../../environment';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private baseUrl: string = environment.apiUrl;
  public isAuthenticated: boolean = false;
  public currentUserName: string | null = '';
  private isBrowser: boolean;

  // 👇 new flag
  public authChecked: boolean = false;

  constructor(
    private http: HttpClient,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {
    this.isBrowser = isPlatformBrowser(this.platformId);

    if (this.isBrowser) {
      this.isAuthenticated = !!localStorage.getItem('authToken');
      this.currentUserName = localStorage.getItem('currentUserName');
    }

    // ✅ mark auth check complete (SSR safe)
    this.authChecked = true;
  }

  register(register: Register): Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(
      `${this.baseUrl}register`,
      register
    );
  }

  login(email: string, password: string): Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(`${this.baseUrl}login`, {
      email,
      password,
    });
  }

  setAuthStatus(token: string, currentUserName: string): void {
    this.isAuthenticated = true;

    if (this.isBrowser) {
      localStorage.setItem('authToken', token);
      localStorage.setItem('currentUserName', currentUserName);
    }

    this.currentUserName = currentUserName;
  }

  logout(): void {
    this.isAuthenticated = false;

    if (this.isBrowser) {
      localStorage.removeItem('authToken');
      localStorage.removeItem('currentUserName');
    }

    this.currentUserName = '';
  }
}
