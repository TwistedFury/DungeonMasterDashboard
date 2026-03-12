using DungeonMasterDashboard.Models;
using DungeonMasterDashboard.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DungeonMasterDashboard;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly UserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _config;

    /// <summary>
    /// Initializes a new instance of the CustomAuthStateProvider class using the specified user service, HTTP context
    /// accessor, and configuration settings.
    /// </summary>
    /// <remarks>Ensure that all dependencies are properly registered in the dependency injection container
    /// before instantiating this class.</remarks>
    /// <param name="userService">The user service that provides user management and authentication operations.</param>
    /// <param name="httpContextAccessor">An accessor that provides access to the current HTTP context for retrieving user information from the request.</param>
    /// <param name="config">The configuration settings used to customize the behavior of the authentication provider.</param>
    public CustomAuthStateProvider(UserService userService, IHttpContextAccessor httpContextAccessor, IConfiguration config)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
        _config = config;
    }

    /// <summary>
    /// Asynchronously retrieves the current authentication state for the user based on the presence of a JSON Web Token
    /// (JWT) in the HTTP request cookies.
    /// </summary>
    /// <remarks>This method checks for a JWT in the request cookies to determine the user's authentication
    /// state. If a valid token is present, the returned <see cref="ClaimsPrincipal"/> contains the claims from the JWT.
    /// If no token is found or an error occurs, an unauthenticated <see cref="ClaimsPrincipal"/> is returned. This
    /// method is typically used in Blazor Server applications to integrate cookie-based authentication with the
    /// authentication state provider.</remarks>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="AuthenticationState"/>
    /// object representing the user's authentication state. The user is authenticated if a valid JWT is found in the
    /// request cookies; otherwise, an unauthenticated user is returned.</returns>
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            if (_httpContextAccessor.HttpContext!.Request.Cookies.ContainsKey(BlazorConstants.AuthCookieName))
            {
                var token = _httpContextAccessor.HttpContext.Request.Cookies[BlazorConstants.AuthCookieName];
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                var identity = new ClaimsIdentity(jsonToken!.Claims, "jwt");
                var user = new ClaimsPrincipal(identity);
                return Task.FromResult(new AuthenticationState(user));
            }

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }
        catch
        {
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }
    }

    public bool Register(string username, string password)
    {
        // Could also validate password rules here
        return _userService.Register(username, password);
    }

    /// <summary>
    /// Authenticates a user with the provided username and password, returning a JSON Web Token (JWT) if successful.
    /// </summary>
    /// <remarks>Ensure that the username and password meet the required criteria for successful
    /// authentication. The token generated can be used for authorization in subsequent API calls.</remarks>
    /// <param name="username">The username of the user attempting to log in. This value must not be null or empty.</param>
    /// <param name="password">The password associated with the specified username. This value must not be null or empty.</param>
    /// <returns>A JSON Web Token (JWT) that can be used for subsequent authenticated requests. The token is valid for 30
    /// minutes.</returns>
    /// <exception cref="Exception">Thrown if the username or password is invalid, indicating that authentication has failed.</exception>
    public string Login(string username, string password)
    {
        var user = _userService.GetUser(username);

        if (user != null && _userService.VerifyPassword(user, password))
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var issuer = _config["Jwt:Issuer"]!;
            var audience = _config["Jwt:Audience"]!;
            var key = _config["Jwt:Key"]!;

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        throw new Exception("Invalid username or password");
    }

    /// <summary>
    /// Notifies subscribers of an authentication state change based on the specified JWT token.
    /// </summary>
    /// <remarks>This method parses the provided JWT token, creates a new authentication state using the
    /// claims contained within the token, and notifies all subscribers of the updated state. An exception may be thrown
    /// if the token is invalid or cannot be parsed.</remarks>
    /// <param name="tokenString">The JSON Web Token (JWT) string from which user claims are extracted to update the authentication state. Must be
    /// a valid JWT.</param>
    public void NotifyAuthStateChangedFromToken(string tokenString)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(tokenString) as JwtSecurityToken;

        var identity = new ClaimsIdentity(jsonToken!.Claims, "jwt");
        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
}