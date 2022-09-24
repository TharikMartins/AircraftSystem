import { MatSnackBar } from '@angular/material/snack-bar';
import { MaintenanceService } from './../../services/maintenance-service';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Maintenance } from 'src/app/models/maintenance';

@Component({
  selector: 'app-add-dialog',
  templateUrl: './add-dialog.component.html',
  styleUrls: ['./add-dialog.component.css']
})
export class AddDialogComponent {
   userId : string;
  constructor(public dialogRef: MatDialogRef<AddDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Maintenance,
              private snackBar : MatSnackBar,
              public service: MaintenanceService) { 
                this.userId = this.data.userId;
              }

  formControl = new FormControl('', [
    Validators.required
  ]);

  cancelClick(): void {
    this.dialogRef.close();
  }

  public confirmAdd(): void {
   this.service.post(this.data).subscribe(
    (response) => {
      this.openSnackBar("Manunteção inserida com sucesso!", "Ok");
    }
    );
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action,{
      duration: 3000
    });
  }
}
