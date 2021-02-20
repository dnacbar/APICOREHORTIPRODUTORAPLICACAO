using System.Collections.Generic;

namespace HORTICOMMAND.DOMAIN.INTERFACE.MODEL
{
    public interface IState
    {
        string IdCountry { get; set; }
        int IdState { get; set; }
        string DsState { get; set; }
        string DsUf { get; set; }
    }
}
