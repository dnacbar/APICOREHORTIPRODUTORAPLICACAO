using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IProducerResult : IUserResult
    {
        Guid Id { get; set; }
        string FantasyName { get; set; }
        string FederalInscription { get; set; }
        string Description { get; set; }
    }
}
