
namespace Gameshop_AdoNet
{
	partial class Glavna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glavna));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKatalog = new System.Windows.Forms.Button();
            this.btnKompanije = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(219, 67);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(927, 728);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnKatalog
            // 
            this.btnKatalog.Location = new System.Drawing.Point(19, 67);
            this.btnKatalog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKatalog.Name = "btnKatalog";
            this.btnKatalog.Size = new System.Drawing.Size(179, 100);
            this.btnKatalog.TabIndex = 1;
            this.btnKatalog.Text = "Katalog";
            this.btnKatalog.UseVisualStyleBackColor = true;
            this.btnKatalog.Click += new System.EventHandler(this.btnKatalog_Click);
            // 
            // btnKompanije
            // 
            this.btnKompanije.Enabled = false;
            this.btnKompanije.Location = new System.Drawing.Point(19, 202);
            this.btnKompanije.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKompanije.Name = "btnKompanije";
            this.btnKompanije.Size = new System.Drawing.Size(179, 98);
            this.btnKompanije.TabIndex = 2;
            this.btnKompanije.Text = "Kompanije";
            this.btnKompanije.UseVisualStyleBackColor = true;
            // 
            // Glavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 890);
            this.Controls.Add(this.btnKompanije);
            this.Controls.Add(this.btnKatalog);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Glavna";
            this.Text = "Gameshop";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnKatalog;
		private System.Windows.Forms.Button btnKompanije;
	}
}

