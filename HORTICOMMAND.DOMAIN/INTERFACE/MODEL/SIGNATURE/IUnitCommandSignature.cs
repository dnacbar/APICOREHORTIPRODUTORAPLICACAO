using System;

namespace HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE
{
    public interface IUnitCommandSignature
    {
        byte? Id { get; set; }
        string Unit { get; set; }
        string Abreviation { get; set; }
        DateTime DateCreation { get; set; }
        DateTime DateAtualization { get; set; }
    }
}
