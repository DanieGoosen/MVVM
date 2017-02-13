using MVVM.Training.ViewModels;
using MVVM.Training.Views;
using System.Windows;

namespace MVVM.Training {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            var window = new Window() {
                Height = 400,
                Width = 600,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            var mainView = new MainView();
            var mainVM = new MainViewModel();
            mainView.DataContext = mainVM;

            window.Content = mainView;
            window.ShowDialog();
        }
    }
}
