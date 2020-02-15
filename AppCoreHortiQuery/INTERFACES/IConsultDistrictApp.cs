﻿using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.INTERFACES
{
    public interface IConsultDistrictApp
    {
        Task<IEnumerable<ConsultDistrictResult>> GetListOfDistricts();
        Task<IEnumerable<ConsultDistrictResult>> GetListOfDistrictsByQuantity(ConsultByQuantitySignature signature);
        Task<ConsultDistrictResult> GetDistrictById(ConsultDistrictByIdNameSignature signature);
        Task<IEnumerable<ConsultDistrictResult>> GetListOfDistrictsByName(ConsultDistrictByIdNameSignature signature);
    }
}