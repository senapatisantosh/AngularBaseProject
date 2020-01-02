import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VisionDashboardComponent } from './vision-dashboard.component';

describe('VisionDashboardComponent', () => {
  let component: VisionDashboardComponent;
  let fixture: ComponentFixture<VisionDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VisionDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VisionDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
