using DominioCoreBasicoCommand;
using System;
using System.Collections.Generic;

namespace BasicAddressDomainCoreCommand
{
    public sealed class Country : Entity
    {
        public IEnumerable<State> LstState { get; set; }
    }
}
