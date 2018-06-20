using System.ComponentModel.DataAnnotations;

namespace Gandiva.Data.Entity
{
    public class Task : Entity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int Creator { get; set; }
        public int Contractor { get; set; }
    }
}