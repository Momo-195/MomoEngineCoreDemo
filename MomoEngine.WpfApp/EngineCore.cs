using EngineFramework.Application;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;

namespace MomoEngine.WpfApp
{
    public class EngineCore
    {
        private static EngineCore _instance = null;
        private static Engine _engine = null;
        private static App _app = null;

        public SplashScreen splashScreen;
        private DispatcherTimer dispatcherTimer;
        public bool IsApplicationInit = false;

        private EngineCore()
        {

        }

        public static EngineCore Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EngineCore();

                return _instance;
            }
        }

        public static Engine engineInstance
        {
            get
            {
                if (_engine == null)
#if DEBUG
                    _engine = new Engine();
#else
                    _engine = new Engine(false);
#endif

                return _engine;
            }
        }

        public static App appInstance
        {
            get
            {
                if (_app == null)
                    _app = new App();

                return _app;
            }

        }

        public void AppRun()
        {
            Init();
            ApplicationRun();
        }

        private void Init()
        {
            splashScreen = new SplashScreen("assets/resources/logo.png");
            splashScreen.Show(false, true);

            Debug.InitDebug();

            //ProcedureComponent.m_EntranceProcedureTypeName = "StartProcedure";
            //engineInstance.AddEngineBehaviour();

            /* 载入当前程序集下所有Behaviour
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                engineInstance.AddBehaviour(type);
            }
            */


            Time.fixedDeltaTime = 2000;
            Time.updateDeltaTime = 1;

            Task.Run(() =>
            {
                while (engineInstance.GetIsFixedUpdate)
                {
                    EngineFixedUpdate();
                }
            });

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromTicks(0);
            dispatcherTimer.Tick += EngineUpdate;
            dispatcherTimer.Start();
        }


        private void ApplicationRun()
        {
            appInstance.InitializeComponent();

            string strProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //检查进程是否已经启动，已经启动则退出程序。 
            if (System.Diagnostics.Process.GetProcessesByName(strProcessName).Length > 1)
            {
                DateTime current = DateTime.Now;
                while (current.AddMilliseconds(500) > DateTime.Now)
                {
                    if (System.Diagnostics.Process.GetProcessesByName(strProcessName).Length <= 1)
                    {
                        appInstance.Run();
                        return;
                    }
                }
                appInstance.StartupUri = new Uri("/Assets/Windows/WindowView/HideWindow.xaml", UriKind.Relative);
                appInstance.Run();

            }
            else
            {
                appInstance.Run();
            }

            ApplicationQuit();
        }

        private void EngineFixedUpdate()
        {
            engineInstance.FixedUpdate(Time.fixedDeltaTime);
        }

        private void EngineUpdate(object sender, EventArgs e)
        {
            if (engineInstance.GetIsUpdate)
            {
                engineInstance.Update(Time.updateDeltaTime);
            }
        }

        public void ApplicationQuit()
        {
            engineInstance.ApplicationQuit();
        }

    }
}
