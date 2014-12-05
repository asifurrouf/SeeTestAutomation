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
    /// <summary>
    /// Summary description for NotebookTests
    /// </summary>
    [TestClass]
    public class NotebookTests
    {
        public AutomationAgent notebookAutomationAgent;
        public NotebookTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [TestProperty("RallyId", "TC8191")]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void DeletePageInAscending()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8191:Delete Page in Ascending Order from Notebook"))
            {
                try
                {
                    NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch(Exception ex)
                {
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                    notebookAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }

            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [TestProperty("RallyId", "TC8192")]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void DeletePageInDescending()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8192:Delete Page in Descending Order from Notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent);
                NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [TestProperty("RallyId", "TC8194")]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void SinglePageNotebookDeleteIconInactive()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8194:Verify delete icon is inactive when single page is present in notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent);
                NotebookCommonMethods.VerifyRightArrowExists(notebookAutomationAgent);
                NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                Assert.AreEqual<string>("false", NotebookCommonMethods.GetDeleteIconEnabledStatus(notebookAutomationAgent));
            }
        }
    }
}
