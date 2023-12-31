﻿using Microsoft.AspNetCore.Identity;

namespace ShopOnline.Api.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
    }
}
