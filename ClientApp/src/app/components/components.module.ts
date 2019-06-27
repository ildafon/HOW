import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from './paginator/paginator.component';
import { DeleteConfirmationComponent } from './delete-confirmation/delete-confirmation.component';
import { UploadComponent } from './upload/upload.component';
import { AvatarUsernameComponent } from './avatar-username/avatar-username.component';
import { MessageComponent } from './message/message.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    PaginatorComponent,
    UploadComponent,
    AvatarUsernameComponent,
    MessageComponent
  ],
  declarations: [PaginatorComponent, UploadComponent, AvatarUsernameComponent, MessageComponent]
})
export class ComponentsModule { }
