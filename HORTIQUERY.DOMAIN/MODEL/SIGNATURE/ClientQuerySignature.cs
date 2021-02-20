using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public class ClientQuerySignature : _BaseQuantitySignature, IClientQuerySignature
    {
        public Guid? Id { get; set; }
        public string Client { get; set; }
        public string Email { get; set; }
    }
}
