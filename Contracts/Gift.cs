using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    public class Gift
    {
        public int GiftId { get; set; }

        public int KidId { get; set; }

        public string GiftName { get; set; }

        public int Priority { get; set; }

        public string WebUrl { get; set; }
    }
}
