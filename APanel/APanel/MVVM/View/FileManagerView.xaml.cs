using APanel.MVVM.ViewModel;
using System.Windows.Controls;

namespace APanel.MVVM.View
{
    /// <summary>
    /// Interaction logic for FileManagerView.xaml
    /// </summary>
    public partial class FileManagerView : UserControl
    {
        public FileManagerView()
        {
            InitializeComponent();

            DataContext = new FileManagerViewModel();
        }
    }
}
