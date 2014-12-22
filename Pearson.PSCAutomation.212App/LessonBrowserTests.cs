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
    [TestClass]
    public class LessonBrowserTests
    {
        public AutomationAgent LessonBrowserAutomationAgent;

        [TestMethod()]
        [TestCategory("Lesson Browser Tests")]
        [WorkItem(1265)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void StartButtonPresentFirstTimeClickOnLesson()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC1265: Verify that Start button is displayed to user when he taps first time on the lesson from lesson browser"))
            {
                try{
                //NavigationCommonMethods.Login(LessonBrowserAutomationAgent, "efoster16", "sch00lnet");
                //System.Threading.Thread.Sleep(5000);
                NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, 6);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, 1);
                LessonBrowserCommonMethods.VerifyLessonBrowserPanelPresent(LessonBrowserAutomationAgent);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, 5);
                LessonBrowserCommonMethods.StartButtonDisplayedFirstTimeClickOnLesson(LessonBrowserAutomationAgent, 5);
                NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }

                catch (AssertFailedException ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                    LessonBrowserAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    LessonBrowserAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(LessonBrowserAutomationAgent);
                    throw ex;
                } 
            }
        }

        [TestMethod()]
        [TestCategory("Lesson Browser Tests")]
        [WorkItem(1375)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void NonSectionedTeacherClickLessonFirstTime()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC1375: Verify that Start button is displayed to user when he taps first time on the lesson from lesson browser provided user is a non-sectioned teacher for that grade"))
            {
                try
                {
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, "sswanson2", "sch00lnet");
                    System.Threading.Thread.Sleep(5000);
                    NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnAddGradeButton(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.AddGradeForTeacher(LessonBrowserAutomationAgent,7);
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, 7);
                    LessonBrowserCommonMethods.WaitAndVerifyUnitIsDownloaded(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(LessonBrowserAutomationAgent, 1);
                    LessonBrowserCommonMethods.VerifyLessonBrowserPanelPresent(LessonBrowserAutomationAgent);
                    System.Threading.Thread.Sleep(100000);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(LessonBrowserAutomationAgent, 1);
                    LessonBrowserCommonMethods.StartButtonDisplayedFirstTimeClickOnLesson(LessonBrowserAutomationAgent, 1);

                    //Remove Grade
                    NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickRemoveGradeButton(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickContinueButonToRemoveGrade(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }

                catch (AssertFailedException ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                    LessonBrowserAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    LessonBrowserAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(LessonBrowserAutomationAgent);
                    throw ex;
                }
            }
        }


        [TestMethod()]
        [TestCategory("Lesson Browser Tests")]
        [WorkItem(1398)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void SectionedTeacherFirstTimeLogin()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC1398: Verify that when sectioned teacher see his sectioned grades and navigates to dashboard when he logs in first time. "))
            {
                try
                {
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, "efoster16", "sch00lnet");
                    System.Threading.Thread.Sleep(3000);
                    LessonBrowserCommonMethods.VerifyMoreToExploreButtonPresent(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyConceptCornerButtonPresent(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyTeacherSupportButtonPresent(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyGradeIsPresent(LessonBrowserAutomationAgent, 6);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }

                catch (AssertFailedException ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                    LessonBrowserAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    LessonBrowserAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(LessonBrowserAutomationAgent);
                    throw ex;
                }
            }
        }


        [TestMethod()]
        [TestCategory("Lesson Browser Tests")]
        [WorkItem(1435)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void PaginationNumberUpdateOnUnitScroll()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC1435: Verify that unit pagination number increment and decrement when user swipes between the units"))
            {
                try
                {
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, "efoster16", "sch00lnet");
                    System.Threading.Thread.Sleep(3000);
                    NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyGradeIsPresent(LessonBrowserAutomationAgent, 6);
                    NavigationCommonMethods.NavigateToELAGrade(LessonBrowserAutomationAgent, 6);
                    NavigationCommonMethods.ClickOnUnitWithinLesson(LessonBrowserAutomationAgent, 3);
                    LessonBrowserCommonMethods.VerifyUnitIsPresent(LessonBrowserAutomationAgent, 3);
                    NavigationCommonMethods.SwipeUnit(LessonBrowserAutomationAgent, Direction.Left);
                    LessonBrowserCommonMethods.VerifyUnitIsPresent(LessonBrowserAutomationAgent, 2);
                    NavigationCommonMethods.SwipeUnit(LessonBrowserAutomationAgent, Direction.Left);
                    LessonBrowserCommonMethods.VerifyUnitIsPresent(LessonBrowserAutomationAgent, 1);
                    NavigationCommonMethods.SwipeUnit(LessonBrowserAutomationAgent, Direction.Right);
                    LessonBrowserCommonMethods.VerifyUnitIsPresent(LessonBrowserAutomationAgent, 2);
                    NavigationCommonMethods.SwipeUnit(LessonBrowserAutomationAgent, Direction.Right);
                    LessonBrowserCommonMethods.VerifyUnitIsPresent(LessonBrowserAutomationAgent, 3);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }

                catch (AssertFailedException ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                    LessonBrowserAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    LessonBrowserAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(LessonBrowserAutomationAgent);
                    throw ex;
                }
            }
        }


        [TestMethod()]
        [TestCategory("Lesson Browser Tests")]
        [WorkItem(1516)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void VerifySelectGradePopUpIsDisplayed()
        {
            using (LessonBrowserAutomationAgent = new AutomationAgent("TC1516: Verify that user is able to view add grade screen when Add Grades button is clicked."))
            {
                try
                {
                    NavigationCommonMethods.Login(LessonBrowserAutomationAgent, "sswanson2", "sch00lnet");
                    System.Threading.Thread.Sleep(5000);
                    NavigationCommonMethods.NavigateToELA(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.ClickOnAddGradeButton(LessonBrowserAutomationAgent);
                    LessonBrowserCommonMethods.VerifyAddGradePopUpIsDisplayed(LessonBrowserAutomationAgent);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                }

                catch (AssertFailedException ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    NavigationCommonMethods.Logout(LessonBrowserAutomationAgent);
                    LessonBrowserAutomationAgent.GenerateReportAndReleaseClient();
                    throw ex;
                }
                catch (Exception ex)
                {
                    LessonBrowserAutomationAgent.CaptureScreenshot(ex.Message);
                    LessonBrowserAutomationAgent.GetDeviceLog();
                    NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(LessonBrowserAutomationAgent);
                    throw ex;
                }
            }
        }

    }
}

