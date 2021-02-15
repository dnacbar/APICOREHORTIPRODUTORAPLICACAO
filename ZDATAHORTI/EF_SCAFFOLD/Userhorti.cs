using System;
using System.Collections.Generic;

#nullable disable

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class Userhorti
    {
        public Userhorti()
        {
            Clients = new HashSet<Client>();
            Producers = new HashSet<Producer>();
        }

        public string DsLogin { get; set; }
        public string DsPassword { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
    }
}
