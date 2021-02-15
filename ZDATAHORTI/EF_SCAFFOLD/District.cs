using System;
using System.Collections.Generic;

#nullable disable

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class District
    {
        public District()
        {
            Clients = new HashSet<Client>();
            Producers = new HashSet<Producer>();
        }

        public Guid IdDistrict { get; set; }
        public string DsDistrict { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
    }
}
