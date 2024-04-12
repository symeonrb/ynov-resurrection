using System.Reflection;

namespace YnovResurrection.Models;

public interface IModel
{
    public string Id { get; set; }

    public static T Clone<T>(T source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        Type type = typeof(T);
        T target = Activator.CreateInstance<T>();
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.CanRead && property.CanWrite)
            {
                object? value = property.GetValue(source);
                property.SetValue(target, value);
            }
        }

        return target;
    }
}