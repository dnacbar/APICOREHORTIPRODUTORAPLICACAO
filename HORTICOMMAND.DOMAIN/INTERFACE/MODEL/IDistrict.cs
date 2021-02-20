using System;
using System.Collections.Generic;

namespace HORTICOMMAND.DOMAIN.INTERFACE.MODEL
{
    public interface IDistrict
    {
        Guid IdDistrict { get; set; }
        string DsDistrict { get; set; }
        DateTime DtCreation { get; set; }
        DateTime DtAtualization { get; set; }
    }
}
