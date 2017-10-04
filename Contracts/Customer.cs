using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
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
