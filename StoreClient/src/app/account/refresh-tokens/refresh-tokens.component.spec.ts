import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RefreshTokensComponent } from './refresh-tokens.component';

describe('RefreshTokensComponent', () => {
  let component: RefreshTokensComponent;
  let fixture: ComponentFixture<RefreshTokensComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RefreshTokensComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RefreshTokensComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
