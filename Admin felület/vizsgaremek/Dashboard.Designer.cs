namespace vizsgaremek
{
    partial class Dashboard
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
            rendeles_id_tb = new TextBox();
            user_id_tb = new TextBox();
            skin_id_tb = new TextBox();
            datum_tb = new TextBox();
            osszeg_tb = new TextBox();
            label1 = new Label();
            insert_btn = new Button();
            update_brn = new Button();
            delete_btn = new Button();
            dataGridView1 = new DataGridView();
            search_btn = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            clear_btn = new Button();
            log_out_btn = new Button();
            exit_btn = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // rendeles_id_tb
            // 
            rendeles_id_tb.Location = new Point(240, 106);
            rendeles_id_tb.Multiline = true;
            rendeles_id_tb.Name = "rendeles_id_tb";
            rendeles_id_tb.Size = new Size(280, 25);
            rendeles_id_tb.TabIndex = 0;
            // 
            // user_id_tb
            // 
            user_id_tb.Location = new Point(240, 154);
            user_id_tb.Multiline = true;
            user_id_tb.Name = "user_id_tb";
            user_id_tb.Size = new Size(280, 25);
            user_id_tb.TabIndex = 1;
            // 
            // skin_id_tb
            // 
            skin_id_tb.Location = new Point(240, 201);
            skin_id_tb.Multiline = true;
            skin_id_tb.Name = "skin_id_tb";
            skin_id_tb.Size = new Size(280, 25);
            skin_id_tb.TabIndex = 2;
            // 
            // datum_tb
            // 
            datum_tb.Location = new Point(240, 248);
            datum_tb.Multiline = true;
            datum_tb.Name = "datum_tb";
            datum_tb.Size = new Size(280, 20);
            datum_tb.TabIndex = 3;
            // 
            // osszeg_tb
            // 
            osszeg_tb.Location = new Point(240, 287);
            osszeg_tb.Multiline = true;
            osszeg_tb.Name = "osszeg_tb";
            osszeg_tb.Size = new Size(280, 20);
            osszeg_tb.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(56, 106);
            label1.Name = "label1";
            label1.Size = new Size(178, 25);
            label1.TabIndex = 5;
            label1.Text = "Rendelés azonosító:";
            // 
            // insert_btn
            // 
            insert_btn.Location = new Point(170, 369);
            insert_btn.Name = "insert_btn";
            insert_btn.Size = new Size(75, 23);
            insert_btn.TabIndex = 10;
            insert_btn.Text = "Insert";
            insert_btn.UseVisualStyleBackColor = true;
            insert_btn.Click += insert_btn_Click;
            // 
            // update_brn
            // 
            update_brn.Location = new Point(251, 369);
            update_brn.Name = "update_brn";
            update_brn.Size = new Size(75, 23);
            update_brn.TabIndex = 11;
            update_brn.Text = "Update";
            update_brn.UseVisualStyleBackColor = true;
            update_brn.Click += update_brn_Click;
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(332, 369);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(75, 23);
            delete_btn.TabIndex = 12;
            delete_btn.Text = "Delete";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Menu;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = SystemColors.Menu;
            dataGridView1.Location = new Point(43, 413);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(659, 180);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // search_btn
            // 
            search_btn.Location = new Point(413, 369);
            search_btn.Name = "search_btn";
            search_btn.Size = new Size(75, 23);
            search_btn.TabIndex = 14;
            search_btn.Text = "Search";
            search_btn.UseVisualStyleBackColor = true;
            search_btn.Click += search_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 154);
            label2.Name = "label2";
            label2.Size = new Size(202, 25);
            label2.TabIndex = 15;
            label2.Text = "Felhasználó azonosító:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(69, 201);
            label3.Name = "label3";
            label3.Size = new Size(165, 25);
            label3.TabIndex = 16;
            label3.Text = "Kinézet azonosító:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(162, 248);
            label4.Name = "label4";
            label4.Size = new Size(72, 25);
            label4.TabIndex = 17;
            label4.Text = "Dátum:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(158, 282);
            label5.Name = "label5";
            label5.Size = new Size(76, 25);
            label5.TabIndex = 18;
            label5.Text = "Összeg:";
            // 
            // clear_btn
            // 
            clear_btn.Location = new Point(494, 369);
            clear_btn.Name = "clear_btn";
            clear_btn.Size = new Size(75, 23);
            clear_btn.TabIndex = 19;
            clear_btn.Text = "Clear";
            clear_btn.UseVisualStyleBackColor = true;
            clear_btn.Click += clear_btn_Click;
            // 
            // log_out_btn
            // 
            log_out_btn.Location = new Point(12, 12);
            log_out_btn.Name = "log_out_btn";
            log_out_btn.Size = new Size(75, 23);
            log_out_btn.TabIndex = 20;
            log_out_btn.Text = "Log Out";
            log_out_btn.UseVisualStyleBackColor = true;
            log_out_btn.Click += log_out_btn_Click;
            // 
            // exit_btn
            // 
            exit_btn.Location = new Point(713, 12);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(75, 23);
            exit_btn.TabIndex = 21;
            exit_btn.Text = "EXIT";
            exit_btn.UseVisualStyleBackColor = true;
            exit_btn.Click += exit_btn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(713, 55);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 22;
            button1.Text = "MENU";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 605);
            Controls.Add(button1);
            Controls.Add(exit_btn);
            Controls.Add(log_out_btn);
            Controls.Add(clear_btn);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(search_btn);
            Controls.Add(dataGridView1);
            Controls.Add(delete_btn);
            Controls.Add(update_brn);
            Controls.Add(insert_btn);
            Controls.Add(label1);
            Controls.Add(osszeg_tb);
            Controls.Add(datum_tb);
            Controls.Add(skin_id_tb);
            Controls.Add(user_id_tb);
            Controls.Add(rendeles_id_tb);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox rendeles_id_tb;
        private TextBox user_id_tb;
        private TextBox skin_id_tb;
        private TextBox datum_tb;
        private TextBox osszeg_tb;
        private Label label1;
        private Button insert_btn;
        private Button update_brn;
        private Button delete_btn;
        private DataGridView dataGridView1;
        private Button search_btn;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button clear_btn;
        private Button log_out_btn;
        private Button exit_btn;
        private Button button1;
    }
}