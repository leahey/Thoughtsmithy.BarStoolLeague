import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridPlayersComponent } from './grid-players.component';

describe('GridPlayersComponent', () => {
  let component: GridPlayersComponent;
  let fixture: ComponentFixture<GridPlayersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridPlayersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridPlayersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
