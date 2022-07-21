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
            this.pictureQRBitcoin = new System.Windows.Forms.PictureBox();
            this.pictureQReth = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBitcoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEthereum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQRBitcoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQReth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(718, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "If you like this software please consider a little donation";
            // 
            // pictureBitcoin
            // 
            this.pictureBitcoin.Image = global::ZampGUI.Properties.Resources.cryptocurrency;
            this.pictureBitcoin.Location = new System.Drawing.Point(282, 152);
            this.pictureBitcoin.Name = "pictureBitcoin";
            this.pictureBitcoin.Size = new System.Drawing.Size(121, 128);
            this.pictureBitcoin.TabIndex = 1;
            this.pictureBitcoin.TabStop = false;
            // 
            // labelBitcoin
            // 
            this.labelBitcoin.AutoSize = true;
            this.labelBitcoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelBitcoin.Location = new System.Drawing.Point(492, 186);
            this.labelBitcoin.Name = "labelBitcoin";
            this.labelBitcoin.Size = new System.Drawing.Size(332, 17);
            this.labelBitcoin.TabIndex = 2;
            this.labelBitcoin.Text = "Bitcoin - click here to copy Address";
            this.labelBitcoin.Click += new System.EventHandler(this.labelBitcoin_Click);
            // 
            // txtBitcoin
            // 
            this.txtBitcoin.Location = new System.Drawing.Point(406, 229);
            this.txtBitcoin.Name = "txtBitcoin";
            this.txtBitcoin.ReadOnly = true;
            this.txtBitcoin.Size = new System.Drawing.Size(467, 24);
            this.txtBitcoin.TabIndex = 3;
            this.txtBitcoin.Text = "39qHhS8PKzSv8AWzrcQFTg8Nk84AphCmPe";
            this.txtBitcoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureEthereum
            // 
            this.pictureEthereum.Image = global::ZampGUI.Properties.Resources.ethereum;
            this.pictureEthereum.Location = new System.Drawing.Point(298, 451);
            this.pictureEthereum.Name = "pictureEthereum";
            this.pictureEthereum.Size = new System.Drawing.Size(86, 89);
            this.pictureEthereum.TabIndex = 4;
            this.pictureEthereum.TabStop = false;
            // 
            // txtEthereum
            // 
            this.txtEthereum.Location = new System.Drawing.Point(406, 503);
            this.txtEthereum.Name = "txtEthereum";
            this.txtEthereum.ReadOnly = true;
            this.txtEthereum.Size = new System.Drawing.Size(467, 24);
            this.txtEthereum.TabIndex = 5;
            this.txtEthereum.Text = "0x74e525323217A4472D4db41A116e6Db067cF8b8a";
            this.txtEthereum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelEth
            // 
            this.labelEth.AutoSize = true;
            this.labelEth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEth.Location = new System.Drawing.Point(483, 465);
            this.labelEth.Name = "labelEth";
            this.labelEth.Size = new System.Drawing.Size(341, 17);
            this.labelEth.TabIndex = 4;
            this.labelEth.Text = "Ethereum - click here to copy Address";
            this.labelEth.Click += new System.EventHandler(this.labelEth_Click);
            // 
            // pictureQRBitcoin
            // 
            this.pictureQRBitcoin.Location = new System.Drawing.Point(12, 92);
            this.pictureQRBitcoin.Name = "pictureQRBitcoin";
            this.pictureQRBitcoin.Size = new System.Drawing.Size(250, 250);
            this.pictureQRBitcoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureQRBitcoin.TabIndex = 6;
            this.pictureQRBitcoin.TabStop = false;
            // 
            // pictureQReth
            // 
            this.pictureQReth.Location = new System.Drawing.Point(12, 377);
            this.pictureQReth.Name = "pictureQReth";
            this.pictureQReth.Size = new System.Drawing.Size(250, 250);
            this.pictureQReth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureQReth.TabIndex = 7;
            this.pictureQReth.TabStop = false;
            // 
            // FormDonate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 648);
            this.Controls.Add(this.pictureQReth);
            this.Controls.Add(this.pictureQRBitcoin);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormDonate";
            this.Load += new System.EventHandler(this.FormDonate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBitcoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEthereum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQRBitcoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQReth)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureQRBitcoin;
        private System.Windows.Forms.PictureBox pictureQReth;
    }
}