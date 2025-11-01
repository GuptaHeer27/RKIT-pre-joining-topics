using Ormlite.Model;
using Ormlite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ormlite.Service
{
    internal class UserService
    {
        private readonly UserRepository _userRepo;

        public UserService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        // Add new user with basic validation
        public void AddUser(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new System.Exception("Name cannot be empty");

            var user = new User { Name = name, Email = email };
            _userRepo.InsertUser(user);
        }

        // Get all users
        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        // Update a user's name
        public void UpdateUser(int id, string newName)
        {
            var user = _userRepo.GetUserById(id);
            if (user == null)
                throw new System.Exception("User not found");

            user.Name = newName;
            _userRepo.UpdateUser(user);
        }

        // Delete a user
        public void DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
        }
    }
}
