﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using PerrineApp.Models;
using System.Security.Claims;

namespace PerrineApp.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public ProtectedSessionStorage _sessionStorage { get; set; }

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            var userId = await _sessionStorage.GetAsync<string>("userId");

            if (userId.Value != null)
            {
                var userName = await _sessionStorage.GetAsync<string>(ClaimTypes.Name);

                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName.Value!),
                    new Claim("userId", userId.Value),
                }, CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }

        public async Task LogInAsync(UserModel user)
        {
            await _sessionStorage.SetAsync("userId", user.Id.ToString());
            await _sessionStorage.SetAsync(ClaimTypes.Name, user.FirstName);

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim("userId", user.Id.ToString()),
                new Claim("picture", user.Picture),
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        public async Task LogOutAsync()
        {
            await _sessionStorage.DeleteAsync("userId");
            await _sessionStorage.DeleteAsync("userName");

            var identity = new ClaimsIdentity();
            var principal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }
    }
}
