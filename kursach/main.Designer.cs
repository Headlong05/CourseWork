namespace kursach
{
    partial class MyApp
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
            tabControl1 = new TabControl();
            page_score = new TabPage();
            volontbox = new CheckBox();
            gtobox = new CheckBox();
            goldbox = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            input_table = new DataGridView();
            page_table = new TabPage();
            button3 = new Button();
            button2 = new Button();
            dataGridView = new DataGridView();
            cmbVuz = new ComboBox();
            tabControl1.SuspendLayout();
            page_score.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)input_table).BeginInit();
            page_table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(page_score);
            tabControl1.Controls.Add(page_table);
            tabControl1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.Location = new Point(3, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.No;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(971, 570);
            tabControl1.TabIndex = 0;
            // 
            // page_score
            // 
            page_score.BackColor = Color.AliceBlue;
            page_score.Controls.Add(volontbox);
            page_score.Controls.Add(gtobox);
            page_score.Controls.Add(goldbox);
            page_score.Controls.Add(label2);
            page_score.Controls.Add(label1);
            page_score.Controls.Add(button1);
            page_score.Controls.Add(input_table);
            page_score.ForeColor = SystemColors.ActiveCaptionText;
            page_score.Location = new Point(4, 39);
            page_score.Name = "page_score";
            page_score.Padding = new Padding(3);
            page_score.Size = new Size(963, 527);
            page_score.TabIndex = 0;
            page_score.Text = "Ввод баллов";
            // 
            // volontbox
            // 
            volontbox.AutoSize = true;
            volontbox.Location = new Point(497, 255);
            volontbox.Name = "volontbox";
            volontbox.Size = new Size(219, 34);
            volontbox.TabIndex = 7;
            volontbox.Text = "Книжка волонтера";
            volontbox.UseVisualStyleBackColor = true;
            // 
            // gtobox
            // 
            gtobox.AutoSize = true;
            gtobox.Location = new Point(497, 170);
            gtobox.Name = "gtobox";
            gtobox.Size = new Size(233, 34);
            gtobox.TabIndex = 6;
            gtobox.Text = "Золотой значок ГТО";
            gtobox.UseVisualStyleBackColor = true;
            // 
            // goldbox
            // 
            goldbox.AutoSize = true;
            goldbox.Location = new Point(497, 87);
            goldbox.Name = "goldbox";
            goldbox.Size = new Size(192, 34);
            goldbox.TabIndex = 5;
            goldbox.Text = "Золотая медаль";
            goldbox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.WhiteSmoke;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(497, 26);
            label2.Name = "label2";
            label2.Size = new Size(443, 32);
            label2.TabIndex = 4;
            label2.Text = "Укажите ваши индивидуальные достижения";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(21, 26);
            label1.Name = "label1";
            label1.Size = new Size(356, 32);
            label1.TabIndex = 2;
            label1.Text = "Укажите свои баллы по предметам";
            // 
            // button1
            // 
            button1.Location = new Point(799, 396);
            button1.Name = "button1";
            button1.Size = new Size(139, 49);
            button1.TabIndex = 1;
            button1.Text = "Далее";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // input_table
            // 
            input_table.BackgroundColor = SystemColors.Control;
            input_table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            input_table.GridColor = SystemColors.ActiveBorder;
            input_table.Location = new Point(21, 87);
            input_table.Name = "input_table";
            input_table.RowHeadersWidth = 72;
            input_table.RowTemplate.Height = 37;
            input_table.Size = new Size(455, 358);
            input_table.TabIndex = 0;
            // 
            // page_table
            // 
            page_table.BackColor = Color.AliceBlue;
            page_table.Controls.Add(button3);
            page_table.Controls.Add(button2);
            page_table.Controls.Add(dataGridView);
            page_table.Controls.Add(cmbVuz);
            page_table.Location = new Point(4, 39);
            page_table.Name = "page_table";
            page_table.Padding = new Padding(3);
            page_table.Size = new Size(963, 527);
            page_table.TabIndex = 1;
            page_table.Text = "Выбор вуза";
            // 
            // button3
            // 
            button3.Location = new Point(330, 20);
            button3.Name = "button3";
            button3.Size = new Size(166, 54);
            button3.TabIndex = 3;
            button3.Text = "Обновить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(20, 425);
            button2.Name = "button2";
            button2.Size = new Size(130, 46);
            button2.TabIndex = 2;
            button2.Text = "Назад";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(20, 94);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 72;
            dataGridView.RowTemplate.Height = 37;
            dataGridView.Size = new Size(907, 298);
            dataGridView.TabIndex = 1;
            // 
            // cmbVuz
            // 
            cmbVuz.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVuz.FormattingEnabled = true;
            cmbVuz.Items.AddRange(new object[] { "РТУ МИРЭА", "МГТУ им. Баумана" });
            cmbVuz.Location = new Point(20, 22);
            cmbVuz.Name = "cmbVuz";
            cmbVuz.Size = new Size(285, 38);
            cmbVuz.TabIndex = 0;
            cmbVuz.SelectedIndexChanged += cmbVuz_SelectedIndexChanged;
            // 
            // MyApp
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(986, 589);
            Controls.Add(tabControl1);
            ForeColor = SystemColors.ControlText;
            Name = "MyApp";
            Text = "Выбор специальности";
            Load += MyApp_Load;
            tabControl1.ResumeLayout(false);
            page_score.ResumeLayout(false);
            page_score.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)input_table).EndInit();
            page_table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage page_score;
        private TabPage page_table;
        private DataGridView input_table;
        private Button button1;
        private Label label2;
        private Label label1;
        private CheckBox volontbox;
        private CheckBox gtobox;
        private CheckBox goldbox;
        private ComboBox cmbVuz;
        private DataGridView dataGridView;
        private Button button2;
        private Button button3;
    }
}