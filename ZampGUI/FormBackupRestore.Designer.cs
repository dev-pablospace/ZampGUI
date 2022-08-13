namespace ZampGUI
{
    partial class FormBackupRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBackupRestore));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.radioButtonSchemaAndData = new System.Windows.Forms.RadioButton();
            this.radioButtonDataOnly = new System.Windows.Forms.RadioButton();
            this.radioButtonSchemaOnly = new System.Windows.Forms.RadioButton();
            this.checkBoxAddCreateDB = new System.Windows.Forms.CheckBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDbBackup = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDbRestore = new System.Windows.Forms.ComboBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnSelectSqlFile = new System.Windows.Forms.Button();
            this.txtPathSQLFile = new System.Windows.Forms.TextBox();
            this.SQLScript = new System.Windows.Forms.TabPage();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.textBoxSql = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SQLScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.SQLScript);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 259);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.radioButtonSchemaAndData);
            this.tabPage1.Controls.Add(this.radioButtonDataOnly);
            this.tabPage1.Controls.Add(this.radioButtonSchemaOnly);
            this.tabPage1.Controls.Add(this.checkBoxAddCreateDB);
            this.tabPage1.Controls.Add(this.btnBackup);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comboBoxDbBackup);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(757, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Backup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // radioButtonSchemaAndData
            // 
            this.radioButtonSchemaAndData.AutoSize = true;
            this.radioButtonSchemaAndData.Location = new System.Drawing.Point(20, 183);
            this.radioButtonSchemaAndData.Name = "radioButtonSchemaAndData";
            this.radioButtonSchemaAndData.Size = new System.Drawing.Size(227, 21);
            this.radioButtonSchemaAndData.TabIndex = 9;
            this.radioButtonSchemaAndData.TabStop = true;
            this.radioButtonSchemaAndData.Text = "Export schema and data";
            this.radioButtonSchemaAndData.UseVisualStyleBackColor = true;
            // 
            // radioButtonDataOnly
            // 
            this.radioButtonDataOnly.AutoSize = true;
            this.radioButtonDataOnly.Location = new System.Drawing.Point(20, 156);
            this.radioButtonDataOnly.Name = "radioButtonDataOnly";
            this.radioButtonDataOnly.Size = new System.Drawing.Size(173, 21);
            this.radioButtonDataOnly.TabIndex = 8;
            this.radioButtonDataOnly.TabStop = true;
            this.radioButtonDataOnly.Text = "Export data Only";
            this.radioButtonDataOnly.UseVisualStyleBackColor = true;
            // 
            // radioButtonSchemaOnly
            // 
            this.radioButtonSchemaOnly.AutoSize = true;
            this.radioButtonSchemaOnly.Location = new System.Drawing.Point(20, 129);
            this.radioButtonSchemaOnly.Name = "radioButtonSchemaOnly";
            this.radioButtonSchemaOnly.Size = new System.Drawing.Size(191, 21);
            this.radioButtonSchemaOnly.TabIndex = 7;
            this.radioButtonSchemaOnly.TabStop = true;
            this.radioButtonSchemaOnly.Text = "Export Schema Only";
            this.radioButtonSchemaOnly.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddCreateDB
            // 
            this.checkBoxAddCreateDB.AutoSize = true;
            this.checkBoxAddCreateDB.Location = new System.Drawing.Point(20, 78);
            this.checkBoxAddCreateDB.Name = "checkBoxAddCreateDB";
            this.checkBoxAddCreateDB.Size = new System.Drawing.Size(282, 21);
            this.checkBoxAddCreateDB.TabIndex = 4;
            this.checkBoxAddCreateDB.Text = "Add \"Create Database\" to sql";
            this.checkBoxAddCreateDB.UseVisualStyleBackColor = true;
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(626, 78);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(125, 57);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "Run Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Database";
            // 
            // comboBoxDbBackup
            // 
            this.comboBoxDbBackup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDbBackup.FormattingEnabled = true;
            this.comboBoxDbBackup.Location = new System.Drawing.Point(104, 26);
            this.comboBoxDbBackup.Name = "comboBoxDbBackup";
            this.comboBoxDbBackup.Size = new System.Drawing.Size(647, 25);
            this.comboBoxDbBackup.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.comboBoxDbRestore);
            this.tabPage2.Controls.Add(this.btnRestore);
            this.tabPage2.Controls.Add(this.btnSelectSqlFile);
            this.tabPage2.Controls.Add(this.txtPathSQLFile);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(757, 229);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Restore";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Database";
            // 
            // comboBoxDbRestore
            // 
            this.comboBoxDbRestore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDbRestore.FormattingEnabled = true;
            this.comboBoxDbRestore.Location = new System.Drawing.Point(163, 69);
            this.comboBoxDbRestore.Name = "comboBoxDbRestore";
            this.comboBoxDbRestore.Size = new System.Drawing.Size(588, 25);
            this.comboBoxDbRestore.TabIndex = 4;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(17, 118);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(140, 23);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnSelectSqlFile
            // 
            this.btnSelectSqlFile.Location = new System.Drawing.Point(17, 29);
            this.btnSelectSqlFile.Name = "btnSelectSqlFile";
            this.btnSelectSqlFile.Size = new System.Drawing.Size(140, 23);
            this.btnSelectSqlFile.TabIndex = 2;
            this.btnSelectSqlFile.Text = "Select SQL file";
            this.btnSelectSqlFile.UseVisualStyleBackColor = true;
            this.btnSelectSqlFile.Click += new System.EventHandler(this.btnSelectSqlFile_Click);
            // 
            // txtPathSQLFile
            // 
            this.txtPathSQLFile.Location = new System.Drawing.Point(163, 31);
            this.txtPathSQLFile.Name = "txtPathSQLFile";
            this.txtPathSQLFile.Size = new System.Drawing.Size(588, 24);
            this.txtPathSQLFile.TabIndex = 1;
            // 
            // SQLScript
            // 
            this.SQLScript.Controls.Add(this.btnRunScript);
            this.SQLScript.Controls.Add(this.textBoxSql);
            this.SQLScript.Location = new System.Drawing.Point(4, 26);
            this.SQLScript.Name = "SQLScript";
            this.SQLScript.Size = new System.Drawing.Size(757, 229);
            this.SQLScript.TabIndex = 2;
            this.SQLScript.Text = "SQL Script";
            this.SQLScript.UseVisualStyleBackColor = true;
            // 
            // btnRunScript
            // 
            this.btnRunScript.Location = new System.Drawing.Point(14, 203);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(119, 23);
            this.btnRunScript.TabIndex = 1;
            this.btnRunScript.Text = "Run Script";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // textBoxSql
            // 
            this.textBoxSql.Location = new System.Drawing.Point(14, 14);
            this.textBoxSql.MaxLength = 0;
            this.textBoxSql.Multiline = true;
            this.textBoxSql.Name = "textBoxSql";
            this.textBoxSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSql.Size = new System.Drawing.Size(727, 183);
            this.textBoxSql.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 283);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBackupRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Backup and Restore";
            this.Load += new System.EventHandler(this.FormBackupRestore_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.SQLScript.ResumeLayout(false);
            this.SQLScript.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDbBackup;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDbRestore;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnSelectSqlFile;
        private System.Windows.Forms.TextBox txtPathSQLFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBoxAddCreateDB;
        private System.Windows.Forms.TabPage SQLScript;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.TextBox textBoxSql;
        private System.Windows.Forms.RadioButton radioButtonDataOnly;
        private System.Windows.Forms.RadioButton radioButtonSchemaOnly;
        private System.Windows.Forms.RadioButton radioButtonSchemaAndData;
    }
}