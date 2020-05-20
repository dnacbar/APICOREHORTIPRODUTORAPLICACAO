using System;

namespace APPDTOCOREHORTIQUERY.RESULT
{
    public sealed class ProducerResult : UserResult
    {
        public Guid IdProducer { get; set; }
        public string DsFantasyName { get; set; }
        public string DsAddress { get; set; }
        public string DsNumber { get; set; }
        public string DsComplement { get; set; }
        public string DsFederalInscription { get; set; }
        public string DsDescription { get; set; }
        public string DsZip { get; set; }
    }
}
