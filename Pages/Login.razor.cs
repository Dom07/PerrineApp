using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using PerrineApp.Models;
using PerrineApp.Services;

namespace PerrineApp.Pages
{
    public partial class Login
    {
        [Inject]
        public AuthenticationStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public LoginModel Model { get; set; } = new LoginModel();

        public async Task LogInAsync()
        {
            if (Model.Username == "dom" && Model.Password == "1234")
            {
                await ((CustomAuthenticationStateProvider)AuthStateProvider).LogInAsync(new UserModel { Id = 1, Name = Model.Username });
                NavigationManager.NavigateTo("/");
            }
            else NavigationManager.NavigateTo("/login");
        }
    }
}
