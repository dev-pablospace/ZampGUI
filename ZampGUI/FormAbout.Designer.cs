
namespace ZampGUI
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxHome = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmail = new System.Windows.Forms.PictureBox();
            this.pictureBoxGithub = new System.Windows.Forms.PictureBox();
            this.pictureBoxSourceforge = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGithub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSourceforge)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(78, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(20, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "ZampGUI \r\nGUI interface for running Web Server and Database";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBoxHome
            // 
            this.pictureBoxHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxHome.Image = global::ZampGUI.Properties.Resources.about_home;
            this.pictureBoxHome.Location = new System.Drawing.Point(78, 238);
            this.pictureBoxHome.Name = "pictureBoxHome";
            this.pictureBoxHome.Size = new System.Drawing.Size(100, 77);
            this.pictureBoxHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHome.TabIndex = 3;
            this.pictureBoxHome.TabStop = false;
            this.pictureBoxHome.Click += new System.EventHandler(this.pictureBoxHome_Click);
            // 
            // pictureBoxEmail
            // 
            this.pictureBoxEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEmail.Image = global::ZampGUI.Properties.Resources.about_email;
            this.pictureBoxEmail.Location = new System.Drawing.Point(211, 238);
            this.pictureBoxEmail.Name = "pictureBoxEmail";
            this.pictureBoxEmail.Size = new System.Drawing.Size(100, 77);
            this.pictureBoxEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEmail.TabIndex = 4;
            this.pictureBoxEmail.TabStop = false;
            this.pictureBoxEmail.Click += new System.EventHandler(this.pictureBoxEmail_Click);
            // 
            // pictureBoxGithub
            // 
            this.pictureBoxGithub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGithub.Image = global::ZampGUI.Properties.Resources.about_github;
            this.pictureBoxGithub.Location = new System.Drawing.Point(342, 238);
            this.pictureBoxGithub.Name = "pictureBoxGithub";
            this.pictureBoxGithub.Size = new System.Drawing.Size(100, 77);
            this.pictureBoxGithub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGithub.TabIndex = 5;
            this.pictureBoxGithub.TabStop = false;
            this.pictureBoxGithub.Click += new System.EventHandler(this.pictureBoxGithub_Click);
            // 
            // pictureBoxSourceforge
            // 
            this.pictureBoxSourceforge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSourceforge.Image = global::ZampGUI.Properties.Resources.about_Sourceforge;
            this.pictureBoxSourceforge.Location = new System.Drawing.Point(78, 321);
            this.pictureBoxSourceforge.Name = "pictureBoxSourceforge";
            this.pictureBoxSourceforge.Size = new System.Drawing.Size(364, 61);
            this.pictureBoxSourceforge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSourceforge.TabIndex = 6;
            this.pictureBoxSourceforge.TabStop = false;
            this.pictureBoxSourceforge.Click += new System.EventHandler(this.pictureBoxSourceforge_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 469);
            this.Controls.Add(this.pictureBoxSourceforge);
            this.Controls.Add(this.pictureBoxGithub);
            this.Controls.Add(this.pictureBoxEmail);
            this.Controls.Add(this.pictureBoxHome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(529, 525);
            this.MinimumSize = new System.Drawing.Size(529, 525);
            this.Name = "FormAbout";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGithub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSourceforge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxHome;
        private System.Windows.Forms.PictureBox pictureBoxEmail;
        private System.Windows.Forms.PictureBox pictureBoxGithub;
        private System.Windows.Forms.PictureBox pictureBoxSourceforge;
    }
}