using efrete.Core.Helpers;

namespace efrete.Addresses.Domain
{
    public class UFState : Enumeration<string>
    {
        public UFState(string id, string name) : base(id, name)
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Rondonia;
            yield return Acre;
            yield return Amazonas;
            yield return Roraima;
            yield return Para;
            yield return Amapa;
            yield return Tocantins;
            yield return Maranhao;
            yield return Piaui;
            yield return Ceara;
            yield return RioGrandeDoNorte;
            yield return Paraiba;
            yield return Pernambuco;
            yield return Alagoas;
            yield return Sergipe;
            yield return Bahia;
            yield return MinasGerais;
            yield return EspiritoSanto;
            yield return RioDeJaneiro;
            yield return SaoPaulo;
            yield return Parana;
            yield return SantaCatarina;
            yield return RioGrandeDoSul;
            yield return MatoGrossoDoSul;
            yield return MatoGrosso;
            yield return Goias;
            yield return DistritoFederal;
        }


        public static UFState Rondonia = new("RO", "Rondônia");
        public static UFState Acre = new("AC", "Acre");
        public static UFState Amazonas = new("AM", "Amazonas");
        public static UFState Roraima = new("RR", "Roraima");
        public static UFState Para = new("PA", "Pará");
        public static UFState Amapa = new("AP", "Amapá");
        public static UFState Tocantins = new("TO", "Tocantins");
        public static UFState Maranhao = new("MA", "Maranhão");
        public static UFState Piaui = new("PI", "Pauí");
        public static UFState Ceara = new("CE", "Ceará");
        public static UFState RioGrandeDoNorte = new("RN", "Rio Grande Do Norte");
        public static UFState Paraiba = new("PB", "Paraíba");
        public static UFState Pernambuco = new("PE", "Pernambuco");
        public static UFState Alagoas = new("AL", "Alagoas");
        public static UFState Sergipe = new("SE", "Sergipe");
        public static UFState Bahia = new("BA", "Bahia");
        public static UFState MinasGerais = new("MG", "Minas Gerais");
        public static UFState EspiritoSanto = new("ES", "Espirito Santo");
        public static UFState RioDeJaneiro = new("RJ", "Rio De Janeiro");
        public static UFState SaoPaulo = new("SP", "São Paulo");
        public static UFState Parana = new("PR", "Paraná");
        public static UFState SantaCatarina = new("SC", "Santa Catarina");
        public static UFState RioGrandeDoSul = new("RS", "Rio Grande Do Sul");
        public static UFState MatoGrossoDoSul = new("MS", "Mato Grosso Do Sul");
        public static UFState MatoGrosso = new("MT", "Mato Grosso");
        public static UFState Goias = new("GO", "Goiás");
        public static UFState DistritoFederal = new("DF", "Distrito Federal");
    }
}