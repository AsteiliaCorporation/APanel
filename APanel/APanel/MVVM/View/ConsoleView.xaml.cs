using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace APanel.MVVM.View
{
    /// <summary>
    /// Interaction logic for ConsoleView.xaml
    /// </summary>
    public partial class ConsoleView : UserControl
    {
        private bool isProcessRunning;

        private int processId;

        public ConsoleView()
        {
            InitializeComponent();

            txtconsole.Text = string.Empty;

            txtbconsoleinput.KeyDown += Input_KeyDown;
        }

        private void Process_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                Dispatcher.BeginInvoke(new Action(() => txtconsole.Text += Environment.NewLine + e.Data));
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (isProcessRunning)
                {
                    Process process = Process.GetProcessById(processId);

                    process.StandardInput.WriteLine(txtbconsoleinput.Text);
                }

                txtbconsoleinput.Text = string.Empty;
            }
        }

        private void btnStart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (isProcessRunning)
            {
                MessageBox.Show("Server has already started!", "Error: 500", MessageBoxButton.OK, MessageBoxImage.Error);
                
                return;
            }

            Process process = new Process();
            //- process.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/";
            //- process.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/Skyblock.bat";
            process.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/";
            process.StartInfo.FileName = "paper-1.19.2-139.jar";
            process.StartInfo.Arguments = "-jar" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/paper -1.19.2-139.jar";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = true;

            process.OutputDataReceived += Process_DataReceived;
            process.ErrorDataReceived += Process_DataReceived;

            isProcessRunning = process.Start();

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            processId = process.Id;
            txtbconsoleinput.Text = processId.ToString();
        }

        private void btnRestart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!isProcessRunning)
            {
                MessageBox.Show("Server is NOT running!", "Error: 501", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            Process process = Process.GetProcessById(processId);

            process.StandardInput.WriteLine("stop");
            process.WaitForExit();

            process.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/";
            process.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/Skyblock.bat";          
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = true;

            process.OutputDataReceived += Process_DataReceived;
            process.ErrorDataReceived += Process_DataReceived;

            isProcessRunning = process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
        }

        private void btnStop_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!isProcessRunning)
            {
                MessageBox.Show("Server is NOT running!", "Error: 502", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            Process process = Process.GetProcessById(processId);

            process.StandardInput.WriteLine("stop");
            process.WaitForExit();
            process.Close();

            isProcessRunning = false;
        }
    }
}
