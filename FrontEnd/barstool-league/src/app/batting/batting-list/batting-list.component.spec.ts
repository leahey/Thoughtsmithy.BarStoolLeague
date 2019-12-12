import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BattingListComponent } from './batting-list.component';

describe('BattingListComponent', () => {
  let component: BattingListComponent;
  let fixture: ComponentFixture<BattingListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BattingListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BattingListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
