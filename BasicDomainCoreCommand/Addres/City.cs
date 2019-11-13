using DominioCoreBasicoCommand;
using System.Collections.Generic;

namespace BasicAddressDomainCoreCommand
{
    public sealed class City : Entity
    {
        public string CdCity { get; set; }
        public State State { get; set; }
        public IEnumerable<District> LstDistrict { get; set; }
    }
}
