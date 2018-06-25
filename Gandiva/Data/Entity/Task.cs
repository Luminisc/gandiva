using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

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
        /// </summary>
        //[ForeignKey("Creator")]
        public virtual User TaskCreator { get; set; }
        /// <summary>
        /// </summary>
        // [ForeignKey("Contractor")]
        public virtual User TaskContractor { get; set; }
        public override string ToString() { return string.Format("Task: {0}", Title); }
		
		public virtual List<Comment> Comments { get; set; }

		public sealed class Configuration : EntityTypeConfiguration<Task>
        {
            public Configuration()
            {
                HasRequired(c => c.TaskCreator)
                    .WithMany()
                    .HasForeignKey(c => c.Creator)
                    .WillCascadeOnDelete(false);

                HasRequired(c => c.TaskContractor)
                    .WithMany()
                    .HasForeignKey(c => c.Contractor)
                    .WillCascadeOnDelete(false);
            }
        }
    }
}