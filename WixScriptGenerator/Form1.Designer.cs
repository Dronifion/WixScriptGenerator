namespace WixScriptGenerator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSelectIcon = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIconFile = new System.Windows.Forms.TextBox();
            this.btnRegenAssemblyName = new System.Windows.Forms.Button();
            this.chkShortcut = new System.Windows.Forms.CheckBox();
            this.btnRegen = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAssemblyName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUpgradeCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItrNo = new System.Windows.Forms.TextBox();
            this.txtItrSym = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lwFiles = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnlwClear = new System.Windows.Forms.Button();
            this.btnlwInsert = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMainExeFile = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkIgnoreSubFolder = new System.Windows.Forms.CheckBox();
            this.btnGetSourceDir = new System.Windows.Forms.Button();
            this.txtSourceDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbDisplay = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCodeSignInfo = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(913, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 523);
            this.panel1.TabIndex = 31;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(913, 523);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSelectIcon);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtIconFile);
            this.tabPage1.Controls.Add(this.btnRegenAssemblyName);
            this.tabPage1.Controls.Add(this.chkShortcut);
            this.tabPage1.Controls.Add(this.btnRegen);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtAssemblyName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtUpgradeCode);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtProductName);
            this.tabPage1.Controls.Add(this.txtManufacturer);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtVersion);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtItrNo);
            this.tabPage1.Controls.Add(this.txtItrSym);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(905, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSelectIcon
            // 
            this.btnSelectIcon.Location = new System.Drawing.Point(849, 164);
            this.btnSelectIcon.Name = "btnSelectIcon";
            this.btnSelectIcon.Size = new System.Drawing.Size(48, 23);
            this.btnSelectIcon.TabIndex = 53;
            this.btnSelectIcon.Text = "...";
            this.btnSelectIcon.UseVisualStyleBackColor = true;
            this.btnSelectIcon.Click += new System.EventHandler(this.btnSelectIcon_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Icon File:";
            // 
            // txtIconFile
            // 
            this.txtIconFile.Location = new System.Drawing.Point(111, 166);
            this.txtIconFile.Name = "txtIconFile";
            this.txtIconFile.Size = new System.Drawing.Size(732, 20);
            this.txtIconFile.TabIndex = 51;
            // 
            // btnRegenAssemblyName
            // 
            this.btnRegenAssemblyName.Location = new System.Drawing.Point(415, 112);
            this.btnRegenAssemblyName.Name = "btnRegenAssemblyName";
            this.btnRegenAssemblyName.Size = new System.Drawing.Size(48, 23);
            this.btnRegenAssemblyName.TabIndex = 50;
            this.btnRegenAssemblyName.Text = "Regen";
            this.btnRegenAssemblyName.UseVisualStyleBackColor = true;
            this.btnRegenAssemblyName.Click += new System.EventHandler(this.btnRegenAssemblyName_Click);
            // 
            // chkShortcut
            // 
            this.chkShortcut.AutoSize = true;
            this.chkShortcut.Checked = true;
            this.chkShortcut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShortcut.Location = new System.Drawing.Point(18, 192);
            this.chkShortcut.Name = "chkShortcut";
            this.chkShortcut.Size = new System.Drawing.Size(248, 17);
            this.chkShortcut.TabIndex = 49;
            this.chkShortcut.Text = "Shortcut and registry entry for the main program";
            this.chkShortcut.UseVisualStyleBackColor = true;
            // 
            // btnRegen
            // 
            this.btnRegen.Location = new System.Drawing.Point(415, 60);
            this.btnRegen.Name = "btnRegen";
            this.btnRegen.Size = new System.Drawing.Size(48, 23);
            this.btnRegen.TabIndex = 48;
            this.btnRegen.Text = "Regen";
            this.btnRegen.UseVisualStyleBackColor = true;
            this.btnRegen.Click += new System.EventHandler(this.btnRegen_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Assembly Name:";
            // 
            // txtAssemblyName
            // 
            this.txtAssemblyName.Location = new System.Drawing.Point(111, 114);
            this.txtAssemblyName.Name = "txtAssemblyName";
            this.txtAssemblyName.Size = new System.Drawing.Size(298, 20);
            this.txtAssemblyName.TabIndex = 46;
            this.txtAssemblyName.Text = "ProductName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Upgrade Code:";
            // 
            // txtUpgradeCode
            // 
            this.txtUpgradeCode.Location = new System.Drawing.Point(111, 62);
            this.txtUpgradeCode.Name = "txtUpgradeCode";
            this.txtUpgradeCode.Size = new System.Drawing.Size(298, 20);
            this.txtUpgradeCode.TabIndex = 43;
            this.txtUpgradeCode.Text = "68f75dde-02f1-42c3-8b75-133a7ad9988d";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Product Name:";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(111, 88);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(298, 20);
            this.txtProductName.TabIndex = 41;
            this.txtProductName.Text = "Product Name";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(111, 36);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(298, 20);
            this.txtManufacturer.TabIndex = 40;
            this.txtManufacturer.Text = "Company Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Manufacturer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Version:";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(111, 140);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(298, 20);
            this.txtVersion.TabIndex = 37;
            this.txtVersion.Text = "1.3.7886";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Iteration No.:";
            // 
            // txtItrNo
            // 
            this.txtItrNo.Location = new System.Drawing.Point(277, 11);
            this.txtItrNo.Name = "txtItrNo";
            this.txtItrNo.Size = new System.Drawing.Size(67, 20);
            this.txtItrNo.TabIndex = 35;
            this.txtItrNo.Text = "1";
            // 
            // txtItrSym
            // 
            this.txtItrSym.Location = new System.Drawing.Point(111, 10);
            this.txtItrSym.Name = "txtItrSym";
            this.txtItrSym.Size = new System.Drawing.Size(67, 20);
            this.txtItrSym.TabIndex = 33;
            this.txtItrSym.Text = "_";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Iteration Symbol:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lwFiles);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(905, 497);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Source";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lwFiles
            // 
            this.lwFiles.CheckBoxes = true;
            this.lwFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwFiles.FullRowSelect = true;
            this.lwFiles.Location = new System.Drawing.Point(3, 74);
            this.lwFiles.MultiSelect = false;
            this.lwFiles.Name = "lwFiles";
            this.lwFiles.Size = new System.Drawing.Size(899, 378);
            this.lwFiles.TabIndex = 52;
            this.lwFiles.UseCompatibleStateImageBehavior = false;
            this.lwFiles.View = System.Windows.Forms.View.Details;
            this.lwFiles.SelectedIndexChanged += new System.EventHandler(this.lwFiles_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnlwClear);
            this.panel3.Controls.Add(this.btnlwInsert);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 452);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(899, 42);
            this.panel3.TabIndex = 51;
            // 
            // btnlwClear
            // 
            this.btnlwClear.Location = new System.Drawing.Point(88, 9);
            this.btnlwClear.Name = "btnlwClear";
            this.btnlwClear.Size = new System.Drawing.Size(75, 23);
            this.btnlwClear.TabIndex = 1;
            this.btnlwClear.Text = "Clear";
            this.btnlwClear.UseVisualStyleBackColor = true;
            this.btnlwClear.Click += new System.EventHandler(this.btnlwClear_Click);
            // 
            // btnlwInsert
            // 
            this.btnlwInsert.Location = new System.Drawing.Point(7, 9);
            this.btnlwInsert.Name = "btnlwInsert";
            this.btnlwInsert.Size = new System.Drawing.Size(75, 23);
            this.btnlwInsert.TabIndex = 0;
            this.btnlwInsert.Text = "Insert";
            this.btnlwInsert.UseVisualStyleBackColor = true;
            this.btnlwInsert.Click += new System.EventHandler(this.btnlwInsert_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMainExeFile);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.chkIgnoreSubFolder);
            this.panel2.Controls.Add(this.btnGetSourceDir);
            this.panel2.Controls.Add(this.txtSourceDir);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(899, 71);
            this.panel2.TabIndex = 50;
            // 
            // lblMainExeFile
            // 
            this.lblMainExeFile.Location = new System.Drawing.Point(112, 33);
            this.lblMainExeFile.Name = "lblMainExeFile";
            this.lblMainExeFile.Size = new System.Drawing.Size(779, 35);
            this.lblMainExeFile.TabIndex = 55;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "Main Exe File:";
            // 
            // chkIgnoreSubFolder
            // 
            this.chkIgnoreSubFolder.AutoSize = true;
            this.chkIgnoreSubFolder.Checked = true;
            this.chkIgnoreSubFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreSubFolder.Location = new System.Drawing.Point(744, 8);
            this.chkIgnoreSubFolder.Name = "chkIgnoreSubFolder";
            this.chkIgnoreSubFolder.Size = new System.Drawing.Size(147, 17);
            this.chkIgnoreSubFolder.TabIndex = 53;
            this.chkIgnoreSubFolder.Text = "Ignore Source Sub-Folder";
            this.chkIgnoreSubFolder.UseVisualStyleBackColor = true;
            // 
            // btnGetSourceDir
            // 
            this.btnGetSourceDir.Location = new System.Drawing.Point(677, 4);
            this.btnGetSourceDir.Name = "btnGetSourceDir";
            this.btnGetSourceDir.Size = new System.Drawing.Size(48, 23);
            this.btnGetSourceDir.TabIndex = 52;
            this.btnGetSourceDir.Text = "...";
            this.btnGetSourceDir.UseVisualStyleBackColor = true;
            this.btnGetSourceDir.Click += new System.EventHandler(this.btnGetSourceDir_Click);
            // 
            // txtSourceDir
            // 
            this.txtSourceDir.Location = new System.Drawing.Point(112, 6);
            this.txtSourceDir.Name = "txtSourceDir";
            this.txtSourceDir.Size = new System.Drawing.Size(559, 20);
            this.txtSourceDir.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Source Directory:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbDisplay);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(905, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Script";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbDisplay
            // 
            this.lbDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDisplay.FormattingEnabled = true;
            this.lbDisplay.HorizontalScrollbar = true;
            this.lbDisplay.Location = new System.Drawing.Point(3, 60);
            this.lbDisplay.Name = "lbDisplay";
            this.lbDisplay.Size = new System.Drawing.Size(899, 434);
            this.lbDisplay.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCodeSignInfo);
            this.panel4.Controls.Add(this.lblInfo);
            this.panel4.Controls.Add(this.btnExport);
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Controls.Add(this.btnStart);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(899, 57);
            this.panel4.TabIndex = 22;
            // 
            // btnCodeSignInfo
            // 
            this.btnCodeSignInfo.Location = new System.Drawing.Point(259, 16);
            this.btnCodeSignInfo.Name = "btnCodeSignInfo";
            this.btnCodeSignInfo.Size = new System.Drawing.Size(75, 23);
            this.btnCodeSignInfo.TabIndex = 23;
            this.btnCodeSignInfo.Text = "Code Sign";
            this.btnCodeSignInfo.UseVisualStyleBackColor = true;
            this.btnCodeSignInfo.Click += new System.EventHandler(this.btnCodeSignInfo_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(340, 21);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 22;
            this.lblInfo.Text = "label1";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(178, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 21;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(97, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(16, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 19;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(620, 144);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 199);
            this.listBox2.TabIndex = 21;
            this.listBox2.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(467, 144);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(138, 199);
            this.listBox1.TabIndex = 20;
            this.listBox1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 545);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WIX Toolset Script Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAssemblyName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUpgradeCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItrNo;
        private System.Windows.Forms.TextBox txtItrSym;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnRegen;
        private System.Windows.Forms.CheckBox chkShortcut;
        private System.Windows.Forms.Button btnRegenAssemblyName;
        private System.Windows.Forms.Button btnSelectIcon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIconFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lwFiles;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnlwClear;
        private System.Windows.Forms.Button btnlwInsert;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkIgnoreSubFolder;
        private System.Windows.Forms.Button btnGetSourceDir;
        private System.Windows.Forms.TextBox txtSourceDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMainExeFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lbDisplay;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCodeSignInfo;
    }
}

