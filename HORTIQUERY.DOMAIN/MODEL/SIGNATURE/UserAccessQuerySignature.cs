namespace HORTIQUERY.DOMAIN.MODEL.SIGNATURE
{
    public sealed class UserAccessQuerySignature : IUserAccessQuerySignature
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
