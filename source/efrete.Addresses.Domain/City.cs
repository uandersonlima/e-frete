using efrete.Core.DomainObjects;

namespace efrete.Addresses.Domain
{
    public class City : Entity<int>
    {
        public City(int id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}