import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PersonDetailComponent } from './person-detail.component';
import { PersonsModule } from './../persons.module';
import { Person } from 'src/app/shared/models/person.model';

describe('PersonDetailComponent', () => {
  let component: PersonDetailComponent;
  let fixture: ComponentFixture<PersonDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonDetailComponent, PersonsModule, Person ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
