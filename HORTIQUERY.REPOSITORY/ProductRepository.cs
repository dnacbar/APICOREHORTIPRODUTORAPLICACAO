using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.REPOSITORY
{
    public class ProductRepository : _BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task<IEnumerable<Product>> FullListOfProducts()
        {
            return await FullListOfEntities(Select: x => new Product
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

        public async Task<IEnumerable<Product>> ListOfProducts(IProductQuerySignature signature)
        {
            return await ListOfEntities(Where: x => signature.Product == null || signature.Product.Contains(x.DsProduct),
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

        public async Task<Product> ProductById(IProductQuerySignature signature)
        {
            return await EntityByFilter(Where: x => signature.Id == x.IdProduct,
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
