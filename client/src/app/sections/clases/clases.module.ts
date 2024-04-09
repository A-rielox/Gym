import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClasesComponent } from './clases/clases.component';
import { PrimeModule } from 'src/app/_prime/prime.module';

@NgModule({
   declarations: [ClasesComponent],
   imports: [CommonModule, PrimeModule],
})
export class ClasesModule {}
