namespace DT_API_CSharp_Example
{
	partial class ApplicationWindow
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
			this.RequestUserAuth_btn = new System.Windows.Forms.Button();
			this.CheckAuthStatus_btn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ResetBtn = new System.Windows.Forms.Button();
			this.Deauth_btn = new System.Windows.Forms.Button();
			this.ProfileLookup_btn = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Response_txt = new System.Windows.Forms.RichTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.AppKey_txt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Domain_txt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// RequestUserAuth_btn
			// 
			this.RequestUserAuth_btn.Dock = System.Windows.Forms.DockStyle.Top;
			this.RequestUserAuth_btn.Location = new System.Drawing.Point(3, 16);
			this.RequestUserAuth_btn.Name = "RequestUserAuth_btn";
			this.RequestUserAuth_btn.Size = new System.Drawing.Size(194, 23);
			this.RequestUserAuth_btn.TabIndex = 0;
			this.RequestUserAuth_btn.Text = "Request User Authentication";
			this.RequestUserAuth_btn.UseVisualStyleBackColor = true;
			this.RequestUserAuth_btn.Click += new System.EventHandler(this.RequestUserAuth_btn_ClickAsync);
			// 
			// CheckAuthStatus_btn
			// 
			this.CheckAuthStatus_btn.Dock = System.Windows.Forms.DockStyle.Top;
			this.CheckAuthStatus_btn.Enabled = false;
			this.CheckAuthStatus_btn.Location = new System.Drawing.Point(3, 39);
			this.CheckAuthStatus_btn.Name = "CheckAuthStatus_btn";
			this.CheckAuthStatus_btn.Size = new System.Drawing.Size(194, 23);
			this.CheckAuthStatus_btn.TabIndex = 1;
			this.CheckAuthStatus_btn.Text = "Check Authentication Status";
			this.CheckAuthStatus_btn.UseVisualStyleBackColor = true;
			this.CheckAuthStatus_btn.Click += new System.EventHandler(this.CheckAuthStatus_btn_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ResetBtn);
			this.groupBox1.Controls.Add(this.Deauth_btn);
			this.groupBox1.Controls.Add(this.ProfileLookup_btn);
			this.groupBox1.Controls.Add(this.CheckAuthStatus_btn);
			this.groupBox1.Controls.Add(this.RequestUserAuth_btn);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 450);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "API Calls";
			// 
			// ResetBtn
			// 
			this.ResetBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ResetBtn.Location = new System.Drawing.Point(3, 424);
			this.ResetBtn.Name = "ResetBtn";
			this.ResetBtn.Size = new System.Drawing.Size(194, 23);
			this.ResetBtn.TabIndex = 4;
			this.ResetBtn.Text = "Reset";
			this.ResetBtn.UseVisualStyleBackColor = true;
			this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
			// 
			// Deauth_btn
			// 
			this.Deauth_btn.Dock = System.Windows.Forms.DockStyle.Top;
			this.Deauth_btn.Enabled = false;
			this.Deauth_btn.Location = new System.Drawing.Point(3, 85);
			this.Deauth_btn.Name = "Deauth_btn";
			this.Deauth_btn.Size = new System.Drawing.Size(194, 23);
			this.Deauth_btn.TabIndex = 3;
			this.Deauth_btn.Text = "Deauthenticate";
			this.Deauth_btn.UseVisualStyleBackColor = true;
			// 
			// ProfileLookup_btn
			// 
			this.ProfileLookup_btn.Dock = System.Windows.Forms.DockStyle.Top;
			this.ProfileLookup_btn.Enabled = false;
			this.ProfileLookup_btn.Location = new System.Drawing.Point(3, 62);
			this.ProfileLookup_btn.Name = "ProfileLookup_btn";
			this.ProfileLookup_btn.Size = new System.Drawing.Size(194, 23);
			this.ProfileLookup_btn.TabIndex = 2;
			this.ProfileLookup_btn.Text = "Profile Lookup";
			this.ProfileLookup_btn.UseVisualStyleBackColor = true;
			this.ProfileLookup_btn.Click += new System.EventHandler(this.ProfileLookup_btn_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.Response_txt);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.AppKey_txt);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.Domain_txt);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(200, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(600, 450);
			this.panel1.TabIndex = 3;
			// 
			// Response_txt
			// 
			this.Response_txt.AcceptsTab = true;
			this.Response_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.Response_txt.Location = new System.Drawing.Point(70, 68);
			this.Response_txt.Name = "Response_txt";
			this.Response_txt.ReadOnly = true;
			this.Response_txt.Size = new System.Drawing.Size(518, 370);
			this.Response_txt.TabIndex = 6;
			this.Response_txt.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Response:";
			// 
			// AppKey_txt
			// 
			this.AppKey_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.AppKey_txt.Location = new System.Drawing.Point(70, 39);
			this.AppKey_txt.Name = "AppKey_txt";
			this.AppKey_txt.Size = new System.Drawing.Size(518, 20);
			this.AppKey_txt.TabIndex = 3;
			this.AppKey_txt.Text = "Ynzp013b7qwrgzXR5jnIVYrGmIUzGe5x2UKOoZuJ3xZ0Y29gkZbFpmvkfCHtOnbp";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "APP Key:";
			// 
			// Domain_txt
			// 
			this.Domain_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.Domain_txt.Location = new System.Drawing.Point(70, 16);
			this.Domain_txt.Name = "Domain_txt";
			this.Domain_txt.Size = new System.Drawing.Size(518, 20);
			this.Domain_txt.TabIndex = 1;
			this.Domain_txt.Text = "https://api2.donutteam.com";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Domain:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Donut Team API C# Example";
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button RequestUserAuth_btn;
		private System.Windows.Forms.Button CheckAuthStatus_btn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox Domain_txt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button ProfileLookup_btn;
		private System.Windows.Forms.TextBox AppKey_txt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox Response_txt;
		private System.Windows.Forms.Button Deauth_btn;
		private System.Windows.Forms.Button ResetBtn;
	}
}

