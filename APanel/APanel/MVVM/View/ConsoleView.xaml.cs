using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
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
    }

    public static class ProcessExtensions
    {
        public static IList<Process> GetChildProcesses(this Process process)
            => new ManagementObjectSearcher(
                    $"Select * From Win32_Process Where ParentProcessID={process.Id}")
                .Get()
                .Cast<ManagementObject>()
                .Select(mo =>
                    Process.GetProcessById(Convert.ToInt32(mo["ProcessID"])))
                .ToList();
    }
}
