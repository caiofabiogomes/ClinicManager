namespace ClinicManager.Core.ValueObjects
{
    public sealed record Cpf
    {
        public Cpf()
        {
            
        }
        public Cpf(string value)
        {
            if (!IsValid(value))
                throw new ArgumentException("CPF inválido.");

            Value = value;
        }

        public string Value { get; init; }

        public bool IsValid(string cpf)
        {
            return !string.IsNullOrWhiteSpace(cpf) && CleanCpf(cpf).Length == 11;
        }

        public string FormatCpf()
        {
            if (!IsValid(Value))
                throw new ArgumentException("CPF inválido.");
            
            return Value.Insert(3, ".").Insert(7, ".").Insert(11, "-");
        }

        public string CleanCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", ""); ;
        }
    }
   
}
