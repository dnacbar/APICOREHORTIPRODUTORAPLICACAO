using System;

namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public class UserQuerySignature
    {
        public Guid? Id { get; set; }
        public bool IsProducer { get; set; }
    }
}