﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class GiftViewModel
    {
        public int GiftId { get; set; }

        public int KidId { get; set; }

        public string GiftName { get; set; }

        public int Priority { get; set; }

        public string WebUrl { get; set; }

        public string KidName { get; set; }

    }
}