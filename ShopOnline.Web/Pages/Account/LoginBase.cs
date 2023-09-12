using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages.Account
{
    public class LoginBase:ComponentBase
    {
        protected UserForAuthenticationDto loginModel = new UserForAuthenticationDto();
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string ErrorMessage { get; set; }
        protected async Task HandleLogin()
        {
            // Call your authentication service or API to perform user login
            var result = await UserService.LoginAsync(email, password);

            if (result.IsAuthenticated)
            {
                // Redirect to the dashboard or another page on successful login
                NavigationManager.NavigateTo("/dashboard");
            }
            else
            {
                // Display an error message to the user
                ErrorMessage = "Invalid credentials. Please try again.";
            }
        }
    }
}
