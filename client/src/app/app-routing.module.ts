import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './sections/home/home/home.component';
import { ClasesComponent } from './sections/clases/clases/clases.component';

const routes: Routes = [
   { path: '', component: HomeComponent, pathMatch: 'full' },
   { path: 'clases', component: ClasesComponent },
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule],
})
export class AppRoutingModule {}
