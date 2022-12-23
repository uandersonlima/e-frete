using efrete.Addresses.Domain;

namespace efrete.Addresses.Data
{
    public class AddressContext
    {
        public AddressContext(string mainPath, string sCPath)
        {
            _mainPath = mainPath;
            _sCPath = sCPath;
            Validate();
        }

        private readonly string _mainPath;
        private readonly string _sCPath;
        public bool Succeeded { get; private set; }
        public List<string> Errors { get; private set; } = new List<string>();

        public IReadOnlyCollection<Address> Addresses => Succeeded
                                                      ? GetAddresses().AsReadOnly()
                                                      : throw new ArgumentException("Não foi possível estabelecer conexão com o banco");

        private void Validate()
        {
            if (string.IsNullOrEmpty(_mainPath) || string.IsNullOrEmpty(_sCPath))
            {
                Errors.Add("Caminho inválido");
                Succeeded = false;
                return;
            }

            if (!File.Exists(_mainPath) || !File.Exists(_sCPath))
            {
                Errors.Add("Não foi possível localizar o arquivo no caminho específicado");
                Succeeded = false;
                return;
            }
            Succeeded = true;
        }

        private List<Address> GetAddresses()
        {
            /*Join LOG_LOCALIDADE.txt with LOG_LOGRADOURO_SC.txt*/
            var listSC = GetAddressWithSCLocationProperties();
            var listGE = GetAddressWithGenericLocationProperties();

            var addressesList = from addressSC in listSC
                                join addressGE in listGE
                                     on addressSC.CityCode equals addressGE.CityCode
                                into temp
                                from aux in temp.DefaultIfEmpty()
                                select new Address(addressSC.ZipCode
                                                , aux.Uf ?? addressSC.Uf
                                                , null, aux.CityCode ?? addressSC.CityCode
                                                , aux.CityName, null
                                                , addressSC.StreetCode, addressSC.StreetName);

            /*---------------------------------------------------*/
            var i = addressesList.Count();
            return addressesList.ToList();
        }


        private List<Address> GetAddressWithGenericLocationProperties()
        {
            var addressesList = new List<Address>();

            /*Reading LOG_LOCALIDADE.txt */
            using (StreamReader mainSr = new StreamReader(_mainPath))
            {
                var locality = string.Empty;
                while ((locality = mainSr.ReadLine()) is not null)
                {
                    var localityProperties = locality.Split('@');

                    //localityProperties.
                    Address address = new(null, localityProperties[1],
                                          null, localityProperties[0],
                                          localityProperties[2], null,
                                          null, null);

                    addressesList.Add(address);
                }
            }
            return addressesList;
        }

        private List<Address> GetAddressWithSCLocationProperties()
        {
            var addressesList = new List<Address>();

            /*Reading LOG_LOGRADOURO_SC.txt */
            using (StreamReader SCSr = new StreamReader(_sCPath))
            {
                var localeAddOns = string.Empty;

                while ((localeAddOns = SCSr.ReadLine()) is not null)
                {

                    var localeAddOnsProperties = localeAddOns.Split('@');

                    //localeAddOnsProperties
                    Address address = new(UInt32.Parse(localeAddOnsProperties[7]), localeAddOnsProperties[1],
                                          null, localeAddOnsProperties[2],
                                          null, null,
                                          localeAddOnsProperties[0], localeAddOnsProperties[10]);

                    addressesList.Add(address);
                }
            }

            return addressesList;
        }

    }
}