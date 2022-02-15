namespace ZampGUI
{
    partial class FormDonate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDonate));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBitcoin = new System.Windows.Forms.PictureBox();
            this.labelBitcoin = new System.Windows.Forms.Label();
            this.txtBitcoin = new System.Windows.Forms.TextBox();
            this.pictureEthereum = new System.Windows.Forms.PictureBox();
            this.txtEthereum = new System.Windows.Forms.TextBox();
            this.labelEth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBitcoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEthereum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "If you like this software please consider a little donation";
            // 
            // pictureBitcoin
            // 
            this.pictureBitcoin.Image = global::ZampGUI.Properties.Resources.cryptocurrency;
            this.pictureBitcoin.Location = new System.Drawing.Point(35, 87);
            this.pictureBitcoin.Name = "pictureBitcoin";
            this.pictureBitcoin.Size = new System.Drawing.Size(130, 128);
            this.pictureBitcoin.TabIndex = 1;
            this.pictureBitcoin.TabStop = false;
            // 
            // labelBitcoin
            // 
            this.labelBitcoin.AutoSize = true;
            this.labelBitcoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelBitcoin.Location = new System.Drawing.Point(305, 117);
            this.labelBitcoin.Name = "labelBitcoin";
            this.labelBitcoin.Size = new System.Drawing.Size(259, 15);
            this.labelBitcoin.TabIndex = 2;
            this.labelBitcoin.Text = "Bitcoin - click here to copy Address";
            this.labelBitcoin.Click += new System.EventHandler(this.labelBitcoin_Click);
            // 
            // txtBitcoin
            // 
            this.txtBitcoin.Location = new System.Drawing.Point(255, 147);
            this.txtBitcoin.Name = "txtBitcoin";
            this.txtBitcoin.ReadOnly = true;
            this.txtBitcoin.Size = new System.Drawing.Size(337, 21);
            this.txtBitcoin.TabIndex = 3;
            this.txtBitcoin.Text = "39qHhS8PKzSv8AWzrcQFTg8Nk84AphCmPe";
            this.txtBitcoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureEthereum
            // 
            this.pictureEthereum.Image = global::ZampGUI.Properties.Resources.ethereum;
            this.pictureEthereum.Location = new System.Drawing.Point(58, 239);
            this.pictureEthereum.Name = "pictureEthereum";
            this.pictureEthereum.Size = new System.Drawing.Size(86, 89);
            this.pictureEthereum.TabIndex = 4;
            this.pictureEthereum.TabStop = false;
            // 
            // txtEthereum
            // 
            this.txtEthereum.Location = new System.Drawing.Point(255, 278);
            this.txtEthereum.Name = "txtEthereum";
            this.txtEthereum.ReadOnly = true;
            this.txtEthereum.Size = new System.Drawing.Size(337, 21);
            this.txtEthereum.TabIndex = 5;
            this.txtEthereum.Text = "0x74e525323217A4472D4db41A116e6Db067cF8b8a";
            this.txtEthereum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelEth
            // 
            this.labelEth.AutoSize = true;
            this.labelEth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEth.Location = new System.Drawing.Point(298, 251);
            this.labelEth.Name = "labelEth";
            this.labelEth.Size = new System.Drawing.Size(266, 15);
            this.labelEth.TabIndex = 4;
            this.labelEth.Text = "Ethereum - click here to copy Address";
            this.labelEth.Click += new System.EventHandler(this.labelEth_Click);
            // 
            // FormDonate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 379);
            this.Controls.Add(this.txtEthereum);
            this.Controls.Add(this.labelEth);
            this.Controls.Add(this.pictureEthereum);
            this.Controls.Add(this.txtBitcoin);
            this.Controls.Add(this.labelBitcoin);
            this.Controls.Add(this.pictureBitcoin);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormDonate";
            this.Text = "FormDonate";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBitcoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEthereum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBitcoin;
        private System.Windows.Forms.Label labelBitcoin;
        private System.Windows.Forms.TextBox txtBitcoin;
        private System.Windows.Forms.PictureBox pictureEthereum;
        private System.Windows.Forms.TextBox txtEthereum;
        private System.Windows.Forms.Label labelEth;
    }
}