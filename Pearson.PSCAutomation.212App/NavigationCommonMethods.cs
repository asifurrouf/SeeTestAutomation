using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;
using experitestClient;

namespace Pearson.PSCAutomation._212App
{
    public static class NavigationCommonMethods
    {

        public static void Login(AutomationAgent navigationAutomationAgent, string userName, string password)
        {
            navigationAutomationAgent.SetText("LoginView", "UserName", userName);
            navigationAutomationAgent.SetText("LoginView", "Password", password);
            navigationAutomationAgent.Click("LoginView", "Login");
        }

        public static void Login(AutomationAgent navigationAutomationAgent, Login login)
        {
            navigationAutomationAgent.SetText("LoginView", "UserName", login.UserName);
            navigationAutomationAgent.SetText("LoginView", "Password", login.Password);
            navigationAutomationAgent.Click("LoginView", "Login");
        }

        public static void Logout(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
            navigationAutomationAgent.Click("SystemTrayMenuView", "LogOutButton");
        }

        public static void LogoutOnException(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "SystemTrayButton"))
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
                navigationAutomationAgent.Click("SystemTrayMenuView", "LogOutButton");
            }
        }

        public static void NavigateToELA(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
            if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "ELAUnitsButton", WaitTime.SmallWaitTime))
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "ELAUnitsButton");
            }
            else
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "UnitLibrary");
                navigationAutomationAgent.Click("SystemTrayMenuView", "ELAUnitsButton");
            }
        }

        public static void NavigateToMath(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
            if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "MathUnitsButton", WaitTime.SmallWaitTime))
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "MathUnitsButton");
            }
            else
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "UnitLibrary");
                navigationAutomationAgent.Click("SystemTrayMenuView", "MathUnitsButton");
            }
        }

        public static void NavigateToELAGrade(AutomationAgent navigationAutomationAgent, int gradeNumber)
        {
            if (gradeNumber > 12 && gradeNumber < 2)
            {
                Assert.Fail("Grade entered (" + gradeNumber.ToString() + ") is invalid");
            }
            navigationAutomationAgent.Click("GradeSelectionMenuView", "ELAGradeButton", gradeNumber.ToString());
        }

        public static void NavigateToMathGrade(AutomationAgent navigationAutomationAgent, int gradeNumber)
        {
            NavigateToMath(navigationAutomationAgent);
            if (gradeNumber > 11 && gradeNumber < 2)
            {
                Assert.Fail("Grade entered (" + gradeNumber.ToString() + ") is invalid");
            }
            navigationAutomationAgent.Click("GradeSelectionMenuView", "MathGradeButton", gradeNumber.ToString());
        }

        public static void ClickOnUnitWithinLesson(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
        }

        public static void StartELAUnitFromUnitLibrary(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
            navigationAutomationAgent.Click("UnitOverView", "ELAUnitStartButton", unitNumber.ToString());
        }

        public static void ClickELAUnitFromUnitLibrary(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "ELAUnitTile", unitNumber.ToString());
        }

        public static void StartMathUnitFromUnitLibrary(AutomationAgent navigationAutomationAgent, int unitNumber)
        {
            navigationAutomationAgent.Click("UnitLibraryView", "MathUnitTile", unitNumber.ToString());
            navigationAutomationAgent.Click("UnitOverView", "MathUnitStartButton", unitNumber.ToString());
        }

        public static void ClickELALessonFromLessonBrowser(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "ELALessonTile", lessonNumber.ToString());       
        }


        public static void ClickOnLessonTile(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "ELALessonTile", lessonNumber.ToString());
        }

        public static void OpenELALessonFromLessonBrowser(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "ELALessonTile", lessonNumber.ToString());
            if (navigationAutomationAgent.WaitforElement("LessonsOverView", "ELALessonContinueButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "ELALessonContinueButton", lessonNumber.ToString());
            }
            else if (navigationAutomationAgent.WaitforElement("LessonsOverView", "ELALessonStartButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "ELALessonStartButton", lessonNumber.ToString());
            }
            else
            {
                navigationAutomationAgent.CaptureScreenshot("Neither Start nor Continue button are found on the screen");
                Assert.Fail("Neither Start nor Continue button are found on the screen");
            }
        }

        public static void OpenMathLessonFromLessonBrowser(AutomationAgent navigationAutomationAgent, int lessonNumber)
        {
            navigationAutomationAgent.Click("LessonBrowserView", "MathLessonTile", (lessonNumber - 1).ToString());
            if (navigationAutomationAgent.WaitforElement("LessonsOverView", "MathLessonStartButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "MathLessonStartButton", lessonNumber.ToString());
            }
            else if (navigationAutomationAgent.WaitforElement("LessonsOverView", "MathLessonContinueButton", lessonNumber.ToString()))
            {
                navigationAutomationAgent.Click("LessonsOverView", "MathLessonContinueButton", lessonNumber.ToString());
            }
            else
            {
                navigationAutomationAgent.CaptureScreenshot("Neither Start nor Continue button are found on the screen");
                Assert.Fail("Neither Start nor Continue button are found on the screen");
            }
        }

        public static void NavigateToTaskPageInLesson(AutomationAgent navigationAutomationAgent, int taskNumber)
        {
            int currentTaskNumber = int.Parse(navigationAutomationAgent.GetElementText("LessonView", "CurrentPageLabel"));
            int numberOfPagesToTraverse = 0;
            if (currentTaskNumber > taskNumber)
            {
                numberOfPagesToTraverse = currentTaskNumber - taskNumber;
                for (int i = 0; i < numberOfPagesToTraverse; i++)
                {
                    navigationAutomationAgent.Click("LessonView", "PreviousButton");
                    System.Threading.Thread.Sleep(500);
                }
            }
            else if (currentTaskNumber < taskNumber)
            {
                numberOfPagesToTraverse = taskNumber - currentTaskNumber;
                for (int i = 0; i < numberOfPagesToTraverse; i++)
                {
                    navigationAutomationAgent.Click("LessonView", "NextButton");
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        public static void NavigateELATaskfromSytemTrayMenu(AutomationAgent navigationAutomationAgent, int gradeNumber, int unitNumber, int lessonNumber, int taskNumber)
        {
            NavigateToELA(navigationAutomationAgent);
            NavigateToELAGrade(navigationAutomationAgent, gradeNumber);
            StartELAUnitFromUnitLibrary(navigationAutomationAgent, unitNumber);
            OpenELALessonFromLessonBrowser(navigationAutomationAgent, lessonNumber);
            NavigateToTaskPageInLesson(navigationAutomationAgent, taskNumber);
        }

        public static void NavigateMathTaskfromSytemTrayMenu(AutomationAgent navigationAutomationAgent, int gradeNumber, int unitNumber, int lessonNumber, int taskNumber)
        {            
            NavigateToMathGrade(navigationAutomationAgent, gradeNumber);
            StartMathUnitFromUnitLibrary(navigationAutomationAgent, unitNumber);
            OpenMathLessonFromLessonBrowser(navigationAutomationAgent, lessonNumber);
            NavigateToTaskPageInLesson(navigationAutomationAgent, taskNumber);
        }

        public static void ClickCancelInSelectGrade(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.WaitforElement("SelectGradeView", "GradeLabel", "5", 10000);
            navigationAutomationAgent.Click("SelectGradeView", "CancelButton");
            Assert.IsTrue(navigationAutomationAgent.WaitForElement("LoginView", "Login", 10000), "User didn't log out after clicking cancel button");
        }

        public static bool PinchOutOnScreen(AutomationAgent navigationAutomationAgent)
        {
            return navigationAutomationAgent.PinchOut();
        }

        public static void LogoutOnExceptionAndReleaseClient(AutomationAgent navigationAutomationAgent)
        {
            if (navigationAutomationAgent.WaitForElement("SystemTrayMenuView", "SystemTrayButton"))
            {
                navigationAutomationAgent.Click("SystemTrayMenuView", "SystemTrayButton");
                navigationAutomationAgent.Click("SystemTrayMenuView", "LogOutButton");
            }
            navigationAutomationAgent.GenerateReportAndReleaseClient();
        }

        public static void SwipeUnit(AutomationAgent navigationAutomationAgent, Direction direction)
        {
            navigationAutomationAgent.Swipe(direction);
        }

        

        public static void ClickTeacherModeButton(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.Click("TasksTopMenuView", "TeacherMode");
        }

         public static void VerifyClassRosterLink(AutomationAgent navigationAutomationAgent)
        {
            navigationAutomationAgent.VerifyElementNotFound("DashboardView", "ClassRosterLink");
        }

    }
}
