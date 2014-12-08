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
                NavigationCommonMethods.Login(navigationAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.Logout(navigationAutomationAgent);
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
    }
}
