import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { ProjectsRoutingModule } from './projects-routing.module';
import { CreateProjectDialogComponent } from './create-project/create-project-dialog.component';
import { EditProjectDialogComponent } from './edit-project/edit-project-dialog.component';
import { ProjectsComponent } from './projects.component';

@NgModule({
    declarations: [
        CreateProjectDialogComponent,
        EditProjectDialogComponent,
        ProjectsComponent,
    ],
    imports: [SharedModule, ProjectsRoutingModule],
})
export class ProjectsModule {}
