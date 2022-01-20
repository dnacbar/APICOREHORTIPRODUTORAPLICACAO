using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public sealed class ProductResult : IProductResult
    {
        public ProductResult(Product product)
        {
            Id = product.IdProduct;
            Product = product.DsProduct;
            Value = product.NmValue;
            PercentDiscount = product.NmPercentDiscount;
            DateDiscount = product.DtDiscount;
            Unit = product.IdUnit;
            Stock = product.BoStock;
            Description = product.DsDescription;
        }

        public Guid Id { get; set; }
        public string Product { get; set; }
        public decimal Value { get; set; }
        public byte? PercentDiscount { get; set; }
        public DateTime? DateDiscount { get; set; }
        public byte? Unit { get; set; }
        public bool? Stock { get; set; }
        public string Description { get; set; }
    }
}