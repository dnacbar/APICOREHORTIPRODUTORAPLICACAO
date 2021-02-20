using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IClientResult : IUserResult
    {
        Guid Id { get; set; }
    }
}
