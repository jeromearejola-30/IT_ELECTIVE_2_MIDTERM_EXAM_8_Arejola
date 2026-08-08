using ConferenceCheckIn.Models;
using System.Collections.Generic;

namespace ConferenceCheckIn.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetByUsername(string username);
        User? Authenticate(string username, string password);
        void Add(User user);
    }
}