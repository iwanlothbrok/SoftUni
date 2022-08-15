using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Routing
{
    public static class RoutingTableExtensions
    {
        private static TController CreateController<TController>(Request request) =>
                (TController)Activator.CreateInstance(typeof(TController), new[] { request });
        public static IRoutingTable MapGet<TController>(
        this IRoutingTable routingTable,
        string path,
        Func<TController, Response> controllerFunc) where TController : Controller
        => routingTable.MapGet(path, request =>
        controllerFunc(CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(
       this IRoutingTable routingTable,
       string path,
       Func<TController, Response> controllerFunc) where TController : Controller
       => routingTable.MapPost(path, request =>
       controllerFunc(CreateController<TController>(request)));
    }
}