import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter,
  ChangeDetectorRef
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CreateProjectInput,
  ProjectServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-project-dialog.component.html'
})
export class CreateProjectDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  project: CreateProjectInput = new CreateProjectInput();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _projectService: ProjectServiceProxy,
    public bsModalRef: BsModalRef,
    private cd: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    //this.project.isActive = true;
    this.cd.detectChanges();
  }

  save(): void {
    this.saving = true;

    this._projectService.create(this.project).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
