using System;

namespace APPDTOCOREHORTICOMMAND.SIGNATURE
{
    public sealed class ProductCommandSignature
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