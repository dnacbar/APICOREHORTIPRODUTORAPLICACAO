using DOMAINCOREHORTICOMMAND.DOMAINOBJECT;
using System.Text.Json.Serialization;

namespace APPDTOCOREHORTICOMMAND.SIGNATURE
{
    public sealed class ProducerCommandSignature
    {
        public string DsProducer { get; set; }
        public string DsFantasyName { get; set; }
        public int IdCity { get; set; }
        public int IdDistrict { get; set; }
        public string DsZip { get; set; }
        public string DsAddress { get; set; }
        public string DsNumber { get; set; }
        public string DsComplement { get; set; }
        public string DsFederalInscription { get; set; }
        public string DsStateInscription { get; set; }
        public string DsMunicipalInscription { get; set; }
        public string DsDescription { get; set; }
        public string DsPhone { get; set; }

        [JsonIgnore]
        public PhoneObject Phone => new PhoneObject(DsPhone);
    }
}
