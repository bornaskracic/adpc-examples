namespace Example03.Meta
{

    //
    // Everything before the string Attribute in the class name will be taken as the name of the attribute when using it
    // In this example: [Simple]Attribute
    //
    [AttributeUsage(AttributeTargets.Property)]
    public class SimpleAttribute : Attribute
    {
        public string Name { get; set; }

        public SimpleAttribute(string name)
        {
            Name = name;
        }     
    }
}