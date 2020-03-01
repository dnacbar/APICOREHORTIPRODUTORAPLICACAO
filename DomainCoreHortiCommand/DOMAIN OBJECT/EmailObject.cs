namespace DOMAINCOREHORTICOMMAND.DOMAIN_OBJECT
{
    public sealed class EmailObject
    {
        public EmailObject(string emailObject)
        {
            Email = emailObject;
            ValidateEmail();
        }

        public string Email { get; private set; }

        private void ValidateEmail()
        {
            if (!Email.Contains("@") || !Email.Contains(".com"))
                Email = null;

            if (Email.Length <= 6)
                Email = null;
        }
    }
}
