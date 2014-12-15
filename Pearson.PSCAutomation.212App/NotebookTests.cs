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
                NotebookCommonMethods.SetNameToPersonalNote(notebookAutomationAgent, "My Personal Notex(1/1)");
                NotebookCommonMethods.VerifyPersonalNoteCreateButtonStatus(notebookAutomationAgent, true);
                NotebookCommonMethods.ClickPersonalNoteCreateButton(notebookAutomationAgent);
                NotebookCommonMethods.VerifyPersonalNoteTitle(notebookAutomationAgent, "My Personal Notex(1/1)");
                NavigationCommonMethods.Logout(notebookAutomationAgent);
            }
        }
    }
}
