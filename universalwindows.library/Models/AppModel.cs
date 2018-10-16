using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace universalwindows.library.Models
{
    [DataContract]
    public class AppModel
    {
        public AppModel()
        {
        }

        public AppModel(string password, string companyImage)
        {
            Password = password;
            CompanyImage = companyImage;
        }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string CompanyImage { get; set; }
    }
}
