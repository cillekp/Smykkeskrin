using System.ComponentModel.DataAnnotations;

namespace Smykkeskrin.model;
using Smykkeskrin.model;

public class User
{
    
    public int Id { get; set; }
    
    [Required(ErrorMessage = "fornavn skal udfyldes")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Efternavn skal udfyldes")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Brugernavn skal udfyldes")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Adgangskode skal udfyldes")]
    [MinLength(7, ErrorMessage = "Adgangskoden skal være mindst 7 tegn")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Email skal udfyldes")]
    [EmailAddress(ErrorMessage = "Indtast en gyldig email-adresse")]
    public string Email { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    
    public Role UserRole { get; set; }

    public User(int id, string firstName, string lastName, string username, string password, string email, string phoneNumber, Role userRole)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        UserRole = userRole;
    }

    public User()
    {
        
    }
    
    public enum Role
    {
        Vip = 0,
        Admin = 1,
        User = 2
    }
    
}