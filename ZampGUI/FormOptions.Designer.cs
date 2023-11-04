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
            this.btnSelectGit = new System.Windows.Forms.Button();
            this.txtPathGit = new System.Windows.Forms.TextBox();
            this.btnSelectSass = new System.Windows.Forms.Button();
            this.txtPathSass = new System.Windows.Forms.TextBox();
            this.btnSelectNode = new System.Windows.Forms.Button();
            this.txtPathNodeJS = new System.Windows.Forms.TextBox();
            this.checkBackUpAllDBOnExit = new System.Windows.Forms.CheckBox();
            this.checkUpdateZampgui = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_http)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_https)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mariadb)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPathEditor
            // 
            this.txtPathEditor.Location = new System.Drawing.Point(15, 14);
            this.txtPathEditor.Name = "txtPathEditor";
            this.txtPathEditor.Size = new System.Drawing.Size(545, 31);
            this.txtPathEditor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Http port";
            // 
            // numericUpDown_http
            // 
            this.numericUpDown_http.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_http.Location = new System.Drawing.Point(15, 338);
            this.numericUpDown_http.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_http.Name = "numericUpDown_http";
            this.numericUpDown_http.Size = new System.Drawing.Size(114, 31);
            this.numericUpDown_http.TabIndex = 4;
            this.numericUpDown_http.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_https
            // 
            this.numericUpDown_https.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_https.Location = new System.Drawing.Point(271, 338);
            this.numericUpDown_https.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_https.Name = "numericUpDown_https";
            this.numericUpDown_https.Size = new System.Drawing.Size(121, 31);
            this.numericUpDown_https.TabIndex = 6;
            this.numericUpDown_https.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_https.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Apache https port";
            this.label3.Visible = false;
            // 
            // numericUpDown_mariadb
            // 
            this.numericUpDown_mariadb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_mariadb.Location = new System.Drawing.Point(139, 338);
            this.numericUpDown_mariadb.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown_mariadb.Name = "numericUpDown_mariadb";
            this.numericUpDown_mariadb.Size = new System.Drawing.Size(121, 31);
            this.numericUpDown_mariadb.TabIndex = 8;
            this.numericUpDown_mariadb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "MariaDB port";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(270, 390);
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
            this.btnCancel.Location = new System.Drawing.Point(392, 390);
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
            this.txtPathConsole.Location = new System.Drawing.Point(12, 134);
            this.txtPathConsole.Multiline = true;
            this.txtPathConsole.Name = "txtPathConsole";
            this.txtPathConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPathConsole.Size = new System.Drawing.Size(777, 168);
            this.txtPathConsole.TabIndex = 12;
            this.txtPathConsole.TextChanged += new System.EventHandler(this.txtPathConsole_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1115, 69);
            this.label5.TabIndex = 13;
            this.label5.Text = "List of folders that you want to appear in the PATH variable when you open a term" +
    "inal\r\nInsert absolute paths to the folders.\r\nDifferent paths must be on separate" +
    " lines.";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnSelectGit
            // 
            this.btnSelectGit.Location = new System.Drawing.Point(577, 44);
            this.btnSelectGit.Name = "btnSelectGit";
            this.btnSelectGit.Size = new System.Drawing.Size(212, 24);
            this.btnSelectGit.TabIndex = 16;
            this.btnSelectGit.Text = "Git Path Bin Folder";
            this.btnSelectGit.UseVisualStyleBackColor = true;
            this.btnSelectGit.Visible = false;
            this.btnSelectGit.Click += new System.EventHandler(this.btnSelectGit_Click);
            // 
            // txtPathGit
            // 
            this.txtPathGit.Location = new System.Drawing.Point(12, 44);
            this.txtPathGit.Name = "txtPathGit";
            this.txtPathGit.Size = new System.Drawing.Size(548, 31);
            this.txtPathGit.TabIndex = 15;
            this.txtPathGit.Visible = false;
            // 
            // btnSelectSass
            // 
            this.btnSelectSass.Location = new System.Drawing.Point(580, 104);
            this.btnSelectSass.Name = "btnSelectSass";
            this.btnSelectSass.Size = new System.Drawing.Size(209, 24);
            this.btnSelectSass.TabIndex = 19;
            this.btnSelectSass.Text = "Dart Sass bin Path";
            this.btnSelectSass.UseVisualStyleBackColor = true;
            this.btnSelectSass.Visible = false;
            this.btnSelectSass.Click += new System.EventHandler(this.btnSelectSass_Click);
            // 
            // txtPathSass
            // 
            this.txtPathSass.Location = new System.Drawing.Point(12, 104);
            this.txtPathSass.Name = "txtPathSass";
            this.txtPathSass.Size = new System.Drawing.Size(548, 31);
            this.txtPathSass.TabIndex = 18;
            this.txtPathSass.Visible = false;
            // 
            // btnSelectNode
            // 
            this.btnSelectNode.Location = new System.Drawing.Point(580, 74);
            this.btnSelectNode.Name = "btnSelectNode";
            this.btnSelectNode.Size = new System.Drawing.Size(209, 24);
            this.btnSelectNode.TabIndex = 22;
            this.btnSelectNode.Text = "NodeJS bin Path";
            this.btnSelectNode.UseVisualStyleBackColor = true;
            this.btnSelectNode.Visible = false;
            this.btnSelectNode.Click += new System.EventHandler(this.btnSelectNode_Click);
            // 
            // txtPathNodeJS
            // 
            this.txtPathNodeJS.Location = new System.Drawing.Point(15, 74);
            this.txtPathNodeJS.Name = "txtPathNodeJS";
            this.txtPathNodeJS.Size = new System.Drawing.Size(545, 31);
            this.txtPathNodeJS.TabIndex = 21;
            this.txtPathNodeJS.Visible = false;
            // 
            // checkBackUpAllDBOnExit
            // 
            this.checkBackUpAllDBOnExit.AutoSize = true;
            this.checkBackUpAllDBOnExit.Location = new System.Drawing.Point(503, 333);
            this.checkBackUpAllDBOnExit.Name = "checkBackUpAllDBOnExit";
            this.checkBackUpAllDBOnExit.Size = new System.Drawing.Size(309, 27);
            this.checkBackUpAllDBOnExit.TabIndex = 24;
            this.checkBackUpAllDBOnExit.Text = "Backup All DB on Exit";
            this.checkBackUpAllDBOnExit.UseVisualStyleBackColor = true;
            // 
            // checkUpdateZampgui
            // 
            this.checkUpdateZampgui.AutoSize = true;
            this.checkUpdateZampgui.Checked = true;
            this.checkUpdateZampgui.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUpdateZampgui.Location = new System.Drawing.Point(503, 360);
            this.checkUpdateZampgui.Name = "checkUpdateZampgui";
            this.checkUpdateZampgui.Size = new System.Drawing.Size(400, 27);
            this.checkUpdateZampgui.TabIndex = 25;
            this.checkUpdateZampgui.Text = "Check New Version at startup";
            this.checkUpdateZampgui.UseVisualStyleBackColor = true;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(801, 427);
            this.Controls.Add(this.checkUpdateZampgui);
            this.Controls.Add(this.checkBackUpAllDBOnExit);
            this.Controls.Add(this.btnSelectNode);
            this.Controls.Add(this.txtPathNodeJS);
            this.Controls.Add(this.btnSelectSass);
            this.Controls.Add(this.txtPathSass);
            this.Controls.Add(this.btnSelectGit);
            this.Controls.Add(this.txtPathGit);
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
            this.MinimumSize = new System.Drawing.Size(770, 491);
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
        private System.Windows.Forms.Button btnSelectGit;
        private System.Windows.Forms.TextBox txtPathGit;
        private System.Windows.Forms.Button btnSelectSass;
        private System.Windows.Forms.TextBox txtPathSass;
        private System.Windows.Forms.Button btnSelectNode;
        private System.Windows.Forms.TextBox txtPathNodeJS;
        private System.Windows.Forms.CheckBox checkBackUpAllDBOnExit;
        private System.Windows.Forms.CheckBox checkUpdateZampgui;
    }
}