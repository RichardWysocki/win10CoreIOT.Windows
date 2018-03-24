namespace ServiceContracts.Contracts
{
    public class KidDTO
    {

       /// <summary>
       /// Kid Id
       /// </summary>
       public int KidId { get; set; }

        /// <summary>
        /// Full name of Kid
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email Address of Kid
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Foreign Key of Kids Family
        /// </summary>
        public int FamilyId { get; set; }

    }
}
