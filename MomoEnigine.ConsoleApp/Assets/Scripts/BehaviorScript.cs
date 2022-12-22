/*----------------------------------------------------------------
 创建者：墨墨
 创建时间：2022/12/22 17:49:40
 文件：BehaviorScript.cs
 功能描述：
----------------------------------------------------------------*/


using EngineFramework.Application;


namespace MomoEnigine.ConsoleApp.Assets.Scripts
{
    public class BehaviorScript : Behaviour
    {

        /// <summary>
        /// 初始化时调用 在Start函数之前调用
        /// </summary>
        private void Awake()
        {
            Debug.Log("BehaviorScript::Awake");
        }

        /// <summary>
        /// 仅当启用脚本实例时 才会在第一帧调用
        /// </summary>
        private void Start()
        {
            Debug.Log("BehaviorScript::Start");
        }

        /// <summary>
        /// 固定时间调用，FixedUpdate通常比Update更频繁地调用
        /// </summary>
        private void FixedUpdate()
        {
            Debug.Log("BehaviorScript::FixedUpdate");
        }

        /// <summary>
        /// 每帧调用一次
        /// </summary>
        private void Update()
        {
            Debug.Log("BehaviorScript::Update");
        }

        /// <summary>
        /// 在Update完成后，每帧调用一次
        /// </summary>
        private void LateUpdate()
        {
            Debug.Log("BehaviorScript::LateUpdate");
        }

        /// <summary>
        /// 在对象存在的最后一帧的所有帧更新之后调用此函数
        /// </summary>
        private void OnDestroy()
        {
            Debug.Log("BehaviorScript::OnDestroy");
        }

        /// <summary>
        /// 当程序退出时调用
        /// </summary>
        private void OnApplicationQuit()
        {
            Debug.Log("BehaviorScript::OnApplicationQuit");
        }

    }
}
