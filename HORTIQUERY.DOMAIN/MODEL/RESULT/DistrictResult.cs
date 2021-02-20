using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public class DistrictResult : IDistrictResult
    {
        public Guid Id { get; set; }
        public string District { get; set; }
    }
}
