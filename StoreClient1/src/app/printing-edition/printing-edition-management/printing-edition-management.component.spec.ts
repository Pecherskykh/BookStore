import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintingEditionManagementComponent } from './printing-edition-management.component';

describe('PrintingEditionManagementComponent', () => {
  let component: PrintingEditionManagementComponent;
  let fixture: ComponentFixture<PrintingEditionManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrintingEditionManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintingEditionManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
