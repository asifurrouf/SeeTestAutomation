using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;
using experitestClient;

namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class CommonReadTests
    {
        public AutomationAgent commonReadAutomationAgent;

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [TestProperty("RallyId", "TC1005")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void PinchOutInVellumMode()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1005:Pinch out in Vellum mode on a common read"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                Assert.IsFalse(NavigationCommonMethods.PinchOutOnScreen(commonReadAutomationAgent));
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }
    }
}
