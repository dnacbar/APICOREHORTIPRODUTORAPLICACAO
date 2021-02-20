using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL.SIGNATURE
{
    public sealed class ProductCommandSignature : IProductCommandSignature
    {
        public Guid? Id { get; set; }
        public string Product { get; set; }
        public decimal Value { get; set; }
        public byte? Discount { get; set; }
        public DateTime? DateDiscount { get; set; }
        public byte? Unit { get; set; }
        public bool? Stock { get; set; }
    }
}