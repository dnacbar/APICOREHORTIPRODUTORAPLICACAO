using System;
using System.Collections.Generic;

namespace HORTICOMMAND.DOMAIN.INTERFACES.MODEL
{
    public interface IUserhorti
    {
        string DsLogin { get; set; }
        string DsPassword { get; set; }
        bool BoActive { get; set; }
        DateTime DtCreation { get; set; }
        DateTime DtAtualization { get; set; }
    }
}
