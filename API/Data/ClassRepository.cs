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

        var xd = userClases.GroupBy(uc => new { classId = uc.ClassId, ClassName = uc.ClassName } );

        userClasesDto = xd.Select(g => new UserClaseDto
        {
            ClassId = g.Key.classId,
            ClassName = g.Key.ClassName,
            ClaseInfo = g.Select(g => new ClaseInfoDto
            {
                DayName = g.DayName,
                HourName = g.HourName,
                SectorName = g.SectorName,
            }).ToList()
        }).ToList();

        return userClasesDto;
    }

}
