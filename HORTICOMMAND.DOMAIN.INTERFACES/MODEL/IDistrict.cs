using System;
using System.Collections.Generic;

namespace HORTICOMMAND.DOMAIN.INTERFACES.MODEL
{
    public interface IDistrict
    {
        Guid IdDistrict { get; set; }
        string DsDistrict { get; set; }
        DateTime DtCreation { get; set; }
        DateTime DtAtualization { get; set; }
    }
}
