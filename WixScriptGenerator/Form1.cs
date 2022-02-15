using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Application Used Library
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
//using WixSharp;
//using Microsoft.Deployment.WindowsInstaller;

namespace WixScriptGenerator
{
    public partial class Form1 : Form
    {
        private static Random _random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private string GetAssemblyVersion()
        {
            string sReturn = string.Empty;
            string sVersionAutoNumber = string.Empty;
            string sVersionSecureMi = string.Empty;
            string sVersionMajor = string.Empty;
            string sVersionMinor = string.Empty;
            string sVersionBuild = string.Empty;
            string sVersionRevision = string.Empty;
            char[] splitArr = new char[1];
            splitArr[0] = Convert.ToChar(".");

            try
            {
                sVersionAutoNumber = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString(); //software asion
                sVersionMajor = sVersionAutoNumber.Split(splitArr)[0];
                sVersionMinor = sVersionAutoNumber.Split(splitArr)[1];
                sVersionBuild = sVersionAutoNumber.Split(splitArr)[2];
                sVersionRevision = sVersionAutoNumber.Split(splitArr)[3];
                sVersionSecureMi = sVersionMajor + "." + sVersionMinor + "." + sVersionBuild + "." + sVersionRevision;

                sReturn = sVersionSecureMi;
            }
            catch { }

            return sReturn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (EvaultWin.Common.evWinAssemblyStrongName.AssemblyStrongName64Bits.IsStrongNameValid_Check() == true)
            {
                lblInfo.Text = string.Empty;
                toolStripStatusLabel1.Text = string.Empty;
                txtSourceDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                txtVersion.Text = GetAssemblyVersion();
                this.Text = "WIX Toolset Script Generator, v" + GetAssemblyVersion();
            }
            else
            {
                MessageBox.Show("Strong Name Key Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnGetSourceDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSourceDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.lwFiles.CheckedItems.Count <= 0)
            {
                MessageBox.Show("No file selected for the installation script.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtIconFile.Text.Length <= 0)
            {
                if (MessageBox.Show("No icon file selected for the installation script. Are you sure to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if (lblMainExeFile.Text.Length <= 0)
            {
                if (MessageBox.Show("No main executable file selected for the installation script. Are you sure to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    LesterWixScriptGenerator();
                }
            }
            else 
            {
                LesterWixScriptGenerator();
            }
        }

        private void LesterWixScriptGenerator()
        {
            List<string> slConfig = null; //Configuration file content in string list
            slConfig = new List<string>();
            List<string> slConfig1 = null; //Configuration file content in string list
            slConfig1 = new List<string>();
            int j = 0;
            int k = 1;
            int iFirst = 0;
            string sDirName1, sDirName2 = string.Empty;
            string sCompStr = string.Empty;
            string sCompStr1 = string.Empty;
            int iFileCount = 0, iFolderCount = 0;
            int iIteration = 0;
            string sGuid = string.Empty;
            string txtProductNameRemovedSpace = string.Empty;
            bool bDoOnce = false;
            string sDoOnceExeId = string.Empty;
            bool bOneInstallFolderOnly = false;
            int iFolderInterationStart = 0;
            int iFolderInterationEnd = 0;

            if (int.TryParse(txtItrNo.Text, out iIteration) == false)
            {
                MessageBox.Show("Iteration Number must be integer!");
                return;
            }

            if (iIteration == 1)
            {
                bOneInstallFolderOnly = true;
            }

            try
            {
                lbDisplay.Items.Clear();

                #region Log Wix xml to lbDisplay
                lbDisplay.Items.Add("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

                #region Declare definition
                txtProductNameRemovedSpace = txtProductName.Text.Replace(" ", "");
                lbDisplay.Items.Add("<?define ProductName = \"" + txtProductName.Text + "\"?>");
                for (int i = 1; i <= iIteration; i++)
                {
                    lbDisplay.Items.Add("<?define service" + txtItrSym.Text + i + " = \"" + txtProductNameRemovedSpace + "" + txtItrSym.Text + i + "\"?>");
                }
                lbDisplay.Items.Add("<?define Manufacturer = \"" + txtManufacturer.Text + "\"?>");
                lbDisplay.Items.Add("<?define Version = \"" + txtVersion.Text + "\"?>");
                lbDisplay.Items.Add("<?define UpgradeCode = \"{" + txtUpgradeCode.Text + "}\"?>");
                #endregion

                #region Declare general settings
                lbDisplay.Items.Add("<Wix xmlns = \"http://schemas.microsoft.com/wix/2006/wi\"");
                lbDisplay.Items.Add("   xmlns:util = \"http://schemas.microsoft.com/wix/UtilExtension\">");
                lbDisplay.Items.Add("<Product Id =\"*\"");
                lbDisplay.Items.Add("   Name =\"$(var.ProductName)\"");
                lbDisplay.Items.Add("   Manufacturer =\"$(var.Manufacturer)\"");
                lbDisplay.Items.Add("   UpgradeCode =\"$(var.UpgradeCode)\"");
                lbDisplay.Items.Add("   Version =\"$(var.Version)\"");
                lbDisplay.Items.Add("   Language =\"1033\">");
                lbDisplay.Items.Add("<Package InstallerVersion =\"300\"");
                lbDisplay.Items.Add("   Compressed =\"yes\"/>");
                lbDisplay.Items.Add("<Media Id =\"1\"");
                lbDisplay.Items.Add("   Cabinet =\"" + txtAssemblyName.Text.Replace(" ", "") + ".cab\"");
                lbDisplay.Items.Add("   EmbedCab =\"yes\"/>");
                lbDisplay.Items.Add("<MajorUpgrade Schedule =\"afterInstallInitialize\"");
                lbDisplay.Items.Add("   DowngradeErrorMessage =\"A newer version of " + txtProductName.Text + " is already installed. Setup will now exit.\"");
                lbDisplay.Items.Add("   AllowSameVersionUpgrades =\"yes\"/>");
                if (txtIconFile.Text.Length > 0)
                {
                    lbDisplay.Items.Add("<Icon Id =\"icon.ico\" SourceFile=\"" + txtIconFile.Text + "\" />");
                    lbDisplay.Items.Add("<Property Id =\"ARPPRODUCTICON\" Value=\"icon.ico\" />");
                }
                #endregion

                #region Define all directories structure
                lbDisplay.Items.Add("<Directory Id =\"TARGETDIR\"");
                lbDisplay.Items.Add("   Name =\"SourceDir\">");
                lbDisplay.Items.Add("   <Directory Id =\"ProgramFilesFolder\">");
                lbDisplay.Items.Add("       <Directory Id =\"ROOTDIRECTORY\"");
                lbDisplay.Items.Add("           Name =\"$(var.Manufacturer)\">");
                lbDisplay.Items.Add("           <Directory Id =\"MainInStallerFolder\"");
                lbDisplay.Items.Add("               Name =\"$(var.ProductName)\">");
                lbDisplay.Items.Add("           </Directory>");
                lbDisplay.Items.Add("       </Directory>");
                lbDisplay.Items.Add("   </Directory>");
                lbDisplay.Items.Add("   <Directory Id =\"ProgramMenuFolder\" />");
                lbDisplay.Items.Add("</Directory>");
                #endregion

                #region Add all program files to main install folder
                lbDisplay.Items.Add("<DirectoryRef Id =\"MainInStallerFolder\">");
                for (int i = 1; i <= iIteration; i++)
                {
                    #region forloop
                    //lbDisplay.Items.Add("<Directory Id =\"INSTALLFOLDER" + txtItrSym.Text + i + "\"");
                    //lbDisplay.Items.Add("   Name =\"$(var.service" + txtItrSym.Text + i + ")\" >");

                    /*
                    lbDisplay.Items.Add("  <Component Id =\"$(var.service" + txtItrSym.Text + i + ")\"");
                    lbDisplay.Items.Add("   Guid =\"{" + Guid.Parse(GetMD5HashFromText("WIX Script Generator " + "$(var.service" + txtItrSym.Text + i + ")")).ToString() + "}\">");
                    lbDisplay.Items.Add("   <util:EventSource Name =\"SecureMi Mta Service\"");
                    lbDisplay.Items.Add("       Log =\"Application\"");
                    lbDisplay.Items.Add("       EventMessageFile =\"C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\EventLogMessages.dll\"/>");
                    lbDisplay.Items.Add("   <File Id =\"exe" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Source =\"S:\\Lester201808\\MTA\\branches\\SecureMiMtaWinSvc\\SecureMiMtaWinSvc\\bin\\Release\\smdlpwsm.exe\"");
                    lbDisplay.Items.Add("       KeyPath =\"yes\" />");
                    lbDisplay.Items.Add("   <File Id =\"appConfig" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Source =\"S:\\Lester201808\\MTA\\branches\\SecureMiMtaWinSvc\\SecureMiMtaWinSvc\\bin\\Release\\smdlpwsm.exe.config\"");
                    lbDisplay.Items.Add("       ReadOnly =\"no\"");
                    lbDisplay.Items.Add("       KeyPath =\"no\" />");
                    lbDisplay.Items.Add("   <File Id =\"mysqlDll" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Source =\"S:\\Lester201808\\MTA\\branches\\SecureMiMtaWinSvc\\SecureMiMtaWinSvc\\bin\\Release\\MySql.Data.dll\"");
                    lbDisplay.Items.Add("       KeyPath =\"no\" />");
                    lbDisplay.Items.Add("   <File Id =\"ioniZipDll" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Source =\"S:\\Lester201808\\MTA\\branches\\SecureMiMtaWinSvc\\SecureMiMtaWinSvc\\bin\\Release\\Ionic.Zip.dll\"");
                    lbDisplay.Items.Add("       KeyPath =\"no\" />");
                    lbDisplay.Items.Add("   <File Id =\"ExchangeDll" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Source =\"S:\\Lester201808\\MTA\\branches\\SecureMiMtaWinSvc\\SecureMiMtaWinSvc\\Library\\Microsoft.Exchange.WebServices.dll\"");
                    lbDisplay.Items.Add("       KeyPath =\"no\" />");
                    lbDisplay.Items.Add("   <File Id =\"UnRarExe" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Source =\"S:\\Lester201808\\MTA\\branches\\SecureMiMtaWinSvc\\SecureMiMtaWinSvc\\Library\\smdlpurar.exe\"");
                    lbDisplay.Items.Add("       KeyPath =\"no\" />");
                    lbDisplay.Items.Add("   <ServiceInstall Id =\"MtaService" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Type =\"ownProcess\"");
                    lbDisplay.Items.Add("       Vital =\"yes\"");
                    lbDisplay.Items.Add("       Name =\"$(var.service" + txtItrSym.Text + i + ")\"");
                    lbDisplay.Items.Add("       DisplayName =\"$(var.service" + txtItrSym.Text + i + ")\"");
                    lbDisplay.Items.Add("       Description =\"SecureMi MTA Service " + i + ". It serves SecureMi DLP.\"");
                    lbDisplay.Items.Add("       Start =\"disabled\"");
                    lbDisplay.Items.Add("       Account =\"NT AUTHORITY\\NETWORK SERVICE\"");
                    lbDisplay.Items.Add("       Interactive =\"no\"");
                    lbDisplay.Items.Add("       ErrorControl =\"ignore\" />");
                    lbDisplay.Items.Add("   <ServiceControl Id =\"ServiceControl" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Stop =\"uninstall\"");
                    lbDisplay.Items.Add("       Remove =\"uninstall\"");
                    lbDisplay.Items.Add("       Name =\"$(var.service" + txtItrSym.Text + i + ")\"");
                    lbDisplay.Items.Add("       Wait =\"yes\" />");
                    lbDisplay.Items.Add("   </Component>");
                    lbDisplay.Items.Add("   <Directory Id =\"DE" + txtItrSym.Text + i + "\" Name=\"de\">");
                    lbDisplay.Items.Add("   <Component Id =\"DeItem" + txtItrSym.Text + i + "\" Guid =\"{" + Guid.Parse(GetMD5HashFromText("WIX Script Generator " + "DeItem" + txtItrSym.Text + i + "")).ToString() + "}\">");
                    lbDisplay.Items.Add("   <File Id =\"smdlpps.resources.dll" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Source =\"S:\\Lester201808\\MTA\\branches\\SecureMiMtaWinSvc\\SecureMiMtaWinSvc\\bin\\Release\\de\\smdlpps.resources.dll\"");
                    lbDisplay.Items.Add("       KeyPath =\"no\" />");
                    lbDisplay.Items.Add("   </Component>");
                    lbDisplay.Items.Add("   </Directory>");
                    lbDisplay.Items.Add("   <Directory Id =\"DEPLOY" + txtItrSym.Text + i + "\" Name=\"Deploy\">");
                    lbDisplay.Items.Add("   <Component Id =\"DeployItem" + txtItrSym.Text + i + "\" Guid =\"{" + Guid.Parse(GetMD5HashFromText("WIX Script Generator " + "DeployItem" + txtItrSym.Text + i + "")).ToString() + "}\">");
                    lbDisplay.Items.Add("   <File Id =\"smdlptk.jar" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Source =\"S:\\Lester201808\\MTA\\branches\\SecureMiMtaWinSvc\\SecureMiMtaWinSvc\\bin\\Release\\Deploy\\smdlptk.jar\"");
                    lbDisplay.Items.Add("       KeyPath =\"no\" />");
                    lbDisplay.Items.Add("   <File Id =\"ico" + txtItrSym.Text + i + "\"");
                    lbDisplay.Items.Add("       Source =\"S:\\Lester201808\\MTA\\branches\\SecureMiMtaWinSvc\\SecureMiMtaWinSvc\\bin\\Release\\Deploy\\Securemi-96x96.ico\"");
                    lbDisplay.Items.Add("       KeyPath =\"no\" />");
                    lbDisplay.Items.Add("   </Component>");
                    */

                    j = 0;
                    k = 1;
                    iFirst = 1;
                    sDirName1 = Path.GetDirectoryName(txtSourceDir.Text);
                    sDirName2 = Path.GetDirectoryName(txtSourceDir.Text);
                    foreach (string sFn in GetAllFilesInDirectory(txtSourceDir.Text, chkIgnoreSubFolder.Checked))
                    {
                        #region foreach (string sFn in GetAllFilesInDirectory(txtSourceDir.Text))
                        sDirName1 = Path.GetDirectoryName(sFn);
                        if (sDirName1 != sDirName2)
                        {
                            if (j == 1)
                            {
                                lbDisplay.Items.Add("   </Component>");//wrong

                                DirectoryInfo oDi1 = new DirectoryInfo(sDirName1);
                                DirectoryInfo oDi2 = new DirectoryInfo(sDirName2);

                                //if (iFirst != 0)
                                if (IsWinSubFolder(oDi1, oDi2) == false)
                                {
                                    lbDisplay.Items.Add("   </Directory>");
                                    iFirst++;
                                }

                                j = 0;
                            }
                            j = 1;

                            sCompStr = Path.GetFileName(Path.GetDirectoryName(sFn)) + "Item" + txtItrSym.Text + i;
                            sCompStr1 = Path.GetFileName(Path.GetDirectoryName(sFn)) + "Item";
                            if (slConfig1.Contains(sCompStr1) == true)
                            {
                                //To handle folder with the same name
                                if (i == 1)
                                {
                                    sCompStr = Path.GetFileName(Path.GetDirectoryName(sFn)) + k.ToString() + "Item";

                                    slConfig1.Add(sCompStr);

                                    sCompStr = sCompStr + txtItrSym.Text + i;
                                    k++;
                                }
                            }

                            if (slConfig1.Contains(sCompStr1) == false)
                            {
                                slConfig1.Add(sCompStr1);
                            }

                            if (iFolderInterationStart >= 1)
                            {
                                lbDisplay.Items.Add("   <Directory Id =\"" + Path.GetFileName(Path.GetDirectoryName(sFn)) + txtItrSym.Text + i + "\" Name=\"" + Path.GetFileName(Path.GetDirectoryName(sFn)) + "\">");
                                iFolderInterationStart++;
                            }
                            sGuid = Guid.Parse(GetMD5HashFromText("WIX Script Generator " + sCompStr)).ToString();
                            lbDisplay.Items.Add("   <Component Id =\"" + sCompStr + "\" Guid=\"{" + sGuid + "}\">");
                            slConfig.Add(sCompStr + " | " + sGuid);
                            iFolderCount++;

                            //Only selected files will be added to installer
                            if (IsFileSelected(sFn) == true)
                            {
                                #region Only selected files will be added to installer
                                lbDisplay.Items.Add("       <File Id =\"" + NormalizingStringWithoutPunctuation(Path.GetFileName(sFn)) + txtItrSym.Text + i + "\"");
                                lbDisplay.Items.Add("           Source =\"" + sFn + "\"");
                                //lbDisplay.Items.Add("           KeyPath =\"no\" />");

                                if (Path.GetExtension(sFn).ToUpper().Equals(".EXE") == true)
                                {
                                    if (bDoOnce == false)
                                    {
                                        if (sFn.Equals(lblMainExeFile.Text) == true)
                                        {
                                            lbDisplay.Items.Add("           KeyPath =\"yes\" />");
                                            if (chkShortcut.Checked == true)
                                            {
                                                sDoOnceExeId = NormalizingStringWithoutPunctuation(Path.GetFileName(sFn)) + txtItrSym.Text + i;
                                            }
                                        }
                                        else
                                        {
                                            lbDisplay.Items.Add("           KeyPath =\"no\" />");
                                        }
                                    }
                                    bDoOnce = true;
                                }
                                else
                                {
                                    lbDisplay.Items.Add("           KeyPath =\"no\" />");
                                }
                                iFileCount++;
                                #endregion
                            }

                            sDirName2 = Path.GetDirectoryName(sFn);
                        }
                        else
                        {
                            //Only selected files will be added to installer
                            if (IsFileSelected(sFn) == true)
                            {
                                #region Only selected files will be added to installer
                                toolStripStatusLabel1.Text = sFn;
                                lbDisplay.Items.Add("       <File Id =\"" + NormalizingStringWithoutPunctuation(Path.GetFileName(sFn)) + txtItrSym.Text + i + "\"");
                                lbDisplay.Items.Add("           Source =\"" + sFn + "\"");
                                //lbDisplay.Items.Add("           KeyPath =\"no\" />");

                                if (Path.GetExtension(sFn).ToUpper().Equals(".EXE") == true)
                                {
                                    if (bDoOnce == false)
                                    {
                                        if (sFn.Equals(lblMainExeFile.Text) == true)
                                        {
                                            lbDisplay.Items.Add("           KeyPath =\"yes\" />");
                                            if (chkShortcut.Checked == true)
                                            {
                                                sDoOnceExeId = NormalizingStringWithoutPunctuation(Path.GetFileName(sFn)) + txtItrSym.Text + i;
                                            }
                                        }
                                        else
                                        {
                                            lbDisplay.Items.Add("           KeyPath =\"no\" />");
                                        }
                                    }
                                    else
                                    {
                                        lbDisplay.Items.Add("           KeyPath =\"no\" />");
                                    }
                                    bDoOnce = true;
                                }
                                else
                                {
                                    lbDisplay.Items.Add("           KeyPath =\"no\" />");
                                }
                                iFileCount++;
                                #endregion
                            }

                            sDirName2 = Path.GetDirectoryName(sFn);
                        }

                        #endregion
                    }//foreach (string sFn in GetAllFilesInDirectory(txtSourceDir.Text))

                    //End of folder for each subfolder
                    lbDisplay.Items.Add("   </Component>");

                    for (int m = 0; m <= iFirst; m++)
                    {
                        if (iFolderInterationEnd >= 1)
                        {
                            lbDisplay.Items.Add("   </Directory>");
                            iFolderInterationEnd++;
                        }
                    }

                    //Close folder DEPLOY folder
                    //lbDisplay.Items.Add("   </Directory>");

                    //Close folder INSTALLFOLDER folder
                    //lbDisplay.Items.Add("   </Directory>");
                    j = 0;
                    #endregion
                }//for (int i = 1; i <= iIteration; i++)
                lbDisplay.Items.Add("</DirectoryRef>");
                #endregion

                #region Add the shortcut to your installer package
                if (bDoOnce == true)
                {
                    if (chkShortcut.Checked == true)
                    {
                        if (sDoOnceExeId.Length > 0)
                        {
                            //Add the shortcut to your installer package
                            lbDisplay.Items.Add("<DirectoryRef Id =\"ProgramMenuFolder\">");
                            lbDisplay.Items.Add("   <Component Id =\"ApplicationShortcut\" Guid=\"{" + Guid.Parse(GetMD5HashFromText("WIX Script Generator " + DateTime.Now.ToString())).ToString() + "}\">");
                            lbDisplay.Items.Add("       <Shortcut Id=\"ApplicationStartMenuShortcut\" Name=\"" + txtProductName.Text + "\" WorkingDirectory=\"MAINFOLDER\" Description=\"Starts " + txtProductName.Text + "\" Target=\"[#" + sDoOnceExeId + "]\" />");
                            lbDisplay.Items.Add("       <RegistryValue Root=\"HKCU\" Key=\"Software\\" + txtManufacturer.Text + @"\" + txtProductName.Text + "\" Name=\"ApplicationShortcutsInstalled\" Type=\"integer\" Value=\"1\" KeyPath=\"yes\" />");
                            lbDisplay.Items.Add("       <RegistryKey Root=\"HKLM\" Key=\"Software\\" + txtManufacturer.Text + @"\" + txtProductName.Text + "\" >");
                            lbDisplay.Items.Add("           <RegistryValue Name=\"Version\" Type=\"string\" Value=\"" + txtVersion.Text + "\" KeyPath=\"no\" />");
                            lbDisplay.Items.Add("       </RegistryKey>");
                            lbDisplay.Items.Add("   </Component>");
                            lbDisplay.Items.Add("</DirectoryRef>");
                        }
                    }
                }
                #endregion

                #region Declare Features
                for (int i = 1; i <= iIteration; i++)
                {
                    #region Forloop for Features
                    lbDisplay.Items.Add("<Feature Id=\"$(var.service" + txtItrSym.Text + i + ")\"");
                    lbDisplay.Items.Add("           Title =\"$(var.service" + txtItrSym.Text + i + ")\"");
                    lbDisplay.Items.Add("           Level =\"1\">");
                    //lbDisplay.Items.Add("<ComponentRef Id=\"$(var.service" + txtItrSym.Text + i + ")\"/>");
                    //lbDisplay.Items.Add("<ComponentRef Id=\"DeItem" + txtItrSym.Text + i + "\"/>");
                    //lbDisplay.Items.Add("<ComponentRef Id=\"DeployItem" + txtItrSym.Text + i + "\"/>");

                    //Export lbDisplay content to text file
                    foreach (string sComp in slConfig1)
                    {
                        lbDisplay.Items.Add("<ComponentRef Id=\"" + sComp + txtItrSym.Text + i + "\"/>");
                    }

                    if (bDoOnce == true)
                    {
                        if (chkShortcut.Checked == true)
                        {
                            if (sDoOnceExeId.Length > 0)
                            {
                                //Add the shortcut to your installer package
                                lbDisplay.Items.Add("<ComponentRef Id=\"ApplicationShortcut\" />");
                            }
                        }
                    }

                    lbDisplay.Items.Add("</Feature>");
                    #endregion
                }
                #endregion

                lbDisplay.Items.Add("</Product>");
                lbDisplay.Items.Add("</Wix>");
                #endregion

                lblInfo.Text = iFolderCount.ToString() + " folders, " + iFileCount.ToString() + " files.";
            }
            catch (Exception exc)
            {
                lbDisplay.Items.Add(exc.Message);
            }
            finally
            {
                foreach (string s in slConfig)
                {
                    listBox1.Items.Add(s);
                }

                foreach (string s in slConfig1)
                {
                    listBox2.Items.Add(s);
                }

                if (slConfig != null)
                {
                    if (slConfig.Count > 0) { slConfig.Clear(); }
                    slConfig = null;
                }
                if (slConfig1 != null)
                {
                    if (slConfig1.Count > 0) { slConfig1.Clear(); }
                    slConfig1 = null;
                }
            }
        }

        private bool IsFileSelected(string sFile)
        {
            bool bReturn = false;

            foreach (ListViewItem myItem in this.lwFiles.CheckedItems)
            {
                //lbDisplay.Items.Add(myItem.SubItems[0].Text);//testing
                if (sFile.Equals(myItem.SubItems[0].Text) == true)
                {
                    bReturn = true;
                }
            }

            return bReturn;
        }

        private static string NormalizingStringWithoutPunctuation(string sInput)
        {
            string sReturn = string.Empty;
            sReturn = sInput.Trim();
            sReturn = StripPunctuation(sReturn);
            sReturn = StripControl(sReturn);
            return sReturn;
        }

        /// <summary>
        /// Strip of punctuation characters from a string of text
        /// </summary>
        /// <param name="sInput">string of text</param>
        /// <returns></returns>
        private static string StripPunctuation(string sInput)
        {
            var sReturn = new StringBuilder();

            foreach (char c in sInput)
            {
                if (!char.IsPunctuation(c))
                    sReturn.Append(c);
            }

            return sReturn.ToString();
        }

        /// <summary>
        /// Strip of control characters from a string of text
        /// </summary>
        /// <param name="sInput">string of text</param>
        /// <returns></returns>
        private static string StripControl(string sInput)
        {
            var sReturn = new StringBuilder();

            foreach (char c in sInput)
            {
                if (!char.IsControl(c))
                    sReturn.Append(c);
            }

            return sReturn.ToString();
        }

        private static bool IsWinSubFolder(DirectoryInfo oPath1, DirectoryInfo oPath2)
        {
            bool bReturn = false;
            if (oPath1.FullName.Contains(oPath2.FullName))
            {
                bReturn = true;
            }
            return bReturn;
        }

        private static bool IsDirectory(string sPath)
        {
            bool bReturn = false;
            System.IO.FileAttributes oFa = System.IO.File.GetAttributes(sPath);
            //bReturn = ((oFa & FileAttributes.Directory) != 0);
            bReturn = oFa.HasFlag(FileAttributes.Directory);
            return bReturn;
        }

        private static IEnumerable<string> GetAllFilesInDirectory(string directoryPath, bool bIgnoreSubdirectory)
        {
            IEnumerable<string> files = null;
            IEnumerable<string> subdirectories = null;
            try
            {
                files = Directory.EnumerateFiles(directoryPath);
                subdirectories = Directory.EnumerateDirectories(directoryPath);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No permission to access " + directoryPath);
            }
            if (files != null)
            {
                foreach (string file in files)
                {
                    yield return file;
                }
            }
            if (bIgnoreSubdirectory == false)
            {
                if (subdirectories != null)
                {
                    foreach (string subdirectory in subdirectories)
                    {
                        foreach (string file in GetAllFilesInDirectory(subdirectory, bIgnoreSubdirectory))
                        {
                            yield return file;
                        }
                    }
                }
            }
        }

        private static int CalculateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        /// <summary>
        /// To generate a random name
        /// </summary>
        /// <returns>Name in string</returns>
        private static string GetRandomName(string sInput)
        {
            int iRandomNo1 = CalculateRandomNumber(1, 999999);
            int iRandomNo2 = CalculateRandomNumber(1000000, 2000000);
            int iRandomNoSalt = 0;
            int iRandomTimes = CalculateRandomNumber(1, 5);
            string sDateTimeNow = DateTime.Now.Ticks.ToString();
            string sSeed = sInput + sDateTimeNow + iRandomNo1.ToString() + iRandomNo2.ToString();

            for (int i = 1; i <= iRandomTimes; i++)
            {
                iRandomNoSalt = CalculateRandomNumber(2000000, 3000000);
                sSeed = GetMD5HashFromText(sSeed).Replace("=", " ").Trim().ToString()
                    + iRandomNoSalt.ToString();
            }
            sSeed = GetMD5HashFromText(sSeed).Replace("=", " ").Trim().ToString();
            return sSeed;
        }

        private static string GetMD5HashFromText(string sIn)
        {
            //Need - using System.Security.Cryptography;
            Encoding enc = Encoding.UTF8;

            byte[] buffer = enc.GetBytes(sIn);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(buffer);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbDisplay.Items.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string sErrMsg = string.Empty;
            string sCurrUserMyDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";
            string sFn = string.Empty;

            if (Directory.Exists(sCurrUserMyDocPath + @"WixToolsetScriptGenerator\") == false)
            {
                Directory.CreateDirectory(sCurrUserMyDocPath + @"WixToolsetScriptGenerator\");
            }
            if (Directory.Exists(sCurrUserMyDocPath + @"WixToolsetScriptGenerator\") == true)
            {
                sFn = sCurrUserMyDocPath + @"WixToolsetScriptGenerator\" + @"wixscript.wxs";
            }

            if (lbDisplay.Items.Count == 0)
            {
                return;
            }

            if (File.Exists(sFn))
            {
                File.Delete(sFn);
            }

            foreach (string sMsg in lbDisplay.Items)
            {
                SimpleLogFile(sFn, sMsg, out sErrMsg);
            }
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.Copy(sFn, saveFileDialog1.FileName, true);

                MessageBox.Show("Done. Please get the script file at [" + saveFileDialog1.FileName + "]", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static bool SimpleLogFile(string sFn, string sContent, out string sErrMsg)
        {
            DateTime dtmCurrentDateTime = DateTime.Now;
            string sCurentDateTime = string.Empty;
            bool bReturn = false;
            sErrMsg = string.Empty;
            try
            {
                if (!File.Exists(sFn))
                {
                    using (StreamWriter oSw = File.CreateText(sFn))
                    {
                        oSw.WriteLine(sContent);
                        //close the writer
                        oSw.Flush();
                        oSw.Close();
                        bReturn = true;
                    }
                }
                else
                {
                    //set up a filestream
                    FileStream oFs = new FileStream(sFn, FileMode.OpenOrCreate, FileAccess.Write);

                    try
                    {
                        //set up a streamwriter for adding text
                        using (StreamWriter oSw = new StreamWriter(oFs))
                        {
                            //find the end of the underlaying filestream
                            oSw.BaseStream.Seek(0, SeekOrigin.End);

                            //add the text
                            oSw.WriteLine(sContent);

                            //close the writer
                            oSw.Flush();
                            oSw.Close();
                            bReturn = true;
                        }
                    }
                    finally
                    {
                        ((IDisposable)oFs).Dispose();
                    }
                }
            }
            catch (Exception exc)
            {
                sErrMsg = exc.Message;
            }

            return bReturn;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRegen_Click(object sender, EventArgs e)
        {
            txtUpgradeCode.Text = Guid.Parse(GetMD5HashFromText("WIX Script Generator " + DateTime.Now.ToString())).ToString();
        }

        private void btnRegenAssemblyName_Click(object sender, EventArgs e)
        {
            txtAssemblyName.Text = txtProductName.Text.Replace(" ", "");
        }

        private void btnSelectIcon_Click(object sender, EventArgs e)
        {            
            openFileDialog1.Filter = "Icon file|*.ico";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtIconFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnlwInsert_Click(object sender, EventArgs e)
        {
            lwFiles.Clear();
            lwFiles.CheckBoxes = true;
            lwFiles.Columns.Add("Source File Name", 1200, HorizontalAlignment.Left);

            foreach (string sFn in GetAllFilesInDirectory(txtSourceDir.Text, chkIgnoreSubFolder.Checked))
            {
                ListViewItem lvwitmFileExplorer = new ListViewItem(sFn);
                lwFiles.Items.Add(lvwitmFileExplorer);
            }
        }

        private void btnlwClear_Click(object sender, EventArgs e)
        {
            lwFiles.Clear();
        }

        private void lwFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lwFiles.SelectedItems.Count == 0)
            {
                return;
            }

            if (Path.GetExtension(this.lwFiles.SelectedItems[0].Text).ToUpper().Equals(".EXE") == true)
            {
                lblMainExeFile.Text = this.lwFiles.SelectedItems[0].Text;
            }
        }

        private void btnCodeSignInfo_Click(object sender, EventArgs e)
        {
            string sMsg = "Please follow these steps to code sign your MSI file by adding the following two lines to your 'Post-build Event Command Line':"
                + "\n\n" + "\"C:\\Program Files (x86)\\Microsoft SDKs\\ClickOnce\\SignTool\\signtool.exe\" sign /a /tr http://timestamp.entrust.net/rfc3161ts2 /fd SHA256 \"!(TargetPath)\""
                + "\n\n" + "\"C:\\Program Files (x86)\\Microsoft SDKs\\ClickOnce\\SignTool\\signtool.exe\" verify /pa /v \"!(TargetPath)\" > ..\\VerifyMsiCodesign.txt "
                + "\n\n" + "Make sure to turn on your Internet to complete the code sign process.";
            MessageBox.Show(sMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
