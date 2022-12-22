namespace MomoEnigine.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EngineCore.Instance.AppRun();
            EngineCore.Instance.ApplicationQuit();
        }
    }
}