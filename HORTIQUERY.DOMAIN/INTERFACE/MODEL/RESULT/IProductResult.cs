using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IProductResult
    {
        Guid Id { get; set; }
        string Product { get; set; }
        decimal Value { get; set; }
        byte? PercentDiscount { get; set; }
        DateTime? DateDiscount { get; set; }
        byte? Unit { get; set; }
        bool? Stock { get; set; }
    }
}
