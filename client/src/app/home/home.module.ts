import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { sha1 } from '@angular/compiler/src/i18n/digest';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports:[HomeComponent]
})
export class HomeModule { }
