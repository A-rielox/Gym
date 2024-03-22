import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavComponent } from './nav/nav.component';
import { PrimeModule } from '../_prime/prime.module';

import { AppRoutingModule } from '../app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './text-input/text-input.component';
import { SidebarComponent } from './sidebar/sidebar.component';

@NgModule({
   declarations: [NavComponent, TextInputComponent, SidebarComponent],
   imports: [CommonModule, PrimeModule, AppRoutingModule, ReactiveFormsModule],
   exports: [NavComponent, SidebarComponent],
})
export class SharedModule {}
