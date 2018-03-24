using System;

namespace ServiceContracts.Contracts
{
    
    public class GiftDTO
    {
       /// <summary>
       /// Gift ID
       /// </summary>
       public int GiftId { get; set; }

       /// <summary>
       /// Foreign Key to Kid that this gift Belongs to
       /// </summary>
       public int KidId { get; set; }

        /// <summary>
        /// Gift Name
        /// </summary>
        public string GiftName { get; set; }

        /// <summary>
        /// Priority of highest Value gift
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WebUrl { get; set; }
        /// <summary>
        /// Uri to Website selling Give
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// ? Not sure?
        /// </summary>
        public bool? EmailSent { get; set; }
    }
}
