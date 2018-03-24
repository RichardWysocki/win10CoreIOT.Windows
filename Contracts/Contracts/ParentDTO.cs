namespace ServiceContracts.Contracts
{
    public class ParentDTO
    {
        /// <summary>
        /// Parent ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Name of Parent
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Email Address of Parent
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Foreign Key to Family ID.
        /// </summary>
        public int FamilyId { get; set; }
    }
}
