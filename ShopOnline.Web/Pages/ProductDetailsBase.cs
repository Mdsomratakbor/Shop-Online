using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductDetailsBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public IProductService ProductService { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage { get; set; }
        protected override async void OnInitialized()
        {
            try
            {
                Product = await ProductService.GetProductById(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
