using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.REPOSITORY
{
    public class DistrictRepository : _BaseRepository<District>, IDiscrictRepository
    {
        public DistrictRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<District> DistrictByIdOrName(IDistrictQuerySignature signature)
        {
            return await EntityByFilter(Where: x => x.IdDistrict == signature.Id || x.DsDistrict == signature.District,
                                        Select: p => new District
                                        {
                                            IdDistrict = p.IdDistrict,
                                            DsDistrict = p.DsDistrict,
                                            DtCreation = p.DtCreation,
                                            DtAtualization = p.DtAtualization
                                        });
        }

        public async Task<IEnumerable<District>> FullListOfDistricts()
        {
            return await FullListOfEntities(Select: x => new District
            {
                IdDistrict = x.IdDistrict,
                DsDistrict = x.DsDistrict,
                DtCreation = x.DtCreation,
                DtAtualization = x.DtAtualization
            },
            OrderBy: p => p.DsDistrict);
        }

        public async Task<IEnumerable<District>> ListOfDistricts(IDistrictQuerySignature signature)
        {
            return await ListOfEntities(Where: x => signature.District == null || x.DsDistrict.Contains(signature.District),
            Select: p => new District
            {
                IdDistrict = p.IdDistrict,
                DsDistrict = p.DsDistrict,
                DtCreation = p.DtCreation,
                DtAtualization = p.DtAtualization
            },
            Page: signature.Page,
            Quantity: signature.Quantity,
            OrderBy: o => o.DsDistrict);
        }
    }
}
