using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json.Nodes;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using DungeonMasterDashboard.Models;

namespace DungeonMasterDashboard.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;
        private readonly ISyncLocalStorageService localStorage;

        public CustomAuthenticationStateProvider(HttpClient httpClient, ISyncLocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;

            var accessToken = localStorage.GetItem<string>("accessToken");
            if (accessToken != null)
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
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
            catch
            {
                
            }

            return new AuthenticationState(user);
        }

        public async Task<FormResult> LoginAsync(string email, string password)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("/login", new { email, password });
                if (response.IsSuccessStatusCode)
                {
                    var strResponse = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonNode.Parse(strResponse);
                    var accessToken = jsonResponse?["accessToken"]?.ToString();
                    var refreshToken = jsonResponse?["refreshToken"]?.ToString();

                    localStorage.SetItem("accessToken", accessToken);
                    localStorage.SetItem("refreshToken", refreshToken);

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

        public void Logout()
        {
            // delete tokens from local storage
            localStorage.RemoveItem("accessToken");
            localStorage.RemoveItem("refreshToken");
            httpClient.DefaultRequestHeaders.Authorization = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<FormResult> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("/register", registerDto);
                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await LoginAsync(registerDto.Email, registerDto.Password);
                    return loginResponse;
                }

                // Registration Errors
                var strResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(strResponse);
                var jsonResponse = JsonNode.Parse(strResponse);
                var errorsObject = jsonResponse!["errors"]!.AsObject();
                var errorsList = new List<string>();
                foreach (var error in errorsObject)
                {
                    errorsList.Add(error.Value![0]!.ToString());
                }

                var formResult = new FormResult
                {
                    Success = false,
                    Errors = errorsList.ToArray()
                };

                return formResult;
            } catch { }
            return new FormResult { Success = false, Errors = ["Connection Error"] };
        }
    }

    public class FormResult
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; } = [];
    }
}
