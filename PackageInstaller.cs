using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PELSI
{
    public class Installer
    {

        public string? GetRootFolder()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the folder where your setup files are located.";
                folderBrowserDialog.UseDescriptionForTitle = true; // For newer Windows versions
                folderBrowserDialog.ShowNewFolderButton = false; // If creating new folders is not needed

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    if (!string.IsNullOrWhiteSpace(selectedPath))
                    {
                        return selectedPath;
                    }
                }

                MessageBox.Show("Folder cannot be null. Please select a valid folder.", "Invalid Folder Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }






        public async Task InstallPackages(string rootFolder)
        {
            string puttyInstaller = Path.Combine(rootFolder, "putty-64bit-0.79-installer.msi");
            string axiomInstaller = Path.Combine(rootFolder, "AXLCSingleEWRITE_V2.0.0.msi");
            string wireSharkInstaller = Path.Combine(rootFolder, "Wireshark-latest-x64.msi");
            string vegaDtmInstaller = $@"{rootFolder}\VEGA\Software\VEGA DTM Collection_device driver DTM_2.0.0.11_xx_SW0216.exe";
            string pactWAREInstaller = $@"{rootFolder}\PACTware_5.0.4.20_xx_SW0215.exe";

            try
            {
                await InstallWithPrompt("Putty", "msiexec.exe", $"/i {puttyInstaller}");
                await InstallWithPrompt("Axiomatic", "msiexec.exe", $"/i {axiomInstaller}");
                await InstallWithPrompt("WireShark", "msiexec.exe", $"/i {wireSharkInstaller}");
                await InstallWithPrompt("Vega & DTMs", vegaDtmInstaller);
                await InstallWithPrompt("PACTware", pactWAREInstaller);
                await InstallWithPrompt("ProLink III", $@"{rootFolder}\software-prolink-iii-basic-v4-9-release-build-553-rev-5-en-6522616\Setup_ProLinkIII_Basic_v4_9_Release_b553_r5.exe");
                await InstallWithPrompt("DSU", $@"{rootFolder}\dsu_setup_Ver2.3_Build_19062116.exe", "/S");
                await InstallWithPrompt("Moxa Nport Discovery Tool", $@"{rootFolder}\Moxa\moxa-nport-5100-series-nport-search-utility-utility-v1.15\nploc_setup_Ver1.15_Build_14063019.exe");
                await InstallWithPrompt("Viber", $@"{rootFolder}\ViberSetup.exe");
                await InstallWithPrompt("MOTOTRBO CPS, ver 2.0", $@"{rootFolder}\MOTOTRBO_CPS_2.0.exe");
                await InstallWithPrompt("RAD", $@"{rootFolder}\rad_14_0_0_installer\setup.exe");
                await InstallWithPrompt("FCS", $@"{rootFolder}\Install_FracCommandSetup 2.1.3.exe");

                MessageBox.Show("End of Software List");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async Task InstallPackage(string taskName, string fileName, string arguments)
        {
            string logDirectory = @"C:\Logs\ELSI_Logs";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            using (Process packageProcess = new Process())
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    Arguments = arguments,
                    FileName = fileName,
                    UseShellExecute = false
                };

                try
                {
                    MessageBox.Show($"{taskName} Installing");
                    packageProcess.StartInfo = processInfo;
                    packageProcess.Start();
                    await packageProcess.WaitForExitAsync();
                }
                catch (Exception ex)
                {
                    string logFilePath = Path.Combine(logDirectory, "ELSI_error.log");

                    using (StreamWriter writer = File.AppendText(logFilePath))
                    {
                        writer.WriteLine($"Error installing {taskName}: {ex.Message} at {DateTime.Now}");
                    }

                    MessageBox.Show($"Error installing {taskName}: {ex.Message}");
                    MessageBox.Show($"Error log located at {logDirectory}");
                }
            }
        }

        private async Task InstallWithPrompt(string taskName, string filePath, string arguments = "")
        {
            DialogResult result = MessageBox.Show($"Do you want to install {taskName}?", "Installation Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                await InstallPackage(taskName, filePath, arguments);
            }
            else
            {
                MessageBox.Show($"{taskName} installation skipped.");
            }
        }
    }
}
