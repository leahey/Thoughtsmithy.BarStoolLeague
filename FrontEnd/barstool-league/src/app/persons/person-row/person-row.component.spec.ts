import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PersonRowComponent } from './person-row.component';
import { PersonBioComponent } from '../person-bio/person-bio.component';
import { Person } from 'src/app/shared/models/person.model';

describe('PersonRowComponent', () => {
  let component: PersonRowComponent;
  let fixture: ComponentFixture<PersonRowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonRowComponent, PersonBioComponent ],
      imports: [ Person ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
