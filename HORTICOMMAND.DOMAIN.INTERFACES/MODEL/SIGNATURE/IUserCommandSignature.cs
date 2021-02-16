namespace HORTICOMMAND.DOMAIN.INTERFACES.MODEL.SIGNATURE
{
    public interface IUserCommandSignature
    {
        bool IsProducer { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string UserName { get; set; } 
        string Phone { get; set; }
    }
}
