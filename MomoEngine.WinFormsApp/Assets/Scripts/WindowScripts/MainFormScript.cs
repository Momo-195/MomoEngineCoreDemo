/*----------------------------------------------------------------
 创建者：墨墨
 创建时间：2022/12/22 18:19:25
 文件：MainWindowScript.cs
 功能描述：
----------------------------------------------------------------*/


using EngineFramework.Application;
using MomoEngine.WinFormsApp.Assets.Windows;

namespace MomoEngine.WinFormsApp.Assets.Scripts.WindowScripts
{
    public class MainFormScript : Behaviour
    {

        private MainForm mainForm;

        public MainFormScript(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }


        /// <summary>
        /// 初始化时调用 在Start函数之前调用
        /// </summary>
        private void Awake()
        {

        }

        /// <summary>
        /// 仅当启用脚本实例时 才会在第一帧调用
        /// </summary>
        private void Start()
        {

        }

        /// <summary>
        /// 固定时间调用，FixedUpdate通常比Update更频繁地调用
        /// </summary>
        private void FixedUpdate()
        {

        }

        /// <summary>
        /// 每帧调用一次
        /// </summary>
        private void Update()
        {
            if (mainForm != null)
            {
                mainForm.Text = $"MainWindow - FPS:{Time.captureFramerate}";
            }
        }

        /// <summary>
        /// 在Update完成后，每帧调用一次
        /// </summary>
        private void LateUpdate()
        {

        }

        /// <summary>
        /// 在对象存在的最后一帧的所有帧更新之后调用此函数
        /// </summary>
        private void OnDestroy()
        {

        }

        /// <summary>
        /// 当程序退出时调用
        /// </summary>
        private void OnApplicationQuit()
        {

        }

    }
}
