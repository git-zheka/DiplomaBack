﻿using VoloLearn.Models.Entities;

namespace VoloLearn.Models.Service
{
    public class CreateUserModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
