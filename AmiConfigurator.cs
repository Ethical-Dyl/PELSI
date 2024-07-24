using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;

namespace PELSI
{
    public class AmiConfigurator
    {

        // This checks the Settings.ini file, and sets it to Designer mode if it is not already.

        public void CheckAndUpdateSettings()
        {
            string settingsFilePath = @"C:\Users\Public\Documents\Advanced Measurements\FCS\Settings.ini";
            MessageBox.Show("Checking if Settings.ini is in Designer mode..");

            if (File.Exists(settingsFilePath))
            {
                try
                {
                    // Read all lines from the Settings.ini file
                    string[] lines = File.ReadAllLines(settingsFilePath);

                    // Check if there are at least two lines
                    if (lines.Length >= 2)
                    {
                        // Check if the second line contains "APP_MODE=Designer"
                        if (!lines[1].Trim().Equals("APP_MODE=Designer", StringComparison.OrdinalIgnoreCase))
                        {
                            // If not, update the second line to "APP_MODE=Designer"
                            lines[1] = "APP_MODE=Designer";

                            // Write the updated lines back to the file
                            File.WriteAllLines(settingsFilePath, lines);

                            MessageBox.Show("Settings.ini has successfully been updated to Designer.");
                            return;
                        }
                    }
                    MessageBox.Show("Settings.ini is set to designer");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating Settings.ini: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Settings.ini file not found.");
            }
        }
        
        // Frontend Logic to call DisableServices
        public static void DisableService(string serviceName)
        {
            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = "sc";
                process.StartInfo.Arguments = $"config {serviceName} start=disabled";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Failed to disable service. Output: {output}");
                }
            }
        }

        // Backend Logic to disable the service
        public void DisableServices()
        {
            // Specify the service name
            string NIWebServ = "NIApplicationWebServer";
            string NIWebServ6 = "NIApplicationWebServer64";

            try
            {
                // Stop the service
                StopService(NIWebServ);
                StopService(NIWebServ6);

                // Disable the service (set its startup type to Disabled)
                DisableService(NIWebServ);
                DisableService(NIWebServ6);

                MessageBox.Show("Service disabled successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void StopService(string serviceName)
        {
            using (ServiceController serviceController = new ServiceController(serviceName))
            {
                if (serviceController.Status == ServiceControllerStatus.Running)
                {
                    serviceController.Stop();
                    serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                }
            }
        }

        // Method to prompt the user for the MAC address
        private string PromptForMacAddress()
        {
            return Microsoft.VisualBasic.Interaction.InputBox("Enter MAC address:", "MAC Address", "00-00-00-00-00-00");
        }


        public void AmiLicense()
        {
            string appPath = @"C:\Program Files (x86)\Advanced Measurements\DVCommand\DVCommand.exe";
            string licensePath = @"C:\Program Files (x86)\Advanced Measurements\DVCommand\license.lic";
            string configPath = @"C:\Program Files (x86)\Advanced Measurements\DVCommand\MC_config_data.bin";

            if (File.Exists(appPath))
            {
                MessageBox.Show("DVCommand.exe is present! \nPreparing to copy License & Config Files");

                // Open cmd and run ipconfig /all
                using (Process pr = new Process())
                {
                    pr.StartInfo.FileName = "cmd.exe";
                    pr.StartInfo.Arguments = "/k ipconfig /all";
                    pr.Start();

                    try
                    {
                        string destinationFolder = string.Empty;
                        using (var dialog = new FolderBrowserDialog())
                        {
                            DialogResult result = dialog.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                destinationFolder = dialog.SelectedPath;

                                // Prompt the user for the MAC address
                                string macAddress = PromptForMacAddress();

                                // Create a folder with the user-provided MAC address as the name
                                string macFolder = Path.Combine(destinationFolder, macAddress);
                                Directory.CreateDirectory(macFolder);

                                // Copy the files to the newly created folder
                                File.Copy(licensePath, Path.Combine(macFolder, "license.lic"));
                                File.Copy(configPath, Path.Combine(macFolder, "MC_config_data.bin"));

                                MessageBox.Show("Files copied successfully.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                    finally
                    {
                        pr.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("DVCommand.exe is not present.");
            }
        }













    }
}