using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;

namespace Experitest
{
    [TestClass]
    public class launchapp
    {
        private string host = "localhost";
        private int port = 8889;
        private string projectBaseDirectory = "C:\\Automation\\SeeTestAutomationUI_11-18";
        protected Client client = null;
        
        [TestInitialize()]
        public void SetupTest()
        {
            client = new Client(host, port, true);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "reports", "launchapp");
        }

        [TestMethod]
        public void Testlaunchapp()
        {
            client.SetDevice("ios_app:Lab13-ipadmini");
            client.Launch("com.pearson.commoncore.f-UpgradeTesting", true, false);
            client.ElementSendText("NATIVE", "class=UIButton", 0, "awhite");
        }

        [TestCleanup()]
        public void TearDown()
        {
            client.GenerateReport(true);
        }
    }
}