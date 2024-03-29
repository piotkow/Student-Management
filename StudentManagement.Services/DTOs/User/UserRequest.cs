﻿using StudentManagement.Models.Entities;

namespace StudentManagement.Services.DTOs.User
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
    }
}
