using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;
using experitestClient;

namespace Pearson.PSCAutomation._212App
{
    public static class LoginLogoutCommonMethods
    {
        public static void VerifyUsernameFieldPresent(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "UserName");
        }

        public static void VerifyPasswordFieldPresent(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "Password");
        }

        public static void VerifyLoginButtonPresent(AutomationAgent LoginLogoutAutomationAgent)
        {
            LoginLogoutAutomationAgent.VerifyElementFound("LoginView", "Login");
        }

        
    }
}
