using EngineFramework.Application;
using System;
using System.Diagnostics;
using System.Reflection;

namespace MomoEnigine.ConsoleApp
{
    public class EngineCore
    {
        private EngineCore() { }

        private static EngineCore _instance = null;
        private static Engine _engine = null;

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
            Init();
        }

        private void Init()
        {
            Debug.InitDebug();
            InitGlobalExceptions();

            //engineInstance.AddEngineBehaviour();
            //ProcedureComponent.m_EntranceProcedureTypeName = "ProcedureStart";

            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] Errors = engineInstance.AddBehaviour(assembly);
            foreach (string Error in Errors)
            {
                Debug.LogWarn(Error);
            }
            Time.fixedDeltaTime = 2000;
            Time.updateDeltaTime = 0;
            engineInstance.RunManuallyBehaviour(Engine.UpdateThread.InvokeThread);
        }


        /// <summary>
        /// 全局异常 只限于主线程
        /// </summary>
        public static void InitGlobalExceptions()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            DivideByZeroException err = (DivideByZeroException)e.ExceptionObject;
            Debug.LogError($"主线程异常:\r\nExceptionObject->Message:\r\n{err.Message}\r\nExceptionObject->StackTrace:\r\n{err.StackTrace}");
        }

        public void ApplicationQuit()
        {
            engineInstance.ApplicationQuit();
        }
    }
}
