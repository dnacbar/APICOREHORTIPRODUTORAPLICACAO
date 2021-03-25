﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class Producer
    {
        public Guid IdProducer { get; set; }
        public string DsEmail { get; set; }
        public string DsProducer { get; set; }
        public string DsFantasyname { get; set; }
        public int? IdCity { get; set; }
        public Guid? IdDistrict { get; set; }
        public string DsZip { get; set; }
        public string DsAddress { get; set; }
        public string DsNumber { get; set; }
        public string DsComplement { get; set; }
        public string DsFederalinscription { get; set; }
        public string DsStateinscription { get; set; }
        public string DsMunicipalinscription { get; set; }
        public string DsDescription { get; set; }
        public string DsPhone { get; set; }

        public virtual City IdCityNavigation { get; set; }
        public virtual District IdDistrictNavigation { get; set; }
    }
}
