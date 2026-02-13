using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json.Nodes;
using System.Net.Http.Headers;

namespace DungeonMasterDashboard.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;

        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            /*
            //var user = new ClaimsPrincipal(new ClaimsIdentity()); // non-authenticated user
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "John") };
            var identity = new ClaimsIdentity(claims, "ANY");
            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
            */

            var user = new ClaimsPrincipal(new ClaimsIdentity()); // non-authenticated user

            try
            {
                var response = await httpClient.GetAsync("manage/info");
                if (response.IsSuccessStatusCode)
                {
                    var strResponse = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonNode.Parse(strResponse);
                    var email = jsonResponse!["email"]!.ToString();

                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, email),
                        new(ClaimTypes.Email, email)
                    };

                    // Set the principal
                    var identity = new ClaimsIdentity(claims, "Token");
                    user = new ClaimsPrincipal(identity);
                    return new AuthenticationState(user);
                }
            } 
            catch (Exception ex)
            {

            }

            return new AuthenticationState(user);
        }

        public async Task<FormResult> LoginAsync(string email, string password)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("authentication/login", new { email, password });
                if (response.IsSuccessStatusCode)
                {
                    var strResponse = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonNode.Parse(strResponse);
                    var accessToken = jsonResponse?["accessToken"]?.ToString();
                    var refreshToken = jsonResponse?["refreshToken"]?.ToString();

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    // Refresh auth state
                    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

                    // Success!
                    return new FormResult { Success = true };
                }
                else
                {
                    return new FormResult { Success = false, Errors = ["Bad Email or Password"] };
                }
            } catch { }

            return new FormResult { Success = false, Errors = [ "Connection Error" ] };
        }
    }

    public class FormResult
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; } = [];
    }
}
