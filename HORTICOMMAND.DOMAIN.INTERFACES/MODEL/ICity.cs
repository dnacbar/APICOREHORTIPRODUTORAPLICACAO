using System.Collections.Generic;

namespace HORTICOMMAND.DOMAIN.INTERFACES.MODEL
{
    public interface ICity
    {
        public int IdCity { get; set; }
        public string IdCountry { get; set; }
        public int IdState { get; set; }
        public string DsCity { get; set; }
        public string CdCity { get; set; }
    }
}
