using System.Collections.Concurrent;
using Microsoft.AspNetCore.Identity;

namespace DungeonMasterDashboard.Services;

// TODO: Commented out areas for use with password hasher

public class UserService
{
    private readonly ConcurrentDictionary<string, User> _users = new();
    private readonly PasswordHasher<User> _hasher = new();

    public User? GetUser(string username)
        => _users.TryGetValue(username, out var user) ? user : null;

    //public bool Register(string username, string password, string role = "user")
    //{
    //    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
    //        throw new ArgumentException("Username and password are required.");

    //    if (_users.ContainsKey(username))
    //        return false;

    //    var user = new User { Username = username, Role = role };
    //    user.PasswordHash = _hasher.HashPassword(user, password);

    //    return _users.TryAdd(username, user);
    //}
    public bool Register(string username, string password, string role = "user")
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Username and password are required.");

        var user = new User
        {
            Username = username,
            Password = password,
            Role = role
        };

        return _users.TryAdd(username, user);
    }

    public bool VerifyPassword(User user, string password)
    {
        //var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
        //return result == PasswordVerificationResult.Success;

        return user.Password.Equals(password);
    }
}
public class User
{
    public required string Username { get; set; } = "";
    public required string Password { get; set; } = "";
    public string Role { get; set; } = "user";
}