import { ChangeDetectorRef, Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/paged-listing-component-base';
import {
  ProjectServiceProxy,
  ProjectDto,
  GetProjectsOutput,
} from '@shared/service-proxies/service-proxies';
import { CreateProjectDialogComponent } from './create-project/create-project-dialog.component';
import { EditProjectDialogComponent } from './edit-project/edit-project-dialog.component';

class PagedProjectsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './projects.component.html',
  animations: [appModuleAnimation()]
})
export class ProjectsComponent extends PagedListingComponentBase<ProjectDto> {
  projects: ProjectDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _projectService: ProjectServiceProxy,
    private _modalService: BsModalService,
    cd: ChangeDetectorRef
  ) {
    super(injector, cd);
  }

  list(
    request: PagedProjectsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._projectService
      .getProjects(null,null)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: GetProjectsOutput) => {
        this.projects = result.projects;
        //this.showPaging(result, pageNumber);
      });
  }

  delete(project: ProjectDto): void {
    abp.message.confirm(
      this.l('ProjectDeleteWarningMessage', project.assignedUserId),
      undefined,
      (result: boolean) => {
        if (result) {
          this._projectService
            .delete(project.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createProject(): void {
    this.showCreateOrEditProjectDialog();
  }

  editProject(project: ProjectDto): void {
    this.showCreateOrEditProjectDialog(project.id);
  }

  showCreateOrEditProjectDialog(id?: number): void {
    let createOrEditProjectDialog: BsModalRef;
    if (!id) {
      createOrEditProjectDialog = this._modalService.show(
        CreateProjectDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditProjectDialog = this._modalService.show(
        EditProjectDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditProjectDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
