using MomoEngine.WinFormsApp.Assets.Scripts.WindowScripts;


namespace MomoEngine.WinFormsApp.Assets.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            (bool state, string error) ret = EngineCore.engineInstance.AddBehaviour<MainFormScript>(this);
            if (!ret.state)
            {
                Debug.LogWarn(ret.error);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            EngineCore.engineInstance.RemoveBehaviour<MainFormScript>();
        }
    }
}
