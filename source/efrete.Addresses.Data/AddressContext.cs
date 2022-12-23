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
            /*FULL JOIN LOG_LOCALIDADE.txt with LOG_LOGRADOURO_SC.txt*/
            var listSC = GetAddressWithSCLocationProperties();
            var listGE = GetAddressWithGenericLocationProperties();

            var leftJoin = from addressSC in listSC
                           join addressGE in listGE
                                on addressSC.CityCode equals addressGE.CityCode
                           into temp
                           from aux in temp.DefaultIfEmpty()
                           select new Address(addressSC.ZipCode ?? aux.ZipCode
                                           , addressSC.Uf ?? aux.Uf
                                           , null
                                           , addressSC.CityCode ?? aux.CityCode
                                           , addressSC.CityName ?? aux.CityName
                                           , null
                                           , addressSC.StreetCode ?? aux.StreetCode
                                           , addressSC.StreetName ?? aux.StreetName);
                           
            // var rightJoin = from addressGE in listGE
            //                 join addressSC in listSC
            //                      on  addressGE.ZipCode equals addressSC.ZipCode
            //                 into temp
            //                 from aux in temp.DefaultIfEmpty()
            //                 select new Address(addressGE.ZipCode ?? aux.ZipCode
            //                                , addressGE.Uf ?? aux.Uf
            //                                , null
            //                                , addressGE.CityCode ?? aux.CityCode
            //                                , addressGE.CityName ?? aux.CityName
            //                                , null
            //                                , addressGE.StreetCode ?? aux.StreetCode
            //                                , addressGE.StreetName ?? aux.StreetName);

            // rightJoin.Count();
            // leftJoin.Count();
            // /*---------------------------------------------------*/
            // var addressesList = rightJoin.Union(leftJoin);

            return leftJoin.ToList();
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