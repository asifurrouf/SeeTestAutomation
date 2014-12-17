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
    public class LoginLogoutTests
    {
        public AutomationAgent LoginLogoutAutomationAgent;

        [TestMethod()]
        [TestCategory("Login Tests")]
        [WorkItem(119)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyControlsOnLoginPageFreshInstallation()
        {
            using (LoginLogoutAutomationAgent = new AutomationAgent("TC119: Verify that after running fresh installation of ccsoc app 'Username', 'Password' and 'Login' fields are available to user"))
            {
                try
                {
                    LoginLogoutCommonMethods.VerifyUsernameFieldPresent(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyPasswordFieldPresent(LoginLogoutAutomationAgent);
                    LoginLogoutCommonMethods.VerifyLoginButtonPresent(LoginLogoutAutomationAgent);
                }

                catch (AssertFailedException ex)
                {
                    LoginLogoutAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(LoginLogoutAutomationAgent);
                    LoginLogoutAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LoginLogoutAutomationAgent.CaptureScreenshot(ex.Message);
                    LoginLogoutAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(LoginLogoutAutomationAgent);
                    throw ex;
                } 
            }
        }

    }
}
