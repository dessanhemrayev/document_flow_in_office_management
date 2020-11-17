
namespace MyBD
{
    partial class data
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dobavlenie = new System.Windows.Forms.NumericUpDown();
            this.vibor = new System.Windows.Forms.NumericUpDown();
            this.sozdatbutton = new System.Windows.Forms.Button();
            this.viborbutton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходВОкноРегистрацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходВОкноВходаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбранныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейтиКПросмотруДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dobavlenie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vibor)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(16, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 356);
            this.dataGridView1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Wide Latin", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(8, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Данные.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.viborbutton);
            this.groupBox1.Controls.Add(this.sozdatbutton);
            this.groupBox1.Controls.Add(this.vibor);
            this.groupBox1.Controls.Add(this.dobavlenie);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(171, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 135);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Wide Latin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(26, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Количество добавляемых данных:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Wide Latin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(219, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Выбор данных:";
            // 
            // dobavlenie
            // 
            this.dobavlenie.Location = new System.Drawing.Point(406, 44);
            this.dobavlenie.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dobavlenie.Name = "dobavlenie";
            this.dobavlenie.Size = new System.Drawing.Size(61, 20);
            this.dobavlenie.TabIndex = 2;
            this.dobavlenie.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // vibor
            // 
            this.vibor.Location = new System.Drawing.Point(406, 84);
            this.vibor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vibor.Name = "vibor";
            this.vibor.Size = new System.Drawing.Size(61, 20);
            this.vibor.TabIndex = 3;
            this.vibor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // sozdatbutton
            // 
            this.sozdatbutton.Location = new System.Drawing.Point(480, 41);
            this.sozdatbutton.Name = "sozdatbutton";
            this.sozdatbutton.Size = new System.Drawing.Size(75, 23);
            this.sozdatbutton.TabIndex = 4;
            this.sozdatbutton.Text = "Создать";
            this.sozdatbutton.UseVisualStyleBackColor = true;
            // 
            // viborbutton
            // 
            this.viborbutton.Location = new System.Drawing.Point(480, 84);
            this.viborbutton.Name = "viborbutton";
            this.viborbutton.Size = new System.Drawing.Size(75, 23);
            this.viborbutton.TabIndex = 5;
            this.viborbutton.Text = "Выбрать";
            this.viborbutton.UseVisualStyleBackColor = true;
            this.viborbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактироватьToolStripMenuItem,
            this.обновитьДанныеToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.перейтиКПросмотруДанныхToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.редактироватьToolStripMenuItem.Text = "Загрузить";
            // 
            // обновитьДанныеToolStripMenuItem
            // 
            this.обновитьДанныеToolStripMenuItem.Name = "обновитьДанныеToolStripMenuItem";
            this.обновитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.обновитьДанныеToolStripMenuItem.Text = "Выгрузить";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходИзПрограммыToolStripMenuItem,
            this.выходВОкноРегистрацииToolStripMenuItem,
            this.выходВОкноВходаToolStripMenuItem});
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // выходИзПрограммыToolStripMenuItem
            // 
            this.выходИзПрограммыToolStripMenuItem.Name = "выходИзПрограммыToolStripMenuItem";
            this.выходИзПрограммыToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.выходИзПрограммыToolStripMenuItem.Text = "Выход из программы";
            // 
            // выходВОкноРегистрацииToolStripMenuItem
            // 
            this.выходВОкноРегистрацииToolStripMenuItem.Name = "выходВОкноРегистрацииToolStripMenuItem";
            this.выходВОкноРегистрацииToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.выходВОкноРегистрацииToolStripMenuItem.Text = "Выход в окно регистрации";
            // 
            // выходВОкноВходаToolStripMenuItem
            // 
            this.выходВОкноВходаToolStripMenuItem.Name = "выходВОкноВходаToolStripMenuItem";
            this.выходВОкноВходаToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.выходВОкноВходаToolStripMenuItem.Text = "Выход в окно входа";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбранныйToolStripMenuItem,
            this.всеДанныеToolStripMenuItem});
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // выбранныйToolStripMenuItem
            // 
            this.выбранныйToolStripMenuItem.Name = "выбранныйToolStripMenuItem";
            this.выбранныйToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выбранныйToolStripMenuItem.Text = "Выбранный";
            // 
            // всеДанныеToolStripMenuItem
            // 
            this.всеДанныеToolStripMenuItem.Name = "всеДанныеToolStripMenuItem";
            this.всеДанныеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.всеДанныеToolStripMenuItem.Text = "Все данные";
            // 
            // перейтиКПросмотруДанныхToolStripMenuItem
            // 
            this.перейтиКПросмотруДанныхToolStripMenuItem.Name = "перейтиКПросмотруДанныхToolStripMenuItem";
            this.перейтиКПросмотруДанныхToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.перейтиКПросмотруДанныхToolStripMenuItem.Text = "Перейти к просмотру данных";
            // 
            // data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер данных";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dobavlenie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vibor)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button viborbutton;
        private System.Windows.Forms.Button sozdatbutton;
        private System.Windows.Forms.NumericUpDown vibor;
        private System.Windows.Forms.NumericUpDown dobavlenie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбранныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейтиКПросмотруДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходИзПрограммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходВОкноРегистрацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходВОкноВходаToolStripMenuItem;
    }
}