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
            try
            {
                using (notebookAutomationAgent = new AutomationAgent("TC8191:Delete Page in Ascending Order from Notebook"))
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
        [WorkItem(8195)]
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
        [WorkItem(8162)]
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
                NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                NotebookCommonMethods.VerifyPersonalNoteFound(notebookAutomationAgent);

            }
        }

        /// <summary>
        /// Make sure device is connected with internet
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8193)]
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
        [WorkItem(8277)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyCommentsInSharedNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8277: Verify that comments are displayed all the time shared notebook is opened by user "))
            {
 
                NavigationCommonMethods.Login(notebookAutomationAgent, "1102524", "sch00lnet"); //student name: Zainab Haver
                System.Threading.Thread.Sleep(1000);

                NavigationCommonMethods.Login(notebookAutomationAgent, "1102524", "sch00lnet"); //student name: Zainab Haver
                System.Threading.Thread.Sleep(5000);
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(5000);
                NotebookCommonMethods.ClickShareNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.SelectTeacherNotebookShare(notebookAutomationAgent);
                NotebookCommonMethods.ClickNextNotebookShare(notebookAutomationAgent);
                NotebookCommonMethods.EnterSharingMessage(notebookAutomationAgent);
                string time = DateTime.Now.ToShortTimeString();
                string date = DateTime.Now.ToShortDateString();
                NotebookCommonMethods.ClickSendNotebookShare(notebookAutomationAgent);
                NotebookCommonMethods.ConfirmNotebookShare(notebookAutomationAgent);
                System.Threading.Thread.Sleep(5000);
                NotebookCommonMethods.SuccessNotebookShare(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickReceivedNotebookLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnReceivedWork(notebookAutomationAgent);
                System.Threading.Thread.Sleep(10000);
                NotebookCommonMethods.ClickOnReceivedWork(notebookAutomationAgent);
                NotebookCommonMethods.VerifyTextInComment(notebookAutomationAgent);

            }
        }


        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Incomplete
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8278)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyNameTimeStampInSharedNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8278: Verify that Name and TimeStamp are displayed in shared notebook opened by user "))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "1102524", "sch00lnet"); //student name: Zainab Haver
                System.Threading.Thread.Sleep(5000);
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(5000);
                NotebookCommonMethods.ClickShareNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.SelectTeacherNotebookShare(notebookAutomationAgent);
                NotebookCommonMethods.ClickNextNotebookShare(notebookAutomationAgent);
                NotebookCommonMethods.EnterSharingMessage(notebookAutomationAgent);
                string time = DateTime.Now.ToShortTimeString();
                string date = DateTime.Now.ToShortDateString();
                NotebookCommonMethods.ClickSendNotebookShare(notebookAutomationAgent);
                NotebookCommonMethods.ConfirmNotebookShare(notebookAutomationAgent);
                System.Threading.Thread.Sleep(5000);
                NotebookCommonMethods.SuccessNotebookShare(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickReceivedNotebookLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnReceivedWork(notebookAutomationAgent);
                System.Threading.Thread.Sleep(10000);
                NotebookCommonMethods.ClickOnReceivedWork(notebookAutomationAgent);
                NotebookCommonMethods.VerifyStudentNameInComment(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
                //verify the time and date stamp in the shared notebook

            }
        }

        
        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8279)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyCommentsNotPresentInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8279: Verify that comments icon is not displayed when sender open the sent notebook from his own account"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "1102524", "sch00lnet"); //student name: Zainab Haver
                System.Threading.Thread.Sleep(5000);
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.VerifyCommentIconNotFoundInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.VerifyCommentTextNotFoundInNotebook(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8280)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyCommentsIconFunctionalityInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8280: Verify the functionality of the comments icon"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet"); //student name: Zainab Haver
                System.Threading.Thread.Sleep(5000);
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickReceivedNotebookLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnReceivedWork(notebookAutomationAgent);
                NotebookCommonMethods.ClickCommentIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.VerifyCommentTextNotFoundInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickCommentIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.VerifyTextInComment(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8281)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyOptionsInNotebookWorkBrowser()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8281: Verify the options present in Notebook Work Browser Pop Up"))
            {

                //NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet"); //student name: Zainab Haver
                //System.Threading.Thread.Sleep(5000);
                //NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.VerifyReceivedNotebookLinkPresent(notebookAutomationAgent);
                NotebookCommonMethods.VerifyPersonalNoteLinkPresent(notebookAutomationAgent);
                NotebookCommonMethods.VerifyWorkBrowserButtonPresent(notebookAutomationAgent);
                //NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }
        

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Incomplete
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8283)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyReceivedWorkOverlayFound()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8283: Verify that the Received Work overlay is displayed when user clicks on Received Notebook link"))
            {

                //NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet"); //student name: Zainab Haver
                //System.Threading.Thread.Sleep(5000);
                //NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickReceivedNotebookLink(notebookAutomationAgent);
                //Get the count of the received work
                NotebookCommonMethods.ReceivedWorkOverlayFound(notebookAutomationAgent);
                //Verify that the number of thumbnails present is equal to the count of the recevied work
                //NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Incomplete
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8284)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyReceivedNoteBookCountIncrements()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8284: Verify that received notebooks count increments by one when user receives one notebook from any other user."))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet"); //student name: Zainab Haver
                System.Threading.Thread.Sleep(1000);
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                //Get the received notebooks count in the variable
                int oldcount = NotebookCommonMethods.GetCountAssociated(notebookAutomationAgent, "ReceivedNotes");
               
                //Login as a student
                NavigationCommonMethods.Login(notebookAutomationAgent, "1102524", "sch00lnet"); //student name: Zainab Haver
                System.Threading.Thread.Sleep(1000);
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(5000);
                NotebookCommonMethods.ClickShareNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.SelectTeacherNotebookShare(notebookAutomationAgent);
                NotebookCommonMethods.ClickNextNotebookShare(notebookAutomationAgent);
                NotebookCommonMethods.EnterSharingMessage(notebookAutomationAgent);
                NotebookCommonMethods.ClickSendNotebookShare(notebookAutomationAgent);
                NotebookCommonMethods.ConfirmNotebookShare(notebookAutomationAgent);
                System.Threading.Thread.Sleep(5000);
                NotebookCommonMethods.SuccessNotebookShare(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                int newcount = NotebookCommonMethods.GetCountAssociated(notebookAutomationAgent, "ReceivedNotes");
                Assert.IsTrue(oldcount == newcount - 1); 
                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }


        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Incomplete
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8286)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void PersonalNotesCreatedWhenPersonalNotesPresent()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8286: Verify that use can create personal notebook when few personal notes are present"))
            {

                //NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet"); //student name: Zainab Haver
                //System.Threading.Thread.Sleep(5000);
                //NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                //Get the count of the personal notes and store it in variable
                NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                //Verify the personal note new count is incremented by one
                //NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Incomplete
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8299)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifyPersonalNotesCountIncrements()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8299: Verify that personal note count increments by one when user create one personal notes"))
            {

                //NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet"); //student name: Zainab Haver
                //System.Threading.Thread.Sleep(5000);
                //NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                //Get the count of the personal notes and store it in variable
                NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                //Verify the personal note new count is incremented by one
                //NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8301)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void GoToWorkBrowserButtonFunctionality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8301: Verify that Work Browser overlay is opened when user clicks on Go to Work Browser button"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet"); //student name: Zainab Haver
                System.Threading.Thread.Sleep(3000);
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickWorkBrowserButton(notebookAutomationAgent);
                NotebookCommonMethods.VerifyWorkBrowserOverlayFound(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Incomplete
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8324)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void ViewTaskNotebookAfterPersonalNotes()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8324: Verify that task notebook is displayed when user clicks on task tile under Current tasks in Notebook Work Broswer pop up"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet"); //student name: Zainab Haver
                System.Threading.Thread.Sleep(3000);
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                NotebookCommonMethods.OpenExistingPersonalNotes(notebookAutomationAgent); //Unable to click on the Personal Note Title
                NotebookCommonMethods.VerifyPersonalNotesTitle(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.CurrentTaskOneTitle(notebookAutomationAgent);
                NotebookCommonMethods.VerifyTaskNotebookFound(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Test Scenari : Create button for Notebook must be in disable when name left blank.
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8161)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyCancelButtonDisabled()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8161: Verify that create button is disabled when user enter no name for notebook "))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                NotebookCommonMethods.SetNameToPersonalNote(notebookAutomationAgent, string.Empty);
                NotebookCommonMethods.VerifyPersonalNoteCreateButtonStatus(notebookAutomationAgent, false);
                NotebookCommonMethods.ClickCancelPersonalNoteCrate(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

       

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Test Scenari : Create button for Notebook must be in disable when name left blank.
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8160)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyCancelButtonDisabled2()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8160: User not able create personal notebook if no character in the field"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                NotebookCommonMethods.SetNameToPersonalNote(notebookAutomationAgent, string.Empty);
                NotebookCommonMethods.VerifyPersonalNoteCreateButtonStatus(notebookAutomationAgent, false);
                NotebookCommonMethods.ClickCancelPersonalNoteCrate(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Test Scenari : Create button for Notebook must be in disable when name left blank.
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(8158)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyCancelButtonDisabled1()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC8158: User not able create personal notebook if no character in the field"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickPersonalNotesLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickCreateNoteInPersonalNote(notebookAutomationAgent);
                NotebookCommonMethods.SetNameToPersonalNote(notebookAutomationAgent, "My Personal Notex");
                NotebookCommonMethods.VerifyPersonalNoteCreateButtonStatus(notebookAutomationAgent, true);
                NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                NotebookCommonMethods.VerifyPersonalNoteTitle(notebookAutomationAgent, "My Personal Notex(1/1)");
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Test Scenari : Draw pop-up with one tap
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(7092)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyDrawingToolEnable()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC7092: Native notebook: Draw pop-up with one tap"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickPenIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.VerifyPenColorPopup(notebookAutomationAgent, true);
                NotebookCommonMethods.ClickEraserIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.VerifyEraserPopup(notebookAutomationAgent, true);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5236)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyEraserSlider()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5236: VerifyNative notebook: Eraser size options"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                Assert.AreEqual<string>("true", NotebookCommonMethods.VerifySliderExists(notebookAutomationAgent));
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10307)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyUserNavigatingToTaskNoteBookToSharedNoteBook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10307: Button is available that leads the user to the task notebook from shared notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickReceivedNotebookLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnReceivedWork(notebookAutomationAgent);
                NotebookCommonMethods.ClickSharedWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickTaskNoteBookButton(notebookAutomationAgent);
                NotebookCommonMethods.VerifyNotebookBrowserExists(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10309)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifySectionedTeacherNavigatingToTaskNoteBookToSharedNoteBook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10309: Sectioned teacher can navigate to task notebook from the shared notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickReceivedNotebookLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnReceivedWork(notebookAutomationAgent);
                NotebookCommonMethods.ClickSharedWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickTaskNoteBookButton(notebookAutomationAgent);
                NotebookCommonMethods.VerifyNotebookBrowserExists(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10311)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifySectionedStudentNavigatingToTaskNoteBookToSharedNoteBook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10311: Sectioned student can navigate to task notebook from the shared notebook"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "1025860", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.NotebookWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickReceivedNotebookLink(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnReceivedWork(notebookAutomationAgent);
                NotebookCommonMethods.ClickSharedWorkBrowserView(notebookAutomationAgent);
                NotebookCommonMethods.ClickTaskNoteBookButton(notebookAutomationAgent);
                NotebookCommonMethods.VerifyNotebookBrowserExists(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10336)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyBottomToolBarInNoteBook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10336: Tool bar button is available in the notebook"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyDeleteIconExists(notebookAutomationAgent);


                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10337)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyWrenchIconClickInNoteBook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10337: Sub menu opens when tapping the wrench icon in the notebook"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                //Math Navigation Needs to be fixed
                //NavigationCommonMethods.NavigateMathTaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyWrenchToolSubMenuExists(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }







        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10338)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyDesmosToolInNoteBook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10338: Desmos tool is available when tapping the wrench icon in the notebook"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                //Math Navigation Needs to be fixed
                //NavigationCommonMethods.NavigateMathTaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                System.Threading.Thread.Sleep(1000);
                NotebookCommonMethods.ClickOnWrenchIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyDesmosTool(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10339)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyUndoRedoInNoteBook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10339: Undo/ redo  button is available in the notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                //Math Navigation Needs to be fixed
                NavigationCommonMethods.NavigateMathTaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyUndoRedoButton(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10340)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyUndoRedoClickInNoteBook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10340: Sub menu opens when tapping the undo/ redo icon in the notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                //Math Navigation Needs to be fixed
                //NavigationCommonMethods.NavigateMathTaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnUndoRedoIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyUndoRedoSubMenu(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10341)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void NewNotebookUndoRedoButton()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10341:Undo/ redo menu closes when tapping outside the canvas"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnUndoRedoIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnNotebookDrawView(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(4626)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void EditModeTextRegionTappingTwice()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC4626:Edit mode in text Region-tapping on the text region twice"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);




                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //1. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                //2. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);
                //3. Insert text                
                //NotebookCommonMethods.EnterTextInNotebookNoKeyboardClose(notebookAutomationAgent);

                System.Threading.Thread.Sleep(500);
                //4. Click somewhere outside the text box
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);


                //5. Double click on region to edit & edit text box
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 2);

                //NotebookCommonMethods.EnterTextInNotebookNoKeyboardClose(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5222)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void DrawDotAndEraseUponTap1()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5222:Drawing-draw a dot and erase a dot upon tap-When I draw dot, I see dot in notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                //CommonReadCommonMethods.OpenCommonRead(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //Draw a dot 
                //1. Select Drawing Tool
                NotebookCommonMethods.ClickPenIconInNotebook(notebookAutomationAgent);

                //2. Draw a dot
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5223)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void DrawDotAndEraseUponTap2()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5223:Drawing-draw a dot and erase a dot upon tap"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                //CommonReadCommonMethods.OpenCommonRead(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                //Draw a dot 
                NotebookCommonMethods.ClickPenIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                //Delete a dot

                //1. Enable Erase Control 
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                //2.Delete dot - Click on screen
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);


                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10473)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void ClosingAndReopeningNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10473:User will be taken to last active notebook page when closing and reopening notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 7);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                NotebookCommonMethods.VerifyCurrentPageNumber(notebookAutomationAgent, "A Taxi Trip", 2, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                notebookAutomationAgent.Sleep();
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyCurrentPageNumber(notebookAutomationAgent, "A Taxi Trip", 2, 2);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(10474)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void VerifyClosingAndReopeningNotebookPages()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC10474:User will be taken to last active notebook page when closing and reopening notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 7);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.AddNewNotebookPage(notebookAutomationAgent);
                NotebookCommonMethods.VerifyCurrentPageNumber(notebookAutomationAgent, "A Taxi Trip", 2, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                notebookAutomationAgent.Sleep();
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyCurrentPageNumber(notebookAutomationAgent, "A Taxi Trip", 2, 2);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5244)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void UndoTextIcon()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5244:Activating Redo/Undo Button"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                // 1.Click on UndoRedo button 

                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);

                // 2.Verifying Inactive Undo & Redo Button

                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyUndoButtonIncative(notebookAutomationAgent));
                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyRedoButtonIncative(notebookAutomationAgent));


                //3.NotebookCommonMethods.EnterTextInNotebookNoKeyboardClose(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(4630)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void ClearingRedoStack()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC4630:Clearing Redo Stack When Notebook Closed"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //1.Click on Drawing icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);

                //2.Swipe Drawn image
                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Right, 100, 500);

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 900, 650, 1);

                //3.Click to reenter to Notebook
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //4.Click on UndoRedo button 

                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);

                //5.Verifying Inactive Undo & Redo Button

                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyUndoButtonIncative(notebookAutomationAgent));
                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyRedoButtonIncative(notebookAutomationAgent));

                //7. Clicking on Redo doesnot make any changes 

                NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(4627)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void AbilityToDrawOverTextRegion()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC4627:Ability To Draw Over Text Region"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //Click on Drawing icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);

                // Swipe the drawingpen in a particular direction to draw             
                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Right, 100, 500);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5228)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void DisappearingDrawingToolbarClickOtherIcon()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5228:Disappearing Tool Popup"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                //Click on Drawing icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);

                //Check Drawing Pop is open 
                Assert.AreEqual<string>("true", NotebookCommonMethods.IsDrawingIconPopUpOpen(notebookAutomationAgent));

                //Click on EraseIcon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);

                //Check Drawing pop is diappeared
                Assert.AreEqual<string>("False", NotebookCommonMethods.VerfiyDrawingIconPopUpOpen(notebookAutomationAgent));
                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5227)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void DrawingOptions()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5227:Drawing options"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //Click on Drawing icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);

                //Check Drawing popup open 
                Assert.AreEqual<string>("True", NotebookCommonMethods.VerfiyDrawingIconPopUpOpen(notebookAutomationAgent));
                Assert.AreEqual<string>("true", NotebookCommonMethods.IsDrawingIconPopUpOpen(notebookAutomationAgent));

                //Click on the notebook 
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                //Popup disappeared
                Assert.AreEqual<string>("False", NotebookCommonMethods.VerfiyDrawingIconPopUpOpen(notebookAutomationAgent));
                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }



        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5229)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void DrawingSizeOptions()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5229:Drawing size options"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //Click on Drawing icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);

                //Check Slider for draw size option is open 
                Assert.AreEqual<string>("true", NotebookCommonMethods.IsDrawingIconPopUpOpen(notebookAutomationAgent));

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(2766)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void VerifyClosingNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC52766: Verify closing notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                notebookAutomationAgent.ClickOnScreen(500, 500, 1);
                NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyNotebookOpen(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyNotebookNotOpen(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(3084)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyExitingNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC3084: Verify exiting notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(4616)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void StackClearingRedo()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC4616:Clearing Redo Stack when Notebook Closed"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //1. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                //2. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                //3. Insert text                

                NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");

                System.Threading.Thread.Sleep(500);

                //4.Click back button to close notebook 
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 900, 650, 1);

                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //5.Click on UndoRedo button 

                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);

                //6.Verifying Inactive Undo & Redo Button

                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyUndoButtonIncative(notebookAutomationAgent));
                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyRedoButtonIncative(notebookAutomationAgent));

                //7. Clicking on Redo doesnot make any changes 

                NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Test Scenari : Closing notebook by tapping on navigation bar button
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(3082)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void NoteBookTopMenuOpenandClosefunctionality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC9082: Closing notebook by tapping on navigation bar button"))
            {
              
                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickOnNotebookButton(notebookAutomationAgent,true);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Test Scenari : Closing notebook by tapping on navigation bar button
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5207)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void NoteBookTextBoxMovingFunctionality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5207: Native notebook: Move text region"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                //Assining the coordinate for textbox to be present in notebook
                NotebookCommonMethods.ClickNoteBookEmptyPage(notebookAutomationAgent,1082,278);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Test Scenari : Closing notebook by tapping on navigation bar button
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5208)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void NoteBookTextBoxMoveAndCheckFunctionality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5208: Native notebook: Editing after moving text region"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                //Assining the coordinate for textbox to be present in notebook
                NotebookCommonMethods.ClickNoteBookEmptyPage(notebookAutomationAgent, 1082, 278);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        /// <summary>
        /// Make sure device is connected with internet. Student and Teacher should be linked with each other and have a common section. 
        /// Teacher should be the sectioned teacher
        /// Test Scenari : Closing notebook by tapping on navigation bar button
        /// </summary>
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5209)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void NoteBookTextBoxMoveAndEditFunctionality()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5209: Native notebook: Moving text region in edit mode should be impossible"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "efoster16", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 6, 1, 1, 4);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);
                //Assining the coordinate for textbox to be present in notebook
                NotebookCommonMethods.EditMovingTextBox(notebookAutomationAgent, 1082, 278);
                NotebookCommonMethods.SetPersonalNoteTextBoxtoEmpty(notebookAutomationAgent, string.Empty);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5248)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void UndoWordRegion()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5248:Undo every 3 Words from the region"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);



                //1. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                //2. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                //3. Insert text                
                NotebookCommonMethods.SendText(notebookAutomationAgent, "An");
                NotebookCommonMethods.SendText(notebookAutomationAgent, " ");

                NotebookCommonMethods.SendText(notebookAutomationAgent, "Apple");
                NotebookCommonMethods.SendText(notebookAutomationAgent, " ");

                NotebookCommonMethods.SendText(notebookAutomationAgent, "a");
                NotebookCommonMethods.SendText(notebookAutomationAgent, " ");

                NotebookCommonMethods.SendText(notebookAutomationAgent, "Day");
                NotebookCommonMethods.SendText(notebookAutomationAgent, " ");

                NotebookCommonMethods.SendText(notebookAutomationAgent, "keeps");
                NotebookCommonMethods.SendText(notebookAutomationAgent, " ");

                NotebookCommonMethods.SendText(notebookAutomationAgent, "doctor");


                //4. Click somewhere outside the text box
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                string WordsInTextBox2 = NotebookCommonMethods.GetWordCountsInTextBox(notebookAutomationAgent);
                Assert.AreEqual<bool>(true, WordsInTextBox2.Contains("keeps doctor"));



                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);

                //5. Get word count 
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);
                string WordsInTextBox = NotebookCommonMethods.GetWordCountsInTextBox(notebookAutomationAgent);

                Assert.AreEqual<bool>(false, WordsInTextBox.Contains("keeps doctor on"));
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }



        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5240)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void UndoTextPosition()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5240:Undo the text region movement"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //1. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                //2. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                //3. Insert text                
                NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");

                System.Threading.Thread.Sleep(500);

                //4. Click somewhere outside the text box
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                //5. Activate the same text region 
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);


                //6.Swipe the TextBox to other location
                NotebookCommonMethods.SwipeTextBoxControl(notebookAutomationAgent, 1150, 400);

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                //7.Click on Undo button 

                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }



        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5242)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void RedoTextPosition()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5242:Redo the Undo text region movement"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //1. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                //2. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                System.Threading.Thread.Sleep(500);
                //3. Insert text                
                NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");

                System.Threading.Thread.Sleep(500);

                //4. Click somewhere outside the text box
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                //5. Double click on region to write another text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);


                NotebookCommonMethods.SwipeTextBoxControl(notebookAutomationAgent, 1150, 400);

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                //6.Click on Undo button 

                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);

                //7.Click on Redo Button

                NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }
        

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5210)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void EndingEditMode()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5210:End Edit Mode by Taping Outside Text Region"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //1. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                //2. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                //3. Insert text                
                NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");

                System.Threading.Thread.Sleep(500);

                //4. Click somewhere outside the text box
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                //5. Activate the same text region 
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                //6.Swipe the TextBox to other location
                NotebookCommonMethods.SwipeTextBoxControl(notebookAutomationAgent, 1150, 400);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }




        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(4615)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void StackClearingUndo()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC4615:Clearing Undo Stack when Notebook Closed"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //1. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                //2. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                //3. Insert text                
                NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");

                System.Threading.Thread.Sleep(500);

                //4.Click back button to close notebook 

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 900, 650, 1);

                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //5.Click on UndoRedo button 

                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);

                //6.Verifying Inactive Undo & Redo Button

                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyUndoButtonIncative(notebookAutomationAgent));
                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyRedoButtonIncative(notebookAutomationAgent));

                //7. Clicking on Undo doesnot make any changes 

                NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }
        
        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5245)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void DependanceUndoandRedoButton()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5245:Dependance between Undo and Redo Button"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //1.Click on Drawing icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);

                //2.Swipe Drawn image
                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Right, 100, 500);

                //3.Click on UndoRedo button
                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);

                //4.Verifying Active Undo Button
                Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyUndoButtonIncative(notebookAutomationAgent));

                //5.Verifying Inactive Redo Button               
                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyRedoButtonIncative(notebookAutomationAgent));

                //6.Click on Undo Button
                NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);

                //7.Check Redo Activated and click
                Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyRedoButtonIncative(notebookAutomationAgent));
                NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5247)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void UndoEnableChangesAfterRedo()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5247:Undo Should be Enable When Changes has been made after SelectingRedo-Text Mode"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //1.Click on text icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //1. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                //2. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                //3. Insert text                
                NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);


                //3.Click on UndoRedo button
                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);

                //6.Click on Undo Button
                NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);

                //6.Click on Redo Button
                NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);

                //5.Verifying Inactive Redo Button               
                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyRedoButtonIncative(notebookAutomationAgent));


                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);
                NotebookCommonMethods.SwipeTextBoxControl(notebookAutomationAgent, 1150, 400);

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);
                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyRedoButtonIncative(notebookAutomationAgent));



                //7.Check Undo Activated and click
                Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyUndoButtonIncative(notebookAutomationAgent));
                NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }



        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(6420)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void VerifyInternetConnectivityPopup()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC6420:Consistent and informative WiFi connection messaging"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "jgrimm2", "sch00lnet");

                //1.Check the popup header text
                Assert.AreEqual<string>("True", NotebookCommonMethods.NoInternetConnectPopupHeader(notebookAutomationAgent));

                //2.Check the popup body text
                Assert.AreEqual<string>("True", NotebookCommonMethods.NoInternetConnectPopupBody(notebookAutomationAgent));

                //3.Click on OK Button
                NotebookCommonMethods.ClickUsernamePasswordOkButton(notebookAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(6417)]
        [Priority(1)]
        [Owner("Namrita Agarwal(vagarna)")]

        public void VerifyDeleteWifiMsg()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC6417:wifi required message removed from ADD GRADES panel"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, Login.GetLogin("Teacher1"));
                NavigationCommonMethods.NavigateToELA(notebookAutomationAgent);
                NotebookCommonMethods.ClickAddGradeNoWifiMsg(notebookAutomationAgent);
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }

        }

        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(634)]
        [Priority(1)]
        [Owner("Mohammed Saquib(msaqib)")]
        public void VerifyLessonNumber()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC634:ELA Browser displays correct lesson number in lesson"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, Login.GetLogin("Teacher1"));
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 2, 1);
                Assert.AreEqual<Boolean>(true, NotebookCommonMethods.VerifyLessonNumber(notebookAutomationAgent, "2"));
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }

         [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(3076)]
        [Priority(1)]
        [Owner("Namrita agarwal")]
        public void LessonShouldFillHalfScreen()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC3075:Lesson should fills half the screen when notebook open"))
            {

                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                // System.Threading.Thread.Sleep(2000);
               int WidthNavigationBar = NotebookCommonMethods.GetWidthOfNavigationBar(notebookAutomationAgent);

                 int WidthLessonTemplate = NotebookCommonMethods.GetWidthOfLessonTemplate(notebookAutomationAgent);

                  Assert.AreEqual<int>(WidthLessonTemplate, WidthNavigationBar / 2);

            }


        }



         [TestMethod()]
         [TestCategory("Notebook Tests")]
         [WorkItem(4614)]
         [Priority(1)]
         [Owner("Namrita agarwal")]
         public void RedoPlainTextChangesInTextRegion()
         {
             using (notebookAutomationAgent = new AutomationAgent("TC4614:Redo Plain Text Changes In Text Region"))
             {
                 NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                 NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                 NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);


                 NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                 NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                 //Writing the text 

                 for (int i = 1; i < 4; i++)
                 {

                     //1. Click on screen to insert text box  
                     NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 650, 1);

                     //2. Click inside text box to insert text
                     NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 650, 1);

                     //3. Insert text                
                     NotebookCommonMethods.SendText(notebookAutomationAgent, "Doctor" + i);

                     System.Threading.Thread.Sleep(500);

                     //4.Click somewhere else

                     NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);
                 }

                 //5.Click on UndoRedo button 

                 NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                 NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);


                 //6. Clicking on Undo button and check changes are done

                 for (int i = 3; i >= 1; i--)
                 {
                     System.Threading.Thread.Sleep(3000);
                     NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);


                     System.Threading.Thread.Sleep(3000);
                     string WordsInTextBox2 = NotebookCommonMethods.GetWordCountsInTextBox(notebookAutomationAgent);



                     string TextToCheck = "Doctor" + i;
                     System.Threading.Thread.Sleep(3000);
                     Assert.AreEqual<bool>(false, WordsInTextBox2.Contains(TextToCheck));


                 }


                 for (int i = 1; i < 4; i++)
                 {
                     System.Threading.Thread.Sleep(3000);

                     NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);


                     System.Threading.Thread.Sleep(3000);
                     string WordsInTextBox3 = NotebookCommonMethods.GetWordCountsInTextBox(notebookAutomationAgent);

                     //It is the limitation in SeeTest - 1st time written numeric character i.e.1 (in this case "Doctor1") is not identifiable
                     if (i == 1)
                     {
                         string TextToCheck = "Doctor";
                         System.Threading.Thread.Sleep(3000);
                         Assert.AreEqual<bool>(true, WordsInTextBox3.Contains(TextToCheck));
                     }
                     else
                     {

                         string TextToCheck = "Doctor" + i;
                         System.Threading.Thread.Sleep(3000);
                         Assert.AreEqual<bool>(true, WordsInTextBox3.Contains(TextToCheck));
                     }
                 }
                 NavigationCommonMethods.Logout(notebookAutomationAgent);
             }
         }




        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(6363)]
        [Priority(1)]
        [Owner("Namrita Agrawal")]
        public void HandModeRemainActiveUnlessAnotherMode()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC6363:Hand Mode RemainActiveUnlessAnotherMode"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //Verifying the icons on toolbar
                NotebookCommonMethods.ClickHandIcon(notebookAutomationAgent);


                Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyHandIconActive(notebookAutomationAgent));

                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyEraseIconActive(notebookAutomationAgent));

                Assert.AreEqual<string>("False", NotebookCommonMethods.VerifyHandIconActive(notebookAutomationAgent));


                NavigationCommonMethods.Logout(notebookAutomationAgent);


            }
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(4631)]
        [Priority(1)]
        [Owner("Mohd Saquib(msaqib)")]
        public void RedoDrawnStrokes()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC4631:Redo Drawn Strokes"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //Click on Drawing icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);

                // Swipe the drawingpen in a particular direction to draw             
                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Right, 100, 500);

                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Up, 300, 100);
                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Down, 300, 100);

                //                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Left, 150, 500);

                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);

                for (int i = 0; i < 3; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                }

                for (int i = 0; i < 3; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                }


                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }



        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(4632)]
        [Priority(1)]
        [Owner("Mohd Saquib(msaqib)")]
        public void ClearingRedoStacksWhenNewChanges()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC4632:Clearing Redo Stacks When New Changes"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //Click on Drawing icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);

                // Swipe the drawingpen in a particular direction to draw             
                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Up, 300, 100);
                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Down, 300, 100);

                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Right, 100, 500);


                //                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Left, 150, 500);

                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);

                for (int i = 0; i < 2; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    NotebookCommonMethods.ClickUndoIconInNotebook(notebookAutomationAgent);
                }

                for (int i = 0; i < 2; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    NotebookCommonMethods.ClickRedoIconInNotebook(notebookAutomationAgent);
                }


                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Right, 100, 500);

                NotebookCommonMethods.ClickUndoRedoIconInNotebook(notebookAutomationAgent);
                Assert.AreEqual<string>("false", NotebookCommonMethods.VerifyRedoButtonIncative(notebookAutomationAgent));

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }




        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(4589)]
        [Priority(1)]
        [Owner("Mohd Saquib(msaqib)")]
        public void SavingDrawingInNotebook()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC4589:Saving drawings in notebook- closing notebook"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //Click on Drawing icon
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickDrawingIconInNotebook(notebookAutomationAgent);

                // Swipe the drawingpen in a particular direction to draw             
                NotebookCommonMethods.Swipe(notebookAutomationAgent, Direction.Right, 100, 500);

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 900, 650, 1);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
            
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(3075)]
        [Priority(1)]
        [Owner("Namrita Agarwal")]
        public void NotebookButtonHighlight()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC3075:NotebookButtonHighlight"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //1.Click on notebook chrome icon
                NotebookCommonMethods.ClickNotebookTopViewIcon(notebookAutomationAgent);
                NotebookCommonMethods.VerifyNotebookIconHighlighted(notebookAutomationAgent);
                Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyNotebookIconHighlighted(notebookAutomationAgent));

                //2.Again Click on the notebook icon
                NotebookCommonMethods.ClickNotebookTopViewIcon2(notebookAutomationAgent);
                NotebookCommonMethods.VerifyNotebookIconHighlighted(notebookAutomationAgent);
                Assert.AreEqual<string>("False", NotebookCommonMethods.VerifyNotebookIconHighlighted(notebookAutomationAgent));


                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }




        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5907)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void SelectingHandToolModeFromToolbar()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5907:Selecting hand tool mode from the toolbar"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //1.Click on TextIcon 
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //2. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 700, 1);

                //3. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 700, 1);

                //4. Insert text                
                NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                //5.Click on hand icon
                NotebookCommonMethods.ClickHandIcon(notebookAutomationAgent);

                //6.Verify hand icon is active
                Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyHandIconActive(notebookAutomationAgent));


                //7. Activate the same text region and swipe the text box
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 700, 1);

                NotebookCommonMethods.SwipeTextBoxControl(notebookAutomationAgent, 1150, 400);

                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }




        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5909)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void TappingOutOfTextRegionInHandmode()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5909:Tapping out of the text region in hand mode"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //1.Click on TextIcon 
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //2. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 700, 1);

                //3. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 700, 1);

                //4. Insert text                
                NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                //5.Click on hand icon
                NotebookCommonMethods.ClickHandIcon(notebookAutomationAgent);

                //6.Verify hand icon is active
                Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyHandIconActive(notebookAutomationAgent));


                //7. Activate the same text region ,click inside the textbox
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 700, 1);
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 700, 1);

                //8.Verify keyboard is active
                NotebookCommonMethods.VerifyKeyboardPresence(notebookAutomationAgent);
                Assert.AreEqual<string>("True", NotebookCommonMethods.VerifyKeyboardPresence(notebookAutomationAgent));

                //9.Click outside the text region
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                //10.Verify again hand icon is active and keyboard is not present

                Assert.AreEqual<string>("False", NotebookCommonMethods.VerifyKeyboardPresence(notebookAutomationAgent));
                Assert.AreEqual<string>("true", NotebookCommonMethods.VerifyHandIconActive(notebookAutomationAgent));

                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }



        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(5921)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void MovingImageInHandmode()
        {
            using (notebookAutomationAgent = new AutomationAgent("TC5921:Moving image in hand mode"))
            {
                NavigationCommonMethods.Login(notebookAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(notebookAutomationAgent, 9, 1, 1, 2);
                NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);

                //1.Add photo after clicking ImageIcon 
                NotebookCommonMethods.AddImageInNoteBook(notebookAutomationAgent);


                //2.Click on TextIcon 
                NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
                NotebookCommonMethods.ClickTextIconInNotebook(notebookAutomationAgent);

                //2. Click on screen to insert text box  
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 700, 1);

                //3. Click inside text box to insert text
                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1230, 700, 1);

                //4. Insert text                
                NotebookCommonMethods.SendText(notebookAutomationAgent, "Tester");

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1150, 400, 1);

                //5.Swipe the text written over the image

                NotebookCommonMethods.DrawADot(notebookAutomationAgent, 1200, 700, 1);
                NotebookCommonMethods.SwipeTextBoxControl(notebookAutomationAgent, 1150, 400);

                //Can be used to move the image 
                //NotebookCommonMethods.SwipeImage(notebookAutomationAgent, 1150, 400);

                NavigationCommonMethods.Logout(notebookAutomationAgent);

            }
        }

    }
}
