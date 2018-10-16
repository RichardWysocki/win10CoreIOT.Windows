using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UniversalWindows.Model;

namespace UniversalWindows.Common
{
    public class PersonBusiness
    {
        public ValidationModel ValidatePerson(PersonModel person)
        {
            ValidationModel checkvalidation = new ValidationModel {errorMessage = "", isValid = false};
            checkvalidation = ValidateAllFieldsComplete(person);
            if (checkvalidation.isValid)
            {
                checkvalidation = ValidateEmail(person.Email);
                if (checkvalidation.isValid)
                    checkvalidation = IsPhone(person.Phone);
            }
            return checkvalidation;
        }

        private ValidationModel ValidateAllFieldsComplete(PersonModel person)
        {
            var response = new ValidationModel { errorMessage = "Please Complete all fields.", isValid = false };
            var validateName = person.Email.Length > 0 & person.Name.Length > 0 & person.Phone.Length > 0;
            if (validateName)
                response.isValid = true;
            return response;
        }

        private ValidationModel ValidateEmail(string personEmail)
        {
            var response = new ValidationModel { errorMessage = "Please Enter a Valid Email Address.", isValid = false };
            string email = personEmail;
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                response.isValid = true;
            return response;
        }

        private ValidationModel IsPhone(string strPhone)
        {
            var response = new ValidationModel {errorMessage = "Please Enter a Valid Phone #.", isValid = false};
            var objPhonePattern = new Regex(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
            var validatePhone = objPhonePattern.IsMatch(strPhone);
            if (validatePhone)
                response.isValid = true;
            return response;
        }
    }
}
