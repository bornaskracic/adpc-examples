using Example03.Meta;
using Example03.Utils;

namespace Example03.Models
{
    public class Entity
    {
        [Simple("identifier")]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        [Complex(typeof(ISOFormatter))]
        public DateTime Timestamp { get; set; }


        public override string ToString()
            => $"{Id};{Name};{Price};{Timestamp}";

        public void Save() => Console.WriteLine(ToString());
    }
}