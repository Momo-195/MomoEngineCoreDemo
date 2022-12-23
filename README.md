# MomoEngine.Core
- MomoEngine.Core是一款轻量级的，集合C#脚本系统，协程等等于一体的框架系统，不依赖于任何平台，开箱即用
- MomoEngine支持的平台：控制台应用，Winfom应用，Wpf应用，Maui(等正式版)
- 使用方类似于Unity脚本系统,就是无GUI编辑器
- 所有脚本都继承自Behavior
- 协程是可以在多线程中启动的
- 立个Flag：并行协程

#### 脚本挂载/移除 函数
```C#
namespace EngineFramework.Application;

public class Engine
{
#region 添加Behaviour脚本

        /// <summary>
        /// 添加一个程序集下所有Behaviour脚本 注意：只能添加 公共无惨构造类 的Behaviour脚本
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <returns>Errors</returns>
        public string[] AddBehaviour(Assembly assembly)

        /// <summary>
        /// 添加多个程序集下所有Behaviour脚本 注意：只能添加 公共无惨构造类 的Behaviour脚本
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <returns>Errors</returns>
        public string[] AddBehaviour(Assembly[] assemblys)

        /// <summary>
        /// 添加Behaviour脚本
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public (bool State, string Error) AddBehaviour(Type type, params object[] args)
    
        /// <summary>
        /// 添加Behaviour脚本
        /// </summary>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public (bool State, string Error) AddBehaviour<T>(params object[] args) where T : Behaviour

#endregion
    
#region 移除Behaviour脚本

        /// <summary>
        /// 移除Behaviour脚本
        /// </summary>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public void RemoveBehaviour<T>() where T : Behaviour

        /// <summary>
        /// 移除Behaviour脚本
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public void RemoveBehaviour(Type type)

        /// <summary>
        /// 移除Behaviour脚本
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <returns></returns>
        public void RemoveBehaviour(string typeName)

#endregion
}
```

#### 协程启停函数 函数
```C#
namespace EngineFramework.Application;

public class Behaviour : BehaviourBase
{
#region 启动协程

        /// <summary>
        /// 启动协程
        /// </summary>
        /// <param name="methodName">函数名称</param>
        /// <returns>协程</returns>
        public Coroutine StartCoroutine(string methodName)

        /// <summary>
        /// 启动协程
        /// </summary>
        /// <param name="methodName">函数名称</param>
        /// <param name="arg">参数</param>
        /// <returns>协程</returns>
        public Coroutine StartCoroutine(string methodName, params object[] arg)

        /// <summary>
        /// 启动协程
        /// </summary>
        /// <param name="routine">迭代器</param>
        /// <returns>协程</returns>
        public Coroutine StartCoroutine(IEnumerator routine)

#endregion

#region 协程是否运行中

        /// <summary>
        /// 协程是否运行中
        /// </summary>
        /// <param name="routine">协程</param>
        /// <returns></returns>
        public bool CoroutineIsRunning(Coroutine routine)

        /// <summary>
        /// 协程是否运行中
        /// </summary>
        /// <param name="routine">迭代器</param>
        /// <returns></returns>
        public bool CoroutineIsRunning(IEnumerator routine)

        /// <summary>
        /// 协程是否运行中
        /// </summary>
        /// <param name="methodName">函数名称</param>
        /// <returns></returns>
        public bool CoroutineIsRunning(string methodName)

#endregion

#region 停止协程

        /// <summary>
        /// 停止协程
        /// </summary>
        /// <param name="methodName">函数名称</param>
        public void StopCoroutine(string methodName)

        /// <summary>
        /// 停止协程
        /// </summary>
        /// <param name="routine">迭代器</param>
        public void StopCoroutine(IEnumerator routine)

        /// <summary>
        /// 停止协程
        /// </summary>
        /// <param name="routine">协程</param>
        public void StopCoroutine(Coroutine routine)

        /// <summary>
        /// 停止所有协程
        /// </summary>
        public void StopAllCoroutines()

#endregion
}
```
