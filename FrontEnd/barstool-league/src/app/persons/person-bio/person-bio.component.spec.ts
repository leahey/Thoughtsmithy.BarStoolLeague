import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PersonBioComponent } from './person-bio.component';
import { RouterModule } from '@angular/router';
import { Person } from '../../shared/models/person.model';

describe('PersonBioComponent', () => {
  let component: PersonBioComponent;
  let fixture: ComponentFixture<PersonBioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonBioComponent ],
      imports: [ RouterModule, Person ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonBioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
