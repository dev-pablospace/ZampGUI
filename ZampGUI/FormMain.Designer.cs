namespace ZampGUI
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.txtOut = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAllProgrammToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAllProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apacheHttpdconfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apacheHttpdvhostsconfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.phpiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mariadbIniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.hostFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeVersStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.importConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apacheHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phpinfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mariaDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phpMyAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.sitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHostEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.onleClickInstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordpressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pHPFoldeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySQLFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apacheFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.backupDBFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.localhostRootFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartStopApache = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartStopMariaDB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxMariaDB = new System.Windows.Forms.PictureBox();
            this.pictureBoxApache = new System.Windows.Forms.PictureBox();
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            this.listViewInfo = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMariaDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxApache)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOut.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOut.Location = new System.Drawing.Point(15, 188);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ReadOnly = true;
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOut.Size = new System.Drawing.Size(834, 222);
            this.txtOut.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationToolStripMenuItem,
            this.editToolStripMenuItem,
            this.browserToolStripMenuItem,
            this.extraToolStripMenuItem,
            this.consoleToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkStatusToolStripMenuItem,
            this.stopAllProgrammToolStripMenuItem,
            this.runAllProgramToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.operationToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_screen;
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.operationToolStripMenuItem.Text = "Server";
            // 
            // checkStatusToolStripMenuItem
            // 
            this.checkStatusToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_circle_exclamation_icon;
            this.checkStatusToolStripMenuItem.Name = "checkStatusToolStripMenuItem";
            this.checkStatusToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.checkStatusToolStripMenuItem.Text = "Check status";
            this.checkStatusToolStripMenuItem.Click += new System.EventHandler(this.checkStatusToolStripMenuItem_Click);
            // 
            // stopAllProgrammToolStripMenuItem
            // 
            this.stopAllProgrammToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_x_circle_icon;
            this.stopAllProgrammToolStripMenuItem.Name = "stopAllProgrammToolStripMenuItem";
            this.stopAllProgrammToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.stopAllProgrammToolStripMenuItem.Text = "Stop All";
            this.stopAllProgrammToolStripMenuItem.Click += new System.EventHandler(this.stopAllProgrammToolStripMenuItem_Click);
            // 
            // runAllProgramToolStripMenuItem
            // 
            this.runAllProgramToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_play_icon;
            this.runAllProgramToolStripMenuItem.Name = "runAllProgramToolStripMenuItem";
            this.runAllProgramToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.runAllProgramToolStripMenuItem.Text = "Run All";
            this.runAllProgramToolStripMenuItem.Click += new System.EventHandler(this.runAllProgramToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_logout_icon;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesConfigToolStripMenuItem,
            this.backupRestoreToolStripMenuItem,
            this.ChangeVersStripMenuItem,
            this.toolStripSeparator11,
            this.importConfigurationToolStripMenuItem,
            this.exportConfigurationToolStripMenuItem,
            this.toolStripSeparator2,
            this.optionsToolStripMenuItem});
            this.editToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_alt_pencil_icon;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // filesConfigToolStripMenuItem
            // 
            this.filesConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apacheHttpdconfToolStripMenuItem,
            this.apacheHttpdvhostsconfToolStripMenuItem,
            this.toolStripSeparator4,
            this.phpiniToolStripMenuItem,
            this.toolStripSeparator5,
            this.mariadbIniToolStripMenuItem,
            this.toolStripSeparator6,
            this.hostFileToolStripMenuItem});
            this.filesConfigToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_alt_pencil_icon;
            this.filesConfigToolStripMenuItem.Name = "filesConfigToolStripMenuItem";
            this.filesConfigToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.filesConfigToolStripMenuItem.Text = "Edit config";
            // 
            // apacheHttpdconfToolStripMenuItem
            // 
            this.apacheHttpdconfToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_file;
            this.apacheHttpdconfToolStripMenuItem.Name = "apacheHttpdconfToolStripMenuItem";
            this.apacheHttpdconfToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.apacheHttpdconfToolStripMenuItem.Text = "apache httpd.conf";
            this.apacheHttpdconfToolStripMenuItem.Click += new System.EventHandler(this.changeConfig_ToolStripMenuItem_Click);
            // 
            // apacheHttpdvhostsconfToolStripMenuItem
            // 
            this.apacheHttpdvhostsconfToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_file;
            this.apacheHttpdvhostsconfToolStripMenuItem.Name = "apacheHttpdvhostsconfToolStripMenuItem";
            this.apacheHttpdvhostsconfToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.apacheHttpdvhostsconfToolStripMenuItem.Text = "apache httpd-vhosts.conf";
            this.apacheHttpdvhostsconfToolStripMenuItem.Click += new System.EventHandler(this.changeConfig_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(256, 6);
            // 
            // phpiniToolStripMenuItem
            // 
            this.phpiniToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_php;
            this.phpiniToolStripMenuItem.Name = "phpiniToolStripMenuItem";
            this.phpiniToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.phpiniToolStripMenuItem.Text = "php ini";
            this.phpiniToolStripMenuItem.Click += new System.EventHandler(this.changeConfig_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(256, 6);
            // 
            // mariadbIniToolStripMenuItem
            // 
            this.mariadbIniToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_mysql;
            this.mariadbIniToolStripMenuItem.Name = "mariadbIniToolStripMenuItem";
            this.mariadbIniToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.mariadbIniToolStripMenuItem.Text = "mariadb ini";
            this.mariadbIniToolStripMenuItem.Click += new System.EventHandler(this.changeConfig_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(256, 6);
            // 
            // hostFileToolStripMenuItem
            // 
            this.hostFileToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_file;
            this.hostFileToolStripMenuItem.Name = "hostFileToolStripMenuItem";
            this.hostFileToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.hostFileToolStripMenuItem.Text = "Host File";
            this.hostFileToolStripMenuItem.Click += new System.EventHandler(this.hostFileToolStripMenuItem_Click);
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_backup;
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.backupRestoreToolStripMenuItem.Text = "Backup - Restore - SQL Script";
            this.backupRestoreToolStripMenuItem.Click += new System.EventHandler(this.backupRestoreToolStripMenuItem_Click);
            // 
            // ChangeVersStripMenuItem
            // 
            this.ChangeVersStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_switch_horizontal_icon;
            this.ChangeVersStripMenuItem.Name = "ChangeVersStripMenuItem";
            this.ChangeVersStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.ChangeVersStripMenuItem.Text = "Change PHP";
            this.ChangeVersStripMenuItem.Visible = false;
            this.ChangeVersStripMenuItem.Click += new System.EventHandler(this.ChangeVersStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(283, 6);
            // 
            // importConfigurationToolStripMenuItem
            // 
            this.importConfigurationToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_json3;
            this.importConfigurationToolStripMenuItem.Name = "importConfigurationToolStripMenuItem";
            this.importConfigurationToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.importConfigurationToolStripMenuItem.Text = "Import Configuration";
            this.importConfigurationToolStripMenuItem.Click += new System.EventHandler(this.importConfigurationToolStripMenuItem_Click);
            // 
            // exportConfigurationToolStripMenuItem
            // 
            this.exportConfigurationToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_json3;
            this.exportConfigurationToolStripMenuItem.Name = "exportConfigurationToolStripMenuItem";
            this.exportConfigurationToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.exportConfigurationToolStripMenuItem.Text = "Export Configuration";
            this.exportConfigurationToolStripMenuItem.Click += new System.EventHandler(this.exportConfigurationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(283, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_cog_icon;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // browserToolStripMenuItem
            // 
            this.browserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apacheHomeToolStripMenuItem,
            this.mariaDBToolStripMenuItem,
            this.toolStripSeparator7,
            this.sitesToolStripMenuItem,
            this.manageSitesToolStripMenuItem});
            this.browserToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_link;
            this.browserToolStripMenuItem.Name = "browserToolStripMenuItem";
            this.browserToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.browserToolStripMenuItem.Text = "Link";
            // 
            // apacheHomeToolStripMenuItem
            // 
            this.apacheHomeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phpinfoToolStripMenuItem});
            this.apacheHomeToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_globe_icon;
            this.apacheHomeToolStripMenuItem.Name = "apacheHomeToolStripMenuItem";
            this.apacheHomeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.apacheHomeToolStripMenuItem.Text = "Apache";
            // 
            // phpinfoToolStripMenuItem
            // 
            this.phpinfoToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_php;
            this.phpinfoToolStripMenuItem.Name = "phpinfoToolStripMenuItem";
            this.phpinfoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.phpinfoToolStripMenuItem.Text = "phpinfo";
            this.phpinfoToolStripMenuItem.Click += new System.EventHandler(this.phpinfoToolStripMenuItem_Click);
            // 
            // mariaDBToolStripMenuItem
            // 
            this.mariaDBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phpMyAdminToolStripMenuItem,
            this.adminerToolStripMenuItem});
            this.mariaDBToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_database_icon;
            this.mariaDBToolStripMenuItem.Name = "mariaDBToolStripMenuItem";
            this.mariaDBToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.mariaDBToolStripMenuItem.Text = "MariaDB ";
            // 
            // phpMyAdminToolStripMenuItem
            // 
            this.phpMyAdminToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_db;
            this.phpMyAdminToolStripMenuItem.Name = "phpMyAdminToolStripMenuItem";
            this.phpMyAdminToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.phpMyAdminToolStripMenuItem.Text = "phpMyAdmin";
            this.phpMyAdminToolStripMenuItem.Click += new System.EventHandler(this.phpMyAdminToolStripMenuItem_Click);
            // 
            // adminerToolStripMenuItem
            // 
            this.adminerToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_db;
            this.adminerToolStripMenuItem.Name = "adminerToolStripMenuItem";
            this.adminerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.adminerToolStripMenuItem.Text = "adminer";
            this.adminerToolStripMenuItem.Click += new System.EventHandler(this.adminerToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(221, 6);
            // 
            // sitesToolStripMenuItem
            // 
            this.sitesToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_website;
            this.sitesToolStripMenuItem.Name = "sitesToolStripMenuItem";
            this.sitesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sitesToolStripMenuItem.Text = "Sites";
            // 
            // manageSitesToolStripMenuItem
            // 
            this.manageSitesToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_website;
            this.manageSitesToolStripMenuItem.Name = "manageSitesToolStripMenuItem";
            this.manageSitesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.manageSitesToolStripMenuItem.Text = "Manage sites";
            this.manageSitesToolStripMenuItem.Click += new System.EventHandler(this.manageSitesToolStripMenuItem_Click);
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHostEntryToolStripMenuItem,
            this.toolStripSeparator3,
            this.onleClickInstallToolStripMenuItem,
            this.pHPFoldeToolStripMenuItem,
            this.mySQLFolderToolStripMenuItem,
            this.apacheFolderToolStripMenuItem,
            this.toolStripSeparator8,
            this.backupDBFolderToolStripMenuItem,
            this.toolStripSeparator9,
            this.localhostRootFolderToolStripMenuItem});
            this.extraToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_menu_icon;
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // showHostEntryToolStripMenuItem
            // 
            this.showHostEntryToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_alt_pencil_icon;
            this.showHostEntryToolStripMenuItem.Name = "showHostEntryToolStripMenuItem";
            this.showHostEntryToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.showHostEntryToolStripMenuItem.Text = "Show Host entry";
            this.showHostEntryToolStripMenuItem.Click += new System.EventHandler(this.showHostEntryToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(234, 6);
            // 
            // onleClickInstallToolStripMenuItem
            // 
            this.onleClickInstallToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordpressToolStripMenuItem});
            this.onleClickInstallToolStripMenuItem.Name = "onleClickInstallToolStripMenuItem";
            this.onleClickInstallToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.onleClickInstallToolStripMenuItem.Text = "Easy Install";
            this.onleClickInstallToolStripMenuItem.Visible = false;
            // 
            // wordpressToolStripMenuItem
            // 
            this.wordpressToolStripMenuItem.Name = "wordpressToolStripMenuItem";
            this.wordpressToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.wordpressToolStripMenuItem.Text = "Wordpress";
            this.wordpressToolStripMenuItem.Click += new System.EventHandler(this.wordpressToolStripMenuItem_Click);
            // 
            // pHPFoldeToolStripMenuItem
            // 
            this.pHPFoldeToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_folder;
            this.pHPFoldeToolStripMenuItem.Name = "pHPFoldeToolStripMenuItem";
            this.pHPFoldeToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.pHPFoldeToolStripMenuItem.Text = "PHP Folder";
            this.pHPFoldeToolStripMenuItem.Click += new System.EventHandler(this.pHPFoldeToolStripMenuItem_Click);
            // 
            // mySQLFolderToolStripMenuItem
            // 
            this.mySQLFolderToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_folder;
            this.mySQLFolderToolStripMenuItem.Name = "mySQLFolderToolStripMenuItem";
            this.mySQLFolderToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.mySQLFolderToolStripMenuItem.Text = "MySQL Folder";
            this.mySQLFolderToolStripMenuItem.Click += new System.EventHandler(this.mySQLFolderToolStripMenuItem_Click);
            // 
            // apacheFolderToolStripMenuItem
            // 
            this.apacheFolderToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_folder;
            this.apacheFolderToolStripMenuItem.Name = "apacheFolderToolStripMenuItem";
            this.apacheFolderToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.apacheFolderToolStripMenuItem.Text = "Apache Folder";
            this.apacheFolderToolStripMenuItem.Click += new System.EventHandler(this.apacheFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(234, 6);
            // 
            // backupDBFolderToolStripMenuItem
            // 
            this.backupDBFolderToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_folder;
            this.backupDBFolderToolStripMenuItem.Name = "backupDBFolderToolStripMenuItem";
            this.backupDBFolderToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.backupDBFolderToolStripMenuItem.Text = "Backup DB Folder";
            this.backupDBFolderToolStripMenuItem.Click += new System.EventHandler(this.backupDBFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(234, 6);
            // 
            // localhostRootFolderToolStripMenuItem
            // 
            this.localhostRootFolderToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_folder;
            this.localhostRootFolderToolStripMenuItem.Name = "localhostRootFolderToolStripMenuItem";
            this.localhostRootFolderToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.localhostRootFolderToolStripMenuItem.Text = "Localhost Root Folder";
            this.localhostRootFolderToolStripMenuItem.Click += new System.EventHandler(this.HttdocsRootFolderToolStripMenuItem_Click);
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.iconfinder_f_command_256_282475;
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripSeparator10,
            this.checkForUpdateToolStripMenuItem,
            this.aboutToolStripMenuItem1,
            this.donateToolStripMenuItem});
            this.helpToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_hand_icon;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Image = global::ZampGUI.Properties.Resources.menu_hand_icon;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(207, 26);
            this.helpToolStripMenuItem1.Text = "Doc Online";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(204, 6);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_arrow_down_icon_1_;
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.checkForUpdateToolStripMenuItem.Text = "Check for Update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Image = global::ZampGUI.Properties.Resources.menu_menu_icon;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(207, 26);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Image = global::ZampGUI.Properties.Resources.menu_coin_dollar_money_icon;
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Visible = false;
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // btnStartStopApache
            // 
            this.btnStartStopApache.Location = new System.Drawing.Point(125, 17);
            this.btnStartStopApache.Name = "btnStartStopApache";
            this.btnStartStopApache.Size = new System.Drawing.Size(100, 23);
            this.btnStartStopApache.TabIndex = 4;
            this.btnStartStopApache.Text = "Start";
            this.btnStartStopApache.UseVisualStyleBackColor = true;
            this.btnStartStopApache.Click += new System.EventHandler(this.btnStartStopApache_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Apache";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "MariaDB";
            // 
            // btnStartStopMariaDB
            // 
            this.btnStartStopMariaDB.Location = new System.Drawing.Point(127, 54);
            this.btnStartStopMariaDB.Name = "btnStartStopMariaDB";
            this.btnStartStopMariaDB.Size = new System.Drawing.Size(98, 23);
            this.btnStartStopMariaDB.TabIndex = 8;
            this.btnStartStopMariaDB.Text = "Start";
            this.btnStartStopMariaDB.UseVisualStyleBackColor = true;
            this.btnStartStopMariaDB.Click += new System.EventHandler(this.btnStartStopMariaDB_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBoxMariaDB);
            this.panel1.Controls.Add(this.btnStartStopMariaDB);
            this.panel1.Controls.Add(this.pictureBoxApache);
            this.panel1.Controls.Add(this.btnStartStopApache);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(606, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 124);
            this.panel1.TabIndex = 11;
            // 
            // pictureBoxMariaDB
            // 
            this.pictureBoxMariaDB.Location = new System.Drawing.Point(19, 49);
            this.pictureBoxMariaDB.Name = "pictureBoxMariaDB";
            this.pictureBoxMariaDB.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxMariaDB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMariaDB.TabIndex = 13;
            this.pictureBoxMariaDB.TabStop = false;
            // 
            // pictureBoxApache
            // 
            this.pictureBoxApache.Location = new System.Drawing.Point(19, 13);
            this.pictureBoxApache.Name = "pictureBoxApache";
            this.pictureBoxApache.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxApache.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxApache.TabIndex = 12;
            this.pictureBoxApache.TabStop = false;
            // 
            // timer_refresh
            // 
            this.timer_refresh.Enabled = true;
            this.timer_refresh.Interval = 15000;
            this.timer_refresh.Tick += new System.EventHandler(this.timer_refresh_Tick);
            // 
            // listViewInfo
            // 
            this.listViewInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewInfo.HideSelection = false;
            this.listViewInfo.Location = new System.Drawing.Point(15, 41);
            this.listViewInfo.Name = "listViewInfo";
            this.listViewInfo.Size = new System.Drawing.Size(585, 124);
            this.listViewInfo.TabIndex = 15;
            this.listViewInfo.UseCompatibleStateImageBehavior = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 428);
            this.Controls.Add(this.listViewInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtOut);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(878, 475);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZampGUI";
            this.Load += new System.EventHandler(this.FrmManZAMP_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMariaDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxApache)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAllProgrammToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runAllProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem filesConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apacheHttpdconfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apacheHttpdvhostsconfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phpiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mariadbIniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupRestoreToolStripMenuItem;
        private System.Windows.Forms.Button btnStartStopApache;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartStopMariaDB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxApache;
        private System.Windows.Forms.PictureBox pictureBoxMariaDB;
        private System.Windows.Forms.ToolStripMenuItem browserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apacheHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phpinfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mariaDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phpMyAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminerToolStripMenuItem;
        private System.Windows.Forms.Timer timer_refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem hostFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHostEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onleClickInstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordpressToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem sitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeVersStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ListView listViewInfo;
        private System.Windows.Forms.ToolStripMenuItem manageSitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem pHPFoldeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mySQLFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apacheFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDBFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localhostRootFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem exportConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importConfigurationToolStripMenuItem;
    }
}

