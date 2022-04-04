using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigateClass, params string[] names)
        {
            Type classType = Type.GetType(investigateClass);
            FieldInfo[] classField = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigateClass}");

            foreach (FieldInfo field in classField.Where(n => names.Contains(n.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().TrimEnd();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type typeClass = Type.GetType(className);
            FieldInfo[] fieldInfo = typeClass.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] methodInfo = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] methodNonPublic = typeClass.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);

            foreach (FieldInfo field in fieldInfo)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in methodInfo.Where(n => n.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in methodNonPublic.Where(n => n.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
