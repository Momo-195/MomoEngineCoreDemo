using System;

namespace MomoEngine.WpfApp
{
    public class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            EngineCore.Instance.AppRun();
        }
    }
}
