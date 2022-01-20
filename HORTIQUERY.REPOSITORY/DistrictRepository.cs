using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.REPOSITORY
{
    public class DistrictRepository : _BaseEFQueryRepository<District>, IDiscrictRepository
    {
        public DistrictRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public Task<District> DistrictByIdOrName(IDistrictQuerySignature signature)
        {
            return EntityByFilter(Where: x => x.IdDistrict == signature.Id || x.DsDistrict == signature.District,
                                        Select: p => new District
                                        {
                                            IdDistrict = p.IdDistrict,
                                            DsDistrict = p.DsDistrict,
                                            DtCreation = p.DtCreation,
                                            DtAtualization = p.DtAtualization
                                        });
        }

        public Task<List<District>> FullListOfDistricts()
        {
            return FullListOfEntity(Select: x => new District
            {
                IdDistrict = x.IdDistrict,
                DsDistrict = x.DsDistrict,
                DtCreation = x.DtCreation,
                DtAtualization = x.DtAtualization
            },
            OrderBy: p => p.DsDistrict);
        }

        public Task<List<District>> ListOfDistricts(IDistrictQuerySignature signature)
        {
            return ListOfEntity(Where: x => signature.District == null || x.DsDistrict.Contains(signature.District),
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
