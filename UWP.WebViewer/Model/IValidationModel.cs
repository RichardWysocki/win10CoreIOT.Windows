namespace UWP.WebViewer.Model
{
    public interface IValidationModel
    {
        string errorMessage { get; set; }
        bool isValid { get; set; }
    }
}