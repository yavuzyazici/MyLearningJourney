﻿namespace FirstProjectWithAPI.WebApi.Entities
{
    public class Contact
    {
        public int ContactId  { get; set; }
        public string MapLocation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OpenHours { get; set; }
    }
}
