using Microsoft.Data.SqlClient;
using Smykkeskrin.model;


namespace Smykkeskrin.Repo;

public class UserRepository : IUserRepository
{

    private readonly string _connectionstring;
    public UserRepository(IConfiguration configuration)
    {
        _connectionstring = configuration.GetConnectionString("DefaultConnection");
    }
    
    
    // create 1
    public void AddUser(User user)
    {
       string sql = "INSERT INTO users (firstName, lastName, userName,password, email,phoneNumber, userRole ) values (@firstName, @lastName , @userName, @password, @email, @phoneNumber, @userRole)";

       using (SqlConnection connection = new SqlConnection(_connectionstring))
       {
           using (SqlCommand command = new SqlCommand(sql, connection))
           {
               command.Parameters.AddWithValue("@firstName", user.FirstName);
               command.Parameters.AddWithValue("@lastName", user.LastName);
               command.Parameters.AddWithValue("@userName", user.Username);
               command.Parameters.AddWithValue("@password", user.Password);
               command.Parameters.AddWithValue("@email", user.Email);
               command.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
               command.Parameters.AddWithValue("@userRole", (int)user.UserRole);
               
               connection.Open();
               command.ExecuteNonQuery(); // når vi ikke skal ha data retur 
           }
       }
    }
    
    // read all 2
    public List<User> GetAllUsers()
    {
       var users = new List<User>();
       string sql = "SELECT id, firstName, lastName, userName, password, email,phoneNumber,userRole FROM users";
       
       using (SqlConnection connection = new SqlConnection(_connectionstring))
       {
           using (SqlCommand command = new SqlCommand(sql, connection))
           {
               connection.Open();
               using (SqlDataReader reader = command.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       User user = new User()
                       {
                           Id = reader.GetInt32(0),
                           FirstName = reader.GetString(1),
                           LastName = reader.GetString(2),
                           Username = reader.GetString(3),
                           Password = reader.GetString(4),
                           Email = reader.GetString(5),
                           PhoneNumber = reader.IsDBNull(6) ? "" : reader.GetString(6),
                           UserRole = (User.Role)reader.GetInt32(7)
                       };
                       users.Add(user);
                   }
               }
           }
       }
       return users;
    }
    
    // read ( by id ) 2 
    public User? GetUserById(int id)
    { 
        string sql = "SELECT id, firstName, lastName, userName, password, email,phoneNumber,userRole FROM users WHERE id = @id";
        using (SqlConnection connection = new SqlConnection(_connectionstring))
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = new User()
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Username = reader.GetString(3),
                            Password = reader.GetString(4),
                            Email = reader.GetString(5),
                            PhoneNumber = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            UserRole = (User.Role)reader.GetInt32(7)
                        };
                        return user;
                    }
                }
            }
        }
        return null;
    }
    
    // update user 3
    public void UpdateUser(User user)
    {
        string sql = " UPDATE user SET firstName = @FirstName, lastName = @LastName, userName = @UserName,  password = @Password, email = @Email, phoneNumber = @PhoneNumber, userRole = @UserRole WHERE id = @id";
        using (SqlConnection connection = new SqlConnection(_connectionstring))
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", user.Id); 
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@UserName", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@UserRole", (int)user.UserRole);
                connection.Open();
                command.ExecuteNonQuery();// igen vi vil ikke ha noget tilbage 
            }
        }
    }
    
    

    public void DeleteUser(int id)
    {
        string sql = "DELETE FROM users WHERE id = @id";
        using (SqlConnection connection = new SqlConnection(_connectionstring))
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
    
    
    
    
    
    
    
    
    
}