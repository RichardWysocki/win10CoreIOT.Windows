using System;

namespace ServiceContracts.Contracts
{
    [Obsolete]
    public class Customer
    {
        /// <summary>
        /// 
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

    }
}
