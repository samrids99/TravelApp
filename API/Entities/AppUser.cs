namespace API.Entities;

public class AppUser
{
    public int Id { get; set; } // represents database columns and id automatically set to primary key
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

}
