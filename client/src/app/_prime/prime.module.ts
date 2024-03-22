import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StyleClassModule } from 'primeng/styleclass';

import { BadgeModule } from 'primeng/badge';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { DividerModule } from 'primeng/divider';

@NgModule({
   declarations: [],
   imports: [
      CommonModule,
      StyleClassModule,
      BadgeModule,
      InputTextModule,
      ButtonModule,
      DividerModule,
   ],
   exports: [
      StyleClassModule,
      BadgeModule,
      InputTextModule,
      ButtonModule,
      DividerModule,
   ],
})
export class PrimeModule {}
