using System;

namespace HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT
{
    public interface IUserResult
    {
        string Name { get; set; }
        string Email { get; set; }
        int? IdState { get; set; }
        int? IdCity { get; set; }
        Guid? IdDistrict { get; set; }
        string Phone { get; set; }
        string Address { get; set; }
        string Number { get; set; }
        string Complement { get; set; }
        string Zip { get; set; }
    }
}
