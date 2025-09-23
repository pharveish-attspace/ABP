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
  ProjectServiceProxy,
  ProjectDto,
  GetProjectsOutput
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-project-dialog.component.html'
})
export class EditProjectDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  project: ProjectDto = new ProjectDto();
  id: number;

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
    this._projectService.getProjects(this.id,null).subscribe((result: GetProjectsOutput) => {
      this.project = result.projects[0] ?? null;
      this.cd.detectChanges();
    });
  }

  save(): void {
    this.saving = true;

    this._projectService.update(this.project).subscribe(
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
