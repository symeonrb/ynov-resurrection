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

        var type = typeof(T);
        var target = Activator.CreateInstance<T>();
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            if (!property.CanRead || !property.CanWrite) continue;
            var value = property.GetValue(source);
            property.SetValue(target, value);
        }

        return target;
    }
}
