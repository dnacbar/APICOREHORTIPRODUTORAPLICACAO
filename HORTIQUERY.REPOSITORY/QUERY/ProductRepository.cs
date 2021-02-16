using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.REPOSITORY;
using DATACOREHORTIQUERY.IQUERY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public class ProductRepository : _BaseRepository<IProduct>, IProductRepository
    {
        public ProductRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task<IEnumerable<IProduct>> FullListOfProducts()
        {
            return await FullListOfEntities(Select: x => new IProduct
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

        public async Task<IEnumerable<IProduct>> ListOfProducts(ConsultProductSignature signature)
        {
            return await ListOfEntities(Where: x => signature.DsProduct == null || signature.DsProduct.Contains(x.DsProduct),
                Select: p => new IProduct
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

        public async Task<IProduct> ProductById(ConsultProductSignature signature)
        {
            return await EntityByFilter(Where: x => signature.IdProduct == x.IdProduct,
                Select: p => new IProduct
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
