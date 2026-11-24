using System.Collections.Generic;
using Smykkeskrin.model;

namespace Smykkeskrin.Repo;

public interface IUserRepository
{
    void AddUser(User user);
    void UpdateUser(User user);
    
    List<User> GetAllUsers();
    User? GetUserById(int id);
    void DeleteUser(int id);
}