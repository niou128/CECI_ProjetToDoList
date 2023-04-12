
using System.ComponentModel;
using System.Data;
using System.Timers;
using Timer = System.Timers.Timer;

namespace CESI_ProjetToDoList
{
    public partial class MainForm : Form
    {
        private ToDoListContext toDoListContext;
        private Timer timer;

        public MainForm()
        {
            InitializeComponent();
            toDoListContext = new ToDoListContext();
            InitializeTimer();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toDoListContext.InitializeDatabase();
            LoadTasks();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 5 * 60 * 1000; // 5 minutes en millisecondes
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Exécutez la méthode LoadTasks dans le thread de l'interface utilisateur
            BeginInvoke(new Action(() =>
            {
                LoadTasks();
            }));
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskNameTextBox.Text) || TimeTaskDatePicker.Value == null)
            {
                MessageBox.Show("Veuillez remplir les champs Nom de la tâche et Date.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Task newTask = new Task
            {
                Name = taskNameTextBox.Text,
                Date = TimeTaskDatePicker.Value,
                IsCompleted = false
            };

            toDoListContext.AddTask(newTask);
            LoadTasks();

            // Nettoyer les champs d'entrée après l'ajout de la tâche
            taskNameTextBox.Clear();
            TimeTaskDatePicker.Value = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //var selectedTask = tasksDataGridView.SelectedRows[0].DataBoundItem as Task;

            //if (selectedTask != null)
            //{
            //    toDoListContext.Tasks.Remove(selectedTask);
            //    toDoListContext.SaveChanges();
            //    LoadTasks();
            //}
        }

        private void LoadTasks()
        {
            var tasks = toDoListContext.GetAllTasks();
            tasksDataGridView.DataSource = ConvertToDataTable(tasks);
            tasksDataGridView.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void TasksDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan oneHour = TimeSpan.FromHours(1);

            // Désactivez la couleur de fond par défaut pour les cellules sélectionnées
            foreach (DataGridViewColumn column in tasksDataGridView.Columns)
            {
                column.DefaultCellStyle.SelectionBackColor = column.DefaultCellStyle.BackColor;
            }

            for (int i = 0; i < tasksDataGridView.Rows.Count; i++)
            {
                var isCompletedCellValue = tasksDataGridView.Rows[i].Cells["IsCompleted"].Value;
                var dateCellValue = tasksDataGridView.Rows[i].Cells["Date"].Value;

                if (isCompletedCellValue != null && dateCellValue != null)
                {
                    DateTime taskDate = (DateTime)dateCellValue;

                    if ((bool)isCompletedCellValue)
                    {
                        tasksDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                    else if (taskDate <= now)
                    {
                        tasksDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (taskDate <= now.Add(oneHour))
                    {
                        tasksDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    }
                }
            }
        }


        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void TasksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifiez si la cellule cliquée est dans la colonne 'IsCompleted'
            if (tasksDataGridView.Columns[e.ColumnIndex].Name == "IsCompleted")
            {
                // Obtenez la tâche correspondante à la ligne
                int taskId = (int)tasksDataGridView.Rows[e.RowIndex].Cells["Id"].Value;
                Task task = toDoListContext.GetTaskById(taskId);

                // Mettez à jour l'état 'IsCompleted' et sauvegardez les modifications dans la base de données
                task.IsCompleted = !task.IsCompleted;
                tasksDataGridView.Rows[e.RowIndex].Cells["IsCompleted"].Value = task.IsCompleted;
                toDoListContext.UpdateTask(task);

                // Changez la couleur de la ligne en fonction de l'état 'IsCompleted'
                if (task.IsCompleted)
                {
                    tasksDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    tasksDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }

                // Validez les modifications de la cellule et rafraîchissez la DataGridView
                tasksDataGridView.EndEdit();
                tasksDataGridView.Refresh();
            }
        }
    }
}