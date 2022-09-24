import { MatSnackBar } from '@angular/material/snack-bar';
import { StageService } from 'src/app/services/stage-service'
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt'
import { AuthenticationService } from './components/auth/authentication-service'
import { MaintenanceService } from './services/maintenance-service'
import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { MaintenanceListComponent } from './components/maintenance-list/maintenance-list.component'
import { MatTableModule } from '@angular/material/table'
import { MatPaginatorModule } from '@angular/material/paginator'
import { MatInputModule } from '@angular/material/input'
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'
import { matSortAnimations, MatSortModule } from '@angular/material/sort'
import { HttpClientModule } from '@angular/common/http'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'
import { AddDialogComponent } from './components/add-dialog/add-dialog.component'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { MatDialogModule } from '@angular/material/dialog'
import { MatSlideToggleModule } from '@angular/material/slide-toggle'
import { StageListComponent } from './components/stage-list/stage-list.component'
import { RouterModule } from '@angular/router'
import { AuthComponent } from './components/auth/auth.component'
import { AuthGuardService } from './components/auth/auth-guard-service'
import { StageAddComponent } from './components/stage-add/stage-add.component'
import { MatSelectModule } from '@angular/material/select';
import {MatCardModule} from '@angular/material/card';
import { NgxMatFileInputModule } from '@angular-material-components/file-input'
import {MatListModule} from '@angular/material/list';

@NgModule({
  declarations: [
    AppComponent,
    MaintenanceListComponent,
    AddDialogComponent,
    StageListComponent,
    AuthComponent,
    StageAddComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatSortModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatPaginatorModule,
    HttpClientModule,
    MatButtonModule,
    MatIconModule,
    FormsModule,
    MatDialogModule,
    MatSlideToggleModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatCardModule,
    NgxMatFileInputModule,
    MatListModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'maintenance-list', pathMatch: 'full' },
      {
        path: '',
        component: MaintenanceListComponent,
        canActivate: [AuthGuardService],
        children: [
          { path: 'maintenance-list', component: MaintenanceListComponent },
        ],
      },
      { path: 'stage-list/:maintenanceId', component: StageListComponent },
      { path: 'stage-add/:maintenanceId', component: StageAddComponent },
      { path: 'auth', component: AuthComponent },
    ]),
  ],
  providers: [
    {
      provide: JWT_OPTIONS,
      useValue: JWT_OPTIONS,
    },
    MaintenanceService,
    AuthGuardService,
    AuthenticationService,
    JwtHelperService,
    StageService,
    MatSnackBar
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
