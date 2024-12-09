using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Driver;
using AppiumTestProject.Core.Elements;
using OpenQA.Selenium;

namespace AppiumTestProject.Core.Helpers
{
    public static class AlertHelper
    {
        private static Button PermissionAllowButton = new("Разрешить", By.XPath("//*[@resource-id=\"com.android.permissioncontroller:id/permission_allow_button\"]"));
        private static Button PermissionAllowForegroundOnlyButton = new("При использовании приложения", By.XPath("//*[@resource-id=\"com.android.permissioncontroller:id/permission_allow_foreground_only_button\"]"));
        private static Button PermissionAllowOneTimeButton = new("Только в этот раз", By.XPath("//*[@resource-id=\"com.android.permissioncontroller:id/permission_allow_one_time_button\"]"));
        private static Button PermissionDenyButton = new("Запретить", By.XPath("//*[@resource-id=\"com.android.permissioncontroller:id/permission_deny_button\"]"));

        public static void ClickPermissionAllow()
        {
            LogHelper.Step("Дадим разрешение алерту на действия", () => PermissionAllowButton.ClickElement());
        }

        public static void ClickPermissionAllowForegroundOnlyButton()
        {
            LogHelper.Step("Дадим разрешение алерту на действия, пока пользуемся приложением", () => PermissionAllowForegroundOnlyButton.ClickElement());
        }

        public static void ClickPermissionAllowOneTimeButton()
        {
            LogHelper.Step("Дадим разрешение алерту на действия только в этот раз", () => PermissionAllowOneTimeButton.ClickElement());
        }

        public static void ClickPermissionDenyButton()
        {
            LogHelper.Step("Дадим запрет алерту на действия", () => PermissionDenyButton.ClickElement());
        }

        public static bool IsAlertExsist()
        {
            return PermissionDenyButton.IsElementExsist();
        }

        public static bool WaitToBeLoaded()
        {
            return AppiumDriver.Wait().Until(_ => IsAlertExsist());
        }

        public static void AssertIsLoaded()
        {
            AssertHelper.AssertIsTrue(WaitToBeLoaded(), "Алерт отображаеться на экране");
        }
    }
}