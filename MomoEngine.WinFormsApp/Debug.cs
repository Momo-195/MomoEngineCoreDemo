using EngineFramework.Log;
using System;

namespace MomoEngine.WinFormsApp
{
    public class Debug
    {
        private static PELog DBLog = null;

        public static void InitDebug()
        {
            LogConfig logConfig = new LogConfig() { enableCover = false, savePath = string.Format("{0}Logs/", AppDomain.CurrentDomain.BaseDirectory), saveName = $"{DateTime.Now.ToString("yyyy-MM-dd HH")}@Log.txt" };
            DBLog = new PELog();
            DBLog.InitSettings(logConfig);
        }

        public static void ColorLog(LogColor logColor, object msg)
        {
            if (msg == null || DBLog == null)
            {
                return;
            }
            DBLog.ColorLog(logColor, $"[client] >> {msg}");
        }

        public static void Log(object msg)
        {
            if (msg == null || DBLog == null)
            {
                return;
            }
            DBLog.Log($"[client] >> {msg}");
        }

        public static void LogWarn(object msg)
        {
            if (msg == null || DBLog == null)
            {
                return;
            }
            DBLog.Warn($"[client] >> {msg}");
        }

        public static void LogError(object msg)
        {
            if (msg == null || DBLog == null)
            {
                return;
            }
            DBLog.Error($"[client] >> {msg}");

        }

    }
}
