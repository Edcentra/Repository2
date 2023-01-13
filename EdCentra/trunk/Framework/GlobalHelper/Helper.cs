using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.InputDevices;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public static class Helper
    {
        public static AutomationElement Find(this AutomationElement root, string name)
        {
            return root.FindFirst(
             TreeScope.Descendants,
             new PropertyCondition(AutomationElement.NameProperty, name));
        }

        public static IEnumerable<AutomationElement> EnumChildButtons(this AutomationElement parent)
        {
            return parent == null ? Enumerable.Empty<AutomationElement>()
                                  : parent.FindAll(TreeScope.Children,
              new PropertyCondition(AutomationElement.ControlTypeProperty,
                                    ControlType.Button)).Cast<AutomationElement>();
        }

        public static bool InvokeButton(this AutomationElement button)
        {
            var invokePattern = button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;

            if (invokePattern != null)
            {
                invokePattern.Invoke();
                invokePattern.Invoke();
            }
            return invokePattern != null;
        }

        public static IEnumerable<AutomationElement> EnumNotificationIcons()
        {
            foreach (var button in AutomationElement.RootElement.Find(
                            "User Promoted Notification Area").EnumChildButtons())
            {
                yield return button;
            }
            foreach (var button in AutomationElement.RootElement.Find(
                          "System Promoted Notification Area").EnumChildButtons())
            {
                yield return button;
            }
            var chevron = AutomationElement.RootElement.Find("Notification Chevron");
            if (chevron != null && chevron.InvokeButton())
            {
                foreach (var button in AutomationElement.RootElement.Find(
                                   "Overflow Notification Area").EnumChildButtons())
                {
                    yield return button;
                }
            }
        }

        /// <summary>
        /// Opens Autopager Console
        /// </summary>
        public static void OpenAutopagerConsole()
        {
            foreach (var icon in EnumNotificationIcons())
            {
                var name = icon.GetCurrentPropertyValue(AutomationElement.NameProperty)
                           as string;
                if (name.StartsWith("Autopager Console"))
                {
                    System.Windows.Point p = icon.GetClickablePoint();
                    Mouse.Instance.DoubleClick(p);
                    Thread.Sleep(5000);
                    break;
                }
            }
        }        
    }
}
