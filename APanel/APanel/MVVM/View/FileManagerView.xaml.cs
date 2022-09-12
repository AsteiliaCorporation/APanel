using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace APanel.MVVM.View
{
    /// <summary>
    /// Interaction logic for FileManagerView.xaml
    /// </summary>
    public partial class FileManagerView : UserControl
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/AsteiliaNetwork/Asteilia-Skyblock/";

        public FileManagerView()
        {
            InitializeComponent();
            
            Get();
        }

        private void Get()
        {
            DirectoryInfo[] directoryInfos = new DirectoryInfo(path).GetDirectories();

            foreach (DirectoryInfo item in directoryInfos)
            {
                Button button = new Button()
                {
                    Height = 36,
                    Padding = new Thickness(16, 0, 16, 0),
                    Background = Brushes.Red,
                    HorizontalContentAlignment = HorizontalAlignment.Stretch,
                    VerticalContentAlignment = VerticalAlignment.Stretch
                };

                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                ColumnDefinition columnDefinition = new ColumnDefinition();

                TextBlock textBlock = new TextBlock()
                {
                    Text = "[  ]",
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                textBlock.SetValue(Grid.ColumnProperty, 1);
                //textBlock.SetValue(Parent, columnDefinition);
            }
        }
    }
}
