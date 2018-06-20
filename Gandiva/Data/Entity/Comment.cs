using System.ComponentModel.DataAnnotations;

namespace Gandiva.Data.Entity
{
    public class Comment : Entity
    {
        public int Task { get; set; }
        public int Creator { get; set; }
        [Required]
        public string Description { get; set; }
    }
}