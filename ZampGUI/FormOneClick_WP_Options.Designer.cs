namespace ZampGUI
{
    partial class FormOneClick_WP_Options
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
            this.txtNumPost = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkOverwriteWebSite = new System.Windows.Forms.CheckBox();
            this.checkDisableAutoUpdate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtNumericPostRevision = new System.Windows.Forms.NumericUpDown();
            this.checkEnableWPPostRevision = new System.Windows.Forms.CheckBox();
            this.checkRemoveDefaultPlugin = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPluginList = new System.Windows.Forms.TextBox();
            this.txtThemeList = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkRemoveDefaultTheme = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumericPostRevision)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumPost
            // 
            this.txtNumPost.Location = new System.Drawing.Point(145, 19);
            this.txtNumPost.Name = "txtNumPost";
            this.txtNumPost.Size = new System.Drawing.Size(68, 21);
            this.txtNumPost.TabIndex = 0;
            this.txtNumPost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Create Dummy Post";
            // 
            // checkOverwriteWebSite
            // 
            this.checkOverwriteWebSite.AutoSize = true;
            this.checkOverwriteWebSite.Location = new System.Drawing.Point(26, 62);
            this.checkOverwriteWebSite.Name = "checkOverwriteWebSite";
            this.checkOverwriteWebSite.Size = new System.Drawing.Size(218, 19);
            this.checkOverwriteWebSite.TabIndex = 2;
            this.checkOverwriteWebSite.Text = "Overwrite existing website (if exists)";
            this.checkOverwriteWebSite.UseVisualStyleBackColor = true;
            // 
            // checkDisableAutoUpdate
            // 
            this.checkDisableAutoUpdate.AutoSize = true;
            this.checkDisableAutoUpdate.Location = new System.Drawing.Point(26, 109);
            this.checkDisableAutoUpdate.Name = "checkDisableAutoUpdate";
            this.checkDisableAutoUpdate.Size = new System.Drawing.Size(138, 19);
            this.checkDisableAutoUpdate.TabIndex = 3;
            this.checkDisableAutoUpdate.Text = "Disable Auto Update";
            this.checkDisableAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Site Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(453, 15);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(239, 21);
            this.txtSiteName.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(453, 62);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(239, 21);
            this.txtDescription.TabIndex = 7;
            // 
            // txtNumericPostRevision
            // 
            this.txtNumericPostRevision.Enabled = false;
            this.txtNumericPostRevision.Location = new System.Drawing.Point(557, 107);
            this.txtNumericPostRevision.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtNumericPostRevision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumericPostRevision.Name = "txtNumericPostRevision";
            this.txtNumericPostRevision.Size = new System.Drawing.Size(68, 21);
            this.txtNumericPostRevision.TabIndex = 9;
            this.txtNumericPostRevision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumericPostRevision.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkEnableWPPostRevision
            // 
            this.checkEnableWPPostRevision.AutoSize = true;
            this.checkEnableWPPostRevision.Location = new System.Drawing.Point(381, 107);
            this.checkEnableWPPostRevision.Name = "checkEnableWPPostRevision";
            this.checkEnableWPPostRevision.Size = new System.Drawing.Size(155, 19);
            this.checkEnableWPPostRevision.TabIndex = 10;
            this.checkEnableWPPostRevision.Text = "WP_POST_REVISIONS";
            this.checkEnableWPPostRevision.UseVisualStyleBackColor = true;
            this.checkEnableWPPostRevision.CheckedChanged += new System.EventHandler(this.checkEnableWPPostRevision_CheckedChanged);
            // 
            // checkRemoveDefaultPlugin
            // 
            this.checkRemoveDefaultPlugin.AutoSize = true;
            this.checkRemoveDefaultPlugin.Location = new System.Drawing.Point(26, 154);
            this.checkRemoveDefaultPlugin.Name = "checkRemoveDefaultPlugin";
            this.checkRemoveDefaultPlugin.Size = new System.Drawing.Size(152, 19);
            this.checkRemoveDefaultPlugin.TabIndex = 11;
            this.checkRemoveDefaultPlugin.Text = "Remove Default Plugin";
            this.checkRemoveDefaultPlugin.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Install plugin (slug list)";
            // 
            // txtPluginList
            // 
            this.txtPluginList.Location = new System.Drawing.Point(26, 228);
            this.txtPluginList.Name = "txtPluginList";
            this.txtPluginList.Size = new System.Drawing.Size(311, 21);
            this.txtPluginList.TabIndex = 13;
            // 
            // txtThemeList
            // 
            this.txtThemeList.Location = new System.Drawing.Point(381, 228);
            this.txtThemeList.Name = "txtThemeList";
            this.txtThemeList.Size = new System.Drawing.Size(311, 21);
            this.txtThemeList.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Install theme (slug list)";
            // 
            // checkRemoveDefaultTheme
            // 
            this.checkRemoveDefaultTheme.AutoSize = true;
            this.checkRemoveDefaultTheme.Location = new System.Drawing.Point(381, 156);
            this.checkRemoveDefaultTheme.Name = "checkRemoveDefaultTheme";
            this.checkRemoveDefaultTheme.Size = new System.Drawing.Size(156, 19);
            this.checkRemoveDefaultTheme.TabIndex = 16;
            this.checkRemoveDefaultTheme.Text = "Remove Default Theme";
            this.checkRemoveDefaultTheme.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(26, 280);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(145, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormOneClick_WP_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 322);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.checkRemoveDefaultTheme);
            this.Controls.Add(this.txtThemeList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPluginList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkRemoveDefaultPlugin);
            this.Controls.Add(this.checkEnableWPPostRevision);
            this.Controls.Add(this.txtNumericPostRevision);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkDisableAutoUpdate);
            this.Controls.Add(this.checkOverwriteWebSite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormOneClick_WP_Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WP Options";
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumericPostRevision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtNumPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkOverwriteWebSite;
        private System.Windows.Forms.CheckBox checkDisableAutoUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.NumericUpDown txtNumericPostRevision;
        private System.Windows.Forms.CheckBox checkEnableWPPostRevision;
        private System.Windows.Forms.CheckBox checkRemoveDefaultPlugin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPluginList;
        private System.Windows.Forms.TextBox txtThemeList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkRemoveDefaultTheme;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}