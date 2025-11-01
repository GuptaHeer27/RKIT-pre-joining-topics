using System.Collections.Generic;
using System.Data;
using ServiceStack.OrmLite;
using Ormlite.Model;
using ServiceStack.Data;

namespace Ormlite.Repository
{
    internal class UserRepository
    {


        private readonly IDbConnectionFactory _dbFactory; // this variable can be assigned only once

        public UserRepository(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void CreateTable()
        {
            using var db = _dbFactory.Open();
            db.CreateTableIfNotExists<User>();
        }

        public void InsertUser(User user)
        {
            using var db = _dbFactory.Open();       /// InsertAll add
            db.Insert(user);                        /// LastInserted ID
        }

        public List<User> GetAllUsers()
        {
            using var db = _dbFactory.Open();
            return db.Select<User>();
        }



        public User GetUserById(int id)
        {
            using var db = _dbFactory.Open();
            return db.SingleById<User>(id);
        }

        public void UpdateUser(User user)                   /// UpdateAll
        {
            using var db = _dbFactory.Open();
            db.Update(user);
        }

        public void DeleteUser(int id)
        {
            using var db = _dbFactory.Open();
            db.DeleteById<User>(id);
        }

    }
}
