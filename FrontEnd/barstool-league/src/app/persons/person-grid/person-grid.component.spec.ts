import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PersonGridComponent } from './person-grid.component';
import { NgbAccordion, NgbPagination, NgbPanel, NgbPanelHeader, NgbPanelToggle } from '@ng-bootstrap/ng-bootstrap';
import { PersonRowComponent } from '../person-row/person-row.component';

describe('PersonGridComponent', () => {
  let component: PersonGridComponent;
  let fixture: ComponentFixture<PersonGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonGridComponent, PersonRowComponent,
        NgbAccordion, NgbPagination, NgbPanel, NgbPanelHeader, NgbPanelToggle
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
