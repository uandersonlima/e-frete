using efrete.Addresses.Domain;

namespace efrete.Addresses.Data
{
    public class AddressContext
    {
        public AddressContext(string path)
        {
            _path = path;
            Validate();
        }

        private readonly string _path;
        public bool Succeeded { get; private set; }
        public List<string> Errors { get; private set; } = new List<string>();

        public IReadOnlyCollection<Address> Addresses => Succeeded
                                                      ? GetAddresses().AsReadOnly()
                                                      : throw new ArgumentException("Não foi possível estabelecer conexão com o banco");

        private void Validate()
        {
            if (string.IsNullOrEmpty(_path))
            {
                Errors.Add("Caminho inválido");
                Succeeded = false;
                return;
            }

            if (!File.Exists(_path))
            {
                Errors.Add("Não foi possível localizar o arquivo no caminho específicado");
                Succeeded = false;
                return;
            }
            Succeeded = true;
        }

        private List<Address> GetAddresses()
        {
            var addressesList = new List<Address>();
            using (StreamReader sr = new StreamReader(_path))
            {
                var line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    var addressProperties = line.Split('@');
                    var uFState = UFState.GetAll<UFState>().Where(uS => uS.Id == addressProperties[1]).FirstOrDefault();

                    Address address = new(Int32.Parse(addressProperties[0]),
                          uFState ?? new UFState("XX", "XXXXXXX"),
                          new City(Int32.Parse(addressProperties[0]), addressProperties[2]),
                            addressProperties[4],
                             addressProperties[5],
                             addressProperties[3]);
                    addressesList.Add(address);
                }
            }
            return addressesList;
        }
    }
}