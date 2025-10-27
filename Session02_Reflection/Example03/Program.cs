using System.Reflection;
using Example03.Meta;
using Example03.Models;
using Example03.Utils;


var entityType = typeof(Entity);

foreach (PropertyInfo prop in entityType.GetProperties())
{
    if (prop.GetCustomAttribute<SimpleAttribute>() is SimpleAttribute attr) 
        Console.WriteLine($"{prop.Name} renamed to: {attr.Name}");
    else
        Console.WriteLine($"{prop.Name}");
    
}

Entity entity = new() { Id = 1, Name = "Test", Price = 25, Timestamp = DateTime.Now };

foreach (PropertyInfo prop in entityType.GetProperties())
{
    if (prop.GetCustomAttribute<ComplexAttribute>() is ComplexAttribute attr)
    {
        var formatter = Activator.CreateInstance(attr.FormatterType) as IFormatter;
        if (prop.PropertyType == typeof(DateTime))
        {
            var value = (DateTime)prop.GetValue(entity);
            string formatted = formatter!.Format(value);
            System.Console.WriteLine($"formatted: {formatted}");
        }
        
    }
       
    
}
