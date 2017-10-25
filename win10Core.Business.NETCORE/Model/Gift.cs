using System;

namespace win10Core.Business.Model
{
    public class Gift
    {
        public int GiftId { get; set; }

        public int KidId { get; set; }

        public string GiftName { get; set; }

        public int Priority { get; set; }

        public string WebUrl { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? EmailSent { get; set; }

    }
}
