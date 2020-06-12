using System;
using System.Collections.Generic;

namespace DOMAINCOREHORTICOMMAND
{
    public class District
    {
        public District()
        {
            Producer = new HashSet<Producer>();
            Client = new HashSet<Client>();
        }

        public Guid IdDistrict { get; set; }
        public string DsDistrict { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Producer> Producer { get; set; }
    }
}
