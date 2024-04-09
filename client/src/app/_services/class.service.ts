import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserClass } from '../_models/userClass';

@Injectable({
   providedIn: 'root',
})
export class ClassService {
   baseUrl = environment.apiUrl;

   constructor(private http: HttpClient) {}

   getUserClasses() {
      return this.http.get<UserClass[]>(this.baseUrl + 'class');
   }

   /*
   [
      {
         "claseId": 1,
         "claseNombre": "Salsa principiantes",
         "claseInfo": [
               {
                  "nombreDia": "L",
                  "nombreHora": 8,
                  "nombreSector": "Piso 2 - A"
               },
               {
                  "nombreDia": "X",
                  "nombreHora": 8,
                  "nombreSector": "Piso 2 - A"
               },
               {
                  "nombreDia": "V",
                  "nombreHora": 8,
                  "nombreSector": "Piso 2 - A"
               }
         ]
      },
      {
         "...
      },
      {
         ...
      }
   ]
   */
}
