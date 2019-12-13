import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintingEditionDialogComponent } from './printing-edition-dialog.component';

describe('PrintingEditionDialogComponent', () => {
  let component: PrintingEditionDialogComponent;
  let fixture: ComponentFixture<PrintingEditionDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrintingEditionDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintingEditionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
