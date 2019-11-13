using DominioCoreBasicoCommand;
using System;

namespace BasicAddressDomainCoreCommand
{
    public sealed class District : Entity
    {
        public City City { get; set; }
    }
}
