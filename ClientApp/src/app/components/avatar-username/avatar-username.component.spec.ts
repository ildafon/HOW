import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AvatarUsernameComponent } from './avatar-username.component';

describe('AvatarUsernameComponent', () => {
  let component: AvatarUsernameComponent;
  let fixture: ComponentFixture<AvatarUsernameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AvatarUsernameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AvatarUsernameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
