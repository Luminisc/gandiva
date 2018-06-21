using System.Data.Entity.ModelConfiguration;

namespace Gandiva.Data.Entity
{
    public class Comment : Entity
    {
        public int Task { get; set; }
        public int Creator { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// </summary>
        /// [ForeignKey("Task")]
        public virtual Task ParentTask { get; set; }
        /// <summary>
        /// </summary>
        /// [ForeignKey("Creator")]
        public virtual User CommentCretor { get; set; }
        public override string ToString() { return string.Format("Comment: {0}", Description); }

        public sealed class Configuration : EntityTypeConfiguration<Comment>
        {
            public Configuration()
            {
                //Property(x => x.Task).IsRequired();
                //Property(x => x.Creator).IsRequired();

                /* Setting relations */
                HasRequired(x => x.ParentTask)
                    .WithMany()
                    .HasForeignKey(x => x.Task)
                    .WillCascadeOnDelete(false);

                HasRequired(x => x.CommentCretor)
                    .WithMany()
                    .HasForeignKey(x => x.Creator)
                    .WillCascadeOnDelete(false);
            }
        }
    }
}