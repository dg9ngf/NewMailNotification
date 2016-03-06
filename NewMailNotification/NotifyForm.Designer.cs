namespace NewMailNotification
{
	partial class NotifyForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.captionLabel = new System.Windows.Forms.Label();
			this.senderLabel = new System.Windows.Forms.Label();
			this.subjectLabel = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// captionLabel
			// 
			this.captionLabel.AutoEllipsis = true;
			this.captionLabel.AutoSize = true;
			this.captionLabel.Location = new System.Drawing.Point(9, 9);
			this.captionLabel.Margin = new System.Windows.Forms.Padding(0);
			this.captionLabel.Name = "captionLabel";
			this.captionLabel.Size = new System.Drawing.Size(76, 20);
			this.captionLabel.TabIndex = 0;
			this.captionLabel.Text = "New mail!";
			this.captionLabel.UseMnemonic = false;
			this.captionLabel.Click += new System.EventHandler(this.NotifyForm_Click);
			// 
			// senderLabel
			// 
			this.senderLabel.AutoEllipsis = true;
			this.senderLabel.AutoSize = true;
			this.senderLabel.Location = new System.Drawing.Point(9, 57);
			this.senderLabel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.senderLabel.Name = "senderLabel";
			this.senderLabel.Size = new System.Drawing.Size(55, 20);
			this.senderLabel.TabIndex = 0;
			this.senderLabel.Text = "Sender";
			this.senderLabel.UseMnemonic = false;
			this.senderLabel.Click += new System.EventHandler(this.NotifyForm_Click);
			// 
			// subjectLabel
			// 
			this.subjectLabel.AutoEllipsis = true;
			this.subjectLabel.AutoSize = true;
			this.subjectLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.subjectLabel.Location = new System.Drawing.Point(9, 33);
			this.subjectLabel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.subjectLabel.Name = "subjectLabel";
			this.subjectLabel.Size = new System.Drawing.Size(60, 20);
			this.subjectLabel.TabIndex = 0;
			this.subjectLabel.Text = "Subject";
			this.subjectLabel.UseMnemonic = false;
			this.subjectLabel.Click += new System.EventHandler(this.NotifyForm_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(113)))), ((int)(((byte)(175)))));
			this.panel1.Controls.Add(this.captionLabel);
			this.panel1.Controls.Add(this.senderLabel);
			this.panel1.Controls.Add(this.subjectLabel);
			this.panel1.Location = new System.Drawing.Point(1, 1);
			this.panel1.Margin = new System.Windows.Forms.Padding(1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(383, 89);
			this.panel1.TabIndex = 1;
			this.panel1.Click += new System.EventHandler(this.NotifyForm_Click);
			// 
			// NotifyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(382, 88);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "NotifyForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "NewMailNotification";
			this.TopMost = true;
			this.Click += new System.EventHandler(this.NotifyForm_Click);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label captionLabel;
		private System.Windows.Forms.Label senderLabel;
		private System.Windows.Forms.Label subjectLabel;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel panel1;
	}
}

