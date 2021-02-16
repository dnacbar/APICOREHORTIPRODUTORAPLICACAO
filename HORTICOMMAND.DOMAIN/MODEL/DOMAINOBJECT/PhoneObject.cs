using HORTI.CORE.CROSSCUTTING.ENUM;
using HORTI.CORE.CROSSCUTTING.EXTENSION;

namespace HORTICOMMAND.DOMAIN.MODEL.DOMAINOBJECT
{
    public sealed class PhoneObject
    {
        public PhoneObject(string phoneObject, EnumCultureInfo cultureInfo = EnumCultureInfo.Brazilian)
        {
            Phone = phoneObject?.Trim();
            CultureInfo = cultureInfo;
        }

        public string Phone { get; private set; }

        public bool IsValid()
        {
            if (CultureInfo == EnumCultureInfo.Brazilian)
                return ValidateBrazilianPhone();

            return false;
        }

        private EnumCultureInfo CultureInfo { get; set; }

        private bool ValidateBrazilianPhone()
        {
            if (Phone.Length != 11)
                return false;

            if (Phone.IsOnlyNumber())
                return false;

            return true;
        }
    }
}

/*DDD 11 – São Paulo – SP
DDD 12 – São José dos Campos – SP
DDD 13 – Santos – SP
DDD 14 – Bauru – SP
DDD 15 – Sorocaba – SP
DDD 16 – Ribeirão Preto – SP
DDD 17 – São José do Rio Preto – SP
DDD 18 – Presidente Prudente – SP
DDD 19 – Campinas – SP
DDD 21 – Rio de Janeiro – RJ
DDD 22 – Campos dos Goytacazes – RJ
DDD 24 – Volta Redonda – RJ
DDD 27 – Vila Velha/Vitória – ES
DDD 28 – Cachoeiro de Itapemirim – ES
DDD 31 – Belo Horizonte – MG
DDD 32 – Juiz de Fora – MG
DDD 33 – Governador Valadares – MG
DDD 34 – Uberlândia – MG
DDD 35 – Poços de Caldas – MG
DDD 37 – Divinópolis – MG
DDD 38 – Montes Claros – MG
DDD 41 – Curitiba – PR
DDD 42 – Ponta Grossa – PR
DDD 43 – Londrina – PR
DDD 44 – Maringá – PR
DDD 45 – Foz do Iguaçú – PR
DDD 46 – Francisco Beltrão/Pato Branco – PR
DDD 47 – Joinville – SC
DDD 48 – Florianópolis – SC
DDD 49 – Chapecó – SC
DDD 51 – Porto Alegre – RS
DDD 53 – Pelotas – RS
DDD 54 – Caxias do Sul – RS
DDD 55 – Santa Maria – RS
DDD 61 – Brasília – DF
DDD 62 – Goiânia – GO
DDD 63 – Palmas – TO
DDD 64 – Rio Verde – GO
DDD 65 – Cuiabá – MT
DDD 66 – Rondonópolis – MT
DDD 67 – Campo Grande – MS
DDD 68 – Rio Branco – AC
DDD 69 – Porto Velho – RO
DDD 71 – Salvador – BA
DDD 73 – Ilhéus – BA
DDD 74 – Juazeiro – BA
DDD 75 – Feira de Santana – BA
DDD 77 – Barreiras – BA
DDD 79 – Aracaju – SE
DDD 81 – Recife – PE
DDD 82 – Maceió – AL
DDD 83 – João Pessoa – PB
DDD 84 – Natal – RN
DDD 85 – Fortaleza – CE
DDD 86 – Teresina – PI
DDD 87 – Petrolina – PE
DDD 88 – Juazeiro do Norte – CE
DDD 89 – Picos – PI
DDD 91 – Belém – PA
DDD 92 – Manaus – AM
DDD 93 – Santarém – PA
DDD 94 – Marabá – PA
DDD 95 – Boa Vista – RR
DDD 96 – Macapá – AP
DDD 97 – Coari – AM
DDD 98 – São Luís – MA
DDD 99 – Imperatriz – MA*/
