using System;
using System.Linq;
using System.Text;
using System.Reflection;

public class Spy
{
    public string StealFieldInfo(string className, params string[] classFields)
    {
        Type type = Type.GetType(className);

        FieldInfo[] fields = type.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Static);

        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(type, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        var filteredFields = fields
            .Where(f => classFields.Contains(f.Name))
            .ToList();

        foreach (FieldInfo field in filteredFields)
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAccessModifiers(string className)
    {
        Type type = Type.GetType(className);

        FieldInfo[] fields = type.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.Static);

        MethodInfo[] classPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        MethodInfo[] filteredNonPublicMethods = classNonPublicMethods
            .Where(m => m.Name.StartsWith("get"))
            .ToArray();

        foreach (MethodInfo method in filteredNonPublicMethods)
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        var filteredPublicMethods = classPublicMethods
            .Where(m => m.Name.StartsWith("set"))
            .ToList();

        foreach (MethodInfo method in filteredPublicMethods)
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {

        Type type = Type.GetType(className);
        string baseClassName = type.BaseType.Name;
        MethodInfo[] classPrivateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {baseClassName}");

        foreach (var privateMethod in classPrivateMethods)
        {
            sb.AppendLine(privateMethod.Name.ToString());
        }
        return sb.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type type = Type.GetType(className);
        MethodInfo[] classMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        foreach (var method in classMethods)
        {
            if (method.Name.Contains("get"))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            } 
            else if (method.Name.Contains("set"))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}