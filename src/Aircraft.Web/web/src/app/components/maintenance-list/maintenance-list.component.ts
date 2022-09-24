import { Router } from '@angular/router';
import { MaintenanceService } from './../../services/maintenance-service';
import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import { Maintenance } from 'src/app/models/maintenance';
import { AddDialogComponent } from '../add-dialog/add-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { StorageKeys } from 'src/app/storage/storage-keys';
import { Stage } from 'src/app/models/stage';

@Component({
  selector: 'app-maintenance-list',
  templateUrl: './maintenance-list.component.html',
  styleUrls: ['./maintenance-list.component.css']
})
export class MaintenanceListComponent implements OnInit {

  displayedColumns: string[] = ['description', 'createdAt', 'status', 'actions'];

  private readonly service :  MaintenanceService;

  public dataSource  = new MatTableDataSource<Maintenance>();
  
  constructor( service :  MaintenanceService, public dialog: MatDialog, private router: Router)  { this.service = service; }

  ngOnInit(): void {
    this.loadData();
  }

  add() {
    const dialogRef = this.dialog.open(AddDialogComponent, {
      data: { maintenance : Maintenance , userId : localStorage.getItem(StorageKeys.USER_ID)}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 1) {
       this.loadData();
      }
    });
  }

  loadData() {
    this.service.get(localStorage.getItem(StorageKeys.USER_ID) || '' ).subscribe(
      (response) => {
        this.dataSource.data = response
      }
     );
  }

  redirectToStage(status : boolean, maintenanceId: string, stages: Stage[] )
  {
    if (status || stages.length > 0)
        this.router.navigate(['/stage-list', maintenanceId]);
      else
        this.router.navigate(['/stage-add', maintenanceId]);
  }

}
