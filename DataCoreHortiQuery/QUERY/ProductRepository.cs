using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTICOMMAND;
using DATACOREHORTIQUERY.IQUERY;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
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
                NmDiscount = x.NmDiscount,
                NmValue = x.NmValue
            },
            OrderBy: p => p.DsProduct);
        }

        public async Task<IEnumerable<Product>> ListOfProducts(ConsultProductSignature signature)
        {
            return await ListOfEntities(Where: x => signature.DsProduct == null || signature.DsProduct.Contains(x.DsProduct),
                Select: p => new Product
                {
                    IdProduct = p.IdProduct,
                    DsProduct = p.DsProduct,
                    BoStock = p.BoStock,
                    DtDiscount = p.DtDiscount,
                    NmDiscount = p.NmDiscount,
                    NmValue = p.NmValue
                },
                Page: signature.Page,
                Quantity: signature.Quantity,
                OrderBy: o => o.DsProduct);
        }

        public async Task<Product> ProductById(ConsultProductSignature signature)
        {
            return await EntityByFilter(Where: x => signature.IdProduct == x.IdProduct,
                Select: p => new Product
                {
                    IdProduct = p.IdProduct,
                    DsProduct = p.DsProduct,
                    BoStock = p.BoStock,
                    DtDiscount = p.DtDiscount,
                    NmDiscount = p.NmDiscount,
                    NmValue = p.NmValue
                });
        }
    }
}
