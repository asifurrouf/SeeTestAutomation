using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pearson.PSCAutomation.Framework;
using experitestClient;

namespace Pearson.PSCAutomation._212App
{
    public static class LessonBrowserCommonMethods
    {
        public static void StartButtonDisplayedFirstTimeClickOnLesson(AutomationAgent LessonBrowserAutomationAgent, int LessonNumber)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("LessonsOverView", "ELALessonStartButton", LessonNumber.ToString());
        }

        public static void VerifyLessonBrowserPanelPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("LessonBrowserView", "LessonBrowserPanel");
        }

        public static void VerifyAddGradeButtonPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("SelectGradeView", "AddGradeButton");
        }

        public static void ClickOnAddGradeButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("SelectGradeView", "AddGradeButton");
        }

        public static void AddGradeForTeacher(AutomationAgent LessonBrowserAutomationAgent, int GradeNumber)
        {
            LessonBrowserAutomationAgent.Click("SelectGradeView", "GradeLabel", GradeNumber.ToString());
            LessonBrowserAutomationAgent.Click("SelectGradeView", "ContinueButton");
        }

        public static void WaitAndVerifyUnitIsDownloaded(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.WaitforElement("UnitLibraryView", "ELAUnitTile", "1", 900000);
        }

        public static void ClickRemoveGradeButton(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("SelectGradeView", "RemoveGradeButton");
        }

        public static void ClickContinueButonToRemoveGrade(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.Click("PopUpView", "RemoveGradeContinueButton");
        }

        public static void WaitAndVerifyUnitIsRemoved(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementNotFound("UnitLibraryView", "ELAUnitTile");
        }

        public static void VerifyMoreToExploreButtonPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "MoreToExploreButton");
        }

        public static void VerifyConceptCornerButtonPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "ConceptCornerButton");
        }

        public static void VerifyTeacherSupportButtonPresent(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("DashboardView", "TeacherSupportButton");
        }

        public static void VerifyGradeIsPresent(AutomationAgent LessonBrowserAutomationAgent, int GradeNumber)
        {
            LessonBrowserAutomationAgent.Click("SelectGradeView", "GradeLabel", GradeNumber.ToString());
        }

        public static void VerifyUnitIsPresent(AutomationAgent LessonBrowserAutomationAgent, int UnitNumber)
        {
            LessonBrowserAutomationAgent.Click("UnitLibraryView", "UnitNumber", UnitNumber.ToString());
        }

        public static void VerifyAddGradePopUpIsDisplayed(AutomationAgent LessonBrowserAutomationAgent)
        {
            LessonBrowserAutomationAgent.VerifyElementFound("SelectGradeView", "SelectGradeLabel");
        }

    }
}
