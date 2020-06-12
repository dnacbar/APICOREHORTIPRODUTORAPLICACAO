using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTICOMMAND;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public class DistrictRepository : _BaseRepository<District>, IDiscrictRepository
    {
        public DistrictRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<District> DistrictByIdOrName(ConsultDistrictSignature signature)
        {
            return await EntityByFilter(Where: x => x.IdDistrict == signature.IdDistrict || x.DsDistrict == signature.DsDistrict,
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

        public async Task<IEnumerable<District>> ListOfDistricts(ConsultDistrictSignature signature)
        {
            return await ListOfEntities(Where: x => signature.DsDistrict == null || x.DsDistrict.Contains(signature.DsDistrict),
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
