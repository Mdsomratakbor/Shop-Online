using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Security.Claims;

namespace ShopOnline.Web.Pages.Account
{
    public class LoginBase : ComponentBase
    {
        protected UserForAuthenticationDto loginModel = new UserForAuthenticationDto();
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string ErrorMessage { get; set; }
        protected async Task HandleLogin()
        {
            try{

                // Call your authentication service or API to perform user login
                var result = await UserService.LoginAsync(loginModel);

                if (result.IsAuthSuccessful)
                {

                    NavigationManager.NavigateTo("/Product");
                }
                else
                {
                    // Display an error message to the user
                    ErrorMessage = "Invalid credentials. Please try again.";
                }
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
            }
            
        }

        private async Task Logout()
        {
            // await UserService.(loginModel);
            // Redirect to the login page or another appropriate page
            NavigationManager.NavigateTo("/account/login");
        }



    }
}
