namespace universalwindows.library.Models
{
    public class ValidationModel : IValidationModel
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
