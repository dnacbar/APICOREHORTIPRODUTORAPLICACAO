using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class ClientResult : UserResult, IClientResult
    {
        public Guid Id { get; set; }
    }
}
