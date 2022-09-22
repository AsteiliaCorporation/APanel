using APanel.ViewModels;
using APanel.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace APanel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public bool ApplicationStarted { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            base.OnStartup(e);

            try
            {
                ForceSingleInstance();

                MainWindow = new AuthenticationView();
                MainWindow.Show();
            }
            catch (ApplicationException applicationException)
            {
                MessageBox.Show(applicationException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // do something.  In fact, here I do a lot of stuff that reflects 
            // some serious recent application illnesss:
            try
            {
                //http://connect.microsoft.com/VisualStudio/feedback/details/618027/uriformatexception-thrown-by-ms-internal-fontcache-util
                Environment.SetEnvironmentVariable("windir", Environment.GetEnvironmentVariable("SystemRoot"));

                // per http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.ietflanguagetag(v=vs.110).aspx

                var cultureName = CultureInfo.CurrentCulture.Name;
                FrameworkElement.LanguageProperty.OverrideMetadata(
                    typeof(FrameworkElement),
                    new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(cultureName)));


                // Setup unhandled exception handlers
                // anything else to do on startup can go here and will fire after the base startup event of the application
                // First make sure anything after this is handled
                // Creates an instance of the class holding delegate methods that will handle unhandled exceptions.
                // CustomExceptionHandler eh = new CustomExceptionHandler();
                // AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(eh.OnAppDomainException);
                // this ensures that any unhandled exceptions bubble up to a messagebox at least
                // Dispatcher.CurrentDispatcher.UnhandledException += new DispatcherUnhandledExceptionEventHandler(eh.OnDispatcherUnhandledException);
                // Start the dispatcher
                // for Galasoft threading and messaging
                // DispatcherHelper.Initialize();

            }
            catch (Exception)
            {
                // ex.PreserveExceptionDetail();
            }
        }

        private void ForceSingleInstance()
        {
            if (ApplicationStarted)
            {
                throw new ApplicationException("Application has already started!\nOnly 1 instance allowed!");
            }

            ApplicationStarted = true;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ApplicationStarted = false;
        }
    }
}
