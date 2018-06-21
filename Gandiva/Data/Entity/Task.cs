using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gandiva.Data.Entity
{
    public class Task : Entity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Creator { get; set; }
        public int Contractor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("Creator")]
        public User TaskCreator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("Contractor")]
        public User TaskContractor { get; set; }
    }


}