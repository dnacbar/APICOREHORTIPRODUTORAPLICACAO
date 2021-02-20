using System;

namespace HORTICOMMAND.DOMAIN.INTERFACE.MODEL
{
    public interface IProducer
    {
        Guid IdProducer { get; set; }
        string DsProducer { get; set; }
        DateTime DtCreation { get; set; }
        DateTime DtAtualization { get; set; }
        string DsFantasyname { get; set; }
        int? IdCity { get; set; }
        Guid? IdDistrict { get; set; }
        string DsZip { get; set; }
        string DsAddress { get; set; }
        string DsNumber { get; set; }
        string DsComplement { get; set; }
        string DsFederalInscription { get; set; }
        string DsStateInscription { get; set; }
        string DsMunicipalInscription { get; set; }
        string DsDescription { get; set; }
        string DsEmail { get; set; }
        string DsPhone { get; set; }
    }
}
