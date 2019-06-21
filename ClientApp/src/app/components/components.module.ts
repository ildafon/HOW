import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from './paginator/paginator.component';
import { DeleteConfirmationComponent } from './delete-confirmation/delete-confirmation.component';
import { UploadComponent } from './upload/upload.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    PaginatorComponent,
    UploadComponent
  ],
  declarations: [PaginatorComponent, UploadComponent]
})
export class ComponentsModule { }
