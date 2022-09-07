using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Warehouse.ModelBinders
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
           if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }
}
