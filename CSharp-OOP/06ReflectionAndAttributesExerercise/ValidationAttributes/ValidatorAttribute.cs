using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfo = obj.GetType().GetProperties();

            foreach (var prop in propertyInfo)
            {
                var attributes = prop.GetCustomAttributes().Where(t => t.GetType().IsSubclassOf(typeof(MyValidationAttribute))).Cast<MyValidationAttribute>().ToArray();
                foreach (var item in attributes)
                {
                    bool isValid = item.IsValid(prop.GetValue(obj));
                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
