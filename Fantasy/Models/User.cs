﻿namespace Fantasy.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } // Store hashed password
}