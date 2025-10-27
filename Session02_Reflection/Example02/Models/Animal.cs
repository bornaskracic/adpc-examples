namespace Example02.Models
{
    public class Animal
    {
        private static int _seed = 0;

        public Animal(string canonicalName, string phylum)
        {
            Id = ++_seed;
            CanonicalName = canonicalName;
            Phylum = phylum;
        }

        public int Id { get; set; }
        public string CanonicalName { get; set; }
        public string Phylum { get; set; }

        public override string ToString()
            => $"{Id} | {CanonicalName}, {Phylum}";
    }
}