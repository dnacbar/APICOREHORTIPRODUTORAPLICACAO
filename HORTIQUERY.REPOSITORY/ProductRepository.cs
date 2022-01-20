using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.REPOSITORY
{
    public class ProductRepository : _BaseEFQueryRepository<Product>, IProductRepository
    {
        public ProductRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public Task<List<Product>> FullListOfProducts()
        {
            return FullListOfEntity(Select: x => new Product
            {
                IdProduct = x.IdProduct,
                DsProduct = x.DsProduct,
                BoStock = x.BoStock,
                DtDiscount = x.DtDiscount,
                NmPercentDiscount = x.NmPercentDiscount,
                NmValue = x.NmValue
            },
            OrderBy: p => p.DsProduct);
        }

        public Task<List<Product>> ListOfProducts(IProductQuerySignature signature)
        {
            return ListOfEntity(Where: x => signature.Product == null || signature.Product.Contains(x.DsProduct),
                Select: p => new Product
                {
                    IdProduct = p.IdProduct,
                    DsProduct = p.DsProduct,
                    BoStock = p.BoStock,
                    DtDiscount = p.DtDiscount,
                    NmPercentDiscount = p.NmPercentDiscount,
                    NmValue = p.NmValue
                },
                Page: signature.Page,
                Quantity: signature.Quantity,
                OrderBy: o => o.DsProduct);
        }

        public Task<Product> ProductByIdOrName(IProductQuerySignature signature)
        {
            return EntityByFilter(Where: x => signature.Id == x.IdProduct || signature.Product == x.DsProduct,
                Select: p => new Product
                {
                    IdProduct = p.IdProduct,
                    DsProduct = p.DsProduct,
                    BoStock = p.BoStock,
                    DtDiscount = p.DtDiscount,
                    NmPercentDiscount = p.NmPercentDiscount,
                    NmValue = p.NmValue
                });
        }
    }
}
