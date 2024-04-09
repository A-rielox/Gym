import { Component, OnInit } from '@angular/core';
import { UserClass } from 'src/app/_models/userClass';
import { ClassService } from 'src/app/_services/class.service';

@Component({
   selector: 'app-clases',
   templateUrl: './clases.component.html',
   styleUrls: ['./clases.component.css'],
})
export class ClasesComponent implements OnInit {
   classes?: UserClass[];

   constructor(private classService: ClassService) {}

   ngOnInit(): void {
      this.loadMyClasses();

      console.log(this.classes);
   }

   loadMyClasses() {
      this.classService.getUserClasses().subscribe({
         next: (myClases) => {
            this.classes = myClases;
         },
      });
   }
}
