using System;

namespace HORTICOMMAND.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IProductCommandSignature
    {
        Guid? Id { get; set; }
        string Product { get; set; }
        decimal Value { get; set; }
        byte? Discount { get; set; }
        DateTime? DateDiscount { get; set; }
        byte? Unit { get; set; }
        bool? Stock { get; set; }
    }
}