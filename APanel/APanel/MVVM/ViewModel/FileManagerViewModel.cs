using APanel.Data;
using APanel.Helper;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace APanel.MVVM.ViewModel
{
    internal class FileManagerViewModel
    {
        private string currentPath;

        public ObservableCollection<FileManagerData> Data { get; set; }

        public Command<FileManagerData> MoreCommand { get; set; }

        public Command<FileManagerData> OpenCommand { get; set; }

        public Command ReturnHomeCommand { get; set; }

        public FileManagerViewModel()
        {
            currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/";

            Data = new ObservableCollection<FileManagerData>();

            GetFiles(currentPath);

            MoreCommand = new Command<FileManagerData>(ExecuteMoreCommand);
            OpenCommand = new Command<FileManagerData>(ExecuteOpenCommand);
            ReturnHomeCommand = new Command(ExecuteReturnHomeCommand);
        }

        private void GetFiles(string path)
        {
            DirectoryInfo[] directoryInfos = new DirectoryInfo(path).GetDirectories();

            foreach (DirectoryInfo item in directoryInfos)
            {
                Data.Add(new FileManagerData()
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
                Data.Add(new FileManagerData()
                {
                    Icon = "📰",
                    Name = item.Name,
                    Size = $"{item.Length.ToString()} Bytes",
                    ModificationTime = item.LastAccessTime.ToString(),
                });
            }
        }

        private void ExecuteOpenCommand(FileManagerData data)
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

        private void ExecuteReturnHomeCommand()
        {
            Data.Clear();

            currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/";

            GetFiles(currentPath);
        }

        private void ExecuteMoreCommand(FileManagerData data)
        {
            MessageBox.Show("This is a test!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            //- data.Name;
        }
    }
}
