namespace API.DTOs;

public class UserClaseDto
{
    public int ClaseId { get; set; }
    public string ClaseNombre { get; set; }

    public List<ClaseInfoDto> ClaseInfo { get; set; }
}
