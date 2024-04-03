namespace ClinicManager.Core.ValueObjects
{
    public record Email
    {
        public Email()
        {
            
        }
        public Email(string value)
        {
            if (!IsValid(value))
                throw new ArgumentException("E-mail inválido.");

            Value = value;
        }

        public string Value { get; init; }

        public static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (email.Count(c => c == '@') != 1)
                return false;

            string[] parts = email.Split('@');
            if (parts.Length != 2)
                return false;

            string localPart = parts[0];
            string domainPart = parts[1];

            if (string.IsNullOrWhiteSpace(localPart) || localPart.Any(c => !IsValidLocalPartCharacter(c)))
                return false;


            if (string.IsNullOrWhiteSpace(domainPart) || domainPart.Any(c => !IsValidDomainPartCharacter(c)))
                return false;

            return true;
        }

        private static bool IsValidLocalPartCharacter(char c)
        {
            return char.IsLetterOrDigit(c) || c == '.' || c == '!' || c == '#' || c == '$' ||
                   c == '%' || c == '&' || c == '\'' || c == '*' || c == '+' || c == '-' ||
                   c == '/' || c == '=' || c == '?' || c == '^' || c == '_' || c == '`' ||
                   c == '{' || c == '|' || c == '}' || c == '~';
        }

        private static bool IsValidDomainPartCharacter(char c)
        {
            return char.IsLetterOrDigit(c) || c == '-' || c == '.';
        }
    }
}
