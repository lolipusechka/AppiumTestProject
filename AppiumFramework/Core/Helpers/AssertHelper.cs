namespace AppiumFramework.Core.Helpers
{
    public static class AssertHelper
    {
        private enum Condition
        {
            ИСТИНА,
            ЛОЖЬ
        }

        public static void AssertIsTrue(bool condition, string message)
        {
            if (condition)
            {
                LogTrue(message);
            }
            else
            {
                var badMsg = LogFalse(message);
                throw new AssertionException(badMsg);
            }
        }

        public static void AssertIsFalse(bool condition, string message)
        {
            if (!condition)
            {
                LogFalse(message);
            }
            else
            {
                var badMsg = LogTrue(message);
                throw new AssertionException(badMsg);
            }
        }

        private static string LogTrue(string message)
        {
            var msg = $"Утверждение, '{message}' - '{Condition.ИСТИНА}'";

            LogHelper.Info(msg);

            return msg;
        }

        private static string LogFalse(string message)
        {
            var msg = $"Утверждение, '{message}' - '{Condition.ЛОЖЬ}'";

            LogHelper.Error(msg);

            return msg;
        }
    }
}
