using System;

namespace HORTIQUERY.DOMAIN.INTERFACES.MODEL.RESULT
{
    public interface ClientResult : IUserResult
    {
        Guid IdClient { get; set; }
    }
}
