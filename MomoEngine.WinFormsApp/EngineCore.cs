using EngineFramework.Application;
using MomoEngine.WinFormsApp.Assets.Windows;

namespace MomoEngine.WinFormsApp
{
    public class EngineCore
    {
        private static EngineCore _instance = null;
        private static Engine _engine = null;

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

        public void AppRun()
        {
            ApplicationRun();
        }

        private void ApplicationRun()
        {
            Debug.InitDebug();
            ApplicationConfiguration.Initialize();

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

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += EngineUpdate;
            timer.Enabled = false;
            timer.Start();

            Application.Run(new MainForm());
            ApplicationQuit();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Debug.LogWarn("Update");
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
