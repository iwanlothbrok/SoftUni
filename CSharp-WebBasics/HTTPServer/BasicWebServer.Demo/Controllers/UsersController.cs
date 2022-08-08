﻿using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        private const string LoginForm = @"<form action='/Login' method='POST'>
                Username: <input type='text' name='Username'/>
                Password: <input type='text' name='Password'/>
                <input type='submit' value ='Log In' /> 
            </form>";
        private const string Username = "user";

        private const string Password = "user123";
        public UsersController(Request request) : base(request)
        {
        }

        public Response Login() => Html(UsersController.LoginForm);
        public Response LogInUser()
        {
            this.Request.Session.Clear();

            var usernameMatches =
                this.Request.Form["Username"] == UsersController.Username;
            var passwordMatches =
             this.Request.Form["Password"] == UsersController.Password;

            if (usernameMatches && passwordMatches)
            {
                if (!Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";
                    var cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName, Request.Session.Id);

                    return Html("<h3>Logged succesfully!</h3>", cookies);
                }
                return Html("<h3>Logged succesfully!</h3>");
            }
            return Redirect("/Login");
        }

    }
}