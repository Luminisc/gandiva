using System.Data.Entity.ModelConfiguration;

namespace Gandiva.Data.Entity
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string SecondaryName { get; set; }
        public string SurName { get; set; }
        public override string ToString() { return string.Format("{0} {1}", SurName, FirstName); }

        public sealed class Configuration : EntityTypeConfiguration<User>
        {
            public Configuration()
            {
                /* Fluent API configuration */
                Property(x => x.SurName).IsRequired().HasMaxLength(100); //for example
                Property(x => x.FirstName).IsRequired();
            }
        }
    }
}