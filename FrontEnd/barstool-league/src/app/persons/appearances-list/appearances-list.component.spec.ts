import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppearancesListComponent } from './appearances-list.component';

describe('AppearancesListComponent', () => {
  let component: AppearancesListComponent;
  let fixture: ComponentFixture<AppearancesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppearancesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppearancesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
