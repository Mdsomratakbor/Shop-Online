using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Services
{
    public class UserService:IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient=httpClient;
        }


    }
}
