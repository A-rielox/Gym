using API.DTOs;
using API.Entities;
using API.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Data;

public class ClassRepository : IClassRepository
{
    private IDbConnection db;

    public ClassRepository(IConfiguration configuration)
    {
        this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }


    ////////////////////////////////////////////////
    ////////////////////////////////////////////////
    ///
    public async Task<IEnumerable<UserClaseDto>> UserClases(int userId)
    {
        List<UserClases> userClases;
        List<UserClaseDto> userClasesDto;

        using (var list = await db.QueryMultipleAsync("sp_horarioDeClasesDeUser",
                                                            new { userId = userId },
                                                            commandType: CommandType.StoredProcedure))
        {
            userClases = list.Read<UserClases>().ToList();
        }

        var xd = userClases.GroupBy(uc => new { claseId = uc.ClaseId, claseNombre = uc.NombreClase } );

        userClasesDto = xd.Select(g => new UserClaseDto
        {
            ClaseId = g.Key.claseId,
            ClaseNombre = g.Key.claseNombre,
            ClaseInfo = g.Select(g => new ClaseInfoDto
            {
                NombreDia = g.NombreDia,
                NombreHora = g.NombreHora,
                NombreSector = g.NombreSector,
            }).ToList()
        }).ToList();

        return userClasesDto;
    }

}
