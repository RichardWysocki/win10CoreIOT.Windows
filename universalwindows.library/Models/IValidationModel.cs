namespace universalwindows.library.Models
{
    public interface IValidationModel
    {
        string ErrorMessage { get; set; }
        bool IsValid { get; set; }
    }
}