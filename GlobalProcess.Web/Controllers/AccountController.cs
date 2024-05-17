﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace GlobalProcess.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        public IActionResult Logout()
        {
            return SignOut(new AuthenticationProperties { RedirectUri = "/" },
                CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
