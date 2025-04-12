using UnityEngine;

namespace XaviEssencials.Runtime
{
    public static class GameLogger
    {
        public static void Log(object message, LogCategory logCategory, Object context = null)
        {
            LogInternal(message, logCategory, LogType.Log, context);
        }

        public static void LogError(object message, LogCategory logCategory, Object context = null)
        {
            LogInternal(message, logCategory, LogType.Error, context);
        }

        public static void LogWarning(object message, LogCategory logCategory, Object context = null)
        {
            LogInternal(message, logCategory, LogType.Warning, context);
        }

        private static void LogInternal(object message, LogCategory logCategory, LogType logType, Object context)
        {
            string formattedMessage = $"[{logCategory.ToString().ToUpper()}] {message}";

            switch (logType)
            {
                case LogType.Log:
                    {
                        if (context != null)
                        {
                            Debug.Log(formattedMessage, context);
                        }
                        else
                        {
                            Debug.Log(formattedMessage);
                        }
                        break;
                    }

                case LogType.Warning:
                    {
                        if (context != null)
                        {
                            Debug.LogWarning(formattedMessage, context);
                        }
                        else
                        {
                            Debug.LogWarning(formattedMessage);
                        }
                        break;
                    }

                case LogType.Error:
                    {
                        if (context != null)
                        {
                            Debug.LogError(formattedMessage, context);
                        }
                        else
                        {
                            Debug.LogError(formattedMessage);
                        }
                        break;
                    }
            }
        }
    }
}
