using DOMAINCOREHORTICOMMAND.DOMAINOBJECT;
using System.Text.Json.Serialization;

namespace APPDTOCOREHORTICOMMAND.SIGNATURE
{
    public sealed class UserCommandSignature
    {
        public bool BoProducer { get; set; }
        public string DsLogin { get; set; }
        public string DsPassword { get; set; }

        [JsonIgnore]
        public EmailObject Email => new EmailObject(DsLogin);
    }
}
