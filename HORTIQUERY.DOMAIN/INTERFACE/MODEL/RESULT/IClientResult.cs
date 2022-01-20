using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IClientResult : IUserResult, IResult
    {
        Guid Id { get; set; }
    }
}
