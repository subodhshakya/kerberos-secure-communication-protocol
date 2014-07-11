namespace CS670ProjectKerberos
{
    partial class SignUpScreen
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
            this.groupBoxCreateAccount = new System.Windows.Forms.GroupBox();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.groupBoxCreateAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCreateAccount
            // 
            this.groupBoxCreateAccount.Controls.Add(this.buttonSignUp);
            this.groupBoxCreateAccount.Controls.Add(this.textBoxConfirmPassword);
            this.groupBoxCreateAccount.Controls.Add(this.labelConfirmPassword);
            this.groupBoxCreateAccount.Controls.Add(this.textBoxPassword);
            this.groupBoxCreateAccount.Controls.Add(this.labelPassword);
            this.groupBoxCreateAccount.Controls.Add(this.textBoxUsername);
            this.groupBoxCreateAccount.Controls.Add(this.labelUsername);
            this.groupBoxCreateAccount.Location = new System.Drawing.Point(129, 104);
            this.groupBoxCreateAccount.Name = "groupBoxCreateAccount";
            this.groupBoxCreateAccount.Size = new System.Drawing.Size(353, 212);
            this.groupBoxCreateAccount.TabIndex = 7;
            this.groupBoxCreateAccount.TabStop = false;
            this.groupBoxCreateAccount.Text = "Create Account";
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(137, 151);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(97, 42);
            this.buttonSignUp.TabIndex = 13;
            this.buttonSignUp.Text = "Sign Up";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(137, 109);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(180, 20);
            this.textBoxConfirmPassword.TabIndex = 12;
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(30, 112);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(94, 13);
            this.labelConfirmPassword.TabIndex = 11;
            this.labelConfirmPassword.Text = "Confirm Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(137, 74);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(180, 20);
            this.textBoxPassword.TabIndex = 10;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(30, 77);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(137, 39);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(180, 20);
            this.textBoxUsername.TabIndex = 8;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(30, 42);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 7;
            this.labelUsername.Text = "Username:";
            // 
            // SignUpScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.groupBoxCreateAccount);
            this.MaximizeBox = false;
            this.Name = "SignUpScreen";
            this.Text = "Sign Up";
            this.groupBoxCreateAccount.ResumeLayout(false);
            this.groupBoxCreateAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCreateAccount;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelUsername;

    }
}