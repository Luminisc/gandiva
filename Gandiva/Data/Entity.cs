using System;
using System.ComponentModel.DataAnnotations;

namespace Gandiva.Data.Entity
{
    public abstract class Entity
    {
        protected Entity()
        {
            CreatedDate = DateTime.Now;
            IsActual = true;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActual { get; set; }
    }

    public class User : Entity
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string SecondaryName { get; set; }
        [StringLength(50)]
        public string SurName { get; set; }
    }

    public class Task : Entity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int Creator { get; set; }
        public int Contractor { get; set; }
    }

    public class Comment : Entity
    {
        public int Task { get; set; }
        public int Creator { get; set; }
        [Required]
        public string Description { get; set; }
    }
}