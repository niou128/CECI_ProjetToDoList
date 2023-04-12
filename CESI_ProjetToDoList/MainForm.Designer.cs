namespace CESI_ProjetToDoList
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tasksDataGridView = new DataGridView();
            taskNameTextBox = new TextBox();
            TimeTaskDatePicker = new DateTimePicker();
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)tasksDataGridView).BeginInit();
            SuspendLayout();
            // 
            // tasksDataGridView
            // 
            tasksDataGridView.AllowUserToAddRows = false;
            tasksDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tasksDataGridView.BackgroundColor = SystemColors.InactiveCaption;
            tasksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tasksDataGridView.Location = new Point(25, 11);
            tasksDataGridView.Margin = new Padding(3, 2, 3, 2);
            tasksDataGridView.MultiSelect = false;
            tasksDataGridView.Name = "tasksDataGridView";
            tasksDataGridView.RowHeadersWidth = 51;
            tasksDataGridView.RowTemplate.Height = 29;
            tasksDataGridView.Size = new Size(646, 217);
            tasksDataGridView.TabIndex = 0;
            tasksDataGridView.CellContentClick += TasksDataGridView_CellContentClick;
            tasksDataGridView.DataBindingComplete += TasksDataGridView_DataBindingComplete;
            // 
            // taskNameTextBox
            // 
            taskNameTextBox.Location = new Point(25, 267);
            taskNameTextBox.Margin = new Padding(3, 2, 3, 2);
            taskNameTextBox.Name = "taskNameTextBox";
            taskNameTextBox.Size = new Size(88, 23);
            taskNameTextBox.TabIndex = 1;
            // 
            // TimeTaskDatePicker
            // 
            TimeTaskDatePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            TimeTaskDatePicker.Format = DateTimePickerFormat.Custom;
            TimeTaskDatePicker.Location = new Point(137, 267);
            TimeTaskDatePicker.Name = "TimeTaskDatePicker";
            TimeTaskDatePicker.Size = new Size(200, 23);
            TimeTaskDatePicker.TabIndex = 3;
            // 
            // addButton
            // 
            addButton.Location = new Point(386, 266);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 4;
            addButton.Text = "Ajouter";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(addButton);
            Controls.Add(TimeTaskDatePicker);
            Controls.Add(taskNameTextBox);
            Controls.Add(tasksDataGridView);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "ToDoList";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)tasksDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tasksDataGridView;
        private TextBox taskNameTextBox;
        private CheckBox checkBox1;
        private DateTimePicker TimeTaskDatePicker;
        private Button addButton;
    }
}