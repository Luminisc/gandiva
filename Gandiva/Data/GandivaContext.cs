using System.Data.Entity;
using Gandiva.Data.Entity;

namespace Gandiva.Data
{
    class GandivaContext : DbContext
    {
        static GandivaContext instance;
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasRequired(c => c.TaskCreator)
                .WithMany()
                .HasForeignKey(c=>c.Creator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasRequired(c => c.TaskContractor)
                .WithMany()
                .HasForeignKey(c => c.Contractor)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
        #region Consructors...
        static GandivaContext() { Database.SetInitializer(new GandivaContextInitializer()); }
        GandivaContext() : base("DefaultConnection") { }
        #endregion

        public static GandivaContext Instance
        {
            get { return instance ?? (instance = new GandivaContext()); }
        }
    }

    class GandivaContextInitializer : DropCreateDatabaseIfModelChanges<GandivaContext>
    {

        protected override void Seed(GandivaContext context)
        {
            /* 5 пользователей */
            context.Users.Add(new User { SurName = "Романенко", FirstName = "Александр", SecondaryName = "Владимирович" });
            context.Users.Add(new User { SurName = "Иванов", FirstName = "Иван", SecondaryName = "Иванович" });
            context.Users.Add(new User { SurName = "Петров", FirstName = "Пётр", SecondaryName = "Петрович" });
            context.Users.Add(new User { SurName = "Сидоров", FirstName = "Сидор", SecondaryName = "Сидорович" });
            context.Users.Add(new User { SurName = "Сергеев", FirstName = "Сергей", SecondaryName = "Сергеевич" });
            context.SaveChanges();

            /* 3 задачи */
            context.Tasks.Add(new Task { Creator = 2, Contractor = 1, Title = "Task #1", Description = "Описание задачи #1" });
            context.Tasks.Add(new Task { Creator = 3, Contractor = 4, Title = "Task #2", Description = "Описание задачи #2" });
            context.Tasks.Add(new Task { Creator = 5, Contractor = 1, Title = "Task #3", Description = "Описание задачи #3" });
            context.SaveChanges();

            /* 10 комментариев к задачам */
            context.Comments.Add(new Comment { Task = 1, Creator = 1, Description = "Комментарий №1\r\nк задаче #1" });
            context.Comments.Add(new Comment { Task = 1, Creator = 2, Description = "Комментарий №2\r\nк задаче #1" });
            context.Comments.Add(new Comment { Task = 1, Creator = 3, Description = "Комментарий №3\r\nк задаче #1" });
            context.Comments.Add(new Comment { Task = 2, Creator = 1, Description = "Комментарий №1\r\nк задаче #2" });
            context.Comments.Add(new Comment { Task = 2, Creator = 2, Description = "Комментарий №2\r\nк задаче #2" });
            context.Comments.Add(new Comment { Task = 3, Creator = 1, Description = "Комментарий №1\r\nк задаче #3" });
            context.Comments.Add(new Comment { Task = 3, Creator = 2, Description = "Комментарий №2\r\nк задаче #3" });
            context.Comments.Add(new Comment { Task = 3, Creator = 3, Description = "Комментарий №3\r\nк задаче #3" });
            context.Comments.Add(new Comment { Task = 3, Creator = 4, Description = "Комментарий №4\r\nк задаче #3" });
            context.Comments.Add(new Comment { Task = 3, Creator = 5, Description = "Комментарий №5\r\nк задаче #3" });

            context.SaveChanges();
        }
    }
}