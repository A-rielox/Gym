import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserClasses } from '../_models/userClasses';

@Injectable({
   providedIn: 'root',
})
export class ClassService {
   baseUrl = environment.apiUrl;

   constructor(private http: HttpClient) {}

   getUserClasses() {
      return this.http.get<UserClasses>(this.baseUrl + 'class');
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
         "claseId": 3,
         "claseNombre": "Zumba avanzado",
         "claseInfo": [
               {
                  "nombreDia": "L",
                  "nombreHora": 18,
                  "nombreSector": "Piso 2 - B"
               },
               {
                  "nombreDia": "X",
                  "nombreHora": 18,
                  "nombreSector": "Piso 2 - B"
               },
               {
                  "nombreDia": "V",
                  "nombreHora": 18,
                  "nombreSector": "Piso 2 - B"
               }
         ]
      },
      {
         "claseId": 5,
         "claseNombre": "Karate adultos intermedio",
         "claseInfo": [
               {
                  "nombreDia": "M",
                  "nombreHora": 20,
                  "nombreSector": "Piso 2 - C"
               },
               {
                  "nombreDia": "J",
                  "nombreHora": 20,
                  "nombreSector": "Piso 2 - C"
               },
               {
                  "nombreDia": "S",
                  "nombreHora": 20,
                  "nombreSector": "Piso 2 - C"
               }
         ]
      }
   ]
   */
}
