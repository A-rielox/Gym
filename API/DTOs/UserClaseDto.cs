namespace API.DTOs;

public class UserClaseDto
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }

    public List<ClaseInfoDto> ClassInfo { get; set; }
}
