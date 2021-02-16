namespace HORTICOMMAND.DOMAIN.MODEL.DOMAINOBJECT
{
    public sealed class EmailObject
    {
        public EmailObject(string emailObject)
        {
            Email = emailObject?.Trim();
        }

        public string Email { get; private set; }
        public bool IsValid()
        {
            if (!Email.Contains("@") || !Email.Contains(".com"))
                return false;

            if (Email.Length <= 6)
                return false;

            return true;
        }
    }
}
