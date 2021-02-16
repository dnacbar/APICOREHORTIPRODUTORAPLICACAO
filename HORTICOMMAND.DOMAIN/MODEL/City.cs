using HORTICOMMAND.DOMAIN.INTERFACES.MODEL;
using System.Collections.Generic;

namespace HORTICOMMAND.DOMAIN.MODEL
{
    public class City : ICity
    {
        public City()
        {
            Client = new HashSet<Client>();
            Producer = new HashSet<Producer>();
        }

        public int IdCity { get; set; }
        public string IdCountry { get; set; }
        public int IdState { get; set; }
        public string DsCity { get; set; }
        public string CdCity { get; set; }

        public virtual State Id { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Producer> Producer { get; set; }
    }
}
