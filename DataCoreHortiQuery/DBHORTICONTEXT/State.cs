using System;
using System.Collections.Generic;

namespace DataCoreHortiQuery.DBHORTICONTEXT
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
        }

        public string IdCountry { get; set; }
        public int IdState { get; set; }
        public string DsState { get; set; }
        public string DsUf { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
