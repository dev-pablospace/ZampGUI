namespace ZampGUI
{
    partial class FormOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.txtPathEditor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_http = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_https = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_mariadb = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialogEditor = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectEdit = new System.Windows.Forms.Button();
            this.txtPathConsole = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBackUpAllDBOnExit = new System.Windows.Forms.CheckBox();
            this.checkUpdateZampgui = new System.Windows.Forms.CheckBox();
            this.txtBackupSQLFolder = new System.Windows.Forms.TextBox();
            this.btnChooseBackupFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_http)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_https)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mariadb)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPathEditor
            // 
            this.txtPathEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathEditor.Location = new System.Drawing.Point(15, 14);
            this.txtPathEditor.Name = "txtPathEditor";
            this.txtPathEditor.Size = new System.Drawing.Size(545, 21);
            this.txtPathEditor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Http port";
            // 
            // numericUpDown_http
            // 
            this.numericUpDown_http.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_http.Location = new System.Drawing.Point(14, 296);
            this.numericUpDown_http.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_http.Name = "numericUpDown_http";
            this.numericUpDown_http.Size = new System.Drawing.Size(114, 21);
            this.numericUpDown_http.TabIndex = 4;
            this.numericUpDown_http.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_https
            // 
            this.numericUpDown_https.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_https.Location = new System.Drawing.Point(270, 296);
            this.numericUpDown_https.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_https.Name = "numericUpDown_https";
            this.numericUpDown_https.Size = new System.Drawing.Size(121, 21);
            this.numericUpDown_https.TabIndex = 6;
            this.numericUpDown_https.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_https.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Apache https port";
            this.label3.Visible = false;
            // 
            // numericUpDown_mariadb
            // 
            this.numericUpDown_mariadb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_mariadb.Location = new System.Drawing.Point(138, 296);
            this.numericUpDown_mariadb.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown_mariadb.Name = "numericUpDown_mariadb";
            this.numericUpDown_mariadb.Size = new System.Drawing.Size(121, 21);
            this.numericUpDown_mariadb.TabIndex = 8;
            this.numericUpDown_mariadb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "MariaDB port";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(270, 402);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(392, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialogEditor
            // 
            this.openFileDialogEditor.FileName = "openFileDialogEditor";
            // 
            // btnSelectEdit
            // 
            this.btnSelectEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectEdit.Location = new System.Drawing.Point(577, 14);
            this.btnSelectEdit.Name = "btnSelectEdit";
            this.btnSelectEdit.Size = new System.Drawing.Size(212, 24);
            this.btnSelectEdit.TabIndex = 11;
            this.btnSelectEdit.Text = "Editor Path";
            this.btnSelectEdit.UseVisualStyleBackColor = true;
            this.btnSelectEdit.Click += new System.EventHandler(this.btnSelectEdit_Click);
            // 
            // txtPathConsole
            // 
            this.txtPathConsole.AcceptsReturn = true;
            this.txtPathConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathConsole.Location = new System.Drawing.Point(12, 101);
            this.txtPathConsole.Multiline = true;
            this.txtPathConsole.Name = "txtPathConsole";
            this.txtPathConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPathConsole.Size = new System.Drawing.Size(777, 154);
            this.txtPathConsole.TabIndex = 12;
            this.txtPathConsole.TextChanged += new System.EventHandler(this.txtPathConsole_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(602, 45);
            this.label5.TabIndex = 13;
            this.label5.Text = "List of folders that you want to appear in the PATH variable when you open a term" +
    "inal\r\nInsert absolute paths to the folders.\r\nDifferent paths must be on separate" +
    " lines.";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // checkBackUpAllDBOnExit
            // 
            this.checkBackUpAllDBOnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBackUpAllDBOnExit.AutoSize = true;
            this.checkBackUpAllDBOnExit.Location = new System.Drawing.Point(14, 350);
            this.checkBackUpAllDBOnExit.Name = "checkBackUpAllDBOnExit";
            this.checkBackUpAllDBOnExit.Size = new System.Drawing.Size(257, 19);
            this.checkBackUpAllDBOnExit.TabIndex = 24;
            this.checkBackUpAllDBOnExit.Text = "Backup All DB on Mariadb Shutdown";
            this.checkBackUpAllDBOnExit.UseVisualStyleBackColor = true;
            // 
            // checkUpdateZampgui
            // 
            this.checkUpdateZampgui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkUpdateZampgui.AutoSize = true;
            this.checkUpdateZampgui.Checked = true;
            this.checkUpdateZampgui.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUpdateZampgui.Location = new System.Drawing.Point(432, 296);
            this.checkUpdateZampgui.Name = "checkUpdateZampgui";
            this.checkUpdateZampgui.Size = new System.Drawing.Size(222, 19);
            this.checkUpdateZampgui.TabIndex = 25;
            this.checkUpdateZampgui.Text = "Check New Version at startup";
            this.checkUpdateZampgui.UseVisualStyleBackColor = true;
            // 
            // txtBackupSQLFolder
            // 
            this.txtBackupSQLFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackupSQLFolder.Location = new System.Drawing.Point(281, 346);
            this.txtBackupSQLFolder.Name = "txtBackupSQLFolder";
            this.txtBackupSQLFolder.Size = new System.Drawing.Size(363, 21);
            this.txtBackupSQLFolder.TabIndex = 26;
            // 
            // btnChooseBackupFolder
            // 
            this.btnChooseBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseBackupFolder.Location = new System.Drawing.Point(650, 346);
            this.btnChooseBackupFolder.Name = "btnChooseBackupFolder";
            this.btnChooseBackupFolder.Size = new System.Drawing.Size(139, 23);
            this.btnChooseBackupFolder.TabIndex = 27;
            this.btnChooseBackupFolder.Text = "Backup Folder";
            this.btnChooseBackupFolder.UseVisualStyleBackColor = true;
            this.btnChooseBackupFolder.Click += new System.EventHandler(this.btnChooseBackupFolder_Click);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(801, 452);
            this.Controls.Add(this.btnChooseBackupFolder);
            this.Controls.Add(this.txtBackupSQLFolder);
            this.Controls.Add(this.checkUpdateZampgui);
            this.Controls.Add(this.checkBackUpAllDBOnExit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPathConsole);
            this.Controls.Add(this.btnSelectEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numericUpDown_mariadb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_https);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_http);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPathEditor);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(817, 491);
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_http)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_https)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mariadb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPathEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_http;
        private System.Windows.Forms.NumericUpDown numericUpDown_https;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_mariadb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialogEditor;
        private System.Windows.Forms.Button btnSelectEdit;
        private System.Windows.Forms.TextBox txtPathConsole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBackUpAllDBOnExit;
        private System.Windows.Forms.CheckBox checkUpdateZampgui;
        private System.Windows.Forms.TextBox txtBackupSQLFolder;
        private System.Windows.Forms.Button btnChooseBackupFolder;
    }
}