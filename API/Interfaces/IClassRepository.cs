using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IClassRepository
{
    Task<IEnumerable<UserClaseDto>> UserClases(int userId);
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