using ConferenceCheckIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceCheckIn.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        private static int _nextId = 1;

        public IEnumerable<User> GetAll() => _users;

        public User? GetByUsername(string username) =>
            _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        public User? Authenticate(string username, string password) =>
            _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);

        public void Add(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }
    }
}