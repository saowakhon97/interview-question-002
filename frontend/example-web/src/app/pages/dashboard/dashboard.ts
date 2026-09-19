import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';


interface UserProfile {
  userId: string;
  username: string;
}

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class DashboardComponent implements OnInit {
  private authService = inject(AuthService);
  private router = inject(Router);
  private changeDetectorRef = inject(ChangeDetectorRef);

  profile: UserProfile | null = null;
  loading = true;
  errorMessage = '';

  ngOnInit(): void {
    this.authService.getProfile().subscribe({
      next: (response: UserProfile) => {
        // console.log('Profile response:', response);

        this.profile = response;
        this.loading = false;

        // console.log('Profile variable:', this.profile);

        this.changeDetectorRef.detectChanges();
      },

      error: (error) => {
        // console.error('Profile error:', error);

        this.loading = false;
        this.errorMessage = 'ไม่สามารถโหลดข้อมูลผู้ใช้ได้';

        this.changeDetectorRef.detectChanges();
      },
    });
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
