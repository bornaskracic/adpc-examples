namespace Example01.Models
{
    class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime Timestamp { get; set; }


        public override string ToString()
            => $"{Id};{Name};{Price};{Timestamp}";

        public void Save() => Console.WriteLine(ToString());
    }    
}