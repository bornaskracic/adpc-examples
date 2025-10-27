using Example03.Utils;

namespace Example03.Meta
{
    
    [AttributeUsage(AttributeTargets.Property)]
    public class ComplexAttribute : Attribute
    {
        public ComplexAttribute(Type formatterType)
        {
            if (!typeof(IFormatter).IsAssignableFrom(formatterType))
                throw new ArgumentException($"{formatterType.Name} must implement IFormatter interface!");
            
            FormatterType = formatterType;
        }

        public Type FormatterType  { get; set; }
    }
}