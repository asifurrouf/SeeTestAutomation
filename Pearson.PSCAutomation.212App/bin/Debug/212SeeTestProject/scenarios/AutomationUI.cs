using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;

namespace Experitest
{
    [TestClass]
    public class AutomationUI
    {
        private string host = "localhost";
        private int port = 8889;
        private string projectBaseDirectory = "C:\\Automation\\SeeTestAutomation_Github\\Pearson.PSCAutomation.212App\\212SeeTestProject";
        protected Client client = null;
        
        [TestInitialize()]
        public void SetupTest()
        {
            client = new Client(host, port, true);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "C:\\Automation\\SeeTestAutomation_Github\\Pearson.PSCAutomation.212App\\212SeeTestProject\\reports", "TestAutomationUI");
        }

        [TestMethod]
        public void TestAutomationUI()
        {
            client.SetDevice("ios_app:Lab11-ipadmini");
            client.Launch("com.pearson.commoncore.f-UpgradeTesting", true, false);
            if (client.WaitForElement("NATIVE", "class=UIButton", 0, 60000))
            {
                // If statement
            }
            client.ElementSendText("NATIVE", "accessibilityIdentifier=LoginScreen.UserNameTextField", 0, "awhite");
            if (client.WaitForElement("NATIVE", "placeholder=Password", 0, 30000))
            {
                // If statement
            }
            client.ElementSendText("NATIVE", "placeholder=Password", 0, "sch00lnet");
            if (client.WaitForElement("NATIVE", "accessibilityLabel=LOG IN", 0, 30000))
            {
                // If statement
            }
            client.Click("NATIVE", "accessibilityLabel=LOG IN", 0, 1);
            if (client.WaitForElement("NATIVE", "accessibilityLabel=button tray normal", 0, 30000))
            {
                // If statement
            }
            client.Click("NATIVE", "accessibilityLabel=button tray normal", 0, 1);
            if (client.WaitForElement("NATIVE", "accessibilityIdentifier=SystemTray.LogOutButton", 0, 30000))
            {
                // If statement
            }
            client.Click("NATIVE", "accessibilityIdentifier=SystemTray.LogOutButton", 0, 1);
        }

        [TestCleanup()]
        public void TearDown()
        {
            client.GenerateReport(false);
        }
    }
}