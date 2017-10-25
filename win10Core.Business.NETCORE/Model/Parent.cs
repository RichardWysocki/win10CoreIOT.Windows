using System.ComponentModel.DataAnnotations;

namespace win10Core.Business.Model
{
    public class Parent
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FamilyId { get; set; }
    }
}
