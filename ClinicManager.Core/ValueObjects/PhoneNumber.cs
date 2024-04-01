namespace ClinicManager.Core.ValueObjects
{
    public record PhoneNumber
    {
        public PhoneNumber(string value)
        {
            if (!IsValid(value))
                throw new ArgumentException("Número de telefone inválido.");

            Value = value;
        }

        public string Value { get; init; }

        public static bool IsValid(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            string cleanedNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            if (cleanedNumber.Length < 10 || cleanedNumber.Length > 15)
                return false;

            if (cleanedNumber.Length > 11 && !cleanedNumber.StartsWith("+"))
                return false;

            return true;
        }

        public string FormatPhoneNumber()
        {
            string cleanedNumber = new string(Value.Where(char.IsDigit).ToArray());

            if (cleanedNumber.Length == 10)
            {
                return string.Format("({0}) {1}-{2}",
                    cleanedNumber.Substring(0, 3),
                    cleanedNumber.Substring(3, 3),
                    cleanedNumber.Substring(6, 4));
            }
            else if (cleanedNumber.Length == 11 && cleanedNumber.StartsWith("1"))
            {
                return string.Format("1 ({0}) {1}-{2}",
                    cleanedNumber.Substring(1, 3),
                    cleanedNumber.Substring(4, 3),
                    cleanedNumber.Substring(7, 4));
            }
            else if (cleanedNumber.Length > 11 && cleanedNumber.StartsWith("+"))
            {
                return string.Format("{0} ({1}) {2}-{3}",
                    cleanedNumber.Substring(0, 2),
                    cleanedNumber.Substring(2, cleanedNumber.Length - 10),
                    cleanedNumber.Substring(cleanedNumber.Length - 10, 3),
                    cleanedNumber.Substring(cleanedNumber.Length - 7, 4));
            }
            else
            {
                return Value;
            }
        }
    }
}
