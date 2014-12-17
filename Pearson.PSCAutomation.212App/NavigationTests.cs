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
    /// Summary description for NavigationTests
    /// </summary>
    [TestClass]
    public class NavigationTests
    {
        public AutomationAgent navigationAutomationAgent;
        public NavigationTests()
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
        [AssemblyInitialize]
        public static void _212AssemblyInitialize(TestContext testContext)
        {

        }

        [ClassInitialize]
        public static void NavigationTestsClassInitialize(TestContext testContext)
        {
        }
        [TestInitialize]
        public void NavigationTestsTestInitialize()
        {

        }


        [AssemblyCleanup]
        public static void _212AssemblyCleanup()
        {

        }

        [ClassCleanup]
        public static void NavigationTestsClassCleanup()
        {

        }
        [TestCleanup]
        public void NavigationTestsTestCleanup()
        {

        }
        #endregion


        [TestMethod()]
        [TestCategory("Navigation Tests")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void LoginAndLogout()
        {            
            using (navigationAutomationAgent = new AutomationAgent("TC7352:Login and Logout"))
            {
                try
                {
                    NavigationCommonMethods.Login(navigationAutomationAgent, "apatton1", "sch00lnet");
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (AssertFailedException ex)
                {
                    navigationAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                    navigationAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.CaptureScreenshot(ex.Message);
                    navigationAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(navigationAutomationAgent);
                    throw ex;
                } 
            }
           
        }

        [TestMethod()]
        [TestCategory("Navigation Tests")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void LoginAndLogout2()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC7353: Log in logout2"))
            {
                NavigationCommonMethods.Login(navigationAutomationAgent, "apatton1", "sch00lnet");
                Assert.IsTrue(false);
                NavigationCommonMethods.Logout(navigationAutomationAgent);

            }
        }

        [TestMethod()]
        [TestCategory("Navigation Tests")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void UnitOverviewVerification()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC7354: Unit Overview verification"))
            {
                NavigationCommonMethods.Login(navigationAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                NavigationCommonMethods.Logout(navigationAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Navigation Tests")]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void LoginAndCancelAddGrades()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC7355: Log in and cancel add grades"))
            {
                NavigationCommonMethods.Login(navigationAutomationAgent, "awhite", "sch00lnet");
                NavigationCommonMethods.ClickCancelInSelectGrade(navigationAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Navigation Tests")]
        [Priority(1)]
        [WorkItem(14048)]
        [Owner("Narasimhan (narsimhan.narayanan)")]
        public void VerifyClassRosterInUnitPreviewOfSectionGrade()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC14048:Verify the class roster should not be displayed in unit preview"))
            {
                try
                {
                    NavigationCommonMethods.Login(navigationAutomationAgent, Login.GetLogin("Grade2SectionedTeacher"));
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, 2);
                    NavigationCommonMethods.ClickELAUnitFromUnitLibrary(navigationAutomationAgent, 1);
                    NavigationCommonMethods.ClickTeacherModeButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyClassRosterLink(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (AssertFailedException ex)
                {
                    navigationAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                    navigationAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.CaptureScreenshot(ex.Message);
                    navigationAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(navigationAutomationAgent);
                    throw ex;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Navigation Tests")]
        [Priority(1)]
        [WorkItem(14048)]
        [Owner("Narasimhan (narsimhan.narayanan)")]
        public void VerifyClassRosterInLessonBrowserOfSectionGrade()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC1810:Verify class roster should not be in Lesson Browser of section grade"))
            {
                try
                {
                    NavigationCommonMethods.Login(navigationAutomationAgent, Login.GetLogin("Grade2SectionedTeacher"));
                    NavigationCommonMethods.NavigateToELA(navigationAutomationAgent);
                    NavigationCommonMethods.NavigateToELAGrade(navigationAutomationAgent, 2);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(navigationAutomationAgent, 1);
                    NavigationCommonMethods.ClickTeacherModeButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyClassRosterLink(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (AssertFailedException ex)
                {
                    navigationAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                    navigationAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.CaptureScreenshot(ex.Message);
                    navigationAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(navigationAutomationAgent);
                    throw ex;
                }
            }

        }

        [TestMethod()]
        [TestCategory("Navigation Tests")]
        [Priority(1)]
        [WorkItem(14048)]
        [Owner("Narasimhan (narsimhan.narayanan)")]
        public void VerifyClassRosterInLessonOfSectionGrade()
        {
            using (navigationAutomationAgent = new AutomationAgent("TC1811:Verify the class roster should not be within a Lesson of section grade"))
            {
                try
                {
                    NavigationCommonMethods.Login(navigationAutomationAgent, Login.GetLogin("Grade2SectionedTeacher"));
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(navigationAutomationAgent, 2, 1, 1, 1);
                    NavigationCommonMethods.ClickTeacherModeButton(navigationAutomationAgent);
                    NavigationCommonMethods.VerifyClassRosterLink(navigationAutomationAgent);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                }
                catch (AssertFailedException ex)
                {
                    navigationAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(navigationAutomationAgent);
                    navigationAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    navigationAutomationAgent.CaptureScreenshot(ex.Message);
                    navigationAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(navigationAutomationAgent);
                    throw ex;
                }
            }

        }

    }
}
