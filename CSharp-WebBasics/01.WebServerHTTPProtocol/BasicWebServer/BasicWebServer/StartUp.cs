using BasicWebServer.Demo;
using BasicWebServer.Demo.Responses;
using BasicWebServer.Server;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer
{
    public class StartUp
    {
        static void Main(string[] args) => new HttpServer(routes => routes
                                                                     .MapGet("/", new TextResponse("Hello from server!"))
                                                                     .MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
                                                                     .MapGet("/Redirect", new RedirectResponse("https://softuni.org/")))
                                                                     .Start();
                                                             
    }
}
