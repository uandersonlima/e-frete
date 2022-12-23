namespace efrete.Addresses.Domain
{
    public class AddressService : IAddressService
    {
        public List<(string, string)> UFStateList()
        {
            return UFState.GetAll<UFState>().Select(uS => (uS.Id, uS.Name)).ToList();
        }
    }
}