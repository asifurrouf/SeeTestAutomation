using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;
using experitestClient;

namespace Pearson.PSCAutomation._212App
{
    public static class NavigationCommonMethods
    {

        public static void Login(AutomationAgent navigationAutomationAgent, string login, string password)
        {
            navigationAutomationAgent.SetText("LoginView", "UserName", login);
            navigationAutomationAgent.SetText("LoginView", "Password", password);
            navigationAutomationAgent.Click("LoginView", "Login");
        }

        public static void Logout(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TopMenuView", "SystemTrayButton");
            navigationAutomationAgent.Click("TopMenuView", "LogOutButton");            
        }

        public static void NavigateToELA(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TopMenuView", "SystemTrayButton");
            if (navigationAutomationAgent.WaitforElement("TopMenuView", "ELAButton", WaitTime.SmallWaitTime))
            {
                navigationAutomationAgent.Click("TopMenuView", "ELAButton");
            }
            else
            {
                navigationAutomationAgent.Click("TopMenuView", "UnitLibrary");
                navigationAutomationAgent.Click("TopMenuView", "ELAButton");
            }
        }
    }
}
