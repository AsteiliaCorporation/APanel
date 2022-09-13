namespace APanel.MVVM.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public PrimaryViewModel PrimaryViewModel { get; }

        public MainViewModel()
        {
            PrimaryViewModel = new PrimaryViewModel();
        }
    }
}
