﻿using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductDetailsBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductService? ProductService { get; set; }

        [Inject]
        public IShoppingCartService? ShoppingService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public ProductDto? Product { get; set; }
        public string? ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
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
        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var carItemDto = await ShoppingService.AddItem(cartItemToAddDto);
                NavigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception)
            {

            }
        }
    }
}
