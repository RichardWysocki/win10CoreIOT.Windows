namespace UniversalWindows.Model
{
    public interface IValidationModel
    {
        string errorMessage { get; set; }
        bool isValid { get; set; }
    }
}