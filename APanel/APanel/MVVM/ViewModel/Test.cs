using APanel.Data;
using APanel.Helper;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace APanel.MVVM.ViewModel
{
    internal class Test
    {
        private string currentPath;

        public ObservableCollection<TestData> Data { get; set; }

        public Command<TestData> MoreCommand { get; set; }

        public Command<TestData> OpenCommand { get; set; }

        public Test()
        {
            currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/";

            Data = new ObservableCollection<TestData>();

            GetFiles(currentPath);

            MoreCommand = new Command<TestData>(ExecuteMoreCommand);
            OpenCommand = new Command<TestData>(ExecuteOpenCommand);
        }

        private void GetFiles(string path)
        {
            DirectoryInfo[] directoryInfos = new DirectoryInfo(path).GetDirectories();

            foreach (DirectoryInfo item in directoryInfos)
            {
                Data.Add(new TestData()
                {
                    Icon = "📁",
                    Name = item.Name,
                    Size = null,
                    ModificationTime = item.LastAccessTime.ToString(),
                });
            }

            FileInfo[] fileInfos = new DirectoryInfo(path).GetFiles();

            foreach (FileInfo item in fileInfos)
            {
                Data.Add(new TestData()
                {
                    Icon = "📰",
                    Name = item.Name,
                    Size = $"{item.Length.ToString()} Bytes",
                    ModificationTime = item.LastAccessTime.ToString(),
                });
            }
        }

        private void ExecuteOpenCommand(TestData data)
        {
            if (data.Size == null)
            {
                Data.Clear();

                currentPath += $"{data.Name}/";

                GetFiles(currentPath);

                return;
            }

            Process process = new Process();
            process.StartInfo.WorkingDirectory = currentPath + $"{data.Name}/";
            process.StartInfo.FileName = Path.TrimEndingDirectorySeparator(currentPath + $"{data.Name}/");
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        private void ExecuteMoreCommand(TestData data)
        {
            MessageBox.Show("This is a test!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            //- data.Name;
        }
    }
}
