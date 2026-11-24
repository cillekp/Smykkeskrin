namespace Smykkeskrin.model;

public class User
{
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
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