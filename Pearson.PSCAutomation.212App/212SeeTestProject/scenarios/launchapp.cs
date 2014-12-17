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
        private string projectBaseDirectory = "C:\\Users\\Pearson\\Documents\\SeeTestAutomation\\Pearson.PSCAutomation.212App\\212SeeTestProject";
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
            client.SetDevice("ios_app:Lab13_Ipad");
            client.Launch("com.pearson.commoncore.f-UpgradeTesting", true, false);
            client.ElementSendText("NATIVE", "class=UIButton", 0, "awhite");
            client.Click("default", "GistAnnotationLabel", 0, 1);
            client.LongClick("default", "CourteousImage", 0, 1, 0, 0);
            client.Click("default", "HighlightCourteous", 0, 1);
            client.Click("default", "ShareButton", 0, 1);
            client.Click("default", "SharedAnnotate", 0, 1);
            client.VerifyElementFound("default", "SharedAnnotateText", 0);
            client.ElementSendText("", "", 0, "");
        }

        [TestCleanup()]
        public void TearDown()
        {
            client.GenerateReport(true);
        }
    }
}