import { StageService } from 'src/app/services/stage-service';
import { Component, OnInit } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Stage } from 'src/app/models/stage'
import {MatSnackBar} from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-stage-add',
  templateUrl: './stage-add.component.html',
  styleUrls: ['./stage-add.component.css'],
})
export class StageAddComponent implements OnInit {
  ngOnInit(): void {}

  stages: Stage[] = []

  stageForm: FormGroup
  isSubmitted: boolean = false
  base64: string | ArrayBuffer | undefined
maintenanceId : string;
  constructor(formBuilder: FormBuilder, private service : StageService, private snackBar: MatSnackBar, 
    private router : ActivatedRoute, private route : Router ) {
    this.stageForm = formBuilder.group({
      description: [
        '',
        Validators.compose([Validators.required, Validators.maxLength(300)]),
      ],
      value: ['', Validators.compose([Validators.required])],
      type: ['', Validators.compose([Validators.required])],
    });
   this.maintenanceId = this.router.snapshot.paramMap.get('maintenanceId') || ''
  }

  onSubmit() {
    if (this.stageForm.valid) {
      let value =
        this.stageForm.value.type == 2 ? this.base64 : this.stageForm.value.value
     
        this.stages.push(
        new Stage(
          this.stageForm.value.description,
          new Date(),
          this.stageForm.value.type,
          value,
          true,
          this.maintenanceId
        ),
      )
    }
  }

  fileChangeEvent(event: any) {
    const input = event.target as HTMLInputElement

    if (!input.files?.length) {
      return
    }

    const file = event.target.files[0]
    const reader = new FileReader()
    reader.readAsDataURL(file)
    reader.onload = () => {
      this.stageForm.patchValue({ value: reader.result })
      this.base64 = reader.result || undefined
    }
  }

  AddStage() {
      this.service.post(this.stages).subscribe(
        (response) => {
          if (response) {
            this.openSnackBar("Etapas inseridas com sucesso!", "Ok");
            this.route.navigate(['/maintenance-list']);
          }else
          {
            this.openSnackBar("Ocorreu um erro", "Ok")
          }
        },
        
      )
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action,{
      duration: 3000
    });
  }

  redirectToMain(){
    this.route.navigate(['/maintenance-list']);
  }
}
