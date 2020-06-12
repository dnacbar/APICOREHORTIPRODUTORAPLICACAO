﻿using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace SERVICECOREHORTICOMMAND.ISERVICE
{
    public interface IUnitDomainService
    {
        Task UnitServiceCreate(Unit unit);
        Task UnitServiceDelete(Unit unit);
        Task UnitServiceUpdate(Unit unit);
    }
}