import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FieldingListComponent } from './fielding-list.component';

describe('FieldingListComponent', () => {
  let component: FieldingListComponent;
  let fixture: ComponentFixture<FieldingListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FieldingListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FieldingListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
