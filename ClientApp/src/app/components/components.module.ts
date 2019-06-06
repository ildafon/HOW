import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from './paginator/paginator.component';
import { DeleteConfirmationComponent } from './delete-confirmation/delete-confirmation.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    PaginatorComponent
  ],
  declarations: [PaginatorComponent]
})
export class ComponentsModule { }
