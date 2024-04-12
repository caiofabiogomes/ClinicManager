namespace ClinicManager.Application.Abstractions
{
    public class ValidationError
    {
        public string FieldName { get; private set; }
        public string ErrorMessage { get; private set; }

        public ValidationError(string fieldName, string errorMessage)
        {
            FieldName = fieldName;
            ErrorMessage = errorMessage;
        }
    }
}
