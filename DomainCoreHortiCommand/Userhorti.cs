using DOMAINCOREHORTICOMMAND.DOMAINOBJECT;
using System;
using System.Collections.Generic;

namespace DOMAINCOREHORTICOMMAND
{
    public class Userhorti
    {
        public Userhorti()
        {
            Client = new HashSet<Client>();
            Producer = new HashSet<Producer>();
        }

        public string DsLogin { get; set; }
        public string DsPassword { get; set; }
        public bool BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public EmailObject Email => new EmailObject(DsLogin);

        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Producer> Producer { get; set; }
    }
}
