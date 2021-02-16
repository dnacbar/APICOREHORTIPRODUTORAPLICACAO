using System;
using System.Collections.Generic;

namespace HORTICOMMAND.DOMAIN.INTERFACES.MODEL
{
    public interface IUnit
    {
        byte IdUnit { get; set; }
        string DsUnit { get; set; }
        string DsAbreviation { get; set; }
        DateTime DtCreation { get; set; }
        DateTime DtAtualization { get; set; }
    }
}