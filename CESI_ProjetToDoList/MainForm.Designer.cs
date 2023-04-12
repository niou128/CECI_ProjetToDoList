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
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)tasksDataGridView).BeginInit();
            SuspendLayout();
            // 
            // tasksDataGridView
            // 
            tasksDataGridView.AllowUserToAddRows = false;
            tasksDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tasksDataGridView.BackgroundColor = SystemColors.InactiveCaption;
            tasksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tasksDataGridView.Location = new Point(54, 27);
            tasksDataGridView.Margin = new Padding(6, 5, 6, 5);
            tasksDataGridView.Name = "tasksDataGridView";
            tasksDataGridView.RowHeadersWidth = 51;
            tasksDataGridView.RowTemplate.Height = 29;
            tasksDataGridView.Size = new Size(1384, 535);
            tasksDataGridView.TabIndex = 0;
            tasksDataGridView.CellClick += TasksDataGridView_CellClick;
            tasksDataGridView.DataBindingComplete += TasksDataGridView_DataBindingComplete;
            // 
            // taskNameTextBox
            // 
            taskNameTextBox.Location = new Point(54, 659);
            taskNameTextBox.Margin = new Padding(6, 5, 6, 5);
            taskNameTextBox.Name = "taskNameTextBox";
            taskNameTextBox.Size = new Size(184, 43);
            taskNameTextBox.TabIndex = 1;
            // 
            // TimeTaskDatePicker
            // 
            TimeTaskDatePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            TimeTaskDatePicker.Format = DateTimePickerFormat.Custom;
            TimeTaskDatePicker.Location = new Point(294, 659);
            TimeTaskDatePicker.Margin = new Padding(6, 7, 6, 7);
            TimeTaskDatePicker.Name = "TimeTaskDatePicker";
            TimeTaskDatePicker.Size = new Size(424, 43);
            TimeTaskDatePicker.TabIndex = 3;
            // 
            // addButton
            // 
            addButton.Location = new Point(827, 656);
            addButton.Margin = new Padding(6, 7, 6, 7);
            addButton.Name = "addButton";
            addButton.Size = new Size(161, 57);
            addButton.TabIndex = 4;
            addButton.Text = "Ajouter";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(1149, 661);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(169, 52);
            deleteButton.TabIndex = 5;
            deleteButton.Text = "supprimer";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 834);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(TimeTaskDatePicker);
            Controls.Add(taskNameTextBox);
            Controls.Add(tasksDataGridView);
            Margin = new Padding(6, 5, 6, 5);
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
        private DateTimePicker TimeTaskDatePicker;
        private Button addButton;
        private Button deleteButton;
    }
}