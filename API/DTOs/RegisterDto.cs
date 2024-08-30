using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto // this dto is used to give an object to the Register method in AccountController.cs rather than it taking in a bunch of parameters
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }

}
