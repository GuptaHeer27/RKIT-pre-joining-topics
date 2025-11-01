using Ormlite.Repository;
using Ormlite.Service;
using Ormlite.Repository;
using Ormlite.Service;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;

class Program
{
    static void Main(string[] args)
    {
        //  Create DB connection factory (MySQL)
        IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(
            "Server=localhost;Database=ormlitedb;User Id=root;Password=maheer2709;",
            MySqlDialect.Provider
        );

        // Initialize Repository and create table
        var userRepo = new UserRepository(dbFactory);
        userRepo.CreateTable();

        //  Initialize Service
        var userService = new UserService(userRepo);

        //  Insert Users
        userService.AddUser("Heer", "heer@example.com");
        userService.AddUser("Riya", "riya@example.com");

        //  Display all users
        Console.WriteLine("All Users:");
        foreach (var user in userService.GetAllUsers())
        {
            Console.WriteLine($"{user.Id}: {user.Name} ({user.Email})");
        }

        //  Update a user
        userService.UpdateUser(1, "Heer Gupta");

        //  Delete a user
        userService.DeleteUser(2);

        // Display after update & delete
        Console.WriteLine("\nAfter Update & Delete:");
        foreach (var user in userService.GetAllUsers())
        {
            Console.WriteLine($"{user.Id}: {user.Name} ({user.Email})");
        }
    }
}
