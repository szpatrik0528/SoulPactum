namespace vizsgaremek
{
    partial class Form1
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
            username_textbox = new TextBox();
            password_textbox = new TextBox();
            login_btn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // username_textbox
            // 
            username_textbox.Location = new Point(148, 107);
            username_textbox.Multiline = true;
            username_textbox.Name = "username_textbox";
            username_textbox.Size = new Size(214, 25);
            username_textbox.TabIndex = 0;
            // 
            // password_textbox
            // 
            password_textbox.Location = new Point(148, 156);
            password_textbox.Multiline = true;
            password_textbox.Name = "password_textbox";
            password_textbox.Size = new Size(214, 25);
            password_textbox.TabIndex = 1;
            // 
            // login_btn
            // 
            login_btn.Location = new Point(205, 198);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(75, 23);
            login_btn.TabIndex = 2;
            login_btn.Text = "login";
            login_btn.UseVisualStyleBackColor = true;
            login_btn.Click += login_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(205, 39);
            label1.Name = "label1";
            label1.Size = new Size(157, 65);
            label1.TabIndex = 3;
            label1.Text = "LOGIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(42, 107);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 4;
            label2.Text = "UserName:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(42, 156);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 5;
            label3.Text = "PassWord:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 301);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(login_btn);
            Controls.Add(password_textbox);
            Controls.Add(username_textbox);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox username_textbox;
        private TextBox password_textbox;
        private Button login_btn;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}