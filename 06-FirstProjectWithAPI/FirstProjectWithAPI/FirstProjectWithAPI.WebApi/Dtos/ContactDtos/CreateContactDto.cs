﻿namespace FirstProjectWithAPI.WebApi.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string MapLocation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OpenHours { get; set; }
    }
}
