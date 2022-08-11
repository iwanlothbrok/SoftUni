using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Responses
{
    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';
        public ViewResponse(string viewName, string controllerName, object model = null) : base("", ContentType.Html)
        {
            if (viewName.Contains(PathSeparator) == false)
            {
                viewName = controllerName + PathSeparator + viewName;
            }
            var viewPath = Path.GetFullPath(
                $"./Views/" +
                viewName.TrimStart(PathSeparator) +
                ".cshtml");


            var viewContent = File.ReadAllText(viewPath);
            if (model != null)
            {
                viewContent = PopulateModel(viewContent, model);
            }

            Body = viewContent;
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model.
                        GetType()
                        .GetProperties()
                        .Select(p => new
                        {
                            p.Name,
                            Value = p.GetValue(model)
                        });
            foreach (var entry in data)
            {
                const string openingBraces = "{{";
                const string closingBraces = "}}";

                viewContent = viewContent.Replace(
                    $"{openingBraces}{entry.Name}{closingBraces}", entry.Value.ToString());
            }
            return viewContent;
        }
    }
}
