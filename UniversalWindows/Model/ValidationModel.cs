namespace UniversalWindows.Model
{
    public class ValidationModel : IValidationModel
    {
        public bool isValid { get; set; }
        public string errorMessage { get; set; }
    }
}
