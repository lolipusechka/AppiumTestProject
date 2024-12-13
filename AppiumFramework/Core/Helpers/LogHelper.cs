using NLog;

namespace AppiumFramework.Core.Helpers
{
    public static class LogHelper
    {
        public static void Debug(string message)
        {
            LogManager.GetCurrentClassLogger().Debug(message);
        }

        public static void Info(string message)
        {
            LogManager.GetCurrentClassLogger().Info(message);
        }

        public static void Error(string message)
        {
            LogManager.GetCurrentClassLogger().Error(message);
        }

        public static T Step<T>(byte stepNumber, string message, Func<T> func)
        {
            var description = $"ШАГ {stepNumber}. {message}";

            Info(description);

            try
            {
                T value = func();

                LogSucces(description);
                ScreenshotHelper.TakeScreenshot(GetFileName(description));

                return value;
            }
            catch (Exception ex)
            {
                LogFault(description, ex);
                throw;
            }
        }

        public static T Step<T>(string message, Func<T> func)
        {
            Info(message);

            try
            {
                T value = func();

                LogSucces(message);
                ScreenshotHelper.TakeScreenshot(GetFileName(message));

                return value;
            }
            catch (Exception ex)
            {
                LogFault(message, ex);
                throw;
            }
        }

        public static void Step(byte stepNumber, string message, Action action)
        {
            var description = $"ШАГ {stepNumber}. {message}";

            Info(description);

            try
            {
                action();

                LogSucces(description);
                ScreenshotHelper.TakeScreenshot(GetFileName(description));
            }
            catch (Exception ex)
            {
                LogFault(description, ex);
                throw;
            }
        }

        public static void Step(string message, Action action)
        {
            Info(message);

            try
            {
                action();

                LogSucces(message);
                ScreenshotHelper.TakeScreenshot(GetFileName(message));
            }
            catch (Exception ex)
            {
                LogFault(message, ex);
                throw;
            }
        }

        private static void LogSucces(string description) => Info($"[ВЫПОЛНЕН] {description}");

        private static void LogFault(string description, Exception exception) => Error($"[{exception.GetType().Name}] {description}");

        private static string GetFileName(string description)
        {
            return description.Replace(" ", "").Replace(".", "").Replace(":", "").Replace("\"", "");
        }
    }
}
