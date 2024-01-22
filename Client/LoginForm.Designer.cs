
namespace WinForms
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passForgetLabel = new System.Windows.Forms.LinkLabel();
            this.Cinema = new System.Windows.Forms.GroupBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.registerLabel = new System.Windows.Forms.LinkLabel();
            this.Cinema.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(134, 75);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(100, 23);
            this.passwordBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasło";
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(134, 33);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(100, 23);
            this.loginBox.TabIndex = 3;
            this.loginBox.TextChanged += new System.EventHandler(this.loginBox_TextChanged);
            // 
            // passForgetLabel
            // 
            this.passForgetLabel.AutoSize = true;
            this.passForgetLabel.Location = new System.Drawing.Point(16, 123);
            this.passForgetLabel.Name = "passForgetLabel";
            this.passForgetLabel.Size = new System.Drawing.Size(110, 15);
            this.passForgetLabel.TabIndex = 5;
            this.passForgetLabel.TabStop = true;
            this.passForgetLabel.Text = "Zapomniałeś hasła?";
            // 
            // Cinema
            // 
            this.Cinema.Controls.Add(this.loginButton);
            this.Cinema.Controls.Add(this.loginBox);
            this.Cinema.Controls.Add(this.passForgetLabel);
            this.Cinema.Controls.Add(this.label1);
            this.Cinema.Controls.Add(this.label2);
            this.Cinema.Controls.Add(this.passwordBox);
            this.Cinema.Location = new System.Drawing.Point(38, 26);
            this.Cinema.Name = "Cinema";
            this.Cinema.Size = new System.Drawing.Size(263, 179);
            this.Cinema.TabIndex = 6;
            this.Cinema.TabStop = false;
            this.Cinema.Text = "Logowanie";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(159, 119);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "Zaloguj";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.registerLabel);
            this.groupBox1.Location = new System.Drawing.Point(347, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 93);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nie masz konta?";
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Location = new System.Drawing.Point(29, 37);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(62, 15);
            this.registerLabel.TabIndex = 0;
            this.registerLabel.TabStop = true;
            this.registerLabel.Text = "Zarejestruj";
            // 
            // LoginForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 232);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cinema);
            this.Name = "LoginForm";
            this.Text = "Kino";
            this.Cinema.ResumeLayout(false);
            this.Cinema.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox passwordBox;
        private Label label2;
        private TextBox loginBox;
        private LinkLabel passForgetLabel;
        private GroupBox Cinema;
        private GroupBox groupBox1;
        private LinkLabel registerLabel;
        private Button loginButton;
    }
}
