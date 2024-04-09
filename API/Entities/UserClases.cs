namespace API.Entities;

public class UserClases
{
    public int UserId { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public string DayName { get; set; }
    public int HourName { get; set; }
    public string SectorName { get; set; }
}

/*
userId	nombre_clase	nombreDia	nombreHora	nombreSector
2	Salsa principiantes	L	8	Piso 2 - A
2	Salsa principiantes	X	8	Piso 2 - A
2	Salsa principiantes	V	8	Piso 2 - A
2	Zumba avanzado	L	18	Piso 2 - B
2	Zumba avanzado	X	18	Piso 2 - B
2	Zumba avanzado	V	18	Piso 2 - B
2	Karate adultos intermedio	M	20	Piso 2 - C
2	Karate adultos intermedio	J	20	Piso 2 - C
2	Karate adultos intermedio	S	20	Piso 2 - C
*/

/*
 export interface UserClasses {
   classId: number;
   className: string;
   classInfo: ClassInfo[];
}

export interface ClassInfo {
   dayName: string;
   hourName: number;
   sectorName: string;
}

 * 
*/