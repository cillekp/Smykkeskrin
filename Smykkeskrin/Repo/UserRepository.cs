using System.Collections.Generic;
using Smykkeskrin.model;

namespace Smykkeskrin.Repo;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users;
    public void AddUser(User user)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        throw new System.NotImplementedException();
    }

    public List<User> GetAllUsers()
    {
        throw new System.NotImplementedException();
    }

    public User? GetUserById(int id)
    {
        throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new System.NotImplementedException();
    }
}