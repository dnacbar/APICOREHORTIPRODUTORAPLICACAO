using System;

namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.RESULT
{
    public interface IProducerResult : IUserResult
    {
        Guid IdProducer { get; set; }
        string DsFantasyName { get; set; }
        string DsAddress { get; set; }
        string DsNumber { get; set; }
        string DsComplement { get; set; }
        string DsFederalInscription { get; set; }
        string DsDescription { get; set; }
        string DsZip { get; set; }
    }
}
