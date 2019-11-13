using DominioCoreBasicoCommand;
using System;
using System.Collections.Generic;

namespace BasicAddressDomainCoreCommand
{
    public sealed class State : Entity
    {
        public string DsUf { get; set; }

        public Country Country { get; set; }
        public IEnumerable<City> LstCity { get; set; }
    }
}
