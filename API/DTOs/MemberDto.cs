﻿namespace API.DTOs;

public class MemberDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PhotoUrl { get; set; }
    public string KnownAs { get; set; }
    public DateTime LastActive { get; set; }
    public string City { get; set; }
    public string Country { get; set; }


    public ICollection<PictureDto> Pictures { get; set; }
}
