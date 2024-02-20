using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PerrineApp.Services;

namespace PerrineApp.Shared
{
    public partial class NavMenu
    {
        [Inject]
        public AuthenticationStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task LogOutAsync() => await ((CustomAuthenticationStateProvider)AuthStateProvider).LogOutAsync();
    }
}
