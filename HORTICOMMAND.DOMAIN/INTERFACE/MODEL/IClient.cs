using System;

namespace HORTICOMMAND.DOMAIN.INTERFACE.MODEL
{
    public interface IClient
    {
        Guid IdClient { get; set; }
        string DsEmail { get; set; }
        string DsClient { get; set; }
        DateTime DtCreation { get; set; }
        DateTime DtAtualization { get; set; }
        int? IdCity { get; set; }
        Guid? IdDistrict { get; set; }
        string DsPhone { get; set; }
        string DsFederalInscription { get; set; }
        string DsZip { get; set; }
        string DsAddress { get; set; }
        string DsNumber { get; set; }
        string DsComplement { get; set; }
    }
}
