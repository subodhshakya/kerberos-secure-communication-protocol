namespace CS670ProjectKerberos
{
    partial class ProjectKerberosForm
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
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.labelProjectNameSignInScreen = new System.Windows.Forms.Label();
            this.groupBoxCredentialsSignInScreen = new System.Windows.Forms.GroupBox();
            this.labelPasswordSignInScreen = new System.Windows.Forms.Label();
            this.labelUsernameSignInScreen = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.groupBoxCredentialsSignInScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSignIn.Location = new System.Drawing.Point(321, 268);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(99, 42);
            this.buttonSignIn.TabIndex = 0;
            this.buttonSignIn.Text = "Sign In";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // labelProjectNameSignInScreen
            // 
            this.labelProjectNameSignInScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProjectNameSignInScreen.AutoSize = true;
            this.labelProjectNameSignInScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjectNameSignInScreen.Location = new System.Drawing.Point(241, 98);
            this.labelProjectNameSignInScreen.Name = "labelProjectNameSignInScreen";
            this.labelProjectNameSignInScreen.Size = new System.Drawing.Size(150, 24);
            this.labelProjectNameSignInScreen.TabIndex = 2;
            this.labelProjectNameSignInScreen.Text = "Project Kerberos";
            // 
            // groupBoxCredentialsSignInScreen
            // 
            this.groupBoxCredentialsSignInScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCredentialsSignInScreen.Controls.Add(this.labelPasswordSignInScreen);
            this.groupBoxCredentialsSignInScreen.Controls.Add(this.labelUsernameSignInScreen);
            this.groupBoxCredentialsSignInScreen.Controls.Add(this.textBoxPassword);
            this.groupBoxCredentialsSignInScreen.Controls.Add(this.textBoxUsername);
            this.groupBoxCredentialsSignInScreen.Location = new System.Drawing.Point(203, 145);
            this.groupBoxCredentialsSignInScreen.Name = "groupBoxCredentialsSignInScreen";
            this.groupBoxCredentialsSignInScreen.Size = new System.Drawing.Size(217, 117);
            this.groupBoxCredentialsSignInScreen.TabIndex = 3;
            this.groupBoxCredentialsSignInScreen.TabStop = false;
            this.groupBoxCredentialsSignInScreen.Text = "Credentials";
            // 
            // labelPasswordSignInScreen
            // 
            this.labelPasswordSignInScreen.AutoSize = true;
            this.labelPasswordSignInScreen.Location = new System.Drawing.Point(82, 65);
            this.labelPasswordSignInScreen.Name = "labelPasswordSignInScreen";
            this.labelPasswordSignInScreen.Size = new System.Drawing.Size(53, 13);
            this.labelPasswordSignInScreen.TabIndex = 7;
            this.labelPasswordSignInScreen.Text = "Password";
            // 
            // labelUsernameSignInScreen
            // 
            this.labelUsernameSignInScreen.AutoSize = true;
            this.labelUsernameSignInScreen.Location = new System.Drawing.Point(79, 19);
            this.labelUsernameSignInScreen.Name = "labelUsernameSignInScreen";
            this.labelUsernameSignInScreen.Size = new System.Drawing.Size(55, 13);
            this.labelUsernameSignInScreen.TabIndex = 6;
            this.labelUsernameSignInScreen.Text = "Username";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(29, 80);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(160, 20);
            this.textBoxPassword.TabIndex = 5;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(29, 35);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(160, 20);
            this.textBoxUsername.TabIndex = 4;
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSignUp.Location = new System.Drawing.Point(203, 268);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(97, 42);
            this.buttonSignUp.TabIndex = 5;
            this.buttonSignUp.Text = "Sign Up";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // ProjectKerberosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.groupBoxCredentialsSignInScreen);
            this.Controls.Add(this.labelProjectNameSignInScreen);
            this.Controls.Add(this.buttonSignIn);
            this.Name = "ProjectKerberosForm";
            this.Text = "Sign In";            
            this.groupBoxCredentialsSignInScreen.ResumeLayout(false);
            this.groupBoxCredentialsSignInScreen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Label labelProjectNameSignInScreen;
        private System.Windows.Forms.GroupBox groupBoxCredentialsSignInScreen;
        private System.Windows.Forms.Label labelPasswordSignInScreen;
        private System.Windows.Forms.Label labelUsernameSignInScreen;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonSignUp;
    }
}

