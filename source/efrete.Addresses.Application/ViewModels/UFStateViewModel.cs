namespace efrete.Addresses.Application.ViewModels
{
    public class UFStateViewModel
    {
        public UFStateViewModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
    }
}