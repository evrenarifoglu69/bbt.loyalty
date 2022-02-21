import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignDefinitionListDetailComponent } from './campaign-definition-list-detail.component';

describe('CampaignDefinitionListDetailComponent', () => {
  let component: CampaignDefinitionListDetailComponent;
  let fixture: ComponentFixture<CampaignDefinitionListDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CampaignDefinitionListDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CampaignDefinitionListDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
