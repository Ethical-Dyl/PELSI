using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PELSI
{
    public class MDTConfigurator
    {
        // Windows Update REGBAK
        public void WindowsREGBAK()
        {
            try
            {
                MessageBox.Show("Running REGBAK");

                string batchFilePath = @"C:\MDT\REGBAK\restorewindowsupdate.bat";

                // Create a new process start info
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Use cmd.exe to run the batch file
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WorkingDirectory = @"C:\MDT\REGBAK\" // Set the working directory to the batch file's location
                };

                // Start the process
                Process process = new Process { StartInfo = processStartInfo };

                try
                {
                    process.Start();

                    // Pass the batch file path as a command to cmd.exe
                    process.StandardInput.WriteLine($"\"{batchFilePath}\"");

                    // Close the standard input to signal the end of the input
                    process.StandardInput.Close();

                    // Read and output the result
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    // Log the output and error to a file
                    File.WriteAllText(@"C:\MDT\REGBAK\log.txt", $"Output:{Environment.NewLine}{output}{Environment.NewLine}Error:{Environment.NewLine}{error}");
                    File.WriteAllText(@"C:\Logs\ELSI_Logs\REGBAKLog.txt", $"Output:{Environment.NewLine}{output}{Environment.NewLine}Error:{Environment.NewLine}{error}");



                    // Check if there were any errors
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Error occurred. See log.txt for details.");
                    }
                    else
                    {
                        MessageBox.Show("REGBAK completed successfully!");
                    }
                }
                finally
                {
                    // Ensure the process is properly closed
                    process.WaitForExit();
                    process.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
























    }
}
