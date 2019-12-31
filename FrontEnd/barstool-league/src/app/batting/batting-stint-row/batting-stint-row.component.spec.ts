import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BattingStintRowComponent } from './batting-stint-row.component';

describe('BattingStintRowComponent', () => {
  let component: BattingStintRowComponent;
  let fixture: ComponentFixture<BattingStintRowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BattingStintRowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BattingStintRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
