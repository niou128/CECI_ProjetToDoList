using System.Data.SQLite;

namespace CESI_ProjetToDoList
{
    public class ToDoListContext
    {
        private string connectionString = "Data Source=todo.db3";

        public void InitializeDatabase()
        {
            if (!File.Exists("todo.db3"))
            {
                SQLiteConnection.CreateFile("todo.db3");

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = @"CREATE TABLE Tasks (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL,
                                Date TEXT NOT NULL,
                                IsCompleted INTEGER NOT NULL)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        public List<Task> GetAllTasks()
        {
            List<Task> tasks = new List<Task>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tasks";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new Task
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Date = DateTime.Parse(reader.GetString(2)),
                                IsCompleted = reader.GetBoolean(3)
                            });
                        }
                    }
                }
                conn.Close();
            }

            return tasks;
        }

        public void AddTask(Task task)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Tasks (Name, Date, IsCompleted) VALUES (@Name, @Date, @IsCompleted)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", task.Name);
                    cmd.Parameters.AddWithValue("@Date", task.Date.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void UpdateTask(Task task)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Tasks SET Name = @Name, Date = @Date, IsCompleted = @IsCompleted WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", task.Id);
                    cmd.Parameters.AddWithValue("@Name", task.Name);
                    cmd.Parameters.AddWithValue("@Date", task.Date);
                    cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Task GetTaskById(int id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tasks WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Task
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Date = reader.GetDateTime(2),
                                IsCompleted = reader.GetBoolean(3)
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
