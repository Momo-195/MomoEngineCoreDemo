using EngineFramework.Application;
using System.Collections;
using System.Windows;


namespace MomoEngine.WpfApp.Assets.Windows.WindowView
{
    /// <summary>
    /// AppStartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AppStartWindow : Window
    {
        public AppStartWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CoroutineEngine.Instance.StartCoroutine(StartWindow());
        }

        private IEnumerator StartWindow()
        {
            yield return new WaitForFrame(1);
            this.Dispatcher.Invoke(() =>
            {
                Window window = new MainWindow();
                window.Show();
                this.Close();
                EngineCore.Instance.splashScreen.Close(new System.TimeSpan());
            });
        }
    }
}
