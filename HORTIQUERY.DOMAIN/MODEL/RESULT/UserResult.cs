using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using System;

namespace HORTIQUERY.DOMAIN.MODEL.RESULT
{
    public abstract class UserResult : IUserResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? IdState { get; set; }
        public int? IdCity { get; set; }
        public Guid? IdDistrict { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Zip { get; set; }
    }
}
