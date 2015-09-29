namespace StyletDependentProperty
{
    using System;
    using System.Linq;

    internal static class Extensions
    {
        public static string GetFriendlyName(this Type type)
        {
            var typeArgs = type.GetGenericArguments();
            if (!typeArgs.Any())
                return type.Name;

            var genericArgString = string.Join(", ", typeArgs.Select(t => t.GetFriendlyName()));
            var typeName = type.Name.Substring(0, type.Name.IndexOf("`", StringComparison.InvariantCulture));

            return $"{typeName}<{genericArgString}>";
        }
    }
}