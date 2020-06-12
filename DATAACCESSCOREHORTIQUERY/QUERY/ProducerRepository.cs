using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTICOMMAND;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class ProducerRepository : _BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<IEnumerable<Producer>> FullListOfProducers()
        {
            return await FullListOfEntities(Select: x => new Producer
            {
                IdProducer = x.IdProducer,
                DsProducer = x.DsProducer,
                DsFantasyname = x.DsFantasyname,
                DsEmail = x.DsEmail,
                DsPhone = x.DsPhone,
                DsAddress = x.DsAddress,
                DsZip = x.DsZip,
                DsComplement = x.DsComplement,
                DsNumber = x.DsNumber,
                DsDescription = x.DsDescription,
                DsFederalInscription = x.DsFederalInscription,
                DsStateInscription = x.DsStateInscription,
                DsMunicipalInscription = x.DsMunicipalInscription,
                IdCityNavigation = new City
                {
                    IdCity = x.IdCityNavigation.IdCity,
                    DsCity = x.IdCityNavigation.DsCity,
                    Id = new State
                    {
                        IdState = x.IdCityNavigation.Id.IdState,
                        DsState = x.IdCityNavigation.Id.DsState,
                        DsUf = x.IdCityNavigation.Id.DsUf
                    }
                },
                IdDistrictNavigation = new District
                {
                    IdDistrict = x.IdDistrictNavigation.IdDistrict,
                    DsDistrict = x.IdDistrictNavigation.DsDistrict
                }
            },
            OrderBy: p => p.DsProducer);
        }

        public async Task<IEnumerable<Producer>> ListOfProducers(ConsultProducerSignature signature)
        {
            return await ListOfEntities(Where: x => (signature.IdProducer == null || signature.IdProducer == x.IdProducer)
                                                 && (signature.DsEmail == null || signature.DsEmail.Contains(x.DsEmail)),
                                        Select: p => new Producer
                                        {
                                            IdProducer = p.IdProducer,
                                            DsProducer = p.DsProducer,
                                            DsFantasyname = p.DsFantasyname,
                                            DsEmail = p.DsEmail,
                                            DsPhone = p.DsPhone,
                                            DsAddress = p.DsAddress,
                                            DsZip = p.DsZip,
                                            DsComplement = p.DsComplement,
                                            DsNumber = p.DsNumber,
                                            DsDescription = p.DsDescription,
                                            DsFederalInscription = p.DsFederalInscription,
                                            DsStateInscription = p.DsStateInscription,
                                            DsMunicipalInscription = p.DsMunicipalInscription,
                                            IdCityNavigation = new City
                                            {
                                                IdCity = p.IdCityNavigation.IdCity,
                                                DsCity = p.IdCityNavigation.DsCity,
                                                Id = new State
                                                {
                                                    IdState = p.IdCityNavigation.Id.IdState,
                                                    DsState = p.IdCityNavigation.Id.DsState,
                                                    DsUf = p.IdCityNavigation.Id.DsUf
                                                }
                                            },
                                            IdDistrictNavigation = new District
                                            {
                                                IdDistrict = p.IdDistrictNavigation.IdDistrict,
                                                DsDistrict = p.IdDistrictNavigation.DsDistrict
                                            }
                                        },
                                        Page: signature.Page,
                                        Quantity: signature.Quantity,
                                        OrderBy: o => o.DsProducer);
        }

        public async Task<Producer> ProducerByIdOrEmail(ConsultProducerSignature signature)
        {
            return await EntityByFilter(Where: x => x.IdProducer == signature.IdProducer || x.DsEmail == signature.DsEmail,
            Select: p => new Producer
            {
                IdProducer = p.IdProducer,
                DsProducer = p.DsProducer,
                DsFantasyname = p.DsFantasyname,
                DsEmail = p.DsEmail,
                DsPhone = p.DsPhone,
                DsAddress = p.DsAddress,
                DsZip = p.DsZip,
                DsComplement = p.DsComplement,
                DsNumber = p.DsNumber,
                DsDescription = p.DsDescription,
                DsFederalInscription = p.DsFederalInscription,
                DsStateInscription = p.DsStateInscription,
                DsMunicipalInscription = p.DsMunicipalInscription,
                IdCityNavigation = new City
                {
                    IdCity = p.IdCityNavigation.IdCity,
                    DsCity = p.IdCityNavigation.DsCity,
                    Id = new State
                    {
                        IdState = p.IdCityNavigation.Id.IdState,
                        DsState = p.IdCityNavigation.Id.DsState,
                        DsUf = p.IdCityNavigation.Id.DsUf
                    }
                },
                IdDistrictNavigation = new District
                {
                    IdDistrict = p.IdDistrictNavigation.IdDistrict,
                    DsDistrict = p.IdDistrictNavigation.DsDistrict
                }
            });
        }
    }
}
