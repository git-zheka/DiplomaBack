﻿namespace VoloLearn.Models.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
}