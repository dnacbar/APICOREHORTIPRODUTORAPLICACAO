using System;
using System.Collections.Generic;

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class District
    {
        public District()
        {
            Client = new HashSet<Client>();
            Producer = new HashSet<Producer>();
        }

        public Guid IdDistrict { get; set; }
        public string DsDistrict { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Producer> Producer { get; set; }
    }
}
