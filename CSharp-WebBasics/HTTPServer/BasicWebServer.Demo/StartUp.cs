﻿using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using BasicWebServer.Server.Routing;
using BasicWebServer.Demo.Controllers;

namespace BasicWebServer.Demo
{
    public class Startup
    {



        public static async Task Main() => await new HttpServer(routes => routes
                                                                .MapGet<HomeController>("/", c => c.Index())
                                                                .MapGet<HomeController>("/Redirect", c => c.Redirect())
                                                                .MapGet<HomeController>("/HTML", c => c.Html())
                                                                //.MapPost<HomeController>("/HTML", c => c.HtmlPostForm())
                                                                .MapGet<HomeController>("/Content", c => c.Content())
                                                                .MapGet<HomeController>("/Cookies", c => c.Cookies())
                                                                .MapGet<HomeController>("/Session", c => c.Session())
                                                                .MapGet<UsersController>("/Login", c => c.Login())
                                                                .MapPost<UsersController>("/Login", c => c.LogInUser())
                                                                .MapGet<UsersController>("/Logout", c => c.Logout())
                                                                .MapGet<UsersController>("/UserProfile", c => c.GetUserData()))
                                                                .Start();


       




    }

}