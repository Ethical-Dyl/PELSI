using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Management;
using System.Net.NetworkInformation;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using System.Text;
using Windows.Management.Deployment;

namespace PELSI
{
    public partial class Form1 : Form
    {

        private string rootFolder;

        
        public Form1()
        {
            InitializeComponent();

            // Declares the rootFolder 
            string rootFolder = string.Empty;

           
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Check Boxes

        // AMI Check Boxes
        private void checkBoxLicense_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void skipSoftware_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void skipSettingsini_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void skipNI_Click(object sender, EventArgs e)
        {

        }
        private void skipREG_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void skipREG_Click(object sender, EventArgs e)
        {

        }

        // MDT Check Boxes
        private void skipREG1_Click(object sender, EventArgs e)
        {

        }

        private void skipREG1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mdtSkipSoftware_CheckedChanged(object sender, EventArgs e)
        {

        }


        // End CheckBoxes


        // Buttons

        // Tech Install - Button Click
        private async void button1_Click(object sender, EventArgs e)
        {
            string techMessage = "1. Install software (unless skipped) \n" +
                                 "2. Check/Update Settings.ini \n" +
                                 "3. Pull AMI License + Config Files \n" +
                                 "4. Disable NI Services \n" +
                                 "5. Run Windows REGBAK";
            MessageBox.Show(techMessage, "Order of Operations", MessageBoxButtons.OK, MessageBoxIcon.None);

            // Create an instance of Installer, AmiConfigurator & MDTConfigurator
            AmiConfigurator amiConfigurator = new AmiConfigurator();
            MDTConfigurator mdtConfigurator = new MDTConfigurator();
            Installer installer = new Installer();

            // Check if the user wants to skip installation
            if (!skipSoftware.Checked)
            {
                rootFolder = installer.GetRootFolder(); // Assigns the value to the class-level field
                if (rootFolder == null)
                {
                    MessageBox.Show("Folder cannot be null. Please select a valid folder.", "Invalid Folder Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exits the method if no valid folder is selected
                }
                await installer.InstallPackages(rootFolder);
            }

            // After the installation process, these run
            if (!skipSettingsini.Checked)
            {
                amiConfigurator.CheckAndUpdateSettings();
            }

            if (!checkBoxLicense.Checked)
            {
                amiConfigurator.AmiLicense();
            }

            if (!skipNI.Checked)
            {
                amiConfigurator.DisableServices();
            }

            if (!skipREG.Checked)
            {
                mdtConfigurator.WindowsREGBAK();
            }
        }

        // AMI License Only Button
        private void button4_Click(object sender, EventArgs e)
        {
            AmiConfigurator amiConfigurator = new AmiConfigurator();
            amiConfigurator.AmiLicense();
        }

        // AMI Settings.ini Only Button
        private void button2_Click(object sender, EventArgs e)
        {
            AmiConfigurator amiConfigurator = new AmiConfigurator();
            amiConfigurator.CheckAndUpdateSettings();
        }

        // SPE Button
        private void speLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Throw up your horns"); //Just 4 fun
        }

        // This is the Check list help button
        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Skip Software - Skips the software Installation.\n\n" +
                             "Skip Settings.ini - This skips to check if the Settings.ini file has been set to Designer mode\n\n" +
                             "Skip AMI License/Config - Pulls and stores AMI License & Config Files.\n\n" +
                             "Skip NI Services - Skips the NI services from being disabled.\n\n" +
                             "Skip REGBACK - Skips REGBAK from being run.";

            MessageBox.Show(message, "Check List Explanation", MessageBoxButtons.OK);
        }

        // End of Buttons
    }
}