using universalwindows.library.Models;

namespace universalwindows.library.Common
{
    public interface IPersonBusiness
    {
        ValidationModel ValidatePerson(PersonModel person);
    }
}