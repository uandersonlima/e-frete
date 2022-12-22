namespace efrete.Addresses.Application.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel(UFStateViewModel uFState, /*string cityName,*/ string neighborhoodName, string streetName, string zipCode)
        {
            UFState = uFState;
            //CityName = cityName;
            NeighborhoodName = neighborhoodName;
            StreetName = streetName;
            ZipCode = zipCode;
        }

        public UFStateViewModel UFState { get; set; }
        public string CityName { get; private set; }
        public string NeighborhoodName { get; private set; }
        public string StreetName { get; private set; }
        public string ZipCode { get; private set; } 
    }
}