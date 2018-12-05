namespace JournalViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TimeView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMachine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dateViewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationViewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineViewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameViewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purposeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journalItemViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalItemViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выбрать директорию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(668, 20);
            this.textBox1.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(126, 110);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(300, 20);
            this.dateTimePickerFrom.TabIndex = 2;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateViewDataGridViewTextBoxColumn,
            this.TimeView,
            this.durationViewDataGridViewTextBoxColumn,
            this.machineViewDataGridViewTextBoxColumn,
            this.nameViewDataGridViewTextBoxColumn,
            this.purposeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.journalItemViewBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(843, 426);
            this.dataGridView1.TabIndex = 3;
            // 
            // TimeView
            // 
            this.TimeView.DataPropertyName = "TimeView";
            this.TimeView.HeaderText = "Время";
            this.TimeView.Name = "TimeView";
            this.TimeView.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Показать от:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выбор компьютера:";
            // 
            // comboBoxMachine
            // 
            this.comboBoxMachine.FormattingEnabled = true;
            this.comboBoxMachine.Location = new System.Drawing.Point(126, 137);
            this.comboBoxMachine.Name = "comboBoxMachine";
            this.comboBoxMachine.Size = new System.Drawing.Size(300, 21);
            this.comboBoxMachine.TabIndex = 6;
            this.comboBoxMachine.SelectedIndexChanged += new System.EventHandler(this.comboBoxMachine_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Выбор пользователя:";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(554, 137);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(300, 21);
            this.comboBoxUser.TabIndex = 8;
            this.comboBoxUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxUser_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(479, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Показать до:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(554, 110);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(300, 20);
            this.dateTimePickerTo.TabIndex = 10;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(709, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Обновить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(186, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(668, 20);
            this.textBox2.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Выбрать файл имен";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(186, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(668, 20);
            this.textBox3.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Выбрать файл компьютеров";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dateViewDataGridViewTextBoxColumn
            // 
            this.dateViewDataGridViewTextBoxColumn.DataPropertyName = "dateView";
            this.dateViewDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateViewDataGridViewTextBoxColumn.Name = "dateViewDataGridViewTextBoxColumn";
            this.dateViewDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durationViewDataGridViewTextBoxColumn
            // 
            this.durationViewDataGridViewTextBoxColumn.DataPropertyName = "durationView";
            this.durationViewDataGridViewTextBoxColumn.HeaderText = "Продолжительность";
            this.durationViewDataGridViewTextBoxColumn.Name = "durationViewDataGridViewTextBoxColumn";
            this.durationViewDataGridViewTextBoxColumn.ReadOnly = true;
            this.durationViewDataGridViewTextBoxColumn.Width = 150;
            // 
            // machineViewDataGridViewTextBoxColumn
            // 
            this.machineViewDataGridViewTextBoxColumn.DataPropertyName = "machineView";
            this.machineViewDataGridViewTextBoxColumn.HeaderText = "Компьютер";
            this.machineViewDataGridViewTextBoxColumn.Name = "machineViewDataGridViewTextBoxColumn";
            this.machineViewDataGridViewTextBoxColumn.ReadOnly = true;
            this.machineViewDataGridViewTextBoxColumn.Width = 150;
            // 
            // nameViewDataGridViewTextBoxColumn
            // 
            this.nameViewDataGridViewTextBoxColumn.DataPropertyName = "nameView";
            this.nameViewDataGridViewTextBoxColumn.HeaderText = "Пользователь";
            this.nameViewDataGridViewTextBoxColumn.Name = "nameViewDataGridViewTextBoxColumn";
            this.nameViewDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purposeDataGridViewTextBoxColumn
            // 
            this.purposeDataGridViewTextBoxColumn.DataPropertyName = "purpose";
            this.purposeDataGridViewTextBoxColumn.HeaderText = "Цель";
            this.purposeDataGridViewTextBoxColumn.Name = "purposeDataGridViewTextBoxColumn";
            this.purposeDataGridViewTextBoxColumn.ReadOnly = true;
            this.purposeDataGridViewTextBoxColumn.Width = 200;
            // 
            // journalItemViewBindingSource
            // 
            this.journalItemViewBindingSource.DataSource = typeof(Journal.JournalItem_View);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 632);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxMachine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(882, 2000);
            this.MinimumSize = new System.Drawing.Size(882, 250);
            this.Name = "Form1";
            this.Text = "Просмотр журнала";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalItemViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource journalItemViewBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMachine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateViewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeView;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationViewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineViewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameViewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purposeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button4;
    }
}

