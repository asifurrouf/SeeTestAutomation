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
        private string projectBaseDirectory = "C:\\Users\\Automation\\Documents\\SeeTestAutomation\\Pearson.PSCAutomation.212App\\212SeeTestProject";
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
            client.SetDevice("ios_app:HCL-Kiran");
            client.Launch("com.pearson.commoncore.f-UpgradeTesting", true, false);
            client.ElementSendText("NATIVE", "class=UIButton", 0, "awhite");
            client.Click("default", "GistAnnotationLabel", 0, 1);
            client.LongClick("default", "CourteousImage", 0, 1, 0, 0);
            client.Click("default", "HighlightCourteous", 0, 1);
            client.Click("default", "ShareButton", 0, 1);
            client.Click("default", "SharedAnnotate", 0, 1);
            client.VerifyElementFound("default", "SharedAnnotateText", 0);
            client.Click("default", "NewWordItem", 0, 1);
            client.Click("default", "VellumModeClear", 0, 1);
            client.VerifyElementFound("default", "VellumModeClearAll", 0);
            client.DragCoordinates(1050, 600, 1150, 600, 2000);
            client.DragCoordinates(1050, 600, 1100, 700, 2000);
            client.DragCoordinates(1100, 700, 1150, 600, 2000);
            client.DragCoordinates(1050, 600, 1100, 500, 2000);
            client.DragCoordinates(1100, 500, 1150, 600, 2000);
            client.DragCoordinates(1100, 700, 1100, 500, 2000);
            client.VerifyElementFound("default", "DiamondImageDrawnInCR", 0);
            client.SendText("{BKSP}");
        }

        [TestCleanup()]
        public void TearDown()
        {
            client.GenerateReport(true);
        }
    }
}