using System.Diagnostics.CodeAnalysis;

namespace win10Core.Business.Standard.Model
{
    [ExcludeFromCodeCoverage]
    public class Client
    {

        public Client()
        {
        }

        public int CustomerID { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }

    }
}
