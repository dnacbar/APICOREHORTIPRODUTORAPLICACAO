using System;
using System.Collections.Generic;

#nullable disable

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class City
    {
        public City()
        {
            Clients = new HashSet<Client>();
            Producers = new HashSet<Producer>();
        }

        public int IdCity { get; set; }
        public string IdCountry { get; set; }
        public int IdState { get; set; }
        public string DsCity { get; set; }
        public string CdCity { get; set; }

        public virtual State Id { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
    }
}
