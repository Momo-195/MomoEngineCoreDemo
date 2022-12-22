using MomoEngine.WpfApp.Assets.Scripts.WindowScripts;
using System.Windows;


namespace MomoEngine.WpfApp.Assets.Windows.WindowView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EngineCore.engineInstance.AddBehaviour<MainWindowScript>(this);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            EngineCore.engineInstance.RemoveBehaviour<MainWindowScript>();
        }
    }
}
