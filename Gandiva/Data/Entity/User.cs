using System.ComponentModel.DataAnnotations;

namespace Gandiva.Data.Entity
{
    public class User : Entity
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string SecondaryName { get; set; }
        [StringLength(50)]
        public string SurName { get; set; }
    }
}