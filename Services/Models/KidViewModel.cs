using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class KidViewModel
    {

        public int KidId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int FamilyId { get; set; }

        public string FamilyName { get; set; }

    }
}