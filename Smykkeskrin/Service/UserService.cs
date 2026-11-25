using Smykkeskrin.model;
using Smykkeskrin.Repo;


namespace Smykkeskrin.Service;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    // login verifisering 
    public User? Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return null;
        }
        List<User> allUsers = _userRepository.GetAllUsers();

        foreach (User user in allUsers)
        {
            if (user.Username == username && user.Password == password)
            {
                return user;
            }
        }

        return null;
    }
    
    //create a new user only one username 
    public void CreateUser(User user)
    {
        List<User> allUsers = _userRepository.GetAllUsers();

        foreach (User existingUser in allUsers)
        {
            if (existingUser.Username.ToLower() == user.Username.ToLower())
            {
                throw new Exception("Brugernavnet er desværre allerede taget.");
            }
        }

        _userRepository.AddUser(user);
    }
    
    
    public List<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
    
    public User? GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }
    
    public void UpdateUser(User user)
    {
        User? existingUser = _userRepository.GetUserById(user.Id);
        if (existingUser == null)
        {
            throw new Exception("Brugeren blev ikke fundet.");
        }

        _userRepository.UpdateUser(user);
    }
    
    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
    }
    
}