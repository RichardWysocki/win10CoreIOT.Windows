using System.Text.RegularExpressions;
using universalwindows.library.Models;

namespace universalwindows.library.Common
{
    public class PersonBusiness : IPersonBusiness
    {
        public ValidationModel ValidatePerson(PersonModel person)
        {
            ValidationModel checkvalidation;
            checkvalidation = ValidateAllFieldsComplete(person);
            if (checkvalidation.IsValid)
            {
                checkvalidation = ValidateEmail(person.Email);
                if (checkvalidation.IsValid)
                    checkvalidation = IsPhone(person.Phone);
            }
            return checkvalidation;
        }

        private ValidationModel ValidateAllFieldsComplete(PersonModel person)
        {
            var response = new ValidationModel { ErrorMessage = "Please Complete all fields.", IsValid = false };
            var validateName = person.Email.Length > 0 & person.Name.Length > 0 & person.Phone.Length > 0;
            if (validateName)
                response.IsValid = true;
            return response;
        }

        private ValidationModel ValidateEmail(string personEmail)
        {
            var response = new ValidationModel { ErrorMessage = "Please Enter a Valid Email Address.", IsValid = false };
            string email = personEmail;
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                response.IsValid = true;
            return response;
        }

        private ValidationModel IsPhone(string strPhone)
        {
            var response = new ValidationModel {ErrorMessage = "Please Enter a Valid Phone #.", IsValid = false};
            var objPhonePattern = new Regex(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
            var validatePhone = objPhonePattern.IsMatch(strPhone);
            if (validatePhone)
                response.IsValid = true;
            return response;
        }
    }
}
