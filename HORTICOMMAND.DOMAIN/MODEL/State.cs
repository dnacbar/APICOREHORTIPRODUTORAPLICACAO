using HORTICOMMAND.DOMAIN.INTERFACES.MODEL;
using System.Collections.Generic;

namespace HORTICOMMAND.DOMAIN.MODEL
{
    public class State : IState
    {
        public State()
        {
            City = new HashSet<ICity>();
        }

        public string IdCountry { get; set; }
        public int IdState { get; set; }
        public string DsState { get; set; }
        public string DsUf { get; set; }

        public virtual ICollection<ICity> City { get; set; }
    }
}
