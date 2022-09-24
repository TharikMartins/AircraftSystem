import { Component, OnInit } from '@angular/core'
import { MatTableDataSource } from '@angular/material/table'
import { ActivatedRoute, Router } from '@angular/router'
import { Stage } from 'src/app/models/stage'
import { MaintenanceService } from 'src/app/services/maintenance-service'
import { StageService } from 'src/app/services/stage-service'
import { StorageKeys } from 'src/app/storage/storage-keys'

@Component({
  selector: 'app-stage-list',
  templateUrl: './stage-list.component.html',
  styleUrls: ['./stage-list.component.css'],
})
export class StageListComponent implements OnInit {
  displayedColumns: string[] = [
    'description',
    'createdAt',
    'status',
    'type',
    'value',
  ]

  private readonly service: StageService

  public dataSource = new MatTableDataSource<Stage>()
  public maintenanceId: string
  constructor(service: StageService, private route: ActivatedRoute, private router: Router) {
    this.service = service
    this.maintenanceId = this.route.snapshot.paramMap.get('maintenanceId') || ''
  }

  ngOnInit(): void {
    this.loadData()
  }

  loadData() {
    this.service.get(this.maintenanceId).subscribe((response) => {
      this.dataSource.data = response
    })
  }

  mapType(type: number) {
    switch (type) {
      case 0:
        return 'Etapa de texto'
      case 1:
        return 'Etapa de número'
      case 2:
        return 'Etapa de arquivo'
      default:
        return 'Erro na etapa'
    }
  }
  download(linkSource : string) {
    const downloadLink = document.createElement('a');
    const fileName = 'etapa.pdf';

    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
  }

  redirectToMain(){
    this.router.navigate(['/maintenance-list']);
  }
}
