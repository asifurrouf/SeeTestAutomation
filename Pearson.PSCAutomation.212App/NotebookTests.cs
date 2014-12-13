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
        [WorkItem(8191)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void DeletePageInAscending()
        { 
            using (notebookAutomationAgent = new AutomationAgent("TC8191:Delete Page in Ascending Order from Notebook"))
            {
                try
                {
                    NavigationCommonMethods.Login(notebookAutomationAgent, Login.GetLogin("Teacher1"));
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                    NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.ClickRightArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NotebookCommonMethods.ClickLeftArrowIcon(notebookAutomationAgent);
                    NotebookCommonMethods.VerifyLeftArrowNotExists(notebookAutomationAgent);
                    NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                }
                catch (AssertFailedException ex)
                {
                    notebookAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(notebookAutomationAgent);
                    notebookAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    notebookAutomationAgent.CaptureScreenshot(ex.Message);
                    notebookAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(notebookAutomationAgent);
                    throw ex;
                } 
            }
                                 
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8192)]
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
                NotebookCommonMethods.VerifyLeftArrowNotExists(notebookAutomationAgent);
                NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8194)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void SinglePageNotebookDeleteIconInactive()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8194:Verify delete icon is inactive when single page is present in notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyLeftArrowNotExists(notebookAutomationAgent);
                NotebookCommonMethods.VerifyRightArrowNotExists(notebookAutomationAgent);
                NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
                Assert.AreEqual<string>("false", NotebookCommonMethods.GetDeleteIconEnabledStatus(notebookAutomationAgent));
            }
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [TestProperty("RallyId", "TC8195")]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void NewNotebookDeleteIconInactive()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8195:Verify delete icon is inactive when new notebook is created with Single page"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyLeftArrowNotExists(notebookAutomationAgent);
                NotebookCommonMethods.VerifyRightArrowNotExists(notebookAutomationAgent);
                Assert.AreEqual<string>("false", NotebookCommonMethods.GetDeleteIconEnabledStatus(notebookAutomationAgent));
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [TestProperty("RallyId", "TC8162")]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void PersonalNotesAppearNotebbokHide()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8162:Verify that personal notebook is displayed and task notebook hide when user select to create personal note"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyTaskNotebookFound(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                //Remove the counting from the personal notes text
                NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickCreateNoteInpersonalNote(notebookAutomationAgent);
                NotebookCommonMethods.VerifyPersonalNoteFound(notebookAutomationAgent);

            }
        }

        /// <summary>
        /// Make sure device is connected with internet
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [TestProperty("RallyId", "TC8193")]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void NotbookPageNotDeleted()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8193: Verify that notebook page is not deleted when user clicks on Cancel button "))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                NotebookCommonMethods.CancelDeleteNotebookPage(notebookAutomationAgent);
                NotebookCommonMethods.VerifyLeftArrowNotExists(notebookAutomationAgent);
                NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
            }
        }


        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [TestProperty("RallyId", "TC8277")]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyCommentsInSharedNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8277: Verify that comments are displayed all the time shared notebook is opened by user "))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "1102524", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.CreatetextboxInsideNotebook(notebookAutomationAgent);

                //client.Click("NATIVE", "", 0, 1);
                // client.Click("NATIVE", "xpath=//*[@class='UIView' and @height>0 and ./*[@text='']]", 0, 1);
                //   if (client.WaitForElement("default", "T", 0, 10000))
                //  {
                // If statement
                //  }
                // client.Click("default", "T", 0, 1);
                // client.Click("default", "E", 0, 1);
                // client.Click("default", "S", 0, 1);
                // client.Click("default", "T", 0, 1);
                //client.Click("default", "CloseKeyboard", 0, 1);

                //NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                //NotebookCommonMethods.CancelDeleteNotebookPage(notebookAutomationAgent);
                //NotebookCommonMethods.VerifyLeftArrowExists(notebookAutomationAgent);
                //NotebookCommonMethods.DeleteNotebookPage(notebookAutomationAgent);
            }
        }


    }
}
