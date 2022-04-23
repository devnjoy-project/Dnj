namespace Microsoft.Extensions.DependencyInjection
{
    public static class ObjectExtension
    {
        public static T GetAttributeFromPropertyOfName<T>(this object obj, string propName) where T : Attribute 
        {
            
            if (obj == null) throw new ArgumentException(nameof(obj));
            if (propName == null) throw new ArgumentNullException(nameof(propName));

                var attrType = typeof(T);
            var prop = obj.GetType().GetProperty(propName);
            if (prop == null) return default(T);
            return prop.GetCustomAttributes(attrType, false).FirstOrDefault() as T;

        }
    }
}