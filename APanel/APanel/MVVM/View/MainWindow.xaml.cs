using APanel.MVVM.ViewModel;
using System.Windows;

namespace APanel.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel mainVM;

        public MainWindow()
        {
            InitializeComponent();

            mainVM = new MainViewModel();
            contentControl.Content = mainVM.primaryVM;
        }
    }
}
