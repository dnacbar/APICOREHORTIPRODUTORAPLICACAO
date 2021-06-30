using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;
using System.Collections.Generic;

namespace HORTICOMMAND.DOMAIN.MODEL
{
    public class Unit
    {
        public Unit()
        {
            Product = new HashSet<Product>();
        }

        public Unit(IUnitCommandSignature signature)
        {
            Product = new HashSet<Product>();

            IdUnit = signature.Id.GetValueOrDefault();
            DsUnit = signature.Unit;
            DsAbreviation = signature.Abreviation;
            DtAtualization = DateTime.Now;
        }

        public byte IdUnit { get; set; }
        public string DsUnit { get; set; }
        public string DsAbreviation { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}