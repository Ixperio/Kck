using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using KasynoGui.Models;

namespace KasynoGui
{
    public partial class Startup
    {
        // Aby uzyskać więcej informacji o konfigurowaniu uwierzytelniania, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Umożliwia aplikacji weryfikowanie znacznika zabezpieczeń podczas logowania się użytkownika.
                    // Jest to funkcja zabezpieczeń używana w przypadku zmiany hasła lub dodawania logowania zewnętrznego do konta.  
           
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

        }
    }
}