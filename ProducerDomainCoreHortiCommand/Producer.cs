using System;
using System.Collections.Generic;
using DominioCoreBasicoCommand;
using BasicContactDomainCoreCommand;

namespace HortiProducerDomainCoreCommand
{
    public sealed class Producer : Entity
    {
        public string DsFantasyName { get; set; }
        public Guid? IdDistrict { get; set; }
        public string DsZip { get; set; }
        public string DsAdress { get; set; }
        public string DsNumber { get; set; }
        public string DsComplement { get; set; }
        public string DsFederalInscription { get; set; }
        public string DsStateInscription { get; set; }
        public string DsMunicipalInscription { get; set; }
        public string DsDescription { get; set; }
        public IEnumerable<Phone> LstPhone { get; set; }
        public IEnumerable<Email> LstEmail { get; set; }
        public DateTime DtBirth { get; set; }
        public byte[] ImgLogo { get; set; }
        public IEnumerable<byte[]> LstProductImage { get; set; }
        public IEnumerable<Product> LstProduct { get; set; }
    }
}
