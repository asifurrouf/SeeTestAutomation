using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;
using experitestClient;

namespace Pearson.PSCAutomation._212App
{
    public static class CommonReadCommonMethods
    {
        public static void OpenCommonRead(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("LessonView", "EreaderDiv");
        }

        public static void ToggleVellumMode(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "VellumMode");
        }

        public static bool PinchOutOnScreen(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.PinchOut();
        }

        public static void ClickOnDoneButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadTopMenuView", "DoneButton");
        }

    }
}
