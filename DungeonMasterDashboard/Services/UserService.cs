using System.Collections.Concurrent;
using Microsoft.AspNetCore.Identity;

namespace DungeonMasterDashboard.Services;

// TODO: Commented out areas for use with password hasher

public class UserService
{
    private readonly ConcurrentDictionary<string, User> _users = new();
    private readonly PasswordHasher<User> _hasher = new();

    /// <summary>
    /// Retrieves the user associated with the specified username, if one exists.
    /// </summary>
    /// <remarks>If the specified username does not exist in the user collection, this method returns null.
    /// Callers should verify that the returned value is not null before accessing user properties.</remarks>
    /// <param name="username">The username of the user to retrieve. Cannot be null or empty.</param>
    /// <returns>The user associated with the specified username, or null if no user is found.</returns>
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

    /// <summary>
    /// Registers a new user with the specified username, password, and role.
    /// </summary>
    /// <remarks>This method adds the user to an internal collection and ensures that usernames are
    /// unique.</remarks>
    /// <param name="username">The unique username for the new user. Cannot be null or whitespace.</param>
    /// <param name="password">The password for the new user. Cannot be null or whitespace.</param>
    /// <param name="role">The role to assign to the new user. Defaults to "user" if not specified.</param>
    /// <returns>true if the user was successfully registered; otherwise, false if the username already exists.</returns>
    /// <exception cref="ArgumentException">Thrown if either <paramref name="username"/> or <paramref name="password"/> is null or consists only of
    /// white-space characters.</exception>
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

    /// <summary>
    /// Determines whether the specified password matches the stored password for the given user.
    /// </summary>
    /// <remarks>This method compares the provided password to the user's stored password using a direct
    /// equality check. It does not perform any hashing or cryptographic verification. For production scenarios,
    /// consider using a secure password hashing mechanism.</remarks>
    /// <param name="user">The user whose password is being verified. This parameter cannot be null.</param>
    /// <param name="password">The password to verify against the user's stored password. This parameter cannot be null.</param>
    /// <returns>true if the provided password matches the user's stored password; otherwise, false.</returns>
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