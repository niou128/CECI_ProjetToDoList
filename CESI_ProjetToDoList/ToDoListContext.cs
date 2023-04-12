using Microsoft.EntityFrameworkCore;

namespace CESI_ProjetToDoList
{
    public class ToDoListContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todo.db3");
        }

        public void InitializeDatabase()
        {
            using (var context = new ToDoListContext())
            {
                // Crée la base de données si elle n'existe pas
                context.Database.EnsureCreated();
            }
        }

        public List<Task> GetAllTasks()
        {
            using (var context = new ToDoListContext())
            {
                var tasks = context.Tasks.ToList();
                return tasks;
            }
        }

        public void AddTask(Task task)
        {
            using (var context = new ToDoListContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }

        public void UpdateTask(Task task)
        {
            using (var context = new ToDoListContext())
            {
                context.Tasks.Update(task);
                context.SaveChanges();
            }
        }

        public Task GetTaskById(int id)
        {
            using (var context = new ToDoListContext())
            {
                return context.Tasks.FirstOrDefault(task => task.Id == id);
            }
        }

        public void DeleteTask(int id)
        {
            using (var context = new ToDoListContext())
            {
                var task = context.Tasks.FirstOrDefault(t => t.Id == id);
                if (task != null)
                {
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                }
            }
        }

    }
}
